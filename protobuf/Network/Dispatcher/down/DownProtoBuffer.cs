using UnityEngine;
using System.Collections;
using System.IO;

public class DownProtoBuffer
{
    public static void OnReciveErrorCode(ProtoBuf.IExtensible data)
    {

    }

    public static void OnReciveLoginRsp(ProtoBuf.IExtensible data)
    {
        //using (MemoryStream m = new MemoryStream(data))
        {
            TankProtocol.PlayerLoginRsp d = (TankProtocol.PlayerLoginRsp)data;
       
        }
    }

    public static void OnReciveHello(ProtoBuf.IExtensible data)
    {
        Util.Log("OnReciveHello");
        //using (MemoryStream m = new MemoryStream(data))
        {
            TankProtocol.Hello d = (TankProtocol.Hello)data;
            Util.Log("hello : " + d.name + d.vector2);
        }
    }

  
    public static void OnRecvPlayerLoginRsp(byte[] data)
    {
         MemoryStream m = new MemoryStream(data);

        
         TankProtocol.PlayerLoginRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.PlayerLoginRsp>(m);
        //basic info
        DataWrapper.Player.instance.SetBasicInfo(rsp.info);
        DataWrapper.Player.instance.SetCurrentTank(rsp.tank);
    }

    public static void OnRecvPlayerSkillRsp(byte[] data)
    {
        
    }
}
