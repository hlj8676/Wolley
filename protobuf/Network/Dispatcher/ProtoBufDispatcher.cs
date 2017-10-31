using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DispatcherProtoBuf
{
    private static DispatcherProtoBuf instance;
    public static DispatcherProtoBuf Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DispatcherProtoBuf();
                instance.Initialize();
            }

            return instance;
        }
    }

    public delegate void OnReciveProtoBuf(byte[] datas);

    private Hashtable hashRecives = new Hashtable();

    public void Initialize()
    {
        Register("PlayerLoginRsp", DownProtoBuffer.OnRecvPlayerLoginRsp);
        Register("PlayerSkillRsp", DownProtoBuffer.OnRecvPlayerSkillRsp);
        Register("PlayerLoginFinishedRsp", BattleAgainHandler.OnRecvLoginFinishedRes);
        Register("PlayerStateRsp", BattleAgainHandler.OnRecvPlayerStateRsp);
        Register("AskRankListRsp", RankHandler.OnRecvAskRankListRsp);
        Register("AskMyRankRsp", RankHandler.OnRecvAskMyRankListRsp);
        Register("ActivedTankIDRsp", RankHandler.OnRecvActivedTankIDRsp);
        Register("ShopRsp", ShopHandler.OnRecvShopRsp);
        Register("StagingPostInfoRsp", ShopHandler.OnRecvStagingPostInfoRsp);
        Register("StagingPostBuyRsq", ShopHandler.OnRecvStagingPostBuyRsq);
        Register("StopBattleServerRsp", BattleAgainHandler.OnRecvExitBattle);
        Register("KickMyAss", BattleAgainHandler.OnRecvKickMyAssRsp);
        Register("ChangeNoti", BattleAgainHandler.OnRecvChangeNoti);
        Register("BatchOpFriendRsp", UserFriendHandle.OnRecvBatchOpFriendRsq);
        Register("BuySuperBulletRsp", TankChestHandler.OnRecvBuySuperBulletRsp);
        Register("TankChestRsp", TankChestHandler.OnRecvCopyChestRsp);
        
        

        DispatcherProtoBuf.Instance.Register("PPVETaskUpdateRsp", PPVETaskUpdate);

        //军团
        Register("AgreeApplyCorpsRsp", ArmyGroupHandler.OnRecvAgreeApplyCorpsRsp);
        Register("ApplyEnterCorpsRsp", ArmyGroupHandler.OnRecvApplyEnterCorpsRsp);
        Register("AppointSubLeaderRsp", ArmyGroupHandler.OnRecvAppointSubLeaderRsp);
        Register("AppointSubLeaderNoti", ArmyGroupHandler.OnRecvAppointSubLeaderNoti);
        Register("GetCorpsApplyRsp", ArmyGroupHandler.OnRecvGetCorpsApplyRsp);
        Register("NewApplyNoti", ArmyGroupHandler.OnRecvNewApplyNoti);
        Register("ChangeCorpsIntroduceRsp", ArmyGroupHandler.OnRecvChangeCorpsIntroduceRsp);
        Register("ChangeCorpsLvNameRsp", ArmyGroupHandler.OnRecvChangeCorpsLvNameRsp);
        Register("ChangeCorpsNameRsp", ArmyGroupHandler.OnRecvChangeCorpsNameRsp);
        Register("CreateCorpsRsp", ArmyGroupHandler.OnRecvCreateCorpsRsp);
        Register("GetCorpsInfoRsp", ArmyGroupHandler.OnRecvGetCorpsInfoRsp);
        Register("KickOutCorpsMemberRsp", ArmyGroupHandler.OnRecvKickOutCorpsMemberRsp);
        Register("LeaveCorpsRsp", ArmyGroupHandler.OnRecvLeaveCorpsRsp);
        Register("SearchCorpsRsp", ArmyGroupHandler.OnRecvSearchCorpsRsp);
        Register("CorpsDonateRsp", ArmyGroupHandler.OnRecvCorpsDonateRsp);
        Register("HasWantNoti", ArmyGroupHandler.OnRecvHasWantNoti);
        Register("CorpsWantListRsp", ArmyGroupHandler.OnRecvCorpsWantListRsp);
        Register("CorpsWantRsp", ArmyGroupHandler.OnRecvCorpsWantRsp);
        Register("ChangeCorpsIconRsp", ArmyGroupHandler.OnRecvChangeCorpsIconRsp);
        Register("CorpsAutoAgreeRsp", ArmyGroupHandler.OnRecvCorpsAutoAgreeRsp);
        Register("CorpsRoomListRsp", ArmyGroupHandler.OnRecvCorpsRoomListRsp);
        Register("CorpsRoomMemberNoti", ArmyGroupHandler.OnRecvCorpsRoomMemberNoti);
        Register("FriendCorpsInfoChangeNoti", ArmyGroupHandler.OnRecvFriendCorpsInfoChangeNoti);

        //VIP
        Register("LimitBuy", ShopHandler.OnRecvLimitBuyChange);

		Register("HeadNoti", Table.Head.OnRecvHeadNoti);

		Register("InviteTaskRsp", UIQRCodeHandle.OnRecInviteTaskRsp);
		Register("InviteRsp", UIQRCodeHandle.OnRecInviteIDRSP);
		Register("InviteListRsp", UIQRCodeHandle.OnRecInviteListRsp);
		Register("InviteTaskRewardRsp", UIQRCodeHandle.OnRecInviteTaskRewardRsp);
        
        ///失恋抽
        Register("TurntableInfoRsp", TenLotteryHandler.OnRecvTurntableInfoRsp);
        
        ///战场命令
        Register("BattleQuickChat", BattleQuickCommandHandler.Receive);

        //by zj 
        Register(new LightNoticeHandle()); //全局公告喇叭
        Register(new WorldMapInfoHandler()); //世界地图

        Register(new AssignHandler()); //委托任务
        Register(new AssignListHandler()); //委托任务列表
        Register(new AssignSucessHandler());//委托任务成功概率
        Register(new AssignResultHandler());//委托任务领取失败or成功


        Register(new TankRepeatHandler());//坦克重复获得
    }

    public void OnDestroy()
    {
        foreach (var k in pbHandles)
        {
            if (k != null)
            {
                k.OnUnRegister();
                UnRegister(k.GetRspName());
            }
        }

        pbHandles.Clear();
        hashRecives.Clear();
        instance = null;
    }

    public List<SuperBOBO.PBHandler> pbHandles = new List<SuperBOBO.PBHandler>();

    public void Register(SuperBOBO.PBHandler handle)
    {
        if (handle != null && !pbHandles.Contains(handle))
        {
            pbHandles.Add(handle);
            Register(handle.GetRspName(), handle.OnRecv);
        }
    }

    public void Register(string protoType, OnReciveProtoBuf onRecive)
    {
        if(hashRecives.ContainsKey(protoType))
            UnRegister(protoType);
        hashRecives.Add(protoType, onRecive);
    }

    public void UnRegister(string protoType)
    {
        if (hashRecives.ContainsKey(protoType))
        {
            hashRecives.Remove(protoType);
        }
    }

    public void OnDispatchProtoBuf(RakNet.BitStream bs)
    {
        Util.Log("OnDispatchProtoBuf");
        while (bs.GetNumberOfUnreadBits() > 0)
        {
            //protobuf 长度和类型
            byte lenth = 0;
            bs.Read(out lenth);
            byte[] name = new byte[lenth];
            bs.Read(name, (uint)name.Length);

            string typename = System.Text.Encoding.Default.GetString(name);
            Util.Log("<color=#ffff00> [OnDispatchProtoBuf] Rsp : </color> " + typename);
            MessageCheck.Instance.RecvMessage(typename);
            //protobuf 内容
            byte[] buffer = new byte[bs.GetNumberOfUnreadBits() / 8];
            bs.Read(buffer, (uint)buffer.Length);


            if (hashRecives.ContainsKey(typename))
            {

                OnReciveProtoBuf onRecive = (OnReciveProtoBuf)hashRecives[typename];
                if (onRecive != null) onRecive(buffer);

            }
            else
            {
                Util.LogError("ProtoBuf 没有找到接收函数 : " + typename);
            }
        }
    }




    public void SendProtoBuffer(string protoType, ProtoBuf.IExtensible data, bool toBattleServer = false)
    {
        Util.Log("<color=#00fff0> [OnDispatchProtoBuf] Req : </color> " + protoType);

        // Util.Log("发送ProtoBuf");
        RakNet.BitStream sendBitStream = new RakNet.BitStream();

        //protobuf 协议类型
        sendBitStream.Write((byte)protoType.Length);
        byte[] byteArray = System.Text.Encoding.Default.GetBytes(protoType);
        sendBitStream.Write(byteArray, (uint)protoType.Length);
        //protobuf 协议本身
        byte[] buffer = null;
        if (data != null)
        {
            using (MemoryStream m = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(m, data);
                m.Position = 0;
                int length = (int)m.Length;
                buffer = new byte[length];
                m.Read(buffer, 0, length);

                sendBitStream.Write(buffer, (uint)length);
            }
        }
        MessageCheck.Instance.SendMessage(protoType);
        Dispatcher.Instance.Send(MessageID.ID_PROTOBUF_MSG, sendBitStream, toBattleServer);
    }

    static void PPVETaskUpdate(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.PPVETaskUpdateRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.PPVETaskUpdateRsp>(m);
        for (int i = 0; i < rsp.taskDataList.Count; i++)
        {
            if (DataWrapper.Player.instance.EveryDayPveCount.ContainsKey(rsp.taskDataList[i].group))
                DataWrapper.Player.instance.EveryDayPveCount[rsp.taskDataList[i].group] = rsp.taskDataList[i].count;
            else
                DataWrapper.Player.instance.EveryDayPveCount.Add(rsp.taskDataList[i].group, rsp.taskDataList[i].count);

            if (DataWrapper.Player.instance.EveryDayPveReset.ContainsKey(rsp.taskDataList[i].group))
                DataWrapper.Player.instance.EveryDayPveReset[rsp.taskDataList[i].group] = rsp.taskDataList[i].reset;
            else
                DataWrapper.Player.instance.EveryDayPveReset.Add(rsp.taskDataList[i].group, rsp.taskDataList[i].reset);

            
        }
        SuperBOBO.EventManager.Instance.FireEvent(GameEventType.PPVETaskUpdate, new object[] { });
    }
}
