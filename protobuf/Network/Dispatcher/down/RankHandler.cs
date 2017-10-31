using UnityEngine;

using System.Collections;
using System.IO;
using System.Collections.Generic;

public class RankHandler
{
    public delegate void OnExpUnLockCallBack(bool fale);
    public static OnExpUnLockCallBack unLockCallBack;

    //请求排行榜数据
    public static void SendAskRankListReq(TankProtocol.RankListType rankListType, uint startIndex)
    {
        Common.ShowLoading(5);

        TankProtocol.AskRankListReq ps = new TankProtocol.AskRankListReq();
        ps.RankListType = rankListType;
        ps.StartIndex = startIndex;
        ps.AskCount = int.Parse(SysEnv.parameters["popularityRefresh"]);

        DispatcherProtoBuf.Instance.SendProtoBuffer("AskRankListReq", ps);
    }

    public static void SendAskRankListReq(TankProtocol.RankListType rankListType, uint startIndex,int count)
    {
        Common.ShowLoading(5);

        TankProtocol.AskRankListReq ps = new TankProtocol.AskRankListReq();
        ps.RankListType = rankListType;
        ps.StartIndex = startIndex;
        ps.AskCount = count;

        DispatcherProtoBuf.Instance.SendProtoBuffer("AskRankListReq", ps);
    }

    //请求个人排行榜数据
    public static void SendAskMyRankListReq(TankProtocol.RankListType rankListType)
    {
        TankProtocol.AskMyRankReq ps = new TankProtocol.AskMyRankReq();
        ps.RankListType = rankListType;
        DispatcherProtoBuf.Instance.SendProtoBuffer("AskMyRankReq", ps);
    }

    //排行榜数据
    public static void OnRecvAskRankListRsp(byte[] data)
    {
        Common.HideLoading();

        MemoryStream m = new MemoryStream(data);

        TankProtocol.AskRankListRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.AskRankListRsp>(m); 

        if(rsp != null && rsp.playerInfo != null)
        {
            DataWrapper.PlayerRank tempRank = DataWrapper.Player.instance.rank;
            TankProtocol.RankListType type = (TankProtocol.RankListType)rsp.RankListType;

            if(tempRank != null)
            {
                 TankProtocol.PlayerRankInfo rankInfo = null;
                 
                 for(int i = 0; i < rsp.playerInfo.Count; i++)
                 {
                     rankInfo = rsp.playerInfo[i];
                     string str = System.Text.Encoding.GetEncoding("UTF-8").GetString(rankInfo.name);
                     tempRank.addRankList(type, str, rankInfo.id, rankInfo.avatarid, getRankValue(rankInfo.rankParamList, 1), getRankValue(rankInfo.rankParamList, 2), getRankValue(rankInfo.rankParamList, 3));
                 }
            }

            SuperBOBO.EventManager.Instance.FireEvent(GameEventType.RankRecvList, type);
        }
    }

    //个人排行榜数据
    public static void OnRecvAskMyRankListRsp(byte[] data)
    {
        MemoryStream m = new MemoryStream(data);

        TankProtocol.AskMyRankRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.AskMyRankRsp>(m);

        if (rsp != null)
        {
            DataWrapper.PlayerRank tempRank = DataWrapper.Player.instance.rank;

            if (tempRank != null)
            {
                tempRank.addMyList(rsp.RankListType, (int)rsp.Rank, (int)rsp.Score, (int)rsp.Popular, (int)rsp.Param);
            }
        }
    }

    private static int getRankValue(List<TankProtocol.RankParam> paramList, int type)
    {
        int value = 0;

        if(paramList != null)
        {
            foreach (TankProtocol.RankParam param in paramList)
            {
                if (param != null && param.type == type)
                {
                    value = param.value;
                    break;
                }
            }
        }

        return value;
    }

    //------------------------------------------------- 车库 --------------------------------------

    public static List<uint> unLockTankID = new List<uint>();

    //车库研发
    public static void OnRecvActivedTankIDRsp(byte[] data)
    {
        unLockTankID.Clear();

        MemoryStream m = new MemoryStream(data);

        TankProtocol.ActivedTankIDRsp rsp = ProtoBuf.Serializer.Deserialize<TankProtocol.ActivedTankIDRsp>(m);

        if (rsp != null && rsp.tankconfigid != null)
        {
            foreach (uint tankId in rsp.tankconfigid)
            {
                unLockTankID.Add(tankId);
            }
        }

        if (UIWareHouseNew.instance != null)
        {
            UIWareHouseNew.instance.updateUnLock();
        }

        if( unLockCallBack != null)
        {
            unLockCallBack(false);
            unLockCallBack = null;
        }
    }

    //研发解锁
    public static void SendUnLockTankReq(uint type, uint tankConfigid)
    {
        TankProtocol.UnlockTank ps = new TankProtocol.UnlockTank();
        ps.type = type;
        ps.tankconfigid = tankConfigid;

        DispatcherProtoBuf.Instance.SendProtoBuffer("UnlockTank", ps);
    }

}
