using UnityEngine;

using System.Collections;
using System.IO;
using System.Collections.Generic;

public class ArmyGroupHandler
{
    public delegate void OnCorpsFriendFrash();
    public static OnCorpsFriendFrash onCorpsFriendFrash = null;
    //请求某个军团全部数据
    public static void SendGetCorpsInfoReq(uint corpsid)
    {
        Common.ShowLoading(5);

        TankProtocol.GetCorpsInfo ps = new TankProtocol.GetCorpsInfo();
        ps.corpsid = corpsid;

        DispatcherProtoBuf.Instance.SendProtoBuffer("GetCorpsInfo", ps);
    }

    //回复某个军团全部数据
    public static void OnRecvGetCorpsInfoRsp(byte[] data)
    {
        Common.HideLoading();

        MemoryStream m = new MemoryStream(data);

        TankProtocol.GetCorpsInfoRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.GetCorpsInfoRsp>(m); 

        if(rsp != null && rsp.errcode == 0)
        {
            DataWrapper.PlayerArmyGroup tempArmyGroup = DataWrapper.Player.instance.armyGroup;

            if (tempArmyGroup.curCorpsInfo != null)
            {
                tempArmyGroup.curCorpsInfo = rsp.corpsInfo;
                tempArmyGroup.updateMyCorpsInfo();
                tempArmyGroup.updateCorpsLvNameInfo(rsp.corpsInfo.corpslvname);

                if (DataWrapper.Player.instance.armyGroup.curMemberInfo.memberlevel == 99 || DataWrapper.Player.instance.armyGroup.curMemberInfo.memberlevel == 100)
                {
                    if (rsp.corpsInfo.applylist.Count > 0)
                    {
                        DataWrapper.Player.instance.armyGroup.m_isShowRedPoint = true;
                    }
                    else
                    {
                        DataWrapper.Player.instance.armyGroup.m_isShowRedPoint = false;
                    }
                }
                else
                {
                    DataWrapper.Player.instance.armyGroup.m_isShowRedPoint = false;
                }
            }

            if (UIArmyGroupMain.instance != null)
            {
                UIArmyGroupMain.instance.updateData(UIArmyGroupMain.LAYER_TYPE.MY_CORPS);
            }

            /*
            else
            {
                tempArmyGroup.curLayerType = UIArmyGroupMain.LAYER_TYPE.MY_CORPS;
                SystemLoader.LoadScenerio(EScenario.army_group);
            }
            */
        }
        else
        {
            UIMessageBox.Show(rsp.errcode);
        }
    }

    //创建军团
    public static void SendCreateCorpsReq(string corpsName, uint iconid)
    {
        TankProtocol.CreateCorps ps = new TankProtocol.CreateCorps();
        ps.corpsname = corpsName;
        ps.iconid = iconid;
        DispatcherProtoBuf.Instance.SendProtoBuffer("CreateCorps", ps);
    }

    public static void OnRecvCreateCorpsRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.CreateCorpsRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.CreateCorpsRsp>(m); 

        if(rsp != null)
        {
            if(rsp.errcode == 0)
            {
                DataWrapper.PlayerArmyGroup tempArmyGroup = DataWrapper.Player.instance.armyGroup;

                if (tempArmyGroup.curCorpsInfo != null)
                {
                    tempArmyGroup.curCorpsInfo = rsp.corps;
                    tempArmyGroup.updateMyCorpsInfo();
                    DataWrapper.Player.instance.armyGroupId = rsp.corps.corpsid;
                }

                if (UIArmyGroupMain.instance != null)
                {
                    UIArmyGroupMain.instance.updateData(UIArmyGroupMain.LAYER_TYPE.MY_CORPS);
                }

                /*
                else
                {
                    tempArmyGroup.curLayerType = UIArmyGroupMain.LAYER_TYPE.MY_CORPS;
                    SystemLoader.LoadScenerio(EScenario.army_group);
                }
                */
            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
            }
        }
    }

    //请求加入军团
    public static void SendApplyEnterCorpsReq(uint corpsID)
    {
        TankProtocol.ApplyEnterCorps ps = new TankProtocol.ApplyEnterCorps();
        ps.corpsid = corpsID;

        DispatcherProtoBuf.Instance.SendProtoBuffer("ApplyEnterCorps", ps);
    }

    public static void OnRecvApplyEnterCorpsRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.ApplyEnterCorpsRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.ApplyEnterCorpsRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {
                UIMessageBox.Show(9018);
            }
            else
            {
                if (rsp.errcode == 9005)
                {
                    string body = Common.getDateTimeToStr(rsp.time);
                    string str = Table.Message.Get(rsp.errcode).Tip;
                    string body1 = string.Format(str, body);

                    UIMessageBox.ShowLittleWindow(body1);
                }
            }
        }
    }

    //军团长处理加入军团请求
    public static void SendAgreeApplyCorpsReq(uint playerID, bool agree)
    {
        TankProtocol.AgreeApplyCorps ps = new TankProtocol.AgreeApplyCorps();
        ps.playerid = playerID;
        ps.agree = agree;

        DispatcherProtoBuf.Instance.SendProtoBuffer("AgreeApplyCorps", ps);
    }

    public static void OnRecvAgreeApplyCorpsRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.AgreeApplyCorpsRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.AgreeApplyCorpsRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {

            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
            }
        }
    }

    //获取最新的申请列表
    public static void SendGetCorpsApplyReq(uint corpsID)
    {
        TankProtocol.GetCorpsApply ps = new TankProtocol.GetCorpsApply();
        ps.corpsid = corpsID;

        DispatcherProtoBuf.Instance.SendProtoBuffer("GetCorpsApply", ps);
    }

    public static void OnRecvGetCorpsApplyRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.GetCorpsApplyRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.GetCorpsApplyRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {
                DataWrapper.PlayerArmyGroup tempArmyGroup = DataWrapper.Player.instance.armyGroup;

                if (tempArmyGroup.curCorpsInfo != null)
                {
                    tempArmyGroup.curApplyMemberInfo = rsp.apply;
                }

                if (UIArmyGroupMain.instance != null)
                {
                    UIArmyGroupMain.instance.updateApplyMemberInfoData();
                }
            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
            }
        }
    }

    //有人申请加入军团，消息处理, 显示小红点
    public static void OnRecvNewApplyNoti(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.NewApplyNoti rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.NewApplyNoti>(m);

        if (rsp != null)
        {
            DataWrapper.Player.instance.armyGroup.m_isShowRedPoint = true;

            if (UIArmyGroupMain.instance != null)
            {
                UIArmyGroupMain.instance.onRedPointShow();
            }
        }
    }
    

    //军团长踢人
    public static void SendKickOutCorpsMemberReq(uint playerID)
    {
        TankProtocol.KickOutCorpsMember ps = new TankProtocol.KickOutCorpsMember();
        ps.playerid = playerID;

        DispatcherProtoBuf.Instance.SendProtoBuffer("KickOutCorpsMember", ps);
    }

    public static void OnRecvKickOutCorpsMemberRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.KickOutCorpsMemberRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.KickOutCorpsMemberRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {
                DataWrapper.PlayerArmyGroup tempArmyGroup = DataWrapper.Player.instance.armyGroup;

                if (tempArmyGroup.curCorpsInfo != null && rsp.playerid != 0)
                {
                    if(tempArmyGroup.deleteMemberPlayer(rsp.playerid))
                    {
                        if (UIArmyGroupMain.instance != null)
                        {
                            UIArmyGroupMain.instance.updateData(UIArmyGroupMain.LAYER_TYPE.MY_CORPS);
                        }
                    }
                }
            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
            }
        }
    }

    //团员退出, 军团长退出
    public static void SendLeaveCorpsReq()
    {
        TankProtocol.LeaveCorps ps = new TankProtocol.LeaveCorps();

        DispatcherProtoBuf.Instance.SendProtoBuffer("LeaveCorps", ps);
    }

    public static void OnRecvLeaveCorpsRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.LeaveCorpsRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.LeaveCorpsRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {

            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
            }
        }
    }


    //军团长改名
    public static void SendChangeCorpsNameReq(string newname)
    {
        TankProtocol.ChangeCorpsName ps = new TankProtocol.ChangeCorpsName();
        ps.newname = newname;

        DispatcherProtoBuf.Instance.SendProtoBuffer("ChangeCorpsName", ps);
    }

    public static void OnRecvChangeCorpsNameRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.ChangeCorpsNameRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.ChangeCorpsNameRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {

            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
            }
        }
    }

    //军团长改公告
    public static void SendChangeCorpsIntroduceReq(string newintroduce)
    {
        TankProtocol.ChangeCorpsIntroduce ps = new TankProtocol.ChangeCorpsIntroduce();
        ps.newintroduce = newintroduce;

        DispatcherProtoBuf.Instance.SendProtoBuffer("ChangeCorpsIntroduce", ps);
    }

    public static void OnRecvChangeCorpsIntroduceRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.ChangeCorpsIntroduceRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.ChangeCorpsIntroduceRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {

            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
            }
        }
    }

    //军团任命副军团长
    public static void SendAppointSubLeaderReq(uint playerID, bool isJieChu = true)
    {
        TankProtocol.AppointSubLeader ps = new TankProtocol.AppointSubLeader();
        ps.playerid = playerID;
        ps.down = isJieChu ? (uint)1 : (uint)0;
             
        DispatcherProtoBuf.Instance.SendProtoBuffer("AppointSubLeader", ps);
    }

    public static void OnRecvAppointSubLeaderRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.AppointSubLeaderRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.AppointSubLeaderRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {

            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
                Debug.LogError("[ArmyGroupHandler] OnRecvAppointSubLeaderRsp error code : " + rsp.errcode);
            }
        }
    }

    //军团长，任命副军团长，副军团长收到通知
    public static void OnRecvAppointSubLeaderNoti(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.AppointSubLeaderNoti rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.AppointSubLeaderNoti>(m);

        if (rsp != null)
        {
            DataWrapper.PlayerArmyGroup tempArmyGroup = DataWrapper.Player.instance.armyGroup;

            if (tempArmyGroup.curCorpsInfo != null)
            {
                tempArmyGroup.renMingSubLeader(rsp.subleaderid, rsp.memberlevel);
            }

            if (UIArmyGroupMain.instance != null && UIArmyGroupMain.instance.m_leaguerLayer.gameObject.activeInHierarchy)
            {
                UIArmyGroupMain.instance.updateData(UIArmyGroupMain.LAYER_TYPE.MY_CORPS);
            }
        }
    }
    

    //军团长与副军团长，自动申请关闭与打开
    public static void SendCorpsAutoAgreeReq(bool isTrue)
    {
        TankProtocol.CorpsAutoAgree ps = new TankProtocol.CorpsAutoAgree();
        ps.autoagree = isTrue ? (uint)0 : (uint)1;

        DispatcherProtoBuf.Instance.SendProtoBuffer("CorpsAutoAgree", ps);
    }

    public static void OnRecvCorpsAutoAgreeRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.CorpsAutoAgreeRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.CorpsAutoAgreeRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {

            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
            }
        }
    }

    //称号
    public static void SendChangeCorpsLvNameReq(List<TankProtocol.CorpsLvNameInfo> newName)
    {
        TankProtocol.ChangeCorpsLvName ps = new TankProtocol.ChangeCorpsLvName();

        foreach(TankProtocol.CorpsLvNameInfo temp in newName)
        {
            ps.newlvname.Add(temp);
        }

        DispatcherProtoBuf.Instance.SendProtoBuffer("ChangeCorpsLvName", ps);
    }

    public static void OnRecvChangeCorpsLvNameRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.ChangeCorpsLvNameRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.ChangeCorpsLvNameRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {

            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
            }
        }
    }

    //查找军团
    public static void SendSearchCorpsReq(uint corpsID)
    {
        TankProtocol.SearchCorps ps = new TankProtocol.SearchCorps();
        ps.corpsid = corpsID;

        DispatcherProtoBuf.Instance.SendProtoBuffer("SearchCorps", ps);
    }

    public static void OnRecvSearchCorpsRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.SearchCorpsRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.SearchCorpsRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {
                DataWrapper.PlayerArmyGroup tempArmyGroup = DataWrapper.Player.instance.armyGroup;
                tempArmyGroup.searchCorpsList.Clear();

                tempArmyGroup.searchCorpsList = rsp.corps;

                if (UIArmyGroupMain.instance != null)
                {
                    UIArmyGroupMain.instance.updateData(UIArmyGroupMain.LAYER_TYPE.SEARCH_CORPS);
                }
                /*
                else
                {
                    tempArmyGroup.curLayerType = UIArmyGroupMain.LAYER_TYPE.SEARCH_CORPS;
                    SystemLoader.LoadScenerio(EScenario.army_group);
                }
                */
            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
                Debug.LogError("[ArmyGroupHandler] OnRecvSearchCorpsRsp error code : " + rsp.errcode);
            }
        }
    }

    //修改头像
    public static void SendChangeCorpsIcon(uint iconID)
    {
        TankProtocol.ChangeCorpsIcon ps = new TankProtocol.ChangeCorpsIcon();
        ps.iconid = iconID;

        DispatcherProtoBuf.Instance.SendProtoBuffer("ChangeCorpsIcon", ps);
    }

    public static void OnRecvChangeCorpsIconRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.ChangeCorpsIconRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.ChangeCorpsIconRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {
                UIArmyGroupInfoLeftLayer.instance.modifyHeadIcon();
            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
            }
        }
    }

    //---------------------------- 捐赠 ----------------------------------

    //请求军团全部的求赠列表
    public static void SendCorpsWantListReq(uint corpsid)
    {
        TankProtocol.CorpsWantList ps = new TankProtocol.CorpsWantList();
        ps.corpsid = corpsid;

        DispatcherProtoBuf.Instance.SendProtoBuffer("CorpsWantList", ps);
    }

    public static void OnRecvCorpsWantListRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.CorpsWantListRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.CorpsWantListRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {
                DataWrapper.PlayerArmyGroup tempArmyGroup = DataWrapper.Player.instance.armyGroup;
                tempArmyGroup.myWantItem.Clear();
                tempArmyGroup.otherWantItem.Clear();

                tempArmyGroup.myWantItem = rsp.myitems;
                tempArmyGroup.otherWantItem = rsp.otheritems;

                if (UIArmyGroupMain.instance != null && UIArmyGroupMain.instance.m_giftLayer.gameObject.activeInHierarchy)
                {
                    UIArmyGroupMain.instance.updateGiftData();
                }
            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
            }
        }
    }

    //个人求赠-----新需求一次只能选择一个
    public static void SendCorpsWantReq(List<uint> itemid)
    {
        TankProtocol.CorpsWant item = new TankProtocol.CorpsWant();

        foreach(uint temp in itemid)
        {
            item.itemid.Add(temp);
        }

        DispatcherProtoBuf.Instance.SendProtoBuffer("CorpsWant", item);
    }

    public static void OnRecvCorpsWantRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.CorpsWantRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.CorpsWantRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {
                DataWrapper.PlayerArmyGroup tempArmyGroup = DataWrapper.Player.instance.armyGroup;

                if (tempArmyGroup.curCorpsInfo != null)
                {
                    tempArmyGroup.myWantItem = rsp.item;
                }

                if (UIArmyGroupMain.instance != null)
                {
                    UIArmyGroupMain.instance.updateGiftData();
                }
            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
            }
        }
    }

    //捐赠
    public static void SendCorpsDonateReq(uint wantid)
    {
        TankProtocol.CorpsDonate ps = new TankProtocol.CorpsDonate();
        ps.wantid = wantid;

        DispatcherProtoBuf.Instance.SendProtoBuffer("CorpsDonate", ps);
    }

    public static void OnRecvCorpsDonateRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.CorpsDonateRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.CorpsDonateRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {
                if(UIArmyGroupMain.instance != null)
                {
                    UIArmyGroupMain.instance.m_giftLayer.otherDataUpdate(rsp.wantid);
                }
            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
            }
        }
    }

    //个人求赠物品，数量修改更新
    public static void OnRecvHasWantNoti(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.HasWantNoti rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.HasWantNoti>(m);

        if (rsp != null)
        {
            if (rsp.items != null)
            {
                if(UIArmyGroupMain.instance != null)
                {
                    UIArmyGroupMain.instance.m_giftLayer.myDataUpdateNumber(rsp.items);
                }
            }
        }
    }

    //------------------------------------- 军团房间数据 ------------------------------

    //请求军团上线数据，不经过军团界面
    public static void SendCorpsRoomListReq(uint corpsID)
    {
        TankProtocol.CorpsRoomList ps = new TankProtocol.CorpsRoomList();
        ps.corpsid = corpsID;

        DispatcherProtoBuf.Instance.SendProtoBuffer("CorpsRoomList", ps);
    }

    public static void OnRecvCorpsRoomListRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.CorpsRoomListRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.CorpsRoomListRsp>(m);

        if (rsp != null)
        {
            if (rsp.errcode == 0)
            {
                DataWrapper.PlayerArmyGroup tempArmyGroup = DataWrapper.Player.instance.armyGroup;

                if (tempArmyGroup != null)
                {
                    foreach(TankProtocol.CorpsRoomMember corpsRoomMember in rsp.member)
                    {
                        tempArmyGroup.roomCorpsMemberHandler(corpsRoomMember);
                    }
                }
            }
            else
            {
                UIMessageBox.Show(rsp.errcode);
            }
        }
    }

    //更新军团成员状态
    public static void OnRecvCorpsRoomMemberNoti(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.CorpsRoomMemberNoti rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.CorpsRoomMemberNoti>(m);

        if (rsp != null)
        {
            DataWrapper.PlayerArmyGroup tempArmyGroup = DataWrapper.Player.instance.armyGroup;

            if (tempArmyGroup != null)
            {
                tempArmyGroup.roomCorpsMemberHandler(rsp.member);
                if (onCorpsFriendFrash != null)
                    onCorpsFriendFrash();
            }
        }
    }

    //更新好友的军团数据
    public static void OnRecvFriendCorpsInfoChangeNoti(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.FriendCorpsInfoChangeNoti rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.FriendCorpsInfoChangeNoti>(m);

        if (rsp != null)
        {
            DataWrapper.Player.instance.friend.modifyCorpsInfo(rsp.playerid, rsp.corpsname, rsp.lvname);
        }
    }
}