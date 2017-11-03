using UnityEngine;
using System.Collections;

using network.message;
using System;

namespace Protocal
{
	public class ResponseLogin
	{
		public static void OnRegister()
		{
			Protocal_Handle.RegisterReceiveProtocal<LoginResponse>(OnResponse_LoginResponse);
			//Protocal_Handle.RegisterReceiveProtocal<KickNtf>(OnNetKickNtf);
			//Protocal_Handle.RegisterReceiveProtocal<ChatDataNtf>(OnNetChatDataNtf);
			//Protocal_Handle.RegisterReceiveProtocal<ChatTokenNtf>(OnNetChatTokenNtf);


			//Protocal_Handle.RegisterReceiveProtocal<SearchUserResponse>(OnNetSearchUserResponse);

		}


		private static void OnResponse_LoginResponse( LoginResponse value )
		{
			Debug.LogFormat("    #####    Login Success ########  ");
			//MainValue.mxDataManager.HostUserInfoData.OnNetLoginResult(value.result , value.userInfo);
		}



		//private static void OnNetKickNtf( KickNtf value )
		//{
		//	Debug.LogError("OnNetKickNtf : " + value.result);
		//	App.Instance.ReLoadGame();
		//}


		//private static void OnNetChatDataNtf( ChatDataNtf value )
		//{
		//	try
		//	{
		//		MainValue.mxDataManager.ChatManager.OnNetChatDataNtf(value);
		//	}
		//	catch( Exception e )
		//	{
		//	}
		//}


		//private static void OnNetChatTokenNtf( ChatTokenNtf value )
		//{
		//	Debug.LogFormat("OnNetChatTokenNtf: opCode = {0} , host = {1} , port = {2} " , value.opCode , value.info.host , value.info.port);

		//}




		//private static void OnNetSearchUserResponse( SearchUserResponse value )
		//{
		//	MainValue.mxDataManager.HostUserInfoData.OnNetSearchUserResponse(value.result);

		//}

	}
}
