using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataWrapper;
public class UserMailHandle:SuperBOBO.NetInterface 
{

    public void Delegate_ID_MAIL_NEW_COMING_RSP(int errorCode)
    {
        if(UIMail.instance)
            DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance.playerMail);
        Player.instance.playerMail.isNewComming = true;
        SuperBOBO.RedPointManager.Instance.ActiveTag("main");      
    }
    public void OnRegister()
    {
        AutoGenProto.delegate_ID_MAIL_NEW_COMING_RSP += Delegate_ID_MAIL_NEW_COMING_RSP;
        SuperBOBO.EventManager.Instance.Reg(GameEventType.MAIL_LIST, (et, p) =>
        {
            SuperBOBO.RedPointManager.Instance.ActiveTag("main");    
        });
        SuperBOBO.EventManager.Instance.Reg(GameEventType.MAIL_GET, (et, p) =>
        {
            SuperBOBO.RedPointManager.Instance.ActiveTag("main");
        });
    }

    public void OnUnRegister()
    {
        AutoGenProto.delegate_ID_MAIL_NEW_COMING_RSP -= Delegate_ID_MAIL_NEW_COMING_RSP;
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }
}
