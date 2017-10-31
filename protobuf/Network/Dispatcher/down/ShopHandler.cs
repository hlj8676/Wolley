using UnityEngine;

using System.Collections;
using System.IO;
using System.Collections.Generic;

using DataWrapper;

public class ShopHandler
{
    public delegate void OnExpUnLockCallBack();
    public static OnExpUnLockCallBack unLockCallBack;

    //请求商城某一类别对应的数据
    public static void SendShopReq(uint shopType)
    {
        Common.ShowLoading(5);

        TankProtocol.ShopReq ps = new TankProtocol.ShopReq();
        ps.shopid = shopType;

        DispatcherProtoBuf.Instance.SendProtoBuffer("ShopReq", ps);
    }

    public static void SendShopBuyReq(uint shopid, uint subid, uint count)
    {
        Common.ShowLoading(5);

        TankProtocol.ShopBuy ps = new TankProtocol.ShopBuy();
        ps.shopid = shopid;
        ps.subid = subid;
        ps.num = count;

        DispatcherProtoBuf.Instance.SendProtoBuffer("ShopBuy", ps);
    }

    //接收商城数据
    public static void OnRecvShopRsp(byte[] data)
    {
        Common.HideLoading();

        OnRecvRechargeRsp(data);

        PlayerShop tempShop = Player.instance.shop;

        MemoryStream m = new MemoryStream(data);

        TankProtocol.ShopRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.ShopRsp>(m);

        if (rsp == null || rsp.shopid == 9 || rsp.shopid == 10)//为钻石     10-》vip礼包
            return;
        if(rsp != null)
        {
            tempShop.GC();

            tempShop.shopId = rsp.shopid;

            //商城类别与名字
            if(rsp.shopvec != null)
            {
                for (int i = 0; i < rsp.shopvec.Count; i++)
                {
                    TankProtocol.ShopVec shopVec = rsp.shopvec[i];
                    PlayerShop.ShopVec playerShopVec = new PlayerShop.ShopVec();

                    //string str = System.Text.Encoding.GetEncoding("UTF-8").GetString(shopVec.shopname);
                    playerShopVec.shopid = shopVec.shopid;
                    playerShopVec.shopname = shopVec.shopname;

                    tempShop.shopMenuList.Add(playerShopVec);
                }
            }

            //商城数据
            if(rsp.shopstu != null)
            {
                for (int i = 0; i < rsp.shopstu.Count; i++)
                {
                    TankProtocol.ShopStu shopstu = rsp.shopstu[i];

                    //等于1的商城限购道具，购买完之后，做屏蔽处理
                    if (shopstu.limitshow == 1 && shopstu.limitcount != 0 && shopstu.limitcount == shopstu.limitcounted)
                    {
                        continue;
                    }

                    PlayerShop.ShopInfo playerShopInfo = new PlayerShop.ShopInfo();

                    playerShopInfo.shopid = shopstu.shopid;
                    playerShopInfo.subid = shopstu.subid;
                    playerShopInfo.order = shopstu.order;
                    playerShopInfo.itemid = shopstu.itemid;
                    playerShopInfo.moneytype = shopstu.moneytype;
                    playerShopInfo.price = shopstu.price;
                    playerShopInfo.discount = shopstu.discount;
                    playerShopInfo.shoplabel = shopstu.shoplabel;
                    playerShopInfo.easybuy = shopstu.easybuy;
                    playerShopInfo.limitnum = shopstu.limitnum;
                    playerShopInfo.limitshow = shopstu.limitshow;
                    playerShopInfo.itemnum = shopstu.itemnum;
                    playerShopInfo.firstrecharge = shopstu.firstrecharge;
                    playerShopInfo.limitcount = shopstu.limitcount;
                    playerShopInfo.limitcounted = shopstu.limitcounted;
                    playerShopInfo.res = shopstu.res;
                    playerShopInfo.preview = shopstu.preview;

                    tempShop.shopList.Add(playerShopInfo);

                }
            }
        }

        if(UIShopMain.instance != null)
        {
            UIShopMain.instance.updateData();
        }
        else
        {
            SystemLoader.LoadScenerio(EScenario.shop);
        }
    }

    //限购更新数量
    public static void OnRecvLimitBuyChange(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.LimitBuy rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.LimitBuy>(m);

        if (UIVIP.instance != null && rsp != null && rsp.shopid == 10)
        {
            UIVIP.OnGIfBuyChange(data);
        }

        Player.instance.shop.updateLimitData(rsp.shopid, rsp.subid, rsp.limitcounted);
    }

    public static void OnRecvRechargeRsp(byte[] data)
    { 
        MemoryStream m = new MemoryStream(data);
        TankProtocol.ShopRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.ShopRsp>(m);
        
        if (rsp == null)
            return;
        ///因为后续加了分支判断，把rsp == nulll判断提出来了
        if (rsp.shopid == 9)//为钻石
        {
            if (UIRechargeHandle.instance!=null)
            {
                UIRechargeHandle.instance.RefreshData(rsp);
            }
            else
            {
                UIRechargeHandle.data = rsp;
                SystemLoader.LoadScenerio(EScenario.recharge);//充值界面
            }
        }
        else if (rsp.shopid == 10)
        {
            if (UIVIP.instance && UIVIP.instance.gameObject && UIVIP.instance.gameObject.activeInHierarchy)
                UIVIP.instance.RecvGIftRspAndShow(rsp);

            VIPRedPointManager.RecvRsp(rsp);
        }
    }

    //----------------------------- 随机商店 begin -------------------------------

    /// <summary>
    /// 进入随机商店请求数据
    /// </summary>
    /// <param name="type">0|1 拉数据|刷新</param>
    public static void SendStagingPostInfoReq(uint type = 0)
    {
        Common.ShowLoading(5);

        TankProtocol.StagingPostInfoReq ps = new TankProtocol.StagingPostInfoReq();
        ps.type = type;

        DispatcherProtoBuf.Instance.SendProtoBuffer("StagingPostInfoReq", ps);
    }

    public static void OnRecvStagingPostInfoRsp(byte[] data)
    {
        Common.HideLoading();

        MemoryStream m = new MemoryStream(data);
        TankProtocol.StagingPostInfoRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.StagingPostInfoRsp>(m);

        DataWrapper.Player.instance.shop.supplyShopList = rsp.shopList;
        DataWrapper.Player.instance.shop.stagingPostCount = rsp.refreshTimes;

        if (UIShopMain.instance && UIShopMain.instance.gameObject.activeInHierarchy)
        {
            ///检查UI是否存在
            if (UIShopSupplyMain.instance == null)
            {
                GameObject go = Common.GenerateResource("UI/Mall/UIMall_Supply");
                Common.AddToParent(go.transform, UIShopMain.instance.transform);
            }

            UIShopSupplyMain.instance.updateData();
            UIShopMain.instance.showTog(UIShopMain.SHOP_MENU_TYPE.SHOP_SUPPLY);
            TenLotteryRedPointManager.CheakOnBranchUI(TenLotteryRedPointManager.UIBranch.ShopUI);
        }
    }

    /// <summary>
    /// 购买随机商店商品
    /// </summary>
    /// <param name="buyIndex">服务器传的顺序下标，用做KEY</param>
    public static void SendStagingPostBuyReq(uint buyIndex = 0)
    {
        TankProtocol.StagingPostBuyReq ps = new TankProtocol.StagingPostBuyReq();
        ps.index = buyIndex;

        DispatcherProtoBuf.Instance.SendProtoBuffer("StagingPostBuyReq", ps);
    }

    public static void OnRecvStagingPostBuyRsq(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);
        TankProtocol.StagingPostBuyRsq rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.StagingPostBuyRsq>(m);

        if (UIShopMain.instance && UIShopMain.instance.gameObject.activeInHierarchy)
        {
            if (UIShopSupplyMain.instance != null)
            {
                UIShopSupplyMain.instance.updateLimitData(rsp.index);
            }
        }
    }

    //----------------------------- 随机商店 end -------------------------------
}