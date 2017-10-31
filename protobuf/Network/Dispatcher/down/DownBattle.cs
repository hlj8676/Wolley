/*
 * 请勿修改！！！
 * 
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using RakNet;



public static class DownBattle
{
    public static void OnReciveEnterRoom(RakNet.BitStream bs)
    {
       
    }

    public static void OnReciveExitRoom(RakNet.BitStream bs)
    {
      
    }

    public static void OnRecivePlayerPos(RakNet.BitStream bs)
    {
      
    }


    public static void OnRecivePlayerSpeedChange(RakNet.BitStream bs)
    {
       
    }


    public static void OnReciveFire(RakNet.BitStream bs)
    {
        
    }


    public static void OnRecivePlayerChangeDir(RakNet.BitStream bs)
    {
       
    }

    public static void OnRecivePlayerHurt(RakNet.BitStream bs)
    {
        
    }

    public static void OnRecivePlayerDead(RakNet.BitStream bs)
    {
        
    }

    public static void OnReciveServerTimestamp(RakNet.BitStream bs)
    {
        //Util.Log("OnReciveServerTimestamp");
        //int timeStamp = 0;
        //bs.ReadCompressed(out timeStamp);
        //SysEnv.SetServerTimestampOffset(timeStamp);
    }

    public static void OnRecivePlayerRevive(RakNet.BitStream bs)
    {
        
    }

    //    message ID_PLAYER_STOP_RSP
    //{
    //    compress uint32	instanceID;		//instanceID
    //    compress int32	x;			//player's position
    //    compress int32	z;
    //    compress uint8  dura;			//256 / 100
    //    compress uint32	timestamp;		//timestamp	
    //}

    public static void OnRecivePlayerStop(RakNet.BitStream bs)
    {
        
    }

    public static void OnRecivePlayerStart(RakNet.BitStream bs)
    {
        while (bs.GetNumberOfUnreadBits() > 0)
        {

           
        }
    }

    public static void OnReciveMultiCommand(RakNet.BitStream bs)
    {
        //Util.LogWarning("OnReciveMultiCommand");
        //TankSendMsg.AddRecvPkg((int)(bs.GetNumberOfUnreadBits() / 8));
        while (bs.GetNumberOfUnreadBits() > 8)
        {
            short length = 0;
            bs.Read(out length);
            byte msgID = 0;
            bs.Read(out msgID);

            RakNet.BitStream stream = new RakNet.BitStream();
            bs.Read(stream, (uint)(length - 8));
            Dispatcher.Instance.Dispatch(msgID, stream,"");
        }
    }
}
