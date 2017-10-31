using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RakNet;
using System.IO;

public class Dispatcher
{
    private static Dispatcher instance;
    public delegate void OnConnected();
    public OnConnected onConnected;

    public delegate void OnEnterGame(bool isConnected);
    public OnEnterGame onEnterGame; //判断是否可以进入游戏

    public UserBuyAttrHandler userBuyAttrHandler = null;
    public bool isBattleServerConnect = false;

    public static Dispatcher Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Dispatcher();
                instance.Initialize();
            }

            return instance;
        }
    }

    public delegate void OnRecive(RakNet.BitStream bs);

    private Hashtable m_hashRecive = new Hashtable();

    public void OnDestroy()
    {
        foreach (var k in handles)
        {
            k.OnUnRegister();
        }
        m_hashRecive.Clear();
        instance = null;
    }

    public void Register(byte messageID, OnRecive onRecive)
    {
        m_hashRecive.Add(messageID, onRecive);
    }

    public void UnRegister(byte messageID)
    {
        m_hashRecive.Remove(messageID);
    }

    public List<SuperBOBO.NetInterface> handles = new List<SuperBOBO.NetInterface>();

    public void Initialize()
    {
        AutoGenProto.GlobalRegister(this);
        ManualProtocol.GlobalRegister(this);
        DownHandlePlayer.Register();

        handles.Clear();
        /*
         * reg by zj
         */

        handles.Add(new UserTankListHandle());
        handles.Add(new UserItemListHandle());
        handles.Add(new UserBasicPropChangeHandle());
        handles.Add(new UserPilotListHandle());
        handles.Add(new UserPilotDetailHandle());
        handles.Add(new UserTankDetailHandle());
        handles.Add(new UserMailHandle());
        handles.Add(new NortifyHandle());
        handles.Add(new UserTaskHandle());
        handles.Add(new UserActiveHandle());
        handles.Add(new BattlePaintHandle());
        handles.Add(new UserSystemOpenHandle());
        handles.Add(new UserTeamGroupHandle());
        handles.Add(new UserGuideHandle());
        handles.Add(new UserRuneHandle());
        handles.Add(new UserFriendHandle());
        handles.Add(new UserActivityHandle());
        handles.Add(new UserTankPaintingHandle());
        handles.Add(new UserPVESaodangHandle());
        


        foreach (var k in handles)
        {
            k.OnRegister();
        }

        //Chat.Register();

        AutoGenProto.delegate_SUB_ID_PLAYER_PPVE_TASK_LIST_RSP = OnPlayerPPVEList;
        Table.MultiPve.Init();

        //加入房间可以在任何界面，全局注册吧
        AutoGenProto.delegate_ID_LOBBY_CREATE_ROOM_RSP = OnCreateRoom;
        //被邀请的弹窗可以在任何界面，全局注册
        AutoGenProto.delegate_ID_LOBBY_ROOM_INVITE_RSP = OnInvited;

        //金币，体力购买
        userBuyAttrHandler = new UserBuyAttrHandler();
        userBuyAttrHandler.OnRegister();

        m_refCounter = (byte)Random.Range(1, 255);
        Util.Log("初始流水号" + m_refCounter);

        DispatcherProtoBuf.Instance.Register("GuideInfo", GuideInfo);
		DispatcherProtoBuf.Instance.Register("RechargeRet", ReturnRechargeRet);
    }

	//收到服务器 充值订单成功 消息
	public static void ReturnRechargeRet(byte[] data)
	{
		MemoryStream m = new MemoryStream(data);
		TankProtocol.RechargeRet rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.RechargeRet>(m);

		TalkingDataAdTracking.TdAdAppCpaOnPay (UILogin.m_channel_uuid, rsp.gameorder, (int)rsp.price, "CNY", "apple");
	}

    //同步数据，处理请求异常 by shilongquan
    public void OnDataUpdate()
    {
        userBuyAttrHandler.OnDataUpdate();
    }

    static void GuideInfo(byte[] data)
    {
        Debug.Log("收到可以战场引导");
        if (GuideManager.instance != null && !GuideManager.instance.NoBattleGuide)//不进战场引导
        {
            SystemLoader.onPreLoaderFinish = InBattleGuide;
            NewerCheckPointGuide.startBattleGuide = true;
        }
    }
    static void InBattleGuide()
    {
        Debug.Log("拉进引导战场");
        ARoom.CreateRoom(RoomType.RoomType_PVE);
        AutoGenProto.Send_SUB_ID_PLAYER_PPVE_MATCH(20100);
        if (UIPlayerBasicProp.instance != null)
            UIPlayerBasicProp.instance.gameObject.SetActive(false);
    }

    static void OnInvited(int errorCode, byte serverID, uint userID, byte lobbyID, ushort roomID, byte roomType, uint battleID)
    {
        if (DataWrapper.Player.instance.copyChest.isEnterChest || GameSetting.Instance.datas.invationOff || GuideManager.instance.IsGuiding() || !DataWrapper.PlayerGuide.instance.AllGuideFinish() || UI_PVP_Result_Window.instance != null || UI_PVE_Result_Window.instance != null)//是否接受邀请
            return;
        string name="";
        if (DataWrapper.Player.instance.friend.getFriendBasicInfo(userID) != null)
        {
            name = DataWrapper.Player.instance.friend.getFriendBasicInfo(userID).fname.ToString();
        }
        if (string.IsNullOrEmpty(name))
        {
            if (DataWrapper.Player.instance.armyGroup.GetRoomCorpsMember(userID) != null)
            {
                name = DataWrapper.Player.instance.armyGroup.GetRoomCorpsMember(userID).playername;
            }
        }

        if (!string.IsNullOrEmpty(name))
        {
            UIMessageBox.Show(name + "邀请你一起战斗",
                () =>
                {
                    //AutoGenProto.Send_ID_GM_MSG(1, "joinroom " + roomID);
                    if (ARoom.GetState() == ARoom.State.none || ARoom.GetState() == ARoom.State.exitroom)
                    {
                        AutoGenProto.Send_ID_LOBBY_ROOM_JOIN(lobbyID, roomID);
                    }
                    else
                    {
                        //UIMessageBox.ShowLittleWindow("请先退出房间");
                        UIMessageBox.Show(307);
                    }
                }, () =>
                {

                }, "参战", "放弃");
        }
    }

    static void OnCreateRoom(int errorCode, byte battleType, uint roomID, uint battleID)
    {
        NetLog.GetInstance().PostLog("creatroom mode = " + ((RoomType)battleType).ToString() + "errorcode = " + errorCode.ToString());
        Debug.Log("creatroom errorcode = " + errorCode + "---" + (RoomType)battleType + "---" + ARoom.GetState() + "room id = " + roomID.ToString());
        Common.HideLoading();
        if (errorCode == 108)
        {
            //UIMessageBox.ShowLittleWindow("房间数达到上限");
            if (UIPVPMode.instance) SystemLoader.Instance.StartCoroutine(UIPVPMode.instance.AnimationWorldMapRevert());
            UIMessageBox.Show(308);
            return;
        }

        if (ARoom.GetState() != ARoom.State.none)//保护
        {
            ARoom.DestroyRoom();
        }
        ARoom.CreateRoom((RoomType)battleType, BattleAgainEnterRecon.Instance.isExitsBattle);
        ARoom.roomSettingHandle.battleID = battleID;
        ARoom.roomSettingHandle.roomID = roomID;
        ARoom.roomSettingHandle.isCreatRoom = true;
        ARoom.cacheRoomId = roomID;
        ARoom.cacheBattleId = battleID;

        Util.LogWarning("创建房间, 服务器默认地图 : " + battleID);


        switch ((RoomType)battleType)
        {
            case RoomType.RoomType_PVP:
            case RoomType.RoomType_Match:
            case RoomType.RoomType_PVP_Union:
            case RoomType.RoomType_PVP_Props:
                if (BattleAgainHandler.isLoadRoomUI())
                {
                    SystemLoader.LoadScenerio(EScenario.pvp_room, new Parameters("mode=" + battleType));
                }
                break;
            case RoomType.RoomType_PVE:
                SystemLoader.LoadScenerio(EScenario.pve);
                break;
        }
        NetLog.GetInstance().PostLog("战斗存在");

        //else
        //{
        //    NetLog.GetInstance().PostLog("Room exist " + ARoom.GetState().ToString());
        //}
    }

    public static void OnPlayerPPVEList(int errorCode, uint group, byte complete)
    {
        Util.Log("OnPlayerPPVEList " + group + "  " + complete);
        Table.MultiPve.SetMapCompleted(group, complete);
    }


    //public static void 

    public void Dispatch(RakNet.BitStream bs, string socketName)
    {
        byte messageID = 0;
        bs.Read(out messageID);

        if ((MessageID)messageID == MessageID.ID_MULTI_COMMAND)
        {
            while (bs.GetNumberOfUnreadBits() > 8)
            {
                ushort length = 0;
                bs.Read(out length);
                byte msgID = 0;
                bs.Read(out msgID);

                RakNet.BitStream stream = new RakNet.BitStream();
                bs.Read(stream, (uint)(length - 8));

                Dispatch(msgID, stream, socketName);
                stream.Dispose();
            }
        }
        else
        {
            Dispatch(messageID, bs, socketName);
        }
        bs.Dispose();
    }

    public void Dispatch(byte messageID, RakNet.BitStream bs, string socketName)
    {
        if ((MessageID)messageID != MessageID.ID_PLAYER_TIMESTAMP_RSP && (MessageID)messageID != MessageID.ID_PLAYER_POSITION_SYNC_RSP && (MessageID)messageID != MessageID.ID_MULTI_COMMAND)
        {

            if ((MessageID)messageID < MessageID.ID_PLAYER_CHAT)
                MessageCheck.Instance.RecvMessage(((DefaultMessageIDTypes)messageID).ToString());
            else
            {
                if ((MessageID)messageID == MessageID.ID_SUBMSG_BEGIN || (MessageID)messageID == MessageID.ID_PROTOBUF_MSG)
                {

                }
                else
                {
                    MessageCheck.Instance.RecvMessage(((MessageID)messageID).ToString());
                }
            }
            LazyDebug.GetInstance().AddLoad(Util.Log, "[" + socketName + "][Dispatcher] 收到协议 :" + (MessageID)messageID);
        }

        if (m_hashRecive.ContainsKey(messageID))
        {
            OnRecive onRecive = (OnRecive)m_hashRecive[messageID];
            if (onRecive != null)
            {
                onRecive(bs);
            }
            else
            {
                LazyDebug.GetInstance().AddLoad(Util.LogError, "没有注册协议号:" + messageID);
            }
        }
        else
        {
            LazyDebug.GetInstance().AddLoad(Util.LogWarning, "net work : " + socketName + "_" + messageID);
            if ((MessageID)messageID == MessageID.ID_PROTOBUF_MSG)
            {
                DispatcherProtoBuf.Instance.OnDispatchProtoBuf(bs);
            }
            else if (messageID == (byte)DefaultMessageIDTypes.ID_CONNECTION_REQUEST_ACCEPTED)
            {
                SuperBOBO.EventManager.Instance.FireEvent(GameEventType.Raknet_connectionAccepted, new object[]{socketName});
                Util.LogWarning("客户端连接服务器成功！（ID_CONNECTION_REQUEST_ACCEPTED_16）");
                updateSocketMessage(messageID, socketName);

                if (onConnected != null)
                {
                    onConnected();
                }

                if (onEnterGame != null)
                {
                    onEnterGame(true);
                }


                reConnetOK(socketName);
            }
            else if (messageID == (byte)DefaultMessageIDTypes.ID_ALREADY_CONNECTED)
            {
                Util.LogWarning("服务器已存在客户端连接，已连接上!(ID_ALREADY_CONNECTED_18)");
                updateSocketMessage(messageID, socketName);

                reConnetOK(socketName);
            }
            else if (messageID == (byte)DefaultMessageIDTypes.ID_CONNECTION_ATTEMPT_FAILED)
            {
                Util.LogWarning("客户端连接服务器失败！(ID_CONNECTION_ATTEMPT_FAILED_17)");

                if (SocketFactory.mainSocket != null && SocketFactory.mainSocket.overrided)
                {
                    Common.NetworkDisConnectBox("(error : 401)");
                    return;
                }

                updateSocketMessage(messageID, socketName);

                if (showNetCloseUI())
                {

                }

                if (onEnterGame != null)
                {
                    onEnterGame(false);
                }
            }
            else if (messageID == (byte)DefaultMessageIDTypes.ID_CONNECTION_LOST) //客户端断网
            {
                SuperBOBO.EventManager.Instance.FireEvent(GameEventType.Raknet_connectionLost, new object[] { socketName });
                if (UIStart.instance != null && UIStart.instance.inUIStart)
                {
                    Common.HideLoading();
                    //断开服务器，防止进入重连逻辑
                    if (SocketFactory.mainSocket != null)
                    {
                        SocketFactory.DeleteMainSocket();
                    }
                    UIMessageBox.Show("网络断开(error : 4442)", () =>
                    {
                        Common.ForceExit();
                    },

                    UIMessageBox.BUTTON_SHOW_STYLE.BUTTON_OK);
                }
                else
                {
                    Util.LogWarning("网络断开连接!(ID_CONNECTION_LOST_22)");
                    updateSocketMessage(messageID, socketName);

                    if (showNetCloseUI())
                    {
                        onReConnect(socketName);
                    }

                    if (onEnterGame != null)
                    {
                        onEnterGame(false);
                    }

                    ARoom.NetHandle.BackToMain();
                }
               
            }
            else if (messageID == (byte)DefaultMessageIDTypes.ID_DISCONNECTION_NOTIFICATION) //服务器主动断开
            {
                SuperBOBO.EventManager.Instance.FireEvent(GameEventType.Raknet_disconnectNotification, new object[] { socketName });
                if (UIStart.instance != null && UIStart.instance.inUIStart)
                {
                    Common.HideLoading();
                    //断开服务器，防止进入重连逻辑
                    if (SocketFactory.mainSocket != null)
                    {
                        SocketFactory.DeleteMainSocket();
                    }
                    UIMessageBox.Show("网络断开(error : 4443)", () =>
                    {
                        Common.ForceExit();
                    },

                    UIMessageBox.BUTTON_SHOW_STYLE.BUTTON_OK);
                }
                else
                {
                    Util.LogWarning("服务器断开连接!(ID_DISCONNECTION_NOTIFICATION_21)");
                    updateSocketMessage(messageID, socketName);

                    if (!string.IsNullOrEmpty(DataWrapper.Player.instance.netCloseInfo))
                    {
                        UIMessageBox.Show(DataWrapper.Player.instance.netCloseInfo, () =>
                        {
                            Common.ForceExit();
                        },

                        UIMessageBox.BUTTON_SHOW_STYLE.BUTTON_OK);
                    }
                    else
                    {
                        Common.NetworkDisConnectBox("(error : 101)");
                    }

                }
             
                /* 取消重连
                if (showNetCloseUI())
                {
                    onReConnect(socketName);
                    Common.OnLostConnect();
                }
                */
            }
            else
            {
                if (messageID < 100)
                {
                    RakNet.DefaultMessageIDTypes rakCode = (RakNet.DefaultMessageIDTypes)messageID;
                    Util.LogError("raknet code: " + rakCode.ToString());
                }
                else
                {
                    Util.LogError("协议号未找到: " + (MessageID)messageID);
                }
            }
        }
    }

    private void updateSocketMessage(byte messageID, string socketName)
    {
        if (socketName == SocketFactory.MAIN_SOCKET_NAME && SocketFactory.mainSocket != null)
        {
            SocketFactory.mainSocket.messageId = messageID;
        }

        if (socketName == SocketFactory.BATTLE_SOCKET_NAME && SocketFactory.battleSocket != null)
        {
            SocketFactory.battleSocket.messageId = messageID;
        }
    }

    private bool showNetCloseUI()
    {
        if (LockScreen.isTimeOutToLockScreen())
        {
            Common.NetworkDisConnectBox("(error : 201)");

            return false;
        }

        return true;
    }

    private void onReConnect(string socketName)
    {
        if (socketName == SocketFactory.MAIN_SOCKET_NAME && SocketFactory.mainSocket != null)
        {

            #if UNITY_IOS
            SocketFactory.reconnectSocket(SocketFactory.mainSocket);
            #else

            SocketFactory.mainSocket.Reconnect();
            #endif
        }

        if (socketName == SocketFactory.BATTLE_SOCKET_NAME && SocketFactory.battleSocket != null)
        {
            #if UNITY_IOS
            SocketFactory.reconnectSocket(SocketFactory.battleSocket);
            #else
            //逻辑服正在重连，战斗服等待重连
            if (SocketFactory.mainSocket != null && SocketFactory.mainSocket.isReconnect)
            {
            isBattleServerConnect = true;
            return;
            }

            SocketFactory.battleSocket.Reconnect();
            #endif
        }
    }

    //逻辑服连接成功，连接战斗服
    public void onReConnectToBattleServer()
    {
        BattleAgainHandler.onEnterBattle = null;

        //玩家还在战斗中，才连接战斗服
        if (BattleAgainEnterRecon.Instance.isExitsBattle)
        {
            if (SocketFactory.battleSocket != null && isBattleServerConnect)
            {
                isBattleServerConnect = false;
                SocketFactory.battleSocket.Reconnect();
            }
        }
        //提示玩家游戏已结束
        else
        {
            exitBattleHandler();
        }
    }

    public void onPalyerBattleServerState()
    {
        BattleAgainHandler.onEnterBattle = null;

        //战斗服非正常逻辑处理，结束，逃跑
        if (!BattleAgainEnterRecon.Instance.isExitsBattle)
        {
            exitBattleHandler();
        }
    }

    public void exitBattleHandler()
    {
        if (UI_PVP_Result_Window.instance != null && UI_PVP_Result_Window.instance.gameObject.activeInHierarchy)
        {
            return;
        }

        if (UI_PVE_Result_Window.instance != null && UI_PVE_Result_Window.instance.gameObject.activeInHierarchy)
        {
            return;
        }

        string str = Table.Message.Get(802).Tip;
        UIMessageBox.Show(str, () =>
        {
            LevelManagerBase.OnExitLevelToUIMain();
        },

        UIMessageBox.BUTTON_SHOW_STYLE.BUTTON_OK);
    }

    //游戏匹配中，断开网络，申请重新进入
    private void matchingNetHandler()
    {
        BattleAgainHandler.onEnterBattle = null;

        //玩家还在战斗中，才连接战斗服
        if (BattleAgainEnterRecon.Instance.isExitsBattle)
        {
            BattleAgainHandler.SendBattleAgain(true);
        }
    }

    //重连成功
    private void reConnetOK(string socketName)
    {
        Common.HideLoading();

        if (socketName == SocketFactory.MAIN_SOCKET_NAME && SocketFactory.mainSocket != null)
        {
            SocketFactory.mainSocket.OnConnect();
            if (SocketFactory.mainSocket.isReconnect)
            {
                AutoGenProto.Send_ID_PLAYER_ACTIVE(1);
                SocketFactory.mainSocket.Reconnected();

                OnDataUpdate();

                //逻辑服断开，检测战斗服是否存在
                if (SocketFactory.battleSocket != null)
                {
                    BattleAgainHandler.onEnterBattle = onReConnectToBattleServer;
                    BattleAgainHandler.SendPlayerState();
                }
                else
                {
                    BattleAgainHandler.onEnterBattle = matchingNetHandler;
                    BattleAgainHandler.SendPlayerState();
                }
            }
        }

        if (socketName == SocketFactory.BATTLE_SOCKET_NAME && SocketFactory.battleSocket != null)
        {
            SocketFactory.battleSocket.OnConnect();
            if (SocketFactory.battleSocket.isReconnect)
            {
                AutoGenProto.Send_ID_PLAYER_ACTIVE(1);
                SocketFactory.battleSocket.Reconnected();

                BattleAgainHandler.onEnterBattle = onPalyerBattleServerState;
                AutoGenProto.Send_SUB_ID_BATTLE_GET_BATTLEINFO(ARoom.GetInstanceID());
            }
        }
    }

    public RakNet.BitStream PackData(MessageID msgID, RakNet.BitStream bitStream)
    {

        RakNet.BitStream payLoad = new RakNet.BitStream();
        payLoad.Write(refCounterNext);
        payLoad.Write(SysEnv.userID);
        payLoad.Write(bitStream);


        RakNet.BitStream bs = new RakNet.BitStream();
        bs.Write((byte)msgID);

        if (msgID > MessageID.ID_NEED_CRC_BEGIN)
        {
            byte[] data = payLoad.GetData();
            ushort crc = CRC16.CRC16_ccitt(data, 0, payLoad.GetNumberOfBytesUsed());
            bs.Write(crc);
        }

        bs.Write(payLoad);
        payLoad.Dispose();
        return bs;
    }

    public void Send(MessageID msgID, RakNet.BitStream bitStream, bool toBattleServer)
    {

        RakNet.BitStream payLoad = new RakNet.BitStream();
        payLoad.Write((byte)refCounterNext);        //协议流水号
        payLoad.Write(SysEnv.userID);
        payLoad.Write(bitStream);        //协议内容


        RakNet.BitStream bitStreamSend = new RakNet.BitStream();
        bitStreamSend.Write((byte)msgID);  //协议号

        if (msgID > MessageID.ID_NEED_CRC_BEGIN)
        {
            byte[] data = payLoad.GetData();
            ushort crc = CRC16.CRC16_ccitt(data, 0, payLoad.GetNumberOfBytesUsed());
            bitStreamSend.Write(crc);
        }

        bitStreamSend.Write(payLoad);

        Util.Log("发送用户id=" + SysEnv.userID);
        //SocketManager.instance.Send(bitStreamSend);

        if (toBattleServer)
        {
            if (SocketFactory.battleSocket && SocketFactory.battleSocket.isConnect())
            {
                SocketFactory.battleSocket.Send(bitStreamSend);
                Util.Log("发送消息到战斗服 " + "协议号：" + msgID + " 流水号：" + refCounter + " 内容大小：" + bitStream.GetNumberOfBitsUsed() / 8 + " user：" + SysEnv.userID);
            }
        }
        else
        {
            SocketFactory.mainSocket.Send(bitStreamSend);

            Util.Log("发送消息 " + "协议号：" + msgID + " 流水号：" + refCounter + " 内容大小：" + bitStream.GetNumberOfBitsUsed() / 8 + " user：" + SysEnv.userID);
        }
    }


    private byte m_refCounter = 1;
    public byte refCounter { get { return m_refCounter; } }
    public byte refCounterNext
    {
        get
        {
            if (m_refCounter == 0xFF)//caution 255%255=0 256%255=0
                m_refCounter = 0;
            m_refCounter = (byte)(++m_refCounter % 0xFF);
            //            Util.Log("-------------------------流水号" + m_refCounter.ToString()+"------------------------");
            return m_refCounter;
        }
    }
}

