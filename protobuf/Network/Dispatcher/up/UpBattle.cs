using UnityEngine;
using System.Collections;
using RakNet;
using System.Collections.Generic;

public static class UpBattle
{

    public static void SendPlayerAttackResult(uint userID, byte bulletID, List<PlayerAttackInfo>attackInfos )
    {
        AutoGenProto.Send_ID_PLAYER_ATTACK(userID, ARoom.GetInstanceID(), (uint)Common.GetClientTimetamp(), bulletID, attackInfos.ToArray());
  
        //AutoGenProto.Send_ID_PLAYER_ATTACK(userID, SysEnv.instanceID, info.target.userID, info.isMiss,  info.hitPaota, (byte)info.hitArea, (int)info.hitPoint.x, (int)info.hitPoint.y, (int)info.hitPoint.z, Common.GetClientTimetamp());
    }

    public static void SendPlayerChangeDir(float localY, int dir, int steerDir,  float dura)
    {
        //AutoGenProto.Send_ID_PLAYER_CHANGE_DIR(SysEnv.instanceID, (int)(100*localY), (short) dir, (byte)steerDir,  (byte)(100*dura), Common.GetClientTimetamp());
    }

    public static void SendClientTimestamp()
    {
        //if (NewerCheckPointGuide.IsNewerBattle())
        //{
        //    AutoGenProto.Send_ID_PLAYER_TIMESTAMP((int)RakNet.RakNet.GetTimeMS(), false);
        //}
       // Util.LogWarning("SendClientTimestamp " + (int)RakNet.RakNet.GetTimeMS());
        //else
            AutoGenProto.Send_ID_PLAYER_TIMESTAMP((uint)RakNet.RakNet.GetTimeMS(), BattleAgainEnterRecon.Instance.isExitsBattle);
    }


    public static void SendPlayerStart(Vector3 pos, int localY, int dir, float dura)
    {
        //AutoGenProto.Send_ID_PLAYER_START(SysEnv.instanceID, (int)(100f * pos.x), (int)(100f * pos.z), (short)(localY), (short)dir, (byte)(100f * dura), Common.GetClientTimetamp());
    }

    public static void SendPlayerStop(Vector3 pos, uint rot, float dura)
    {
        //AutoGenProto.Send_ID_PLAYER_STOP(ARoom.GetInstanceID(), (int)(100f * pos.x), (int)(100f * pos.z), rot, (byte)(100f * dura), Common.GetClientTimetamp());
    }

    public static void SendPlayerPos(Vector3 pos, int dir, int speed)
    {
        //AutoGenProto.Send_ID_PLAYER_POS(SysEnv.instanceID, (int)(100f * pos.x), (int)(100f * pos.z), (short)dir, (byte)speed, Common.GetClientTimetamp());
    }


    public static void SendPlayerChangeSpeed(Vector3 pos, int gear, float dura)
    {
        //AutoGenProto.Send_ID_PLAYER_CHANGE_SPEED(SysEnv.instanceID, (int)(100f * pos.x), (int)(100f * pos.z), (byte)gear, (byte)(100f * dura), Common.GetClientTimetamp());
    }

    
    public static void SendExitBattle()
    {
        AutoGenProto.Send_ID_PLAYER_EXIT_INSTANCE(ARoom.GetInstanceID());
    }

    public static void SendPlayerHurt(uint userIDBeDamage, ushort damage)
    {
        //AutoGenProto.Send_ID_PLAYER_HURT(ARoom.GetInstanceID(), userIDBeDamage, damage, Common.GetClientTimetamp());
    }

    public static void SendPlayerDead()
    {
        RakNet.BitStream bs = new RakNet.BitStream();
        int instanceID = 0;
        bs.WriteCompressed(ARoom.GetInstanceID());
        bs.WriteCompressed(Common.GetClientTimetamp());
        TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_DEAD, bs));
    }

    public static void SendPlayerRevive()
    {
        RakNet.BitStream bs = new RakNet.BitStream();
        int instanceID = 0;
        bs.WriteCompressed(ARoom.GetInstanceID());
        bs.WriteCompressed(Common.GetClientTimetamp());
        //bs.WriteCompressed(roomID);
        TankSendMsg.AddPkg(Common.CraetePkg(MessageID.ID_PLAYER_REVIVE, bs));
    }
}