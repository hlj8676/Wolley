using UnityEngine;
using System.Collections;
using System;

public class Protocal_Handle
{
	public static void RegisterReceiveProtocalHandle( System.Type type , System.Action<object> cbFun )
	{
		network.NetworkController.getInstance().registerReceiveProtoBuf(type , cbFun);
	}

	public static void Init()
	{
		//Protocal.ResponseBuilding.OnRegister();
		Protocal.ResponseLogin.OnRegister();
		//Protocal.ResponseResources.OnRegister();
		//Protocal.ResponseTimer.OnRegister();
		//Protocal.ResponseQuest.OnRegister();
		//Protocal.ResponseUser.OnRegister();
		//Protocal.ResponseItem.OnRegister();
		//Protocal.ResponseTroop.OnRegister();
		//Protocal.ResponseMap.OnRegister();
		//Protocal.ResponseResearch.OnRegister();
		//Protocal.ResponseMail.OnRegister();
		//Protocal.ResponseHero.OnRegister();
		//Protocal.ResponseRecruitHall.OnRegister();
		//Protocal.ResponseBuff.OnRegister();
		//Protocal.ResponseMarch.OnRegister();
		//Protocal.ResponseMapUserNtf.OnRegister();
		//Protocal.ResponseMapAlert.OnRegister();
		//Protocal.ResponseMapMail.OnRegister();
		//Protocal.ResponseChest.OnRegister();
		//Protocal.ResponseFight.OnRegister();
		//Protocal.ResponseGarrison.OnRegister();
		//Protocal.ResponseRepair.OnRegister();
		//Protocal.ResponsePay.OnRegister();
		//Protocal.ResponseVip.OnRegister();
		//Protocal.ResponseEvent.OnRegister();
		//Protocal.ResponseAlliance.OnRegister();
		//Protocal.ResponseBlackmarket.OnRegister();
		//Protocal.ResponseActivity.OnRegister();
		//Protocal.ResponseMapPve.OnRegister();
		//Protocal.ResponseUserStatistics.OnRegister();
		//Protocal.ResponseOffline.OnRegister();
		//Protocal.ResponseManoeuver.OnRegister();
		//Protocal.ResponseManoeuverShop.OnRegister();
		//Protocal.ResponsePVE.OnRegister();
		//Protocal.ResponseFtue.OnRegister();
		//Protocal.ResponseCapital.OnRegister();
		//Protocal.ResponseScroll.OnRegister();
		//Protocal.ResponseHuoDong.OnRegister();
		//Protocal.ResponseRanking.OnRegister();
		//Protocal.ResponseHeartBeat.OnRegister();
	}



	private static Action<object> RunMainThread<T>( Action<T> action )
	{
		return delegate ( object obj )
		{
			Loom.QueueOnMainThread(delegate ( object parm )
			{
				T value = (T)parm;
				if( null != value )
				{
					action(value);
				}
				else
				{
					Debug.LogWarningFormat("OnResponse{0} is null" , typeof(T));
				}
			}
						, obj);
		};
	}


	public static void RegisterReceiveProtocal<T>( Action<T> action )
	{
		network.NetworkController.getInstance().registerReceiveProtoBuf(typeof(T) , RunMainThread<T>(action));
	}



}