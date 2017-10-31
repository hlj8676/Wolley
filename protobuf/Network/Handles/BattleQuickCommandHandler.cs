using UnityEngine;
using System.Collections;
using System.IO;

public class BattleQuickCommandHandler 
{

    public static void Send(uint _senderId, uint _cmd)
    {
        TankProtocol.BattleQuickChat qc = new TankProtocol.BattleQuickChat();
        qc.cmd = _cmd;
        qc.playerId = _senderId;

        DispatcherProtoBuf.Instance.SendProtoBuffer("BattleQuickChat", qc, true);
    }

    public static void Receive(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.BattleQuickChat rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.BattleQuickChat>(m);

        if (rsp == null)
            return;

        if (UIQuickCommand.instance)
            UIQuickCommand.instance.OnPlay(rsp.playerId, rsp.cmd);

    }

}
