using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;
using RakNet;
using System.IO;
using System.Threading;


public class SocketManager : MonoBehaviour
{
    public delegate void OnReConnected();//重连后回调
    public OnReConnected onReConnected;

    public delegate void OnPingCallBack(NETWORK_PING index);//PING 值回调
    public OnPingCallBack onPingCallBack;

    private RakPeerInterface m_clientSocket;
    Packet m_receivePacket;
    RakNet.AddressOrGUID m_serverGUID;

    public uint maxClient = 10;
    public string address;
    public int port;
    public Dictionary<int, float> tester = new Dictionary<int, float>();
    public string socketName;
    public byte messageId; //当前连接状态
    public TankSendMsg sendMsg;
    public int m_serverPing = 0;
    public bool overrided = false; //ios 上断线重连复制出的新socket

    public enum NETWORK_PING
    {
        NICE = 1,
        COMMONLY,
        BAD,
    }

    void Awake()
    {
        sendMsg = gameObject.AddComponent<TankSendMsg>();
        sendMsg.socket = this;
    }

    //判断网络是否连接中
    public bool isConnect()
    {
        bool connect = false;

        if (messageId == (byte)DefaultMessageIDTypes.ID_CONNECTION_REQUEST_ACCEPTED || messageId == (byte)DefaultMessageIDTypes.ID_ALREADY_CONNECTED)
        {
            connect = true;
        }

        return connect;
    }

    public int getServerPingValue()
    {
        return m_serverPing;
    }

    public NETWORK_PING getServerPingIndex()
    {
        NETWORK_PING index = NETWORK_PING.NICE;

        if (pingArray != null && pingArray.Length == 4)
        {
            if (m_serverPing > int.Parse(pingArray[1]) && m_serverPing < int.Parse(pingArray[2]))
            {
                index = NETWORK_PING.COMMONLY;
            }
            else if (m_serverPing > int.Parse(pingArray[2]) && m_serverPing < int.Parse(pingArray[3]))
            {
                index = NETWORK_PING.BAD;
            }
            else if (m_serverPing > int.Parse(pingArray[3]))
            {
                index = NETWORK_PING.BAD;
            }
        }

        return index;
    }

    public RakPeerInterface GetClientSocket()
    {
        return m_clientSocket;
    }

    public void AddTestData(MessageID i)
    {
        int id = (int)i;
        float t = Common.GetRaknetTime();
        if (tester.ContainsKey(id))
        {
            tester[id] = t;
        }
        else
        {
            tester.Add(id, t);
        }
    }

    public void CaculateData(int i)
    {
        int id = i;
        id--;
        if (tester.ContainsKey(id))
        {
            //Util.LogError(string.Format("数据包 {0} 来回时间:   {1} ", (MessageID)id, (Time.time - tester[id]).ToString()));
            if ((MessageID)id == MessageID.ID_PLAYER_TIMESTAMP)
            {
                float f = Common.GetRaknetTime() - tester[id];
                //Util.LogError(string.Format("数据包 {0} 来回时间:   {1} ", (MessageID)id, f));
            }

            tester.Remove(id);
        }
    }

    //void RecvThread()
    //{
    //    while (true)
    //    {
    //        m_receivePacket = m_clientSocket.Receive();
    //        while (m_receivePacket != null)
    //        {
    //            if (m_receivePacket != null)
    //            {
    //                onNetPacket(ref m_receivePacket);
    //            }
    //            m_clientSocket.DeallocatePacket(m_receivePacket);
    //            m_receivePacket = m_clientSocket.Receive();
    //        }

    //    }
    //}

    IEnumerator CheckTimeStamp()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            //UpBattle.SendClientTimestamp();
        }
    }

    public void UpdateTimeStamp()
    {
        StartCoroutine(CheckTimeStamp());
    }

    //  #define AF_INET     2
    //  #define AF_INET6    10
    //  AF_UNSPEC 0

    // Use this for initialization
    void Start()
    {
        initReconnectData();
        NewConnection();
    }

    void NewConnection()
    {
        Util.Log("开启RakNet: " + SysEnv.gateAddress + " port:" + port);

        bool bIsIPV6 = false;
        address = Common.GetIPHost(address, "" + port, out bIsIPV6);

        m_serverGUID = new AddressOrGUID(new SystemAddress(address, (ushort)port));
        m_clientSocket = RakPeerInterface.GetInstance();

        SocketDescriptor des = new SocketDescriptor();
        Debug.LogError("Start::address===" + address + "  bIsIPV6==" + bIsIPV6);
        #if UNITY_IOS && !UNITY_EDITOR
        des.socketFamily = 0;
        #else
        des.socketFamily = 2;
        #endif
        m_clientSocket.SetOccasionalPing(true);
        m_clientSocket.AllowConnectionResponseIPMigration(true);
        m_clientSocket.Startup(maxClient, des, 1);
        m_clientSocket.SetTimeoutTime(1000 * 10, m_serverGUID.systemAddress);
        String strM = "";
        RakNet.PublicKey noKey = new RakNet.PublicKey();
		ConnectionAttemptResult result;
        if (bIsIPV6)
        {
            SysEnv.fTokenActivityTime = 20f;
            result = m_clientSocket.Connect(address, (ushort)port, strM, strM.Length, noKey);
        }
        else
        {
            SysEnv.fTokenActivityTime = 20f;
            result = m_clientSocket.Connect(address, (ushort)port, strM, strM.Length, noKey, 0, 24, 2000);
        }
            

        if (result != ConnectionAttemptResult.CONNECTION_ATTEMPT_STARTED)
        {
            //isReconnectHandler(result);
            #if UNITY_IOS
            iosReConnectHandler();
            #endif

            Util.LogWarning("启动RakNet失败，错误码: " + result);
        }
    }
        
    public void Send(RakNet.BitStream bitStream, bool highPriority = false)
    {
        try
        {
            if (!highPriority)
            {
                m_clientSocket.Send(bitStream, PacketPriority.HIGH_PRIORITY, RakNet.PacketReliability.RELIABLE,
                    (char)0, m_serverGUID, false);
            }
            else
            {
                m_clientSocket.Send(bitStream, PacketPriority.HIGH_PRIORITY, RakNet.PacketReliability.RELIABLE,
                    (char)0, m_serverGUID, false);

                /*
                m_clientSocket.Send(bitStream, PacketPriority.IMMEDIATE_PRIORITY, RakNet.PacketReliability.UNRELIABLE,
                          (char)0, m_serverGUID, false);
                */
            }
        }
        catch (System.Exception e)
        {
            Util.LogError("Send socket exception = " + e.ToString());
        }
    }




    public void onNetPacket(ref Packet msgPacket)
    {
        RakNet.BitStream bs = new RakNet.BitStream();
        bs.Write(msgPacket.data, msgPacket.length);

        Dispatcher.Instance.Dispatch(bs, socketName);
    }

    void OnDestroy()
    {
        if (sendMsg != null)
            Destroy(sendMsg);
        EndConnection();
    }

    //----------------------- shilongquan.alvin begin -------------------

    public bool isReconnect = false; //是否正在重新连接
    private float reconnectTime = 0; //总的连接时间，用于超时判断
    private float SPACE_TIME = 0; //间隔连接时间
    private float TIME_OUT = 30; //超时时间
    private int requestCount = 3; //重连总次数
    private int curRequestNumber = 0; //当前请求的次数
    public static int curRequestNumberIos = 0;

    ConnectionState connectState = ConnectionState.IS_NOT_CONNECTED;
    private string[] tempArray;

    private float pingIntervalTime = 0; //ping间隔
    private string[] pingArray;

    private void initReconnectData()
    {
        curRequestNumber = 0;
        TIME_OUT = float.Parse(SysEnv.parameters["MaxTime"]);
        string spaceTimeStr = SysEnv.parameters["LinkTime"];
        string levels = spaceTimeStr.Replace("{", "").Replace("}", "");
        tempArray = levels.Split(',');

        if (tempArray != null)
        {
            requestCount = tempArray.Length;
            SPACE_TIME = float.Parse(tempArray[curRequestNumber]);
        }

        string pingStr = SysEnv.parameters["Game_Ping_Q"];
        string pingStr1 = pingStr.Replace("{", "").Replace("}", "");
        pingArray = pingStr1.Split(',');
    }

    public bool isActive()
    {
        return m_clientSocket.IsActive();
    }
    bool closed = false;

    void EndConnection()
    {
        Util.Log("End connection");
        if (m_clientSocket != null)
        {
            Util.Log("End current connection");
            //m_clientSocket.Shutdown(0);          
            //m_clientSocket.CloseConnection(new SystemAddress(address, (ushort)port), false);
            //m_clientSocket.Shutdown(300);              
            RakPeer.DestroyInstance(m_clientSocket);
        }
        else
        {
            Util.Log("sokcet null");
        }
    }

    private bool isReconnectHandler(ConnectionAttemptResult result)
    {
        if (result != ConnectionAttemptResult.CONNECTION_ATTEMPT_STARTED)
        {
            Util.LogWarning("启动RakNet失败，错误码: " + result);

            StartCoroutine(ReconnectIEnumerator());
            return false;
        }

        Util.LogWarning("启动RakNet失败，成功: " + result);
        return true;
    }

    IEnumerator ReconnectIEnumerator()
    {
        yield return new WaitForSeconds(5f);
        SocketFactory.reconnectSocket(this);
        Util.LogWarning("ReconnectIEnumerator!!");
        //Reconnect();
    }

    //重连
    public void Reconnect()
    {
        isReconnect = true;
        SetState(ConnectionState.IS_NOT_CONNECTED);

        String strM = "";
        RakNet.PublicKey noKey = new RakNet.PublicKey();
        ConnectionAttemptResult result = m_clientSocket.Connect(address, (ushort)port, strM, strM.Length, noKey, 0, 24, 2000);

        #if UNITY_IOS
        if (isReconnectHandler(result))
        {
            Reconnected();
            return;
        }

        Common.ShowLoading();

        curRequestNumber++;

        if(curRequestNumber > 6)
        {
            StopCoroutine(ReconnectIEnumerator());
            Common.NetworkDisConnectBox("(error : 401)");
        }
        #else
        if (result != ConnectionAttemptResult.CONNECTION_ATTEMPT_STARTED)
        {
        Util.LogWarning("启动RakNet失败，错误码: " + result);
        }

        curRequestNumber++;

        if (curRequestNumber < tempArray.Length)
        {
        SPACE_TIME = float.Parse(tempArray[curRequestNumber]);
        }
        else
        {
        SPACE_TIME = 10f;
        }

        StartCoroutine(showLoading());
        #endif
    }

    private void iosReConnectHandler()
    {
        Util.LogWarning("iosReConnectHandler : " + curRequestNumberIos);

        curRequestNumberIos++;

        if (curRequestNumberIos > 6)
        {
            curRequestNumberIos = 0;
            StopCoroutine(ReconnectIEnumerator());
            Common.NetworkDisConnectBox("(error : 401)");
        }
        else
        {
            StartCoroutine(ReconnectIEnumerator());
        }
    }

    public void SetState(ConnectionState st)
    {
        connectState = st;
        Debug.Log("netstate = " + connectState);
    }

    void LateUpdate()
    {
        if (m_clientSocket != null && (connectState == ConnectionState.IS_CONNECTED || connectState == ConnectionState.IS_NOT_CONNECTED))
        {
            m_receivePacket = m_clientSocket.Receive();
            while (m_receivePacket != null)
            {
                if (m_receivePacket != null)
                {
                    onNetPacket(ref m_receivePacket);
                    if (m_receivePacket != null)
                    {
                        m_receivePacket.Dispose();
//                        m_clientSocket.DeallocatePacket(m_receivePacket);
                    }

                }
               
                m_receivePacket = m_clientSocket.Receive();
            }

        }
    }
    void Update()
    {
        if (isReconnect)
        {
            reconnectTime += Time.deltaTime;

            if (reconnectTime >= TIME_OUT)
            {
                Common.NetworkDisConnectBox("(error : 401)");
                return;
            }

            if (reconnectTime >= SPACE_TIME)
            {
                againReconnect();
            }
        }

        pingIntervalTime += Time.deltaTime;
        if (pingIntervalTime > 2.0f && m_clientSocket != null && m_serverGUID != null)
        {
            pingIntervalTime = 0;
            m_serverPing = m_clientSocket.GetAveragePing(m_serverGUID);

            if (onPingCallBack != null)
            {
                onPingCallBack(getServerPingIndex());
            }

            //Debug.Log("netWork ping :" + m_serverPing);
        }
    }

    IEnumerator showLoading()
    {
        yield return new WaitForSeconds(2.0f);

        if (isReconnect)
        {
            Common.ShowLoading();
        }
    }

    //已重连成功
    public void Reconnected()
    {
        curRequestNumber = 0;
        reconnectTime = 0;
        isReconnect = false;
        StopCoroutine(showLoading());
        Common.HideLoading();

        if (onReConnected != null)
        {
            onReConnected();
        }
    }

    //客户端关闭连接
    public void onDestroyConnect()
    {
        //m_clientSocket.CloseConnection(m_serverGUID, true);

        if (m_clientSocket != null)
        {
            m_clientSocket.Shutdown(0);
        }
    }

    //再次重连
    public void againReconnect()
    {
        if (reconnectTime >= TIME_OUT)
        {
            return;
        }

        Reconnect();
    }


    public void OnConnect()
    {
        curRequestNumberIos = 0;
        SetState(ConnectionState.IS_CONNECTED);
        if (overrided)
        {
            Util.Log("OnConnect send reconnect set ip");
            AutoGenProto.Send_ID_RECONNECT_SET_IP();
        }
    }

    //----------------------- shilongquan.alvin end -------------------



   



}