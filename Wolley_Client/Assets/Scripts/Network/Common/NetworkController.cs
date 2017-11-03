using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using network.message;



namespace network
{

	public class NetworkController : ProtoSocket
	{
		private static NetworkController _instance;

		public static NetworkController getInstance()
		{
			if( _instance == null )
			{
				_instance = new NetworkController();
			}
			return _instance;
		}

		public NetworkController() : base(delegate
		{ App.Instance.OnNetDisonnected(); })

		{
		}
	}
}