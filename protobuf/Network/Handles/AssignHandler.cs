using UnityEngine;
using System.Collections;
using System.IO;
using SuperBOBO;


/// <summary>
/// 委托任务
/// </summary>
public class AssignHandler : PBHandler
{

    public const string AssignReq = "Assign";
    public const string AcceptAssignReq = "AcceptAssign";
    public const string GetRewardAssignReq = "GetRewardAssign";
    public const string CancelAssignReq = "CancelAssign";


    public const string Rsp = "AssignRsp";

    public static void SendAssign(uint id)
    {
        Common.ShowLoading();
        TankProtocol.Assign qc = new TankProtocol.Assign();
        qc.id = id;
        DispatcherProtoBuf.Instance.SendProtoBuffer(AssignReq, qc);
    }

    public static void SendAcceptAssign(uint id,uint tankid,uint pilotid)
    {
        Common.ShowLoading();
        TankProtocol.AcceptAssign qc = new TankProtocol.AcceptAssign();
        qc.id = id;
        qc.tankid = tankid;
        qc.pilotid = pilotid;
        DispatcherProtoBuf.Instance.SendProtoBuffer(AcceptAssignReq, qc);
    }

    public static void SendGetReward(uint id)
    {
        Common.ShowLoading();
        TankProtocol.GetRewardAssign qc = new TankProtocol.GetRewardAssign();
        qc.id = id;
        DispatcherProtoBuf.Instance.SendProtoBuffer(GetRewardAssignReq, qc);
    }

    

    public static void SendCancelAssign(uint id)
    {
        Common.ShowLoading();
        TankProtocol.CancelAssign qc = new TankProtocol.CancelAssign();
        qc.id = id;
        DispatcherProtoBuf.Instance.SendProtoBuffer(CancelAssignReq, qc);
    }

    public string GetRspName()
    {
        return Rsp;
    }

    public void OnRecv(byte[] datas)
    {
        Common.HideLoading();
        MemoryStream m = new MemoryStream(datas);
        TankProtocol.AssignRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.AssignRsp>(m);

        if (rsp == null)
            return;

        if (DataWrapper.Player.instance != null)
        {
            DataWrapper.PlayerAssign pa = DataWrapper.Player.instance.FindPlayerAssign(rsp.assign.id);
            if (pa != null)
            {
                
                var k = rsp.assign;
                pa.id = k.id;
                pa.pilotid = k.pilotid;
                pa.state = k.state;
                pa.successpct = k.successpct;
                pa.tankid = k.tankid;
                pa.taskid = k.taskid;
                pa.accepttime = k.accepttime;
                if (pa.taskid == 0)
                    pa.data = null;
                else
                    pa.data = Table.Appoint.Get(k.taskid);
               
                DataWrapper.Player.instance.assigns.Sort(DataWrapper.PlayerAssign.Sort);

                SuperBOBO.EventManager.Instance.FireEvent(GameEventType.Assign, pa);
                SuperBOBO.EventManager.Instance.FireEvent(GameEventType.AssignList);

            }
        }
    }

    public void OnUnRegister()
    {

    }
}

/// <summary>
/// 委托任务
/// </summary>
public class AssignListHandler : PBHandler
{

    public const string Req = "AssignList";
    public const string Rsp = "AssignListRsp";
    public const string RefreshAssignReq = "RefreshAssign";

    public static void Send()
    {
        Common.ShowLoading();

        DispatcherProtoBuf.Instance.SendProtoBuffer(Req, null);
    }

    public static void SendRefreshAssign(uint byenergy)
    {
        Common.ShowLoading();

        TankProtocol.RefreshAssign qc = new TankProtocol.RefreshAssign();
        qc.byenergy = byenergy;
        DispatcherProtoBuf.Instance.SendProtoBuffer(RefreshAssignReq, qc);
    }


    public string GetRspName()
    {
        return Rsp;
    }

    public void OnRecv(byte[] datas)
    {
        Common.HideLoading();
        MemoryStream m = new MemoryStream(datas);
        TankProtocol.AssignListRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.AssignListRsp>(m);

        if (rsp == null)
            return;

        if (DataWrapper.Player.instance != null)
        {
            DataWrapper.Player.instance.assigns.Clear();

            foreach(var k in rsp.assignlist)
            {
                DataWrapper.PlayerAssign pa = new DataWrapper.PlayerAssign();
                pa.id = k.id;
                pa.pilotid = k.pilotid;
                pa.state = k.state;
                pa.successpct = k.successpct;
                pa.tankid = k.tankid;
                pa.taskid = k.taskid;
                pa.accepttime = k.accepttime;
                if (pa.taskid == 0)
                    pa.data = null;
                else
                    pa.data = Table.Appoint.Get(k.taskid);
                DataWrapper.Player.instance.assigns.Add(pa);
            }
            DataWrapper.Player.instance.assigns.Sort(DataWrapper.PlayerAssign.Sort);

            SuperBOBO.EventManager.Instance.FireEvent(GameEventType.AssignList);
        }
    }

    public void OnUnRegister()
    {

    }
}

/// <summary>
/// 委托任务概率
/// </summary>
public class AssignSucessHandler : PBHandler
{
    public const string Rsp = "AssignSuccesspctRsp";
    public const string Req = "AssignSuccesspct";

    public string GetRspName()
    {
        return Rsp;
    }

    public void OnRecv(byte[] datas)
    {
        Common.HideLoading();
        MemoryStream m = new MemoryStream(datas);
        TankProtocol.AssignSuccesspctRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.AssignSuccesspctRsp>(m);

        if (rsp == null)
            return;


        SuperBOBO.EventManager.Instance.FireEvent(GameEventType.AssignSucess,rsp.successpct);

    }

    public void OnUnRegister()
    {
        
    }

    public static void SendAssignSucess(uint id,uint tankid,uint pilotid)
    {
        Common.ShowLoading();

        TankProtocol.AssignSuccesspct qc = new TankProtocol.AssignSuccesspct();
        qc.taskid = id;
        qc.tankid = tankid;
        qc.pilotid = pilotid;

        DispatcherProtoBuf.Instance.SendProtoBuffer(Req, qc);
    }
}


/// <summary>
/// 委托领取的失败or成功
/// </summary>
public class AssignResultHandler : PBHandler
{
    public const string Rsp = "AssignResultRsp";

    public string GetRspName()
    {
        return Rsp;
    }

    public void OnRecv(byte[] datas)
    {
        Common.HideLoading();
        MemoryStream m = new MemoryStream(datas);
        TankProtocol.AssignResultRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.AssignResultRsp>(m);

        if (rsp == null)
            return;


        if (rsp.result == 2)
        {
            UIMessageBox.Show("任务失败,请重新委派");
        }
    }

    public void OnUnRegister()
    {

    }

   
}