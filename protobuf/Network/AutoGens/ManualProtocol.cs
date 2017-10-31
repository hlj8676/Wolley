using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class PVPScoreInfoExtra : IData
{
    public uint userID;
    public byte tankID;
    public byte tankType;
    public int hurt;
    public byte kill;
    public uint honor;
    public byte dead;
    public uint point;
    public uint freeReviveCount;
    public uint expendReviveCount;
    public uint assistant;
    public uint award;
    public uint vip;
    public uint extraItemID;
    public uint extraItemCount;
    public List<ItemInfo> itemList;
    public PVPScoreInfoExtra(uint userID, byte tankID, byte tankType, int hurt, byte kill, uint honor, byte dead, uint point, uint freeReviveCount, uint expendReviveCount, uint assistant, uint award, uint vip, uint extraItemID, uint extraItemCount, List<ItemInfo> itemList)
    {
        this.userID = userID;
        this.tankID = tankID;
        this.tankType = tankType;
        this.hurt = hurt;
        this.kill = kill;
        this.honor = honor;
        this.dead = dead;
        this.point = point;
        this.freeReviveCount = freeReviveCount;
        this.expendReviveCount = expendReviveCount;
        this.assistant = assistant;
        this.award = award;
        this.vip = vip;
        this.extraItemID = extraItemID;
        this.extraItemCount = extraItemCount;
        this.itemList = itemList;
    }
}


public enum BattleShootType
{
    NORMAL = 0,  //普通
    RICOCHET =1, //跳弹
    PENECHRATE = 2,//穿透
    CRITICAL = 3,  //暴击
    IMMUMN = 4, //免疫  
    PERFECT = 5  //完美一击
};


public class ManualProtocol
{

    public delegate void Delegate_ID_SKILL_DAMAGE_RSP(uint playerId, uint skillId, List<HurtInfo> hurtInfos, List<Point> points);
    public static Delegate_ID_SKILL_DAMAGE_RSP delegate_ID_SKILL_DAMAGE_RSP = null;

    public static void Recv_ID_SKILL_DAMAGE_RSP(RakNet.BitStream bs)
    {
        //Util.LogError("Recv_ID_SKILL_DAMAGE_RSP");
        int playerId;
        bs.ReadCompressed(out playerId);
        int skillId;
        bs.ReadCompressed(out skillId);
        short elapseSeconds;
        bs.ReadCompressed(out elapseSeconds);
        byte len;
        bs.ReadCompressed(out len);
      
        List<HurtInfo> list = new List<HurtInfo>();
        for (int i = 0; i < len; i++)
        {
            int target;
            bs.ReadCompressed(out target);
            int key;
            bs.ReadCompressed(out key);
            int value;
            bs.ReadCompressed(out value);

            HurtInfo val = new HurtInfo((uint)target, (uint)key, value); list.Add(val);
            list.Add(val);
        }


        bs.ReadCompressed(out len);

        List<Point> list2 = new List<Point>();
        for (int i = 0; i < len; i++)
        {
            short x;
            bs.ReadCompressed(out x);
            short y;
            bs.ReadCompressed(out y);

            Point p = new Point((ushort)x, (ushort)y);
            list2.Add(p);
        }



        if (delegate_ID_SKILL_DAMAGE_RSP != null)
        {
            delegate_ID_SKILL_DAMAGE_RSP((uint)playerId, (uint)skillId, list, list2);
        }
    }





    public delegate void Delegate_ID_BATTLE_SCORE_RSP(uint userID, byte tankID, byte tankType, int hurt, byte kill, uint honor, byte dead, uint point, uint freeReviveCount, uint expendReviveCount, uint assistant, uint award, uint vip, uint extraItemID, uint extraItemCount, List<ItemInfo> itemList);
    public static Delegate_ID_BATTLE_SCORE_RSP delegate_ID_BATTLE_SCORE_RSP = null;
    public delegate void Delegate_ID_BATTLE_SCORE_RSP_completed();
    public static Delegate_ID_BATTLE_SCORE_RSP_completed delegate_ID_BATTLE_SCORE_RSP_completed = null;

    public delegate void Delegate_ID_BATTLE_SCORE_RSP_1(PlayerBattleInfo[] infos);
    public static Delegate_ID_BATTLE_SCORE_RSP_1 delegate_ID_BATTLE_SCORE_RSP_1 = null;

    public static void Recv_ID_BATTLE_SCORE_RSP(RakNet.BitStream bs)
    {

        List<PlayerBattleInfo> infos = new List<PlayerBattleInfo>();

        while (bs.GetNumberOfUnreadBits() > 8)
        {
            int userID;
            bs.ReadCompressed(out userID);
            byte tankID;
            bs.ReadCompressed(out tankID);
            byte tankType;
            bs.ReadCompressed(out tankType);
            int hurt;
            bs.ReadCompressed(out hurt);
            byte kill;
            bs.ReadCompressed(out kill);
            int honor;
            bs.ReadCompressed(out honor);
            byte dead;
            bs.ReadCompressed(out dead);
            int point;
            bs.ReadCompressed(out point);

            int freeReviveCount;
            bs.ReadCompressed(out freeReviveCount);

            int expendReviveCount;
            bs.ReadCompressed(out expendReviveCount);
            int assistant;
            bs.ReadCompressed(out assistant);
            int award;
            bs.ReadCompressed(out award);
            int vip;
            bs.ReadCompressed(out vip);

            int extraItemID;
            bs.ReadCompressed(out extraItemID);

            int extraItemCount;
            bs.ReadCompressed(out extraItemCount);

            byte size;
            bs.ReadCompressed(out size);


           
            

            List<ItemInfo> itemList = new List<ItemInfo>();
            while (size > 0)
            {
                size--;
                int itemId;
                bs.ReadCompressed(out itemId);
                int count;
                bs.ReadCompressed(out count);
                ItemInfo ii = new ItemInfo((uint)itemId, (uint)count);
                itemList.Add(ii);
            }

            PlayerBattleInfo pif = new PlayerBattleInfo();
            pif.dead = dead;
            pif.expendReviveCount = expendReviveCount;
            pif.freeReviveCount = freeReviveCount;
            pif.honor = honor;
            pif.hurt = hurt;
            pif.itemList = itemList;
            pif.kill = kill;
            pif.point = point;
            pif.tankID = tankID;
            pif.tankType = tankType;
            pif.userID = (uint)userID;


            infos.Add(pif);

            

            if (delegate_ID_BATTLE_SCORE_RSP != null)
            {
                delegate_ID_BATTLE_SCORE_RSP((uint)userID, tankID, tankType, hurt, kill, (uint)honor, dead, (uint)point, (uint)freeReviveCount, (uint)expendReviveCount, (uint)assistant, (uint)award, (uint)vip, (uint)extraItemID, (uint)extraItemCount, itemList);
            }
        }
        if (delegate_ID_BATTLE_SCORE_RSP_completed != null)
        {
            delegate_ID_BATTLE_SCORE_RSP_completed();
        }

        if (delegate_ID_BATTLE_SCORE_RSP_1 != null)
        {
            delegate_ID_BATTLE_SCORE_RSP_1(infos.ToArray());
        }
    }


    public static void GlobalRegister(Dispatcher dispatcher)
    {
        dispatcher.Register((byte)MessageID.ID_SKILL_DAMAGE_RSP, Recv_ID_SKILL_DAMAGE_RSP);
        dispatcher.Register((byte)MessageID.ID_BATTLE_SCORE_RSP, Recv_ID_BATTLE_SCORE_RSP);
		dispatcher.Register((byte)MessageID.ID_PLAYER_DETAIL_INFO_RSP, Recv_ID_PLAYER_DETAIL_INFO_RSP);
    }

	public delegate void  Delegate_ID_PLAYER_DETAIL_INFO_RSP(int _errcode, byte type,uint hp,RakNet.RakString name,uint exp,ushort level,byte gender,uint gold,ushort energy,uint diamond,byte rank,uint rankLevel,uint active,uint honor,uint buyGoldTimes,uint buyEnergyTimes,bool ignoreTutorial,uint avatarid,uint strategypoint,uint dexp,uint rexp,uint yexp,uint sexp,uint mexp, uint globalExp, uint country,uint touchneedtime,byte touchremaincount,uint recharge,uint corpsid,uint armorpoint,uint recharge6,uint recharge30,uint recharge68,uint recharge128,uint recharge328,uint recharge648,uint monthCard25, uint invite, List<uint> list);
	public static  Delegate_ID_PLAYER_DETAIL_INFO_RSP delegate_ID_PLAYER_DETAIL_INFO_RSP = null;
	public static void Recv_ID_PLAYER_DETAIL_INFO_RSP(RakNet.BitStream bs)
	{
		int _errcode = 0;
		byte type;
		bs.ReadCompressed(out type);
		uint hp;
		bs.ReadCompressed(out hp);
		RakNet.RakString name;
		name = new RakNet.RakString();
		bs.ReadCompressed(name);
		uint exp;
		bs.ReadCompressed(out exp);
		ushort level;
		bs.ReadCompressed(out level);
		byte gender;
		bs.ReadCompressed(out gender);
		uint gold;
		bs.ReadCompressed(out gold);
		ushort energy;
		bs.ReadCompressed(out energy);
		uint diamond;
		bs.ReadCompressed(out diamond);
		byte rank;
		bs.ReadCompressed(out rank);
		uint rankLevel;
		bs.ReadCompressed(out rankLevel);
		uint active;
		bs.ReadCompressed(out active);
		uint honor;
		bs.ReadCompressed(out honor);
		uint buyGoldTimes;
		bs.ReadCompressed(out buyGoldTimes);
		uint buyEnergyTimes;
		bs.ReadCompressed(out buyEnergyTimes);
		bool ignoreTutorial;
		bs.ReadCompressed(out ignoreTutorial);
		uint avatarid;
		bs.ReadCompressed(out avatarid);
		uint strategypoint;
		bs.ReadCompressed(out strategypoint);
		uint dexp;
		bs.ReadCompressed(out dexp);
		uint rexp;
		bs.ReadCompressed(out rexp);
		uint yexp;
		bs.ReadCompressed(out yexp);
		uint sexp;
		bs.ReadCompressed(out sexp);
		uint mexp;
		bs.ReadCompressed(out mexp);
        uint globalExp;
        bs.ReadCompressed(out globalExp);
		uint country;
		bs.ReadCompressed(out country);
		uint touchneedtime;
		bs.ReadCompressed(out touchneedtime);
		byte touchremaincount;
		bs.ReadCompressed(out touchremaincount);
		uint recharge;
		bs.ReadCompressed(out recharge);
		uint corpsid;
		bs.ReadCompressed(out corpsid);
		uint armorpoint;
		bs.ReadCompressed(out armorpoint);
		uint recharge6;
		bs.ReadCompressed(out recharge6);
		uint recharge30;
		bs.ReadCompressed(out recharge30);
		uint recharge68;
		bs.ReadCompressed(out recharge68);
		uint recharge128;
		bs.ReadCompressed(out recharge128);
		uint recharge328;
		bs.ReadCompressed(out recharge328);
		uint recharge648;
		bs.ReadCompressed(out recharge648);
        uint monthCard25;
        bs.ReadCompressed(out monthCard25);
		uint invite;
		bs.ReadCompressed(out invite);

		List<uint>list = new List<uint>();
		while (bs.GetNumberOfUnreadBits () > 8) 
		{
			uint headinfo;
			bs.ReadCompressed (out headinfo);
			list.Add (headinfo);
		}

		if(delegate_ID_PLAYER_DETAIL_INFO_RSP!=null)
		{
			delegate_ID_PLAYER_DETAIL_INFO_RSP(_errcode, type, hp, name, exp, level, gender, gold, energy, diamond, rank, rankLevel, active, honor, buyGoldTimes, buyEnergyTimes, ignoreTutorial, avatarid, strategypoint, dexp, rexp, yexp, sexp, mexp, globalExp, country, touchneedtime, touchremaincount, recharge, corpsid, armorpoint, recharge6, recharge30, recharge68, recharge128, recharge328, recharge648,monthCard25,invite,list);
		}
	}
}
