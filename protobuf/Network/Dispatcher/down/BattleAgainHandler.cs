using UnityEngine;
using System.Collections;
using System.IO;

public class BattleAgainHandler
{
    public delegate void OnPlayerStateRsp();
    public static OnPlayerStateRsp onEnterBattle;

    private static uint playerState; //玩家在服务器的状态

    //玩家退出前是否在战斗中
    public static void OnRecvLoginFinishedRes(byte[] data)
    {
        if (UIStart.instance)
            UIStart.instance.SetCreateDisVis();

        MemoryStream m = new MemoryStream(data);

        TankProtocol.PlayerLoginFinishedRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.PlayerLoginFinishedRsp>(m);

        SendPlayerState();
        DownHandlePlayer.OnFinished(0);
        SysEnv.isToKenEnterGame = false;
    }

    //战斗退出，因服务器重启或关闭, 由服务器主动通知
    public static void OnRecvExitBattle(byte[] data)
    {
        if (NewerCheckPointGuide.IsNewerBattle())
        {
            Common.NetworkDisConnectBox("(error : 902)");
            return;
        }
        //UIMessageBox.Show(802);
        LevelManagerBase.OnExitLevelToUIMain();
    }

    //是否重新进入战斗
    public static void SendBattleAgain(bool isEnter)
    {
        TankProtocol.PlayerRedoJoinBattle ps = new TankProtocol.PlayerRedoJoinBattle();
        ps.isJoinBattle = isEnter;

        DispatcherProtoBuf.Instance.SendProtoBuffer("PlayerRedoJoinBattle", ps);

        Common.ShowLoading(true);
    }

    //获得玩家，当前在服务器的状态
    public static void OnRecvPlayerStateRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.PlayerStateRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.PlayerStateRsp>(m);

        if (rsp != null)
        {
            playerState = rsp.playerState;

            if ((TankProtocol.PlayerStateType)rsp.playerState == TankProtocol.PlayerStateType.PLAYER_STATE_BATTLE ||
                (TankProtocol.PlayerStateType)rsp.playerState == TankProtocol.PlayerStateType.PLAYER_STATE_FLEE)
            {
                BattleAgainEnterRecon.Instance.isExitsBattle = true;
            }
            else
            {
                BattleAgainEnterRecon.Instance.isExitsBattle = false;
            }

            if (onEnterBattle != null)
            {
                onEnterBattle();
            }

            if ((TankProtocol.PlayerStateType)rsp.playerState != TankProtocol.PlayerStateType.PLAYER_STATE_BATTLE)
            {
                if (LevelManagerBase.onBattleSateNoBattle != null)
                {
                    LevelManagerBase.onBattleSateNoBattle(rsp.playerState);
                }
            }

            Debug.LogWarning("玩家在服务器当前的状态: " + rsp.playerState.ToString());
        }
    }

    //踢玩家-----用于玩家作弊
    public static void OnRecvKickMyAssRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.KickMyAss rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.KickMyAss>(m);

        Common.NetworkDisConnectBox("(error : 1001)");
    }


    public static void SendPlayerState()
    {
        TankProtocol.PlayerState ps = new TankProtocol.PlayerState();
        DispatcherProtoBuf.Instance.SendProtoBuffer("PlayerState", ps);
    }

    public static bool isLoadRoomUI()
    {
        return (TankProtocol.PlayerStateType)playerState == TankProtocol.PlayerStateType.PLAYER_STATE_BATTLE || (TankProtocol.PlayerStateType)playerState == TankProtocol.PlayerStateType.PLAYER_STATE_IDLE;
    }

    public static bool isGoUIMain()
    {
        return (TankProtocol.PlayerStateType)playerState == TankProtocol.PlayerStateType.PLAYER_STATE_FLEE || (TankProtocol.PlayerStateType)playerState == TankProtocol.PlayerStateType.PLAYER_STATE_PUNISH;
    }

    /// <summary>
    ///  重新进入游戏，判断是否在战斗中
    /// </summary>
    /// <returns>true 存在 </returns>
    public static bool isGameInBattle() 
    {
        return (TankProtocol.PlayerStateType)playerState == TankProtocol.PlayerStateType.PLAYER_STATE_BATTLE || (TankProtocol.PlayerStateType)playerState == TankProtocol.PlayerStateType.PLAYER_STATE_FLEE;
    }

    /// <summary>
    /// 用于服务器，更新数据
    /// </summary>
    /// <param name="data"></param>
    public static void OnRecvChangeNoti(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.ChangeNoti rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.ChangeNoti>(m);

        if(rsp != null)
        {
            foreach (TankProtocol.ChangeKeyValue value in rsp.changes)
            {
                modifyChangeKeyValue((TankProtocol.ChangeInfo)value.key, value.value);
            }
        }

    }

    public static void modifyChangeKeyValue(TankProtocol.ChangeInfo key, uint value)
    {
        switch (key)
        {
            //军团ID
            case TankProtocol.ChangeInfo.enm_corps_id:

                //申请加入军团，被批准加入军团
                if (DataWrapper.Player.instance.armyGroupId == 0 && value != 0)
                {
                    DataWrapper.Player.instance.armyGroupId = value;
                    DataWrapper.Player.instance.armyGroup.clearData();
                    ArmyGroupHandler.SendGetCorpsInfoReq(DataWrapper.Player.instance.armyGroupId);
                    ArmyGroupHandler.SendCorpsRoomListReq(DataWrapper.Player.instance.armyGroupId);
                }
                //被开除，解散处理
                else if (DataWrapper.Player.instance.armyGroupId != 0 && value == 0)
                {
                    DataWrapper.Player.instance.armyGroupId = 0;
                    DataWrapper.Player.instance.armyGroup.clearData();
                    DataWrapper.Player.instance.armyGroup.curRoomCorpsMember = new System.Collections.Generic.List<TankProtocol.CorpsRoomMember>();
                    ArmyGroupHandler.SendSearchCorpsReq(DataWrapper.Player.instance.armyGroupId);
                }
                break;
            //自动申请开关
            case TankProtocol.ChangeInfo.enm_corps_autoagree:
                if (DataWrapper.Player.instance.armyGroup != null && DataWrapper.Player.instance.armyGroup.curCorpsInfo != null)
                {
                    DataWrapper.Player.instance.armyGroup.curCorpsInfo.autoagree = value;
                }
                break;
            //随机商店剩余次数, 用于显示商城小红点
            case TankProtocol.ChangeInfo.enm_stagingpost_freeTimes:
                DataWrapper.Player.instance.shop.stagingPostCount = value;
                break;
            //坦克宝箱，超级射击弹药次数
            case TankProtocol.ChangeInfo.enm_superBulletBuyCount:
                DataWrapper.Player.instance.copyChest.superBulletBuyCount = value;
                break;
            //坦克宝箱，普通射击次数
            case TankProtocol.ChangeInfo.enm_fireCount:
                DataWrapper.Player.instance.copyChest.fireCount = value;
                break;
            //委托任务免费刷新次数
            case TankProtocol.ChangeInfo.enm_refreshAssign:
                DataWrapper.Player.instance.assignFreeCount = value;
                break;
            //委托任务接取次数
            case TankProtocol.ChangeInfo.enm_assignTaskLimit:
                DataWrapper.Player.instance.assignTaskLimit = value;
                break;
        }

        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance);
    }

    //是否重新进入战斗
    public static void SendItemExchangeReq(uint itemid, uint count)
    {
        TankProtocol.ItemExchangeReq ps = new TankProtocol.ItemExchangeReq();
        ps.id = itemid;
        ps.num = count;

        DispatcherProtoBuf.Instance.SendProtoBuffer("ItemExchangeReq", ps);
    }
}
