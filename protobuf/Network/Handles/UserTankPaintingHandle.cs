using UnityEngine;
using System.Collections;
using System.IO;

public class UserTankPaintingHandle : SuperBOBO.NetInterface
{
    public void OnRegister()
    {
        DispatcherProtoBuf.Instance.Register("CoatingInfoRsp", ReturnCoatingInfoRsp);
        DispatcherProtoBuf.Instance.Register("CoatingBuyRsp", ReturnCoatingBuyRsp);
        DispatcherProtoBuf.Instance.Register("CoatingEquipOptionRsp", ReturnCoatingEquipOptionRsp);

        DispatcherProtoBuf.Instance.Register("TankDecorationInfoRsp", ReturnTankDecorationInfoRsp);
        DispatcherProtoBuf.Instance.Register("TankDecorationBuyRsp", ReturnTankDecorationBuyRsp);
        DispatcherProtoBuf.Instance.Register("TankDecorationEquipRsp", ReturnTankDecorationEquipRsp);
        
    }

    public void OnUnRegister()
    {
        DispatcherProtoBuf.Instance.UnRegister("CoatingInfoRsp");
        DispatcherProtoBuf.Instance.UnRegister("CoatingBuyRsp");
        DispatcherProtoBuf.Instance.UnRegister("CoatingEquipOptionRsp");

        DispatcherProtoBuf.Instance.UnRegister("TankDecorationInfoRsp");
        DispatcherProtoBuf.Instance.UnRegister("TankDecorationBuyRsp");
        DispatcherProtoBuf.Instance.UnRegister("TankDecorationEquipRsp");
    }
    public void ReturnCoatingEquipOptionRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.CoatingEquipOptionRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.CoatingEquipOptionRsp>(m);
        DataWrapper.Player.instance.UpdateCoatingEquip(rsp.tankId, rsp.info, rsp.type);
        SuperBOBO.EventManager.Instance.FireEvent(GameEventType.CoatingEquipOptionRsp, new object[] {});
    }
    public void ReturnCoatingBuyRsp(byte[] data)
    {
      //  Debug.LogError("_______>g购买已经返回");
        MemoryStream m = new MemoryStream(data);
        TankProtocol.CoatingBuyRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.CoatingBuyRsp>(m);
        if(rsp.state==3)
        {
          
            return;
        }
        else if (rsp.state == 2)
        {
           // Debug.LogError("_______>抽了已经拥有的涂装 换了钱=" + rsp.tankId.ToString());
            SuperBOBO.EventManager.Instance.FireEvent(GameEventType.CoatingBuyRsp, new object[] { rsp.state,rsp.info, rsp.tankId });
        }
        else
        {
          //  Debug.LogError("_______>抽奖成功");
            DataWrapper.Player.instance.AddCoatingData(rsp.tankId, rsp.info);
            SuperBOBO.EventManager.Instance.FireEvent(GameEventType.CoatingBuyRsp, new object[] { rsp.state, rsp.info });
            
        }
    }
    public static void ReturnCoatingInfoRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.CoatingInfoRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.CoatingInfoRsp>(m);
        DataWrapper.Player.instance.InitCoatingInfoList(rsp.dataList);

        SuperBOBO.EventManager.Instance.FireEvent(GameEventType.CoatingInfoRsp, new object[] { });
    }
    public static void ReturnTankDecorationInfoRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.TankDecorationInfoRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.TankDecorationInfoRsp>(m);
        DataWrapper.Player.instance.InitDecorationInfoList(rsp.info);
      
        SuperBOBO.EventManager.Instance.FireEvent(GameEventType.TankDecorationInfoRsp, new object[] { });
    }
    public static void ReturnTankDecorationBuyRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.TankDecorationBuyRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.TankDecorationBuyRsp>(m);
         DataWrapper.Player.instance.UpdateDecorationInfo(rsp.data);

         SuperBOBO.EventManager.Instance.FireEvent(GameEventType.TankDecorationBuyRsp, new object[] { });
    }
    public static void ReturnTankDecorationEquipRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.TankDecorationEquipRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.TankDecorationEquipRsp>(m);
        DataWrapper.Player.instance.UpdateDecorationInfo(rsp.data);

        SuperBOBO.EventManager.Instance.FireEvent(GameEventType.TankDecorationEquipRsp, new object[] { });
    }
    
    public void OnDataUpdate()
    {
      
    }

}
