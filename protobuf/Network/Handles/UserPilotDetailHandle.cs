using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserPilotDetailHandle:SuperBOBO.NetInterface
{

    public  void Init()
    {      
        
    }


    public void Delegate_SUB_ID_PILOT_DETAIL_INFO_RSP(int errorCode, byte type, PilotDetailInfo[] list)
    {
        DataWrapper.Player.instance.FindPilot(list[0].pilotId).SetDetailInfo(list[0]);
        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance.FindPilot(list[0].pilotId));
    }

    public void OnRegister()
    {
        AutoGenProto.delegate_SUB_ID_PILOT_DETAIL_INFO_RSP += Delegate_SUB_ID_PILOT_DETAIL_INFO_RSP;
    }

    public void OnUnRegister()
    {
        AutoGenProto.delegate_SUB_ID_PILOT_DETAIL_INFO_RSP -= Delegate_SUB_ID_PILOT_DETAIL_INFO_RSP;
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }
}
