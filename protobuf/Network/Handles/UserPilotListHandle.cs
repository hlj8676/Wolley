using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DataWrapper;


public class UserPilotListHandle:SuperBOBO.NetInterface 
{
    public delegate void Delegate_ON_GET_NEW_PILOT();
    public static Delegate_ON_GET_NEW_PILOT delegate_ON_GET_NEW_PILOT;
    public void Delegate_SUB_ID_PILOT_LIST_RSP(int errorCode, byte type, PilotDetailInfo[] list)
    {
        List<PilotDetailInfo> lst = new List<PilotDetailInfo>(list);
       // UIWait.Wait(false);
        switch (type)
        {
            case 0://list
                DataWrapper.Player.instance.SetPilot(lst);
                DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance);
                AskAllPilotTankExpReq();
                break;
            case 1://add
                //UIMessageBox.Show(504,null);
                DataWrapper.Player.instance.AddPilot(lst);
                DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance);
                if (delegate_ON_GET_NEW_PILOT != null) delegate_ON_GET_NEW_PILOT();
                else
                    OnActivePilot(list);
                break;
            case 2://delete
                DataWrapper.Player.instance.DeletePilot(lst);
                DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance);
                break;
        }
    }

    void OnActivePilot(PilotDetailInfo[] list)
    {
        string pilotDataId = list[0].pilotTempId + "-" + list[0].pilotRank;
        SituationalManager.LoadSituational(Table.Pilot.datas[pilotDataId].Appear);
        
    }
    public void Delegate_SUB_ID_PROFESSOR_LIST_RSP(int errorCode, byte type, ProfessorDetailInfo[] list)
    {
        List<ProfessorDetailInfo> lst = new List<ProfessorDetailInfo>(list);
        //UIWait.Wait(false);
        switch (type)
        {
            case 0://list
                DataWrapper.Player.instance.SetProfessor(lst);
                DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance);
                break;
            case 1://add
                UIMessageBox.Show(string.Format("恭喜您获得教授！"));
                DataWrapper.Player.instance.AddProfessor(lst);
                DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance);
                break;
            case 2://delete
                DataWrapper.Player.instance.RemoveProfessor(lst);
                DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance);
                break;
        }
    }
    public static void AskAllPilotTankExpReq()
    {
        for (int i = 0; i < Player.instance.pilots.Count; i++)
        {
            TankProtocol.AskPilotTankExpReq ask = new TankProtocol.AskPilotTankExpReq();
            ask.pilotid = (uint)Player.instance.pilots[i].pilotIdx;
            DispatcherProtoBuf.Instance.SendProtoBuffer("AskPilotTankExpReq", ask);
        }
    }
   
    public static void AskPilotTankExpReq(uint pilotIdx)
    {
        TankProtocol.AskPilotTankExpReq ask = new TankProtocol.AskPilotTankExpReq();
        ask.pilotid = pilotIdx;
        DispatcherProtoBuf.Instance.SendProtoBuffer("AskPilotTankExpReq", ask);
    }
    public static void AskPilotTankExpRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.AskPilotTankExpRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.AskPilotTankExpRsp>(m);
        DataWrapper.PlayerPilot pilot = DataWrapper.Player.instance.FindPilot((int)rsp.pilotid);
        pilot.SetLiscence(rsp);
    }
    public static void ReturnDeclareLoveRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.DeclareLoveRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.DeclareLoveRsp>(m);
        if (rsp.errorCode==0)
        {
            for (int i = 0; i < rsp.pilotFavor.Count; i++)
            {
                DataWrapper.Player.instance.SetPilotFavor(rsp.pilotFavor[i]);

            }
        }
        else
        {
            string str = Table.Message.Get(rsp.errorCode).Tip;
            UIMessageBox.Show(str);
        }
      
        SuperBOBO.EventManager.Instance.FireEvent(GameEventType.DeclareLoveRsp, new object[] { rsp.errorCode});
    }
    public static void ReturnTouchPilotRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.TouchPilotRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.TouchPilotRsp>(m);
        DataWrapper.Player.instance.touchneedtime = rsp.touchneedtime;
        DataWrapper.Player.instance.touchremaincount =(byte) rsp.touchremainCount;

        for (int i = 0; i < DataWrapper.Player.instance.pilots.Count; i++)
        {
            if (rsp.pilotId == DataWrapper.Player.instance.pilots[i].pilotIdx)
            {
                DataWrapper.Player.instance.pilots[i].detail.favorPoint += (ushort)rsp.addFavor;
                break;
            }
        }
        if (UIPilotHandle.pilot != null)
        {
            if (UIPilotHandle.pilot.pilotIdx == rsp.pilotId)
            {
                //UIPilotHandle.pilot.detail.favorPoint += (ushort)rsp.addFavor;
            }

        }
        if (rsp.addFavor>0)
        {
            SuperBOBO.EventManager.Instance.FireEvent(GameEventType.TouchPilotRsp, new object[] { rsp.pilotId, rsp.addFavor });
        }
        else
        {
            SuperBOBO.EventManager.Instance.FireEvent(GameEventType.TouchPilotRsp, new object[] { rsp.pilotId});
        }
      
    }

    public static void ReturnGiftPilotRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.SendGiftPilotRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.SendGiftPilotRsp>(m);
        for (int i = 0; i < DataWrapper.Player.instance.pilots.Count; i++)
        {
            if (rsp.pilotId == DataWrapper.Player.instance.pilots[i].pilotIdx)
            {
                DataWrapper.Player.instance.pilots[i].detail.favorPoint += (ushort)rsp.addFavor;
                break;
            }
        }
        if (UIPilotHandle.pilot != null)
        {
            if (UIPilotHandle.pilot.pilotIdx == rsp.pilotId)
            {
                //UIPilotHandle.pilot.detail.favorPoint += (ushort)rsp.addFavor;
            }

        }
        if (rsp.addFavor > 0)
        {
            SuperBOBO.EventManager.Instance.FireEvent(GameEventType.SendGiftPilotRsp, new object[] { rsp.pilotId, rsp.addFavor });
        }
        else
        {
            SuperBOBO.EventManager.Instance.FireEvent(GameEventType.SendGiftPilotRsp, new object[] { rsp.pilotId });
        }
    }

   
     public static void SvnVersionRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.SvnVersionRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.SvnVersionRsp>(m);
        Debug.LogError("-------------------->请求版本配置信息的消息返回了");
         
        string showstr = "";
        string myUIstr = "";
       //  Application.dataPath
        string str=  FileUtils.ReadStringFromStreaming("ClientTableVar.txt");
        string xxx= str.Replace("\r\n", "|");
        string[] aaaa = xxx.Split('|');
       // string[] aaaa = File.ReadAllLines(Application.streamingAssetsPath + "/ClientTableVar.txt", System.Text.Encoding.GetEncoding("UTF-8"));
        if (aaaa.Length > 10)
        {
            myUIstr = aaaa[10];
            myUIstr = myUIstr.Replace("最后修改的版本", "客户端Table配置版本");
          
            showstr += myUIstr;
        }

        str = FileUtils.ReadStringFromStreaming("ClientLuaVar.txt");
        xxx = str.Replace("\r\n", "|");
        aaaa = xxx.Split('|');
       // aaaa = File.ReadAllLines(Application.streamingAssetsPath + "/ClientLuaVar.txt", System.Text.Encoding.GetEncoding("UTF-8"));
        if (aaaa.Length > 10)
        {
            myUIstr = aaaa[10];
            myUIstr = myUIstr.Replace("最后修改的版本", "客户端Lua配置版本");
           // 
            showstr +="\n"+ myUIstr;
        }
        myUIstr ="服务器Table配置版本：" + rsp.serverConfig;
        showstr += "\n" + myUIstr;
        myUIstr = "服务器Lua配置版本：" + rsp.serverLua;
        showstr += "\n" + myUIstr;
        myUIstr = "服务器代码版本：" + rsp.serverVer;
        showstr += "\n" + myUIstr;
        UIMessageBox.ShowMessageLittleWindow_Version(showstr);
    }
    public void OnRegister()
    {
        AutoGenProto.delegate_SUB_ID_PILOT_LIST_RSP += Delegate_SUB_ID_PILOT_LIST_RSP;
        AutoGenProto.delegate_SUB_ID_PROFESSOR_LIST_RSP += Delegate_SUB_ID_PROFESSOR_LIST_RSP;
        DispatcherProtoBuf.Instance.Register("AskPilotTankExpRsp", AskPilotTankExpRsp);
        DispatcherProtoBuf.Instance.Register("DeclareLoveRsp", ReturnDeclareLoveRsp);
        DispatcherProtoBuf.Instance.Register("TouchPilotRsp", ReturnTouchPilotRsp);
        DispatcherProtoBuf.Instance.Register("SendGiftPilotRsp", ReturnGiftPilotRsp);
        DispatcherProtoBuf.Instance.Register("SvnVersionRsp", SvnVersionRsp);
    }

    public void OnUnRegister()
    {
        AutoGenProto.delegate_SUB_ID_PILOT_LIST_RSP -= Delegate_SUB_ID_PILOT_LIST_RSP;
        AutoGenProto.delegate_SUB_ID_PROFESSOR_LIST_RSP -= Delegate_SUB_ID_PROFESSOR_LIST_RSP;
        DispatcherProtoBuf.Instance.UnRegister("AskPilotTankExpRsp");
        DispatcherProtoBuf.Instance.UnRegister("DeclareLoveRsp");
        DispatcherProtoBuf.Instance.UnRegister("TouchPilotRsp");
        DispatcherProtoBuf.Instance.UnRegister("SendGiftPilotRsp");
        DispatcherProtoBuf.Instance.UnRegister("SvnVersionRsp");
    }

    //断线重连后，数据同步调用方法 by shilongquan
    public void OnDataUpdate()
    {

    }
}
