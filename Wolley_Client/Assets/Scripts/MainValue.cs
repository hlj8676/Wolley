//using Game.Data;
//using network;

public class MainValue
{
	// public const string SOCKET_IP_ADDRESS = "jc-demo.6waves.com";
	//public const string defaultServerAddress = "jc-demo.6waves.com";
	//public const int defaultServerPort = 2013;


	public const int majorVersion = 0;
	public const int minorVersion = 51;
	public const int revisionVersion = 0;

	//public const string DefaultLanguage = "EN";
	//public const string DefaultLanguageKey = "Language";


	//public static bool isShowLand = false;

	public static string Version { get { return string.Format("{0}.{1}.{2}" , majorVersion , minorVersion , revisionVersion); } }


	public static string DbFileName { get { return "slg_sqlite.db"; } }
	//public static string LuaCodeFileName { get { return "luacode.unity3d"; } }


	//private static NetworkController networkController;
	//private static CSVManager csvManager = new CSVManager();
	//private static DataManager dataManager = new DataManager();
	//private static DelayCallAction delayCall = new DelayCallAction();
	//private static DelegateManager delegateMgr = new DelegateManager();

	
	//public static NetworkController mxNetworkController { get { return networkController; } }

	//public static TaskManager mxTaskManager { get { return dataManager.TaskData; } }
	//public static CSVManager mxCSVManager { get { return csvManager; } }
	//public static DataManager mxDataManager { get { return dataManager; } }
	//public static DelayCallAction mxDelayInvoke { get { return delayCall; } }

	//public static DelegateManager mxDelegateManager { get { return delegateMgr; } }

	public static LuaMainValue mxLuaMain { get; private set; }
	//public static ILuaUiManager mxLuaUiManager { get { return mxLuaMain.GetUIManager(); } }
	//public static ILuaWorldGuiManager mxLuaWorldGui { get { return mxLuaMain.GetWorldGuiManager(); } }

	public static void Init()
	{
		//networkController = NetworkController.getInstance();

		//Protocal_Handle.Init();
		//csvManager.Init();

		//string lang = UnityUtil.UnityHelper.GetPlayerPrefsString(DefaultLanguageKey);
		//if( string.IsNullOrEmpty(lang) )
		//{
		//	lang = DefaultLanguage;
		//}

		//if( !csvManager.SetLanguage(lang) )
		//{
		//	csvManager.SetLanguage(DefaultLanguage);
		//}

		//dataManager.Init();
	}




	internal static void InitLua( LuaMainValue luaMainValue )
	{
		mxLuaMain = luaMainValue;
	}


	public static void UnInit()
	{
		//mxDataManager.ChatManager.Disconnect();
		//mxNetworkController.Disconnect();


		// delegateMgr.UnInit();

		mxLuaMain = null;


		//csvManager.Dispose();
	}



	public static void Update( float deltaTime )
	{
		//delayCall.Update(deltaTime);
		if( null != mxLuaMain )
		{
			mxLuaMain.Update();
		}
	}



	public static void UpdatePreSecond()
	{
		//if( dataManager.HostUserInfoData.isLogin )
		//{
		//	dataManager.ResourceData.UpdatePreSecond();
		//	dataManager.ChatManager.UpdatePreSecond();
			mxLuaMain.UpdatePreSecond();
		//}
	}


	public static void Reset()
	{
		//dataManager.Reset();
		//delayCall.Reset();
		//mxTaskManager.Reset();
		mxLuaMain.Reset();

		//if(App.IsWorld)
		//{
		//	delegateMgr.Reset();
		//}
	}


	public static string GetCopyFilePath()
	{
#if UNITY_STANDALONE && !UNITY_EDITOR
		string path = UnityEngine.Application.dataPath;
#else
		string path = System.IO.Path.Combine(UnityEngine.Application.persistentDataPath , Version);
#endif
		return path;
	}

	public static string GetDbFileName()
	{
		string dbFileName = System.IO.Path.Combine(GetCopyFilePath() , DbFileName);
		return dbFileName;
	}




	public static string GetHotfixDbFileName()
	{
		string dbFileName = System.IO.Path.Combine(HotfixPath , DbFileName);
		return dbFileName;
	}



	private static string HotfixPathName { get { return "hotfix/assets"; } }
	public static string HotfixPath
	{
		get
		{
			string hotfixPath = System.IO.Path.Combine(UnityEngine.Application.persistentDataPath , HotfixPathName);
			return hotfixPath;
		}
	}


}
