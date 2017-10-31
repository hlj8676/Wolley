using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System;
using LitJson;

public class IPServerManager : MonoBehaviour
{
  
    Dictionary<int, UIIPServer.IPServerLine> serverLines = new Dictionary<int, UIIPServer.IPServerLine>();
    bool refreshList = false;

    bool connected = false;
    bool needInvitation = false;
    bool alreadyInvitation = false;
    const float TIME_OUT = 60f;
    float curTime = 0;

    StateObjectNew state = new StateObjectNew();

    bool isConnect = true;
    int connectCount = 0;

    public static IPServerManager Instance;


    internal class StateObjectNew
    {
        public TcpClient client = null;
        public int totalBytesRead = 0;
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize];
    }

    public class IPPackageNew
    {
        RakNet.BitStream bs;

        public IPPackageNew()
        {
            bs = new RakNet.BitStream();
        }

        public RakNet.BitStream GetBitStream()
        {
            return bs;
        }

        public byte[] GetData()
        {
            return bs.GetData();
        }

        public uint GetDataLength()
        {
            return bs.GetNumberOfBytesUsed();
        }
    }

    TcpClient client;
    private NetworkStream streamToServer;

    public void SendMessage(IPPackageNew msg)
    {
        try
        {
            client.GetStream().Write(msg.GetData(), 0, (int)msg.GetDataLength());
            client.GetStream().Flush();
        }
        catch (System.Exception ex)
        {
            Debug.LogError(ex.ToString());
            onReConnect();
        }
    }


    public void OnGetMail(byte[] data)
    {
        string s = Encoding.UTF8.GetString(data, 0, data.Length);
        Debug.Log(s + "      " + s.Length);
        JsonData jData = JsonMapper.ToObject(new JsonReader(s));

        SysEnv.mailServerAddress = jData["ip"].ToString();
        SysEnv.mailServerPort = int.Parse(jData["pt"].ToString());
    }

    public void OnGetServerList(byte[] data)
    {
        string s = Encoding.UTF8.GetString(data, 0, data.Length);
        Debug.Log(s + "      " + s.Length);
        JsonData jData = JsonMapper.ToObject(new JsonReader(s));
        SysEnv.SetIPServerJsonData(jData);
        SysEnv.servers.Clear();
        serverLines.Clear();
        if (jData["s"].Count == 0)
        {
            UIMessageBox.ShowLittleWindow("服务器个数为零！！！");
            return;
        }
        //公告http
        SysEnv.noticeHttp = jData["c"].ToString();

        //服务器列表
        for (int i = 0; i < jData["s"].Count; i++)
        {
            JsonData jd = jData["s"][i];
            UIIPServer.IPServerData d = new UIIPServer.IPServerData(jd);
            SysEnv.servers.Add(d);
        }

        //服务器状态
        for (int i = 0; i < jData["sl"].Count; i++)
        {
            JsonData jd = jData["sl"][i];
            UIIPServer.IPServerLine d = new UIIPServer.IPServerLine();

            d.id = int.Parse(jd["id"].ToString());
            d.count = int.Parse(jd["ct"].ToString());
            d.canConnect = Boolean.Parse(jd["co"].ToString());

            serverLines.Add(d.id, d);
        }

        //是否需要激活码
        {
            JsonData jd = jData["ar"][0];
            needInvitation = (jd["ac"].ToString() == "1" ? true : false);
            alreadyInvitation = (jData["a"].ToString() == "1" ? true : false);

            if (needInvitation)
            {
                if (alreadyInvitation)
                    refreshList = true;
                else
                    UIManager.Instance.PushUI("UI/Activation");
            }
            else
            {
                refreshList = true;
            }
        }
    }

    //4
    public void OnGetUserID(byte[] data)
    {
        string s = Encoding.UTF8.GetString(data, 0, data.Length);
        Util.Log(s + "      " + s.Length);
        JsonData jData = JsonMapper.ToObject(new JsonReader(s));

        if (jData["s"] != null)
        {
            JsonData jd = jData["s"];
            UIIPServer.IPServerData d = new UIIPServer.IPServerData(jd);
            SysEnv.SetSelectedServer(d);
        }

        if (jData["c"] != null)
        {
            //公告http
            SysEnv.noticeHttp = jData["c"].ToString();
        }

        if(jData["err"] != null)
        {
            Util.Log("[IPServerManager] OnGetUserID error:" + jData["err"]);
        }

        SysEnv.userID = uint.Parse(jData["uid"].ToString());
        SysEnv.serverID = uint.Parse(jData["sid"].ToString());
        SysEnv.setToKenStr(jData["tk"].ToString());

        //如果token 为空，重试请求
        /*
        if (string.IsNullOrEmpty(SysEnv.toKenStr))
        {
            SuperBOBO.EventManager.Instance.FireEvent(GameEventType.Login_TokenFail, null);
            Debug.Log("ipserver token :" + SysEnv.toKenStr);
            return;
        }
        */

        SuperBOBO.EventManager.Instance.FireEvent(GameEventType.Login_TokenSuccess, null);
    }

    private void OnGetData2(byte[] data)
    {

        string s = Encoding.UTF8.GetString(data, 0, data.Length);
        JsonData jData = JsonMapper.ToObject(new JsonReader(s));
        int id = int.Parse(jData["m"].ToString());

        switch (id)
        {
            //服务器列表
            case 2:
                SuperBOBO.EventManager.Instance.FireEvent(GameEventType.Login_GetServerIPList, data);
                break;

            //选择服务器，进入UIStart
            case 4:
                SuperBOBO.EventManager.Instance.FireEvent(GameEventType.Login_GetUserID, data);
                break;

            //邮件
            case 5:
                SuperBOBO.EventManager.Instance.FireEvent(GameEventType.Login_GetMailServer, data);

                break;
            //增加是否需要激活码
            case 10:
                switch (jData["s"].ToString())
                {
                    case "1"://成功
                        refreshList = true;
                        UIMessageBox.ShowLittleWindow("激活成功");
                        break;
                    case "2"://已经被激活
                        UIInvitation.instance.lb_tip.text = "激活码已使用";
                        Common.HideLoading();
                        break;
                    case "3"://激活无效
                        UIInvitation.instance.lb_tip.text = "激活码无效";
                        Common.HideLoading();
                        break;

                }
                break;
        }
    }

    public void OnTimeOut()
    {
        Common.NetworkDisConnectBox("(error : 601)");
    }


    private bool isEffective(int serverId)
    {
        bool isTrue = false;

        if (SysEnv.servers != null && SysEnv.servers.Count > 0)
        {
            foreach (UIIPServer.IPServerData temp in SysEnv.servers)
            {
                if (temp.id == serverId)
                {
                    isTrue = true;
                    break;
                }
            }
        }

        return isTrue;
    }

    private UIIPServer.IPServerData getRecommend()
    {
        UIIPServer.IPServerData data = new UIIPServer.IPServerData();

        if (SysEnv.servers != null && SysEnv.servers.Count > 0)
        {
            data = SysEnv.servers[0];

            foreach (UIIPServer.IPServerData temp in SysEnv.servers)
            {
                if (temp.fg == 1)
                {
                    data = temp;
                    break;
                }
            }
        }

        return data;
    }

    UIIPServer.IPServerData data;
    public void CheckLoginServer()
    {
        data = SysEnv.getUserSaveServerInfo();

        if (!string.IsNullOrEmpty(data.name) && isEffective(data.id) && data.ipServer_channe_id == Common.IPSERVER_CHANNE_ID)
        {
            //用最新服务器发下来的地址
            if (SysEnv.servers != null && SysEnv.servers.Count > 0)
            {
                foreach (UIIPServer.IPServerData temp in SysEnv.servers)
                {
                    if (temp.id == data.id)
                    {
                        SysEnv.SetSelectedServer(temp);
                        break;
                    }
                }
            }
        }
        else
        {
            //默认选择服务器逻辑
            if (SysEnv.servers != null && SysEnv.servers.Count > 0)
            {
                data = getRecommend();
                SysEnv.SetSelectedServer(data);
            }
        }

        if (serverLines.ContainsKey(data.id))
        {
            if (serverLines[data.id].canConnect)
            {
                SysEnv.serverStateSpriteName = Common.GetIPServerLight(serverLines[data.id].count).ToString();
            }
            else
            {
                SysEnv.serverStateSpriteName = "4";
            }
        }
    }

    [System.Serializable]
    public class ServerJsonData
    {
        public int id;
        public int time;
        public int extra;
    }

    //连接服务器或重连
    public static void onReConnect()
    {
        if (Instance.client != null && Instance.client.Connected)
        {
            Instance.StopAllCoroutines();
            Instance.client.GetStream().Close();
            Instance.client.Close();
        }

        Instance.resetValue();

        TcpAgentClient.Instance.Connect(SysEnv.ipServerAddress, SysEnv.ipServerPort, Instance.OnConnectIPServer, true);
    }

    protected void OnConnectIPServer(TcpAgentClient.StateConnect sc)
    {
        if (sc.client.Connected)
        {
            Util.Log("connected to ipserver");

            client = sc.client;
            streamToServer = sc.client.GetStream();

            SuperBOBO.EventManager.Instance.FireEvent(GameEventType.Login_ConnectedIPServerSucc, null);
        }
        else
        {
            SuperBOBO.EventManager.Instance.FireEvent(GameEventType.Login_ConnectedIPServerFail, null);
        }
    }


    //数据重置
    private void resetValue()
    {
        isConnect = true;
        connectCount = 0;
        curTime = 0;
    }

    //游戏结束
    private void gameOver()
    {
        StopAllCoroutines();

        isConnect = false;

        Common.NetworkDisConnectBox("(error : 301)");
    }

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        isConnect = true;
        connectCount = 0;
        curTime = 0;

        TcpAgentClient.onRecvData += OnGetData2;
    }

    public static void Send_ID_SERVER_GETLIST()
    {
        if (Instance != null)
        {
            RakNet.BitStream pkg = new RakNet.BitStream();
            pkg.Write((byte)1);
            pkg.Write((byte)Common.IPSERVER_CHANNE_ID);
            pkg.Write((byte)0);

            Encoding encoding = Encoding.GetEncoding("UTF-8");
            pkg.Write(encoding.GetString(encoding.GetBytes(UILogin.m_channel_uuid)));

            IPPackageNew ipkg = new IPPackageNew();
            ipkg.GetBitStream().Write((int)pkg.GetNumberOfBytesUsed());
            ipkg.GetBitStream().Write(pkg);
            Instance.SendMessage(ipkg);

            Debug.Log("Send_ID_SERVER_GETLIST");
        }
    }

    public static void Send_ID_PLAYER_GETID( )
    {
        if (SysEnv.serverID != 0)
        {
            Send_ID_Player_GetID((byte)SysEnv.serverID);
        }
        else
        {
            Send_ID_Player_GetID((byte)Instance.data.id);
        }
        //22 xiaojun
    }

    //延迟重试连接IPSERVER
    public static void delaySendIDPlayerGetID()
    {

    }

    public static void Send_ID_Player_GetID(byte serverID)
    {
        if (Instance != null)
        {
            RakNet.BitStream pkg = new RakNet.BitStream();
            pkg.Write((byte)3);
            pkg.Write((byte)Common.IPSERVER_CHANNE_ID);
            pkg.Write((byte)serverID);
            Encoding encoding = Encoding.GetEncoding("UTF-8");
            pkg.Write(encoding.GetString(encoding.GetBytes(UILogin.m_channel_uuid)));

            IPPackageNew ipkg = new IPPackageNew();
            ipkg.GetBitStream().Write((int)pkg.GetNumberOfBytesUsed());
            ipkg.GetBitStream().Write(pkg);
            Instance.SendMessage(ipkg);

            Util.Log("Send_ID_Player_GetID");
        }
    }

    public static void Send_ID_GET_MAIL_IP()
    {
        IPPackageNew pkg = new IPPackageNew();
        pkg.GetBitStream().Write((int)2);
        pkg.GetBitStream().Write((byte)5);
        pkg.GetBitStream().Write((byte)Common.IPSERVER_CHANNE_ID);
        Instance.SendMessage(pkg);

        Util.Log("Send_ID_GET_MAIL_IP");
    }

    /// <summary>
    /// 发送邀请码
    /// </summary>
    public static void Send_Invitation(string invitation)
    {
        IPPackageNew pkg = new IPPackageNew();
        pkg.GetBitStream().Write((byte)9);
        pkg.GetBitStream().Write((byte)Common.IPSERVER_CHANNE_ID);
        Encoding encoding = Encoding.GetEncoding("UTF-8");

        RakNet.BitStream _pkg = new RakNet.BitStream();
        _pkg.Write(encoding.GetString(encoding.GetBytes(UILogin.m_channel_uuid)));
        pkg.GetBitStream().Write((byte)_pkg.GetNumberOfBytesUsed());//长度

        pkg.GetBitStream().Write(encoding.GetString(encoding.GetBytes(UILogin.m_channel_uuid)));

        RakNet.BitStream __pkg = new RakNet.BitStream();
        __pkg.Write(encoding.GetString(encoding.GetBytes(invitation)));
        pkg.GetBitStream().Write((byte)__pkg.GetNumberOfBytesUsed());//长度

        pkg.GetBitStream().Write(encoding.GetString(encoding.GetBytes(invitation)));

        IPPackageNew ipkg = new IPPackageNew();
        ipkg.GetBitStream().Write((int)pkg.GetBitStream().GetNumberOfBytesUsed());
        ipkg.GetBitStream().Write(pkg.GetBitStream());
        Instance.SendMessage(ipkg);
    }

    void OnDestroy()
    {
        TcpAgentClient.onRecvData = null;
        Instance = null;
    }

    public void Done(bool isLoadUIStart = true)
    {
        TcpAgentClient.Instance.Destroy();
        Common.HideLoading();

        if (isLoadUIStart)
        {
            UIManager.Instance.PushUI("UI/UIStart");
        }

        DestroyImmediate(gameObject);
    }

    protected bool getServerList = false;
}