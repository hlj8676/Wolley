using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace network
{
	class SocketClient : IDisposable
	{
		private const int MAX_PKT_SIZE = 32767;

		private byte[] byteBuffer = new byte[MAX_PKT_SIZE];
		private TcpClient _client;
		private MemoryStream _memStream;
		private BinaryReader _reader;


		private Action onControlConnect;
		private Action onControlDiconnected;
		private Action<byte[]> onControlReceived;

		public bool IsConnected { get { return _client != null ? _client.Connected : false; } }
		public SocketClient( Action onConnect , Action onDisconnect , Action<byte[]> onReceived )
		{
			onControlConnect = onConnect;
			onControlDiconnected = onDisconnect;
			onControlReceived = onReceived;
		}


		private string connect_host;
		private int connect_port;

		/// <summary>
		/// 连接服务器 
		/// </summary>
		public bool ConnectServer( string host , int port )
		{
			if( _client != null )
			{
				Debug.LogError(" WARNNING ---> SocketClient is connected !!! ");
				return false;
			}

			Debug.LogFormat(" ConnectServer ( {0} , {1} ) " , host , port);
			connect_host = host;
			connect_port = port;
#if UNITY_IOS
			if( isIPAddress(host) )
			{
				InitTcpClient(AddressFamily.InterNetwork);
				try
				{
					_client.BeginConnect( host , port , OnConnectedHandler , null);
				}
				catch( Exception e )
				{
					Debug.LogError(e.Message);
					ConnectClose();
					return false;
				}
			}
			else
			{
				try
				{
					Dns.BeginGetHostEntry(host , ar => { OnGetHostEntryHandle(ar , port); } , null);
				}
				catch( Exception e )
				{
					OnDisconnected(e.Message);
					return false;
				}
			}
			return true;
#else
			InitTcpClient(AddressFamily.InterNetwork);
			try
			{
				_client.BeginConnect(host , port , OnConnectedHandler , null);
			}
			catch( Exception e )
			{
				OnDisconnected(e.Message);
				return false;
			}
#endif
			return true;
		}


		private static bool isIPAddress( string ip )
		{
			bool foundMatch = false;
			try
			{
				foundMatch = System.Text.RegularExpressions.Regex.IsMatch(ip , @"\d+\.\d+\.\d+\.\d+" , System.Text.RegularExpressions.RegexOptions.Singleline);
			}
			catch( ArgumentException ex )
			{
			}
			return foundMatch;
		}


		private static bool isHaveIPv4( IPAddress[] addressList )
		{
			foreach( IPAddress ip in addressList )
			{
				if( ip.AddressFamily == AddressFamily.InterNetwork )
				{
					return true;
				}
			}
			return false;
		}


		private void OnGetHostEntryHandle( IAsyncResult ar , int port )
		{
			try
			{
				IPHostEntry entry = Dns.EndGetHostEntry(ar);
				IPAddress[] addressList = entry.AddressList;
				AddressFamily family = isHaveIPv4(addressList) ? AddressFamily.InterNetwork : AddressFamily.InterNetworkV6;
				//Debug.LogFormat("AddressFamily = {0}" , family);
				InitTcpClient(family);
				_client.BeginConnect(addressList , port , OnConnectedHandler , null);
			}
			catch( Exception e )
			{
				OnDisconnected(e.Message);
			}
		}


		private void InitTcpClient( AddressFamily family )
		{
			_memStream = new MemoryStream();
			_reader = new BinaryReader(_memStream);

			_client = new TcpClient(family);
			_client.SendTimeout = 1000;
			_client.ReceiveTimeout = 1000;
			_client.NoDelay = true;
		}


#if UNITY_EDITOR
		//重连测试
		public void shutdown()
		{
			if( null != _client )
			{
				_client.Close();
			}
		}
#endif
		/// <summary>
		/// 关闭链接
		/// </summary>
		public void ConnectClose( bool useDisconnectdEvent = true )
		{
			if( _client == null )
			{
				return;
			}

			Dispose();

			if( useDisconnectdEvent )
			{
				onControlDiconnected();
			}
		}

		/// <summary>
		/// 连接上服务器
		/// </summary>
		private void OnConnectedHandler( IAsyncResult asr )
		{
			_client.GetStream().BeginRead(byteBuffer , 0 , MAX_PKT_SIZE , OnReadMsgHandler , null);
			onControlConnect();
		}

		/// <summary>
		/// 读取消息
		/// </summary>
		private void OnReadMsgHandler( IAsyncResult msg )
		{
			int bytesRead = 0;
			try
			{
				lock( _client.GetStream() )
				{
					//读取字节流到缓冲区
					bytesRead = _client.GetStream().EndRead(msg);
				}
				if( bytesRead < 1 )
				{//包尺寸有问题，断线处理
					OnDisconnected("bytesRead < 1");
					return;
				}
				//分析数据包内容，抛给逻辑层
				receiveMsgHandler(byteBuffer , bytesRead);
				lock( _client.GetStream() )
				{
					//分析完，再次监听服务器发过来的新消息
					//清空数组
					Array.Clear(byteBuffer , 0 , byteBuffer.Length);
					_client.GetStream().BeginRead(byteBuffer , 0 , MAX_PKT_SIZE , OnReadMsgHandler , null);
				}
			}
			catch( Exception ex )
			{
				//PrintBytes();
				OnDisconnected(ex.Message);
			}
		}

		/// <summary>
		/// 接收到消息
		/// </summary>
		private void receiveMsgHandler( byte[] bytes , int length )
		{
			_memStream.Seek(0 , SeekOrigin.End);
			_memStream.Write(bytes , 0 , length);
			//Reset to beginning
			_memStream.Seek(0 , SeekOrigin.Begin);
			UInt32 messageLen = 0;
			while( getRemainingBytes() > 4 )
			{
				messageLen = (UInt32)_reader.ReadInt32();
				if( BitConverter.IsLittleEndian )
				{
					messageLen = ConverterBigLittle.ReverseBytes(messageLen);
				}
				if( getRemainingBytes() >= messageLen )
				{
					MemoryStream msg = new MemoryStream();
					BinaryWriter writer = new BinaryWriter(msg);
					writer.Write(_reader.ReadBytes((int)messageLen));
					msg.Seek(0 , SeekOrigin.Begin);
					OnReceivedMessage(msg);
				}
				else
				{
					_memStream.Position = _memStream.Position - 4;
					break;
				}
			}
			byte[] leftover = _reader.ReadBytes((int)getRemainingBytes());
			_memStream.SetLength(0);
			_memStream.Write(leftover , 0 , leftover.Length);
		}

		/// <summary>
		/// 剩余的字节
		/// </summary>
		private long getRemainingBytes()
		{
			return _memStream.Length - _memStream.Position;
		}

		/// <summary>
		/// 丢失链接
		/// </summary>
		private void OnDisconnected( string msg )
		{
			ConnectClose();   //关掉客户端链接
			Debug.LogErrorFormat(" SocketClient {0}:{1} disconnected :[ {2} ]" , connect_host , connect_port , msg);
		}

		/// <summary>
		/// 接收到消息
		/// </summary>
		/// <param name="ms"></param>
		private void OnReceivedMessage( MemoryStream ms )
		{
			BinaryReader r = new BinaryReader(ms);
			byte[] data = r.ReadBytes((int)( ms.Length - ms.Position ));
			//ByteBuffer buffer = new ByteBuffer(message);
			//int size = buffer.ReadInt();
			//NetManager.Instance.DispatchProto(size, buffer);
			onControlReceived(data);

		}

		/// <summary>
		/// 写数据
		/// </summary>
		public void WriteMessage( byte[] message )
		{
			if( message == null )
				return;

			if( _client == null || !_client.Connected )
			{
				Debug.LogError("WriteMessage failed :::  client.connected----->>false");
				//UIManager.Instance.ShowMessage("Error:Connect Failed!");
				return;
			}

			MemoryStream msg = null;
			using( msg = new MemoryStream() )
			{
				msg.Position = 0;
				BinaryWriter writer = new BinaryWriter(msg);
				UInt32 msglen = (UInt32)message.Length;

				if( BitConverter.IsLittleEndian )
				{
					msglen = ConverterBigLittle.ReverseBytes(msglen);
				}

				writer.Write(msglen);
				writer.Write(message);
				//writer.Write(msg);
				writer.Flush();

				byte[] payload = msg.ToArray();
				_client.GetStream().BeginWrite(payload , 0 , payload.Length , OnWrite , null);
			}
		}

		/// <summary>
		/// 向链接写入数据流
		/// </summary>
		private void OnWrite( IAsyncResult r )
		{
			try
			{
				_client.GetStream().EndWrite(r);
			}
			catch( Exception ex )
			{
				Debug.LogError("onWrite--->>>" + ex.Message);
			}
		}


		public void Dispose()
		{
			if( _client != null )
			{
				( (IDisposable)_client ).Dispose();
			}
			if( _memStream != null )
			{
				_memStream.Dispose();
			}
			if( _reader != null )
			{
				( (IDisposable)_reader ).Dispose();
			}
			_client = null;
			_memStream = null;
			_reader = null;
		}
	}
}
