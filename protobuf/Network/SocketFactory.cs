using UnityEngine;
using System.Collections;

public class SocketFactory
{
    public static SocketManager mainSocket;
    public static SocketManager battleSocket;

    public static string MAIN_SOCKET_NAME = "main socket";
    public static string BATTLE_SOCKET_NAME = "battle socket";



    public static void CreateMainSocket(string address,int  port)
    {
        GameObject go = SystemLoader.Instance.gameObject;
        mainSocket = go.AddComponent<SocketManager>();
        mainSocket.address = address;
        mainSocket.port = port;
        mainSocket.socketName = MAIN_SOCKET_NAME;       
     
    }

    public static void DeleteMainSocket()
    {
      if (mainSocket != null)
        {
            Util.LogWarning("close main socket!!!");
            AutoGenProto.Send_ID_PLAYER_LOGINOUT();      

            mainSocket.onDestroyConnect();
            GameObject.Destroy(mainSocket);
        }

        mainSocket = null;
    }

    public static void CreateBattleSocket(string address, int port)
    {
        Util.LogWarning("create battle socket " + address + ":" + port);

        GameObject go = new GameObject("socketBattle");
        MonoBehaviour.DontDestroyOnLoad(go);
        battleSocket = go.AddComponent<SocketManager>();
        battleSocket.address = address;
        battleSocket.port = port;
        battleSocket.socketName = BATTLE_SOCKET_NAME;
      
 
    }

    public static void DeleteBattleSocket()
    {
        if (battleSocket != null)
        {
            Util.LogWarning("close battle socket!!!");

            //battleSocket.onDestroyConnect();

            GameObject.Destroy(battleSocket.gameObject);
        }

        battleSocket = null;
    }

    /// <summary>
    /// 重连处理
    /// </summary>
    /// <param name="tempSocket"></param>
    public static void reconnectSocket(SocketManager tempSocket)
    {
        if (tempSocket != null)
        {
            Util.LogWarning("reconnectSocket 1");
            string address = tempSocket.address;
            int port = tempSocket.port;
            GameObject.Destroy(tempSocket);

            if (tempSocket.socketName == MAIN_SOCKET_NAME)
            {
                Util.LogWarning("reconnectSocket 2");
                SocketFactory.CreateMainSocket(address, port);
                SocketFactory.mainSocket.overrided = true;
            }
            else
            {
                SocketFactory.CreateBattleSocket(address, port);
            }

            Common.ShowLoading(50);
        }
    }
}
