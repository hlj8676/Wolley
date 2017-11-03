using network.message;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



namespace network
{


	public class ProtoSocket
	{

		private SocketClient _socketClient;

		private Dictionary<string , Type> _protoSendKMap;
		private Dictionary<Type , string> _protoSendTMap;
		private Dictionary<Type , Action<object>> _protoReceiveMap;


		private Action onDisconnectSocket;
		public ProtoSocket( Action onDisdonnectd )
		{
			onDisconnectSocket = onDisdonnectd;
			_protoSendKMap = new Dictionary<string , Type>();
			_protoSendTMap = new Dictionary<Type , string>();
			_protoReceiveMap = new Dictionary<Type , Action<object>>();

			_socketClient = new SocketClient(onConnectedHandler , onDisonnectedHandler , onReceivedMessageHandler);
		}

		public bool IsConnected { get { return _socketClient.IsConnected; } }

#if UNITY_EDITOR
		//重连测试
		internal SocketClient Socket { get { return _socketClient; } }
#endif
		public bool ConnectToServer( string address , int port , Action onConnect )
		{
			onConnectSuccess = onConnect;
			return _socketClient.ConnectServer(address , port);
		}


		public void Disconnect()
		{
			_socketClient.ConnectClose(false);
		}



		internal bool registerSendProtoBuf( Type type )
		{
			if( _protoSendTMap.ContainsKey(type) )
			{
				Debug.LogError(" [NetworkController] registerSendProtoBuf repeated !!! ");
				return false;
			}

			return executeRegSendProto(type);
		}


		internal bool registerReceiveProtoBuf( Type type , Action<object> cbFun )
		{
			if( _protoReceiveMap.ContainsKey(type) )
			{
				Debug.LogErrorFormat(" [NetworkController] registerReceiveProtoBuf {0} repeated !!! " , type.Name);
				return false;
			}

			if( registerSendProtoBuf(type) )
			{
				_protoReceiveMap[type] = cbFun;
				return true;
			}

			Debug.LogError(" [NetworkController] registerReceiveProtoBuf failed !!! ");
			return false;
		}


		private bool executeRegSendProto( Type type )
		{
			string typeS = type.ToString();
			string[] tempArr = typeS.Split('.');

			if( tempArr.Length != 3 )
			{
				return false;
			}

			_protoSendKMap[tempArr[2]] = type;
			_protoSendTMap[type] = tempArr[2];

			return true;
		}


		internal void sendMsg( object protoMsg )
		{
			string head = getMsgHead(protoMsg);
			if( head == "" )
			{
				Debug.LogError(" [NetworkController] SendMsg Error head = null ");
				return;
			}

			MemoryStream ms = new MemoryStream();
			ProtoBuf.Serializer.Serialize(ms , protoMsg);

			FSMessage fsMsg = new FSMessage();
			fsMsg.head = head;
			fsMsg.body = ms.ToArray();

			ms = new MemoryStream();
			ProtoBuf.Serializer.Serialize(ms , fsMsg);

			_socketClient.WriteMessage(ms.ToArray());
		}


		private string getMsgHead( object protoMsg )
		{
			Type tempT = protoMsg.GetType();
			if( _protoSendTMap.ContainsKey(tempT) )
			{
				return _protoSendTMap[tempT];
			}
			else
			{
				if( executeRegSendProto(tempT) )
				{
					return _protoSendTMap[tempT];
				}
			}

			return "";
		}


		//---------------------- handler ------------------------------------
		internal void onConnectedHandler()
		{
			Debug.Log(" [NetworkController] Socket is connected !!! ");

			Loom.QueueOnMainThread(( parm ) =>
			{
				if( null != onConnectSuccess )
				{
					onConnectSuccess();
					onConnectSuccess = null;
				}
			} , null);
		}


		private Action onConnectSuccess;


		internal void onDisonnectedHandler()
		{
			Debug.LogError(" [NetworkController] Socket is disonnected !!! ");

			_socketClient = null;
			_socketClient = new SocketClient(onConnectedHandler , onDisonnectedHandler , onReceivedMessageHandler);

			Loom.QueueOnMainThread(( parm ) =>
			{
				onDisconnectSocket();
			} , null);
		}



		internal void onReceivedMessageHandler( byte[] data )
		{
			FSMessage fsMsg = ProtoBuf.Serializer.Deserialize<FSMessage>(new MemoryStream(data));

			if( fsMsg == null )
			{
				Debug.LogError(" [NetworkController] onReceivedMessageHandler Error data = null ");
				return;
			}

			if( !_protoSendKMap.ContainsKey(fsMsg.head) )
			{
				Debug.LogError(" [NetworkController] onReceivedMessageHandler Not Have Key[" + fsMsg.head + "] ");
				return;
			}

			Type tempT = _protoSendKMap[fsMsg.head];

			if( !_protoReceiveMap.ContainsKey(tempT) )
			{
				Debug.LogError(" [NetworkController] onReceivedMessageHandler Not Have Type[" + tempT + "] ");
				return;
			}

			object msgBody = ProtoBuf.Serializer.Deserialize(tempT , new MemoryStream(fsMsg.body));
			_protoReceiveMap[tempT](msgBody);
		}



	}

}

