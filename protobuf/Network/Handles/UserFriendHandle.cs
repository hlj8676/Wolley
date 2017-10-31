using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DataWrapper;

public class UserFriendHandle:SuperBOBO.NetInterface
{
    public delegate void FRIENDSREQ_CALLBACK();
    public static FRIENDSREQ_CALLBACK onFriendsreq;

    private static PlayerFriend playerFriendData = null;

    public static void initRequest()
    {
        AutoGenProto.Send_SUB_ID_FRIEND_GET_FRIENDS_LIST();//获取好友列表
        AutoGenProto.Send_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST();//请求好友申请列表

        if (Player.instance.armyGroupId != 0)
        {
            ArmyGroupHandler.SendCorpsRoomListReq(Player.instance.armyGroupId);
        }
    }

    //好友列表
    private void Delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP(int errorCode, uint fid, ushort flevel, uint lastofflinetime, byte lineStatus, RakNet.RakString fname, uint icon, RakNet.RakString corpsname, RakNet.RakString lvname)
    {
        if (playerFriendData != null)
        {
            FriendBasicInfo temp = new FriendBasicInfo(fid, flevel, lastofflinetime, lineStatus, fname, icon, corpsname, lvname);
            playerFriendData.playerFriendDataHandler(temp);

            //判断是否服务器主动推送数据, 有新好友
            if(!playerFriendData.isRequestFriend)
            {
                //如果在好友界面，不通知
                if(UIFriendMain.instance == null)
                {
                    playerFriendData.friendNewNotice.Add(temp);
                }

                //如果在主界面，显示通知
                if (UIMainHandle.instance != null && UIMainHandle.instance.gameObject.activeInHierarchy)
                {
                    UIMainHandle.instance.showNewFriend();
                }
            }
        }
    }

    private void Delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP_completed()
    {
        Util.Log("Delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP_completed");
        playerFriendData.isRequestFriend = false;
    }

    //申请好友列表
    private void Delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP(int errorCode, uint fid, ushort flevel, byte type, byte status, RakNet.RakString fname, uint icon)
    {
        if (playerFriendData != null)
        {
            FriendReqBasicInfo temp = new FriendReqBasicInfo(fid, flevel, type, status, fname, icon);
            playerFriendData.playerReqFriendDataHandler(temp);

            //判断是否服务器主动推送数据, 有新好友申请
            if (!playerFriendData.isRequestFriendReq)
            {
                //在好友列表界面不通知
                if (UIFriendMain.instance == null && (FriendReqType)type == FriendReqType.FRType_Positive)
                {
                    playerFriendData.friendRequestNotice.Add(temp);
                }

                //如果在主界面，显示通知
                if (UIMainHandle.instance != null && UIMainHandle.instance.gameObject.activeInHierarchy)
                {
                    UIMainHandle.instance.showRequestFriend();
                }
            }
        }
    }

    private void Delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP_completed()
    {
        Util.Log("Delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP_completed");

        playerFriendData.isRequestFriendReq = false;

        if (onFriendsreq != null)
        {
            onFriendsreq();
        }
    }

    //同意或拒绝好友申请 rsp
    private void Delegate_SUB_ID_FRIEND_REQUEST_RSP(int errorCode, uint userID, bool isAccept)
    {
        Util.Log("Delegate_SUB_ID_FRIEND_REQUEST_RSP:" + userID + "  " + isAccept);

        if (playerFriendData != null)
        {
            playerFriendData.deleteReqFriendData(userID);
        }
    }

    //删除好友 rsp
    private void Delegate_SUB_ID_FRIEND_DELETE_RSP(int errorCode, uint userID)
    {
        Util.Log("Delegate_SUB_ID_FRIEND_DELETE_RSP:" + userID);

        if (playerFriendData != null)
        {
            playerFriendData.deleteFriendData(userID);
        }
    }

    //有新好友
    private void Delegate_SUB_ID_FRIEND_ADD_RSP(int errorCode, uint userID, RakNet.RakString name)
    {
        Util.Log("Delegate_SUB_ID_FRIEND_ADD_RSP:" + userID);
    }

    //更新好友状态
    private void Delegate_SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP(int errorCode, uint userID, byte lineStatus)
    {
        if (playerFriendData != null)
        {
            //在好友列表界面不通知
            if (UIFriendMain.instance == null)
            {
                FriendBasicInfo info = playerFriendData.getFriendBasicInfo(userID);

                if (info == null)
                {
                    return;
                }

                //证明是从离线，到上线
                if (info.lineStatus == 0 && lineStatus != 0)
                {
                    if (info != null)
                    {
                        playerFriendData.friendOnLineNotice.Add(info);
                    }
                }
            }

            //如果在主界面，显示通知
            if (UIMainHandle.instance != null && UIMainHandle.instance.gameObject.activeInHierarchy)
            {
                UIMainHandle.instance.showOnlineFriend();
            }

            playerFriendData.updatePlayerFriendStatus(userID, lineStatus);
        }
    }
    
    //更新好友等级
    private void Delegate_SUB_ID_FRIEND_MODIFY_LEVEL_RSP(int errorCode, uint userID, ushort flevel)
    {
        if (playerFriendData != null)
        {
            playerFriendData.updatePlayerFriendLevel(userID, flevel);
        }
    }

    private void Delegate_SUB_ID_FRIEND_MODIFY_ICON_RSP(int errorCode, uint userID, ushort icon)
    {
        if (playerFriendData != null)
        {
            playerFriendData.updatePlayerFriendIcon(userID, icon);
        }
    }

    //批量添加好友
    private void Delegate_SUB_ID_FRIEND_BATCH_ADD_RSP(int errorCode, uint fid, ushort flevel, uint lastofflinetime, byte lineStatus, RakNet.RakString fname, uint icon, RakNet.RakString corpsname, RakNet.RakString lvname)
    {
        if (playerFriendData != null)
        {
            FriendBasicInfo temp = new FriendBasicInfo(fid, flevel, lastofflinetime, lineStatus, fname, icon, corpsname, lvname);
            playerFriendData.playerFriendMoreAddHandler(temp);
        }
    }


    public void OnRegister()
    {
        AutoGenProto.delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP += Delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP; //好友列表
        AutoGenProto.delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP_completed += Delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP_completed;
        AutoGenProto.delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP += Delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP; //其他人向自己申请好友列表，与个人向别人申请好友列表
        AutoGenProto.delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP_completed += Delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP_completed;
        AutoGenProto.delegate_SUB_ID_FRIEND_ADD_RSP += Delegate_SUB_ID_FRIEND_ADD_RSP;//新好友添加
        AutoGenProto.delegate_SUB_ID_FRIEND_REQUEST_RSP += Delegate_SUB_ID_FRIEND_REQUEST_RSP; //好友请求处理
        AutoGenProto.delegate_SUB_ID_FRIEND_DELETE_RSP += Delegate_SUB_ID_FRIEND_DELETE_RSP; //删除好友处理
        AutoGenProto.delegate_SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP += Delegate_SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP; //更新好友状态
        AutoGenProto.delegate_SUB_ID_FRIEND_BATCH_ADD_RSP += Delegate_SUB_ID_FRIEND_BATCH_ADD_RSP; //批量添加好友
        AutoGenProto.delegate_SUB_ID_FRIEND_MODIFY_LEVEL_RSP += Delegate_SUB_ID_FRIEND_MODIFY_LEVEL_RSP; //更新好友等级
        AutoGenProto.delegate_SUB_ID_FRIEND_MODIFY_ICON_RSP += Delegate_SUB_ID_FRIEND_MODIFY_ICON_RSP; //更新好友ICON

        playerFriendData = Player.instance.friend;
    }

    public void OnUnRegister()
    {
        AutoGenProto.delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP -= Delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP;
        AutoGenProto.delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP_completed -= Delegate_SUB_ID_FRIEND_GET_FRIENDS_LIST_RSP_completed;
        AutoGenProto.delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP -= Delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP; //其他人向自己申请好友列表，与个人向别人申请好友列表
        AutoGenProto.delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP_completed -= Delegate_SUB_ID_FRIEND_GET_FRIENDSREQ_LIST_RSP_completed;
        AutoGenProto.delegate_SUB_ID_FRIEND_ADD_RSP -= Delegate_SUB_ID_FRIEND_ADD_RSP;//新好友添加
        AutoGenProto.delegate_SUB_ID_FRIEND_REQUEST_RSP -= Delegate_SUB_ID_FRIEND_REQUEST_RSP; //好友请求处理
        AutoGenProto.delegate_SUB_ID_FRIEND_DELETE_RSP -= Delegate_SUB_ID_FRIEND_DELETE_RSP; //删除好友处理
        AutoGenProto.delegate_SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP -= Delegate_SUB_ID_FRIEND_MODIFY_LINESTATUS_RSP; //更新好友状态
        AutoGenProto.delegate_SUB_ID_FRIEND_BATCH_ADD_RSP -= Delegate_SUB_ID_FRIEND_BATCH_ADD_RSP; //批量添加好友
        AutoGenProto.delegate_SUB_ID_FRIEND_MODIFY_LEVEL_RSP -= Delegate_SUB_ID_FRIEND_MODIFY_LEVEL_RSP; //更新好友等级
        AutoGenProto.delegate_SUB_ID_FRIEND_MODIFY_ICON_RSP -= Delegate_SUB_ID_FRIEND_MODIFY_ICON_RSP; //更新好友ICON
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }

    //--------------------------- protobuf --------------------------

    private static List<uint> curDeleteFriendList = new List<uint>();
    //一键同意，一键拒绝，批量删除
    public static void SendBatchOpFriendReq(TankProtocol.OpFriendType type, List<uint> userid = null)
    {
        TankProtocol.BatchOpFriend ps = new TankProtocol.BatchOpFriend();
        ps.type = type;

        if (userid != null)
        {
            curDeleteFriendList.Clear();

            foreach(uint id in userid)
            {
                ps.id.Add(id);
                curDeleteFriendList.Add(id);
            }
        }

        DispatcherProtoBuf.Instance.SendProtoBuffer("BatchOpFriend", ps);
    }

    public static void OnRecvBatchOpFriendRsq(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.BatchOpFriendRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.BatchOpFriendRsp>(m);

        if (rsp.errcode == 0)
        {
            if (rsp.type == TankProtocol.OpFriendType.enm_del_friend)
            {
                if (curDeleteFriendList != null && curDeleteFriendList.Count > 0)
                {
                    foreach (uint userid in curDeleteFriendList)
                    {
                        if (playerFriendData != null)
                        {
                            playerFriendData.deleteFriendData(userid);
                        }
                    }
                }
            }
            else if(rsp.type == TankProtocol.OpFriendType.enm_accept_friend)
            {
                if(UIFriendBatch.instance != null)
                {
                    UIFriendBatch.instance.updateStatusFriend(true);
                }
            }
            else if (rsp.type == TankProtocol.OpFriendType.enm_refuse_friend)
            {
                if (UIFriendBatch.instance != null)
                {
                    UIFriendBatch.instance.updateStatusFriend(false);
                }
            }

            Debug.Log("[OnRecvBatchOpFriendRsq] : " + rsp.type);
        }
    }

}
