using UnityEngine;
using System.Collections;
using System.IO;
using SuperBOBO;

public class WorldMapInfoHandler : PBHandler
{

    public const string Req = "WorldMapInfoReq";
    public const string Rsp = "WorldMapInfoRsp";

    public static void Send()
    {

        DispatcherProtoBuf.Instance.SendProtoBuffer(Req, null);
    }


    public string GetRspName()
    {
        return Rsp;
    }

    public void OnRecv(byte[] datas)
    {
        MemoryStream m = new MemoryStream(datas);
        TankProtocol.WorldMapInfoRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.WorldMapInfoRsp>(m);

        if (rsp == null)
            return;

        if (DataWrapper.Player.instance != null)
        {
            DataWrapper.Player.instance.worldMapInfo.m_kill = rsp.m_kill;
            DataWrapper.Player.instance.worldMapInfo.s_kill = rsp.s_kill;
            DataWrapper.Player.instance.worldMapInfo.d_kill = rsp.d_kill;
            DataWrapper.Player.instance.worldMapInfo.playerInfos.Clear();
            DataWrapper.Player.instance.worldMapInfo.corpsInfos.Clear();
            foreach (var k in rsp.best_commander)
            {
                DataWrapper.Player.instance.worldMapInfo.playerInfos.Add(new DataWrapper.BestKillInfo(k.name, k.kill));
            }
            foreach (var k in rsp.best_corps)
            {
                DataWrapper.Player.instance.worldMapInfo.corpsInfos.Add(new DataWrapper.BestKillInfo(k.name, k.kill));
            }


            DataWrapper.Player.instance.worldMapInfo.mine_kill = rsp.mine_kill;
            DataWrapper.Player.instance.worldMapInfo.corps_kill = rsp.corps_kill;


            SuperBOBO.EventManager.Instance.FireEvent(GameEventType.WorldMapInfo);
        }
    }

    public void OnUnRegister()
    {

    }
}


