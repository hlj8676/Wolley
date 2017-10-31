using UnityEngine;
using System.Collections;

public class ProtoPPVEHandle :  SuperBOBO.NetInterface{

    public void OnRegister()
    {
        throw new System.NotImplementedException();
    }

    public void OnUnRegister()
    {
        throw new System.NotImplementedException();
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }
}
