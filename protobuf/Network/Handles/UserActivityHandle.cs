using UnityEngine;
using System.Collections;
using System.IO;

public class UserActivityHandle : SuperBOBO.NetInterface
{
    public void OnRegister()
    {
        DispatcherProtoBuf.Instance.Register("ActivityListRsp", ActivityListRsp);
        DispatcherProtoBuf.Instance.Register("ActivityRsp", ActivityRsp);
        DispatcherProtoBuf.Instance.Register("ActivityDescRsp", ActivityDescRsp);
        DispatcherProtoBuf.Instance.Register("DailySignInfoRsp", ReturnDailySignInfoRsp);
        DispatcherProtoBuf.Instance.Register("DailySignInRsq", ReturnDailySignInRsq);
        DispatcherProtoBuf.Instance.Register("DailySignGetRewardRsq", ReturnDailySignGetRewardRsq);
        
    }

    public void OnUnRegister()
    {
        DispatcherProtoBuf.Instance.UnRegister("ActivityListRsp");
        DispatcherProtoBuf.Instance.UnRegister("ActivityRsp");
        DispatcherProtoBuf.Instance.UnRegister("ActivityDescRsp");
        DispatcherProtoBuf.Instance.UnRegister("DailySignInfoRsp");
        DispatcherProtoBuf.Instance.UnRegister("DailySignInRsq");
    
    }

    public static void ReturnDailySignGetRewardRsq(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.DailySignGetRewardRsq rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.DailySignGetRewardRsq>(m);
        if (DataWrapper.Player.instance.activityMonthSign != null)
        {
           DataWrapper.Player.instance.activityMonthSign.rewardList= rsp.rewardList;
          
        }
        else
        {
            NetLog.GetInstance().PostLog("----------->签到的数据activityMonthSign是null");
            Debug.LogError("----------->签到的数据activityMonthSign是null");
        }
        SuperBOBO.EventManager.Instance.FireEvent(GameEventType.DailySignInRsq, new object[] { });
        SuperBOBO.RedPointManager.Instance.Triggle("main",10);
    }
    public static void ReturnDailySignInRsq(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.DailySignInRsq rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.DailySignInRsq>(m);
        if( DataWrapper.Player.instance.activityMonthSign!=null)
        {
            DataWrapper.Player.instance.activityMonthSign.signList.Add(rsp.pos);
            DataWrapper.Player.instance.activityMonthSign.buqiantimes = rsp.buqiantimes;
        }
        else
        {
            NetLog.GetInstance().PostLog("----------->签到的数据activityMonthSign是null");
            Debug.LogError("----------->签到的数据activityMonthSign是null");
        }
        SuperBOBO.EventManager.Instance.FireEvent(GameEventType.DailySignInRsq, new object[] { });
        SuperBOBO.RedPointManager.Instance.Triggle("main",10);
    }
    public static void ReturnDailySignInfoRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.DailySignInfoRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.DailySignInfoRsp>(m);
        DataWrapper.Player.instance.activityMonthSign.InitPlayerActivityMonthSign(rsp);
        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance.activityMonthSign);
        SuperBOBO.RedPointManager.Instance.Triggle("main",10);
    }
    public void OnDataUpdate()
    {
      
    }
    public static void ActivityListRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.ActivityListRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.ActivityListRsp>(m);
        DataWrapper.Player.instance.activity.AddRange(rsp.actlist);
        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance.activity);//shuaxin
        //if(UIActivityHandle.instance != null)
         //   UIActivityHandle.instance.UIInit();

        //本地没有缓存固定信息的就请求服务器返回信息
        for (int i = 0; i < rsp.actlist.Count; i++)
        {
            if (!DataWrapper.Player.instance.activity.ActivityHasKey((int)rsp.actlist[i].descid))
            {
                if (!Table.EventDesc.datas.ContainsKey(rsp.actlist[i].descid))//本地表里没有的向服务器请求
                {
                    TankProtocol.ActivityDesc ad = new TankProtocol.ActivityDesc();
                    ad.descid = rsp.actlist[i].descid;
                    DispatcherProtoBuf.Instance.SendProtoBuffer("ActivityDesc", ad);
                }
            }
        }
        SuperBOBO.RedPointManager.Instance.ActiveTag("main");
        SystemLoader.Instance.StartCoroutine(DownTexture());
    }

    static IEnumerator DownTexture()
    {
        if (UIMainHandle.clickActivity)
        {
            string path = Application.persistentDataPath + "/huodong";
            foreach (var p in DataWrapper.Player.instance.activity.actDic)
            {
                if (UIActivityHandle.activityTexCache.ContainsKey(p.Key))
                    continue;

                if (p.Key == 1 || p.Value[0].descid == 0)
                    continue;

                bool isshow = false;
                DataWrapper.PlayerActivity.ActivityConstantInfo constantInfo = DataWrapper.Player.instance.activity.GetActivityConstantInfo(p.Value[0].descid);
                if (constantInfo.showType == 8)
                {
                    if (DataWrapper.Player.instance.recharge6 > 0)
                        isshow = true;
                    if (DataWrapper.Player.instance.recharge30 > 0)
                        isshow = true;
                    if (DataWrapper.Player.instance.recharge68 > 0)
                        isshow = true;
                    if (DataWrapper.Player.instance.recharge128 > 0)
                        isshow = true;
                    if (DataWrapper.Player.instance.recharge328 > 0)
                        isshow = true;
                    if (DataWrapper.Player.instance.recharge648 > 0)
                        isshow = true;
                    if (!isshow)
                        continue;
                }

                string filePath = path + "/" + p.Key + ".png";

                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);
                string wwwPath = "";
                if (System.IO.File.Exists(filePath))
                {
    #if UNITY_EDITOR
                    wwwPath = "file:///" + filePath;
    #elif UNITY_ANDROID
                wwwPath = "file:///" + filePath;
    #elif UNITY_IOS
                wwwPath = "file:///" + filePath;
    #endif

                }
                else
                {
                    wwwPath = string.Format("http://zjlmcdn.joygame.cn/webres/activity/title/{0}.png", p.Key);
                }
                WWW www = new WWW(wwwPath);
                yield return www;
                UIActivityHandle.activityTexCache.Add(p.Key, www.texture);
                if (!System.IO.File.Exists(filePath))
                {
                    Texture2D t = www.texture;
                    byte[] b = t.EncodeToPNG();
                    System.IO.File.WriteAllBytes(filePath, b);
                }
            }
            Common.HideLoading();
            SystemLoader.LoadScenerio(EScenario.activity);
            UIMainHandle.clickActivity = false;
        }
    }
    public static void ActivityRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.ActivityRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.ActivityRsp>(m);
        DataWrapper.Player.instance.activity.AddAct(rsp.act);
        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance.activity);//shuaxin
        SuperBOBO.RedPointManager.Instance.ActiveTag("main");
        if (UIFirstRechargeHandle.instance != null)
        {
            UIFirstRechargeHandle.instance.OnRefresh(null);
            UIFirstRechargeHandle.instance.OnGetReward();
        }
    }
    public static void ActivityDescRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.ActivityDescRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.ActivityDescRsp>(m);
        DataWrapper.PlayerActivity.ActivityConstantInfo aci = new DataWrapper.PlayerActivity.ActivityConstantInfo();
        aci.desId = rsp.descid;
        aci.name = rsp.eventname;
        aci.group = rsp.eventgroup;
        aci.des = rsp.eventdesc;
        aci.showContent = rsp.showcontent;
        aci.showType = rsp.showtype;
        aci.openUI = "";
        DataWrapper.Player.instance.activity.SaveActivityConstantInfo(aci);
        DataWrapper.ModelDispatcher.Instance.Dispatch(DataWrapper.Player.instance.activity);//shuaxin
        SuperBOBO.RedPointManager.Instance.ActiveTag("main");
    }
}
