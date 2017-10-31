using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DataWrapper;
using System.IO;
public class UserActiveHandle:SuperBOBO.NetInterface
{

    public List<uint> actives = new List<uint>();



    private void Delegate_SUB_ID_ACTIVE_REWARD_RSP(int errorCode, uint activeValue)
    {
        Util.Log("activeValue " + activeValue);
        Player.instance.activeGiftGotten.Add(activeValue);
        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance);
    }

    private void Delegate_SUB_ID_ACTIVE_GOTTEN_RSP(int errorCode, uint value)
    {
        
        Util.Log("gift gotten " +value + " " + actives.Count);
        foreach (var k in actives)
        {
            if (k == value)
                return;
        }
        actives.Add(value);
    }

    private void Delegate_SUB_ID_ACTIVE_GOTTEN_RSP_completed()
    {
        Player.instance.activeGiftGotten.Clear();
        foreach (var k in actives)
        { 
             Player.instance.activeGiftGotten.Add(k);
        }
        actives.Clear();

        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance);

    }

    public void OnRegister()
    {
        AutoGenProto.delegate_SUB_ID_ACTIVE_REWARD_RSP += Delegate_SUB_ID_ACTIVE_REWARD_RSP;
        AutoGenProto.delegate_SUB_ID_ACTIVE_GOTTEN_RSP += Delegate_SUB_ID_ACTIVE_GOTTEN_RSP;
        AutoGenProto.delegate_SUB_ID_ACTIVE_GOTTEN_RSP_completed += Delegate_SUB_ID_ACTIVE_GOTTEN_RSP_completed;
       // AutoGenProto.delegate_ID_ITEM_LIST_RSP += Delegate_ID_ITEM_LIST_RSP;
      //  AutoGenProto.delegate_DailySignInfoRsp += Delegate_SUB_ID_ACTIVE_GOTTEN_RSP;

    }

    public void OnUnRegister()
    {
        AutoGenProto.delegate_SUB_ID_ACTIVE_REWARD_RSP -= Delegate_SUB_ID_ACTIVE_REWARD_RSP;
        AutoGenProto.delegate_SUB_ID_ACTIVE_GOTTEN_RSP -= Delegate_SUB_ID_ACTIVE_GOTTEN_RSP;
        AutoGenProto.delegate_SUB_ID_ACTIVE_GOTTEN_RSP_completed -= Delegate_SUB_ID_ACTIVE_GOTTEN_RSP_completed;
        //AutoGenProto.delegate_ID_ITEM_LIST_RSP -= Delegate_ID_ITEM_LIST_RSP;
    }
    public static void ReturnDailySignInfoRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.DailySignInfoRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.DailySignInfoRsp>(m);
    }
    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }

    //private void Delegate_ID_ITEM_LIST_RSP(byte updateType, ItemInfo[] list)
    //{
    //    if (updateType == 1)
    //        UITip.ShowItemGet(DataWrapper.PlayerBag.ChangeType(list));
    //}
}
