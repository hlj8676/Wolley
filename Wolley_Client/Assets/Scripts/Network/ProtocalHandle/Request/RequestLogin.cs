
using network;
using network.message;

namespace Protocal
{
	public class RequestLogin
	{
		public void OnRequest_Login( long uid , string version , int cityId )
		{
			OnRequest_Reg(uid , version , cityId);
		}

		//public void OnRequest_Login( string strUserID , string strPassword )
		//{
		//	LoginRequest req = new LoginRequest();

		//	req.uid = 1;
		//	req.ttp = 3215647;
		//	req.token = "token123456478";
		//	req.udid = "udidadid";
		//	req.userName = "1000102";
		//	req.accountType = 1;
		//	req.serverId = 1;

		//	NetworkController.getInstance().sendMsg(req);
		//}

		private void OnRequest_Reg( long uid , string version , int cityId )
		{
			LoginRequest req = new LoginRequest();

			req.uid = uid;
			//req.ttp = 3215647;
			//req.uid6w = SixWaves.Intance.UID;
			//req.token = SixWaves.Intance.Token;
			//req.udid = "udidadid";
			//req.userName = "1000102";
			//req.accountType = 1;
			//req.serverId = 1;
			//req.version = version;
			//req.cityId = cityId;
			NetworkController.getInstance().sendMsg(req);
		}


		public void StoryGuideComplete()
		{
			//NetworkController.getInstance().sendMsg(new StoryGuideCompleteRequest { });
		}





		public void SearchUser( long uid )
		{
			//NetworkController.getInstance().sendMsg(new SearchUserRequest() { uid = uid });
		}




		//SearchUserRequest


	}
}