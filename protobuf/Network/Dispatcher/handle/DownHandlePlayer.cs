/*
 * 
 * ֻ�����޸ĺ���������
 * 
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using RakNet;
using System.IO;
public static class DownHandlePlayer
{
    //public static void OnRequestPlayerGetUserid(int userID, byte svrID, byte type)
    //{
    //    Util.Log("OnRequestPlayerGetUserid" + userID + "  " + svrID);


    // RoomManager.playerID = userID;

    //    GameObject obj = UIManager.Instance.currentUI;
    //    UIStart uiStart = obj.GetComponent<UIStart>();
    //    if (uiStart)
    //    {
    //        uiStart.OnRequestPlayerGetUserid(userID, svrID, type);
    //    }
    //}

    public static void OnRequestPlayerLogin(byte type, int hp, RakNet.RakString name, int exp, short level, byte gender, int gold, byte energy, byte rank, int rankLevel)
    {
        GameObject obj = UIManager.Instance.currentUI;
        UIStart uiStart = obj.GetComponent<UIStart>();
        if (uiStart)
        {
            uiStart.OnRequestPlayerLogin();
        }
        
        Util.Log("  " + name.ToString() + "  " + exp + "  " + gender);
        NetLog.GetInstance().PostLog("OnRequestPlayerLogin->" + name.ToString() + "->" + exp + "->" + gender);
    }

    public static void OnRequestErrorCode(int _errCode, uint errorCode, uint param)
    {
        ServerErrorCode errorEnum = (ServerErrorCode)errorCode;

        if (errorCode != 808)//登录验证时，收到错误码，不取消转菊花
        {
            Common.HideLoading();
        }

        NetLog.GetInstance().PostLog("OnRequestErrorCode : "  + errorEnum.ToString());

        Debug.LogError("OnRequestErrorCode : " + errorEnum);
        if (errorEnum == ServerErrorCode.ERROR_LOGIN_NOUSER)
        {
            GameObject obj = UIManager.Instance.currentUI;
            UIStart uiStart = obj.GetComponent<UIStart>();
            if (uiStart)
            {
                uiStart.OnRequestPlayerLoginError_NoUser(errorCode, param);
            }
        }
        else if (errorEnum == ServerErrorCode.ERROR_LOGIN_NAME_EXISTS)
        {
            GameObject obj = UIManager.Instance.currentUI;
            UIStart uiStart = obj.GetComponent<UIStart>();
            if (uiStart)
            {
                uiStart.OnRequestPlayerLoginError_NameExists(errorCode, param);
            }
        }
        else if (errorEnum == ServerErrorCode.ERROR_SYSTEM_UNKNOWN)
        {
            if (ARoom.GetState() == ARoom.State.inroom)
            {
                if (ARoom.IsPVPCommonMode())
                {
                    if (!ARoom.IsPVPPractice())
                    {
                        if (PVPMatchRoom.UIHandle.pvpInMatch)
                        {
                            PVPMatchRoom.uiHandle.OnCancleMatchUI();
                            ARoom.DestroyRoom();
                        }
                    }
                    UIMessageBox.Show(107);
                }
                else if (ARoom.GetRoomMode() == RoomType.RoomType_PVE)
                {
                    UIMessageBox.Show(107);
                    SystemLoader.LoadPrevScenerio();
                    ARoom.SetState(ARoom.State.none);
                }

            }
        }
        else if (errorEnum == ServerErrorCode.ERROR_LOGIN_DIRTYWORD_EXISTS)
        {
            GameObject obj = UIManager.Instance.currentUI;
            UIStart uiStart = obj.GetComponent<UIStart>();
            if (uiStart)
            {
                uiStart.OnRequestPlayerLoginError_DirtywordExists(errorCode, param);
            }
        }
        else if (errorEnum == ServerErrorCode.ERROR_LOGIN_PLAYER_ONLINE)
        {
            GameObject obj = UIManager.Instance.currentUI;
            UIStart uiStart = obj.GetComponent<UIStart>();

            if (uiStart)
            {
                uiStart.resetHandler();
            }

            string str = UIMessageBox.GetMsg(errorCode, null);
            UIMessageBox.Show(str, null);

            /*
            UILoading.Instance.SetCallBack(delegate(float value)
            {
                UIMessageBox.Show_By_Id(errorCode, () =>
                {
                    Util.Log("UILogin");
                    Common.ForceExit();
                });
            });
            UILoading.Instance.SetProgress(1f);
            */

        }
        else if (errorEnum == ServerErrorCode.ERROR_LOGIN_KICKOFF_PLAYER)
        {
            string str = UIMessageBox.GetMsg(errorCode, null);

            DataWrapper.Player.instance.netCloseInfo = str;

            UIMessageBox.Show(str, () =>
            {
                Common.ForceExit();
            },

            UIMessageBox.BUTTON_SHOW_STYLE.BUTTON_OK);

            if (SocketFactory.mainSocket != null)
            {
                SocketFactory.DeleteMainSocket();
            }
        }
        else if (errorEnum == ServerErrorCode.ERROR_LOGIN_NOUSER)
        {
            UIMessageBox.Show(errorCode);
        }
        else if (errorEnum == ServerErrorCode.ERROR_SYSTEM_PROTOVERSION_DIFFERENT)
        {
            GameObject obj = UIManager.Instance.currentUI;
            UIStart uiStart = obj.GetComponent<UIStart>();

            if (uiStart)
            {
                uiStart.resetHandler();
            }

            string str = UIMessageBox.GetMsg(errorCode, null);

            UIMessageBox.Show(str, () =>
            {
                Common.ForceExit();
            },

            UIMessageBox.BUTTON_SHOW_STYLE.BUTTON_OK);
        }
        else if (errorEnum == ServerErrorCode.ERROR_ASSISTANT)
        {
            if (UIBattle.instance != null)
                UIBattle.instance.ShowAssists();
        }
        else if (errorCode == 4444)
        {
            UIMessageBox.Show("网络断开(error : 4444)", () =>
            {
                Common.ForceExit();
            },

            UIMessageBox.BUTTON_SHOW_STYLE.BUTTON_OK);
        }
        else if (Table.Message.Contains((uint)errorCode))
        {
            if (errorCode == 803) //逃跑
            {
                string t = string.Format("{0:D2}:{1:D2}", param / 60, param % 60);
                UIMessageBox.ShowLittleWindow(string.Format(Table.Message.datas[(uint)errorCode].Tip, t));
                if (UIPVPMode.instance) SystemLoader.Instance.StartCoroutine(UIPVPMode.instance.AnimationWorldMapRevert());        
            }
            else if (errorCode == 808) //token
            {
                Debug.Log("[DownHandlePlayer] OnRequestErrorCode errorCode:" + errorCode);

                GameObject obj = UIManager.Instance.currentUI;
                UIStart uiStart = obj.GetComponent<UIStart>();

                if (uiStart)
                {
                    uiStart.reLoginHandler();
                }
            }
            else if (errorCode == 850)
            {
                System.DateTime time = Common.StampToDateTime(param.ToString()); 
                string t;
                t = time.ToString("yyyy/MM/dd hh:mm:ss");
                UIMessageBox.ShowLittleWindow(string.Format(Table.Message.datas[(uint)errorCode].Tip, "", t));
            }
            else if(errorCode == 851)
            {
                System.DateTime time = Common.StampToDateTime(param.ToString());        
                string t;
                t = time.ToString("yyyy/MM/dd hh:mm:ss");
                UIMessageBox.ShowLittleWindow(string.Format(Table.Message.datas[(uint)errorCode].Tip, t));
            }
           

            else
            {
                UIMessageBox.Show(errorCode);
                
            }
        }
    }

    public static void Register()
    {
        //AutoGenProto.delegate_ID_PLAYER_LOGIN_RSP = OnRequestPlayerLogin;
       // AutoGenProto.delegate_ID_PLAYER_LOGIN_FINISHED_RSP += OnFinished;

		ManualProtocol.delegate_ID_PLAYER_DETAIL_INFO_RSP += OnPlayerDetailInfo;
        AutoGenProto.delegate_ID_ERROR_RSP += OnRequestErrorCode;
        DispatcherProtoBuf.Instance.Register("CollegeUnopened", ReturnCollegeUnopened);
        DispatcherProtoBuf.Instance.Register("PlayerExtraInfo", ReturnPlayerExtraInfo);
    }
    public static void ReturnPlayerExtraInfo(byte[] data)
    {
          MemoryStream m = new MemoryStream(data);
          TankProtocol.PlayerExtraInfo rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.PlayerExtraInfo>(m);
        if(   DataWrapper.Player.instance.m_PlayerExtraInfo==null)
        {
            DataWrapper.Player.instance.m_PlayerExtraInfo = rsp.info;
        }
        else
        {
            for (int i = 0; i < rsp.info.Count;i++ )
            {
                bool _Contains=false;
                 
                for (int k = 0; k < DataWrapper.Player.instance.m_PlayerExtraInfo.Count;k++ )
                {
                    if( DataWrapper.Player.instance.m_PlayerExtraInfo[k].first==rsp.info[i].first)
                    {
                        DataWrapper.Player.instance.m_PlayerExtraInfo[k].second = rsp.info[i].second;
                        _Contains = true;
                    }
                }
                if (_Contains == false)
                {
                    DataWrapper.Player.instance.m_PlayerExtraInfo.Add(rsp.info[i]);
                }
            }

        }
        SuperBOBO.EventManager.Instance.FireEvent(GameEventType.PlayerExtraInfo, new object[] { });
        
    }
    public static void ReturnCollegeUnopened(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.CollegeUnopened rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.CollegeUnopened>(m);
        DataWrapper.Player.instance.interaction = rsp.interaction;
        DataWrapper.Player.instance.unopenSchool = rsp.id;
    }
    public static void OnFinished_Guide()
    {
        OnFinished_Game();
    }

    private static void OnFinished_Game()
    {
       

        NetLog.GetInstance().Init();
        NetLog.GetInstance().PostLog("Receive-Protocol-ID_PLAYER_LOGIN_FINISHED_RSP");
        
        LogDrive();
       
        //zj
        AutoGenProto.Send_SUB_ID_TASK_LIST(0);
        AutoGenProto.Send_SUB_ID_TASK_LIST(1);

        

        SysEnv.isGameRun = true;
        SysEnv.isCheckNetClose = true;
        UserFriendHandle.initRequest();
        UserRuneHandle.Send_Page_List();

        SystemLoader.OnLogin(); 
    }
    static void LogDrive()
    {
        NetLog.GetInstance().PostLog(string.Format("serverName:{0}", SysEnv.selectServerData.name));
        NetLog.GetInstance().PostLog(string.Format("userName:{0}", DataWrapper.Player.instance.name));

        NetLog.GetInstance().PostLog("deviceName:" + SystemInfo.deviceModel);
        NetLog.GetInstance().PostLog("graphicsMemorySize:" + SystemInfo.graphicsMemorySize);
        NetLog.GetInstance().PostLog("operatingSystem:" + SystemInfo.operatingSystem);
        NetLog.GetInstance().PostLog("processorType:" + SystemInfo.processorType);
        NetLog.GetInstance().PostLog("processorCount:" + SystemInfo.processorCount);
        NetLog.GetInstance().PostLog("systemMemorySize:" + SystemInfo.systemMemorySize);
        
        NetLog.GetInstance().PostLog("Protocolnumber:" + (int)ProtoVersion.ProtoVersion_ID);
        NetLog.GetInstance().PostLog("GameVersion:" + Application.version);
    }

    public static void OnFinished(int errorCode)
    {
        #if UNITY_EDITOR || UNITY_STANDALONE_WIN

        #elif UNITY_ANDROID
            #if SDK_Quick
                 AndroidSDKManager.updateRoleInfo(false);
            #endif
        #elif UNITY_IOS
            #if SDK_Quick
                IOSSDKManager.updateRoleInfo(false);
            #endif
        #endif

        SendLoadingFinishedNeedMSG();
        Common.HideLoading();
   

        if (GuideManager.instance.NoGuide)
        {
            UIStart.instance.canSelectGuide = false;
            AutoGenProto.Send_SUB_ID_TUTORIAL_IGNORE(true);
            OnFinished_Game();
        }
        else
        {
            //if (UIStart.instance.canSelectGuide)
            //{
            //    UIStart.instance.OpenGuideSelect();
            //}
            //else
            {
                OnFinished_Game();
            }
        }
    }
    //登入成功以后，向服务器请求一些一上线就需要知道的数据
    public static void  SendLoadingFinishedNeedMSG()
{
    DispatcherProtoBuf.Instance.SendProtoBuffer("DailySignInfoReq", new TankProtocol.DailySignInfoReq());//wuxingxing
    DispatcherProtoBuf.Instance.SendProtoBuffer("CoatingInfoReq", new TankProtocol.CoatingInfoReq());//wuxingxing
    DispatcherProtoBuf.Instance.SendProtoBuffer("TankDecorationInfoReq", new TankProtocol.TankDecorationInfoReq());//wuxingxing
    NetLog.GetInstance().PostLog("-------》登入成功，成功请求了一些初始数据消息");
}
	public static void OnPlayerDetailInfo(int errorCode, byte type, uint hp, RakNet.RakString name, uint exp, ushort level, byte gender, uint gold, ushort energy, uint diamond, byte rank, uint rankLevel, uint active, uint honor, uint buyGoldTimes, uint buyEnergyTimes, bool ignoreTutorial, uint avatarid, uint strategypoint, uint dexp, uint rexp, uint yexp, uint sexp, uint mexp, uint globalExp, uint country, uint touchneedtime, byte touchremaincount, uint recharge, uint corpsid, uint armorpoint, uint recharge6, uint recharge30, uint recharge68, uint recharge128, uint recharge328, uint recharge648,uint monthCard25, uint invite, List<uint> list)
    {
		DataWrapper.Player.instance.SetPlayerDetailInfo(type, hp, name, exp, level, gender, gold, energy, diamond, rank, rankLevel, honor, buyGoldTimes, buyEnergyTimes, avatarid, strategypoint, dexp, rexp, yexp, sexp, mexp, globalExp, country, touchneedtime, touchremaincount, recharge, corpsid, armorpoint, recharge6, recharge30, recharge68, recharge128, recharge328, recharge648, monthCard25, invite);
        DataWrapper.Player.instance.activePoint = active;
        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance);


        DataWrapper.PlayerVIP.CheckAndDoChange();
        TenLotteryRedPointManager.ToGetDataFromServerAtGameStart();

		Table.Head.InitSpecialHeadList (list);

        if (!GuideManager.instance.NoGuide)
            GuideManager.instance.NoGuide = ignoreTutorial;

       
    }
}