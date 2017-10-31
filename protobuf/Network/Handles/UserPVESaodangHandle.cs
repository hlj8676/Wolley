using UnityEngine;
using System.Collections;
using System.IO;

public class UserPVESaodangHandle : SuperBOBO.NetInterface
{
    public void OnRegister()
    {
        DispatcherProtoBuf.Instance.Register("PveRushRsp", ReturnPveRushRsp);
        DispatcherProtoBuf.Instance.Register("PveResetRsp", ReturnPveResetRsp);
        
    }

    public void OnUnRegister()
    {
        DispatcherProtoBuf.Instance.UnRegister("PveRushRsp");
        DispatcherProtoBuf.Instance.UnRegister("PveResetRsp");
    
    }
    public void OnDataUpdate()
    {

    }
    public static void ReturnPveResetRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.PveResetRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.PveResetRsp>(m);
       
        if (DataWrapper.Player.instance.EveryDayPveReset.ContainsKey((uint)rsp.id))
        {
            DataWrapper.Player.instance.EveryDayPveReset[rsp.id] = rsp.count;
        }
        else
        {
            DataWrapper.Player.instance.EveryDayPveReset.Add(rsp.id, rsp.count);
        }

         if (DataWrapper.Player.instance.EveryDayPveCount.ContainsKey((uint)rsp.id))
         {
             DataWrapper.Player.instance.EveryDayPveCount[rsp.id] =0;
         }
         else
         {
             DataWrapper.Player.instance.EveryDayPveCount.Add(rsp.id, 0);
         }
         SuperBOBO.EventManager.Instance.FireEvent(GameEventType.PveResetRsp, new object[] { });
         UIMessageBox.Show(2008);
    }
    public static void ReturnPveRushRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.PveRushRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.PveRushRsp>(m);
        SuperBOBO.EventManager.Instance.FireEvent(GameEventType.PveRushRsp, new object[] { rsp.reward,rsp.rate});
    }
 
}
