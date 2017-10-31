using UnityEngine;
using System.Collections;

public class UserSystemOpenHandle : SuperBOBO.NetInterface
{
    public void OnRegister()
    {
        AutoGenProto.delegate_SUB_ID_OPEN_FUNCTION_RSP += OpenManager.instance.AddOpenList;
    }

    public void OnUnRegister()
    {
        AutoGenProto.delegate_SUB_ID_OPEN_FUNCTION_RSP -= OpenManager.instance.AddOpenList;
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }
}
