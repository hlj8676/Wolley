using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using Core;

public class UpProtoBuf  {


    public static void SendPlayerUseSkill(int skillID, List<SkillResultInfo> results)
    {
        TankProtocol.PlayerSkill ps = new TankProtocol.PlayerSkill();
        ps.skillID = (uint)skillID;

        foreach (SkillResultInfo res in results)
        {
            TankProtocol.PlayerHurtInfo hurt = new TankProtocol.PlayerHurtInfo();

            //hurt.hurt = (uint)res.va;
            hurt.target = (uint)res.target.GetID();
            ps.hurtInfos.Add(hurt);
        }
        DispatcherProtoBuf.Instance.SendProtoBuffer("PlayerSkill", ps);
    }

    //public static void SendLoginReq(TankProtocol. data)
    //{
    //    //TankProtocol.LoginReq data = new TankProtocol.LoginReq();
    //    //data.ch_uid = 1;
    //    //data.channel = 1;
    //    //data.version = 1;
    //    DispatcherProtoBuf.Instance.SendProtoBuffer("LoginReq", data);
    //}

    ////test
    //public static void SendHello(TankProtocol.Hello data)
    //{
    //    //TankProtocol.Hello data = new TankProtocol.Hello();
    //    //data.name = "Hello";
    //    DispatcherProtoBuf.Instance.SendProtoBuffer("Hello", data);
    //}
}
