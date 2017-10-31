using UnityEngine;
using System.Collections;
using DataWrapper;

public class UserGuideHandle : SuperBOBO.NetInterface
{
    void Delegate_SUB_ID_TUTORIAL_RSP(int errorCode, uint id, bool finish)
    {
        Util.Log("----------------Delegate_SUB_ID_TUTORIAL_RSP--------------------");
        GuideInfoForServer guide = new GuideInfoForServer();
        guide.guideId = id;
        guide.isFinish = finish;
        PlayerGuide.instance.AddGuide(guide);
        //GuideManager.instance.CheckGuideToTrigger(1, Player.instance.level);//检测是否一级引导
    }
    public void OnRegister()
    {
        AutoGenProto.delegate_SUB_ID_TUTORIAL_RSP += Delegate_SUB_ID_TUTORIAL_RSP;
    }



    public void OnUnRegister()
    {
        AutoGenProto.delegate_SUB_ID_TUTORIAL_RSP -= Delegate_SUB_ID_TUTORIAL_RSP;
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }
}
