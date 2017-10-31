using UnityEngine;
using System.Collections;
using System.IO;

public class TenLotteryHandler  
{
    public enum ReqType
    { 
        NORMAL = 0,
        COIN_FREE,
        COIN_SINGLE,
        COIN_TEN,
        DIAMOND_FREE,
        DIAMOND_SINGLE,
        DIAMOND_TEN,
    }

    public static void SendTurntableInfoReq(ReqType _tp)
    {
        Common.ShowLoading(5);

        uint tp = (uint)_tp;

        TankProtocol.TurntableInfoReq tr = new TankProtocol.TurntableInfoReq();
        tr.type = tp;

        DispatcherProtoBuf.Instance.SendProtoBuffer("TurntableInfoReq", tr);
    }

    public static void OnRecvTurntableInfoRsp(byte[] data)
    {
        Common.HideLoading();

        MemoryStream m = new MemoryStream(data);
        TankProtocol.TurntableInfoRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.TurntableInfoRsp>(m);

        if (rsp == null)
            return;

        TenLotteryRedPointManager.OnRecvRspFromServer(rsp);

        if (UIShopMain.instance && UIShopMain.instance.gameObject.activeInHierarchy)
        {
            ///检查UI是否存在
            if (!UITenLottery.instane)
            {
                GameObject go = Common.GenerateResource("UI/Mall/UIMall_Arms");
                Common.AddToParent(go.transform, UIShopMain.instance.transform);
            }

            if (UIShopMain.instance)
            {
                UIShopMain.instance.showTog(UIShopMain.SHOP_MENU_TYPE.SHOP_ARMS);
            }
        }

        if(UITenLottery.instane)
            UITenLottery.instane.OnRecvRsp(rsp);    
    }
	
}
