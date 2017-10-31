using UnityEngine;

using System.Collections;
using System.IO;
using System.Collections.Generic;

using DataWrapper;

public class TankChestHandler
{

    /// <summary>
    /// 射击
    /// </summary>
    /// <param name="type">1平民弹药 2超级弹药</param>
    /// <param name="choice">宝箱编号1-3</param>
    /// <param name="ten">1一发 2十连</param>
    public static void SendCopyChestReq(uint type, uint choice, uint ten)
    {
        Common.ShowLoading(5);

        TankProtocol.TankChestReq ps = new TankProtocol.TankChestReq();
        ps.type = type;
        ps.choice = choice;
        ps.ten = ten;

        DispatcherProtoBuf.Instance.SendProtoBuffer("TankChestReq", ps);
    }

    public static void OnRecvCopyChestRsp(byte[] data)
    {
        Common.HideLoading();

        MemoryStream m = new MemoryStream(data);
        TankProtocol.TankChestRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.TankChestRsp>(m);

        if(rsp.errcode == 0)
        {
            if(UICopyChestBattle.instance != null)
            {
                UICopyChestBattle.instance.updateDataText();
            }
        }
        else
        {
            UIMessageBox.Show(rsp.errcode);
        }
    }

    /// <summary>
    /// 购买弹药
    /// </summary>
    /// <param name="count">数量</param>
    public static void SendBuySuperBulletReq(uint count)
    {
        Common.ShowLoading(5);

        TankProtocol.BuySuperBullet ps = new TankProtocol.BuySuperBullet();
        ps.count = count;

        DispatcherProtoBuf.Instance.SendProtoBuffer("BuySuperBullet", ps);
    }

    public static void OnRecvBuySuperBulletRsp(byte[] data)
    {
        Common.HideLoading();

        MemoryStream m = new MemoryStream(data);
        TankProtocol.BuySuperBulletRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.BuySuperBulletRsp>(m);

        if (rsp.errcode == 0)
        {
            UICopyChestBattle.instance.updateDataText();
        }
        else
        {
            UIMessageBox.Show(rsp.errcode);
        }
    }
}