using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
	public static App Instance;

	private LuaMain luaMain;

	// Use this for initialization
	void Start()
	{
		Debug.LogWarning("CultureInfo = " + System.Globalization.CultureInfo.CurrentCulture);
		Debug.LogWarning("Application.systemLanguage = " + Application.systemLanguage);


		Instance = this;

		//SixWaves.Intance.Init();
		//Analysis.Intance.Add(SixWaves.Intance);

		//IAP.Intance.Init();
		//IAP.Intance.BuyResult = OnBuyResult;

		DontDestroyOnLoad(this);

		//Loom.Initialize();

		// 网络初始化
		//MainValue.Init();
		//MainValue.mxCSVManager.MapData.Read();

		luaMain = new LuaMain();
		LuaMainValue luaMainValue = luaMain.InitLuaEnv();

		//MainValue.InitLua(luaMainValue);
		luaMain.InitLuaEvent();

		//MainState.Init();

		string isDebug = PlayerPrefs.GetString("isDebug");
		if( isDebug == "true" )
		{
			SetDebug(true);
		}
		else
		{
			SetDebug(false);
		}

		// 限制帧率60
		Application.targetFrameRate = 60;
	}



	//private void OnBuyResult( string skuId , string originalJson , string signature )
	//{
	//	List<network.message.IapPackageInfo> info = MainValue.mxDataManager.PayData.Info;
	//	int packageId = 0;
	//	if( null != info )
	//	{
	//		network.message.IapPackageInfo value = info.Find(e => e.productId == skuId);
	//		if( null != value )
	//		{
	//			packageId = value.id;
	//		}
	//	}

	//	C2S._pay.RequestIapBuyFinish(packageId , skuId , originalJson , signature);
	//}




	internal void SetDebug( bool isDebug )
	{
		//FPSCounter fps = gameObject.GetComponent<FPSCounter>();
		//if( isDebug )
		//{
		//	if( null == fps )
		//	{
		//		fps = gameObject.AddComponent<FPSCounter>();
		//	}

		//	Game.Type.ConstValue.isDebug = true;

		//	PlayerPrefs.SetString("isDebug" , "true");
		//}
		//else
		//{
		//	Game.Type.ConstValue.isDebug = false;

		//	PlayerPrefs.SetString("isDebug" , "false");
		//}

		//if( null != fps )
		//{
		//	fps.enabled = isDebug;
		//}


	}



	private void OnDisable()
	{
		//if( null != MainValue.mxLuaUiManager )
		//{
		//	MainValue.mxLuaUiManager.GameGuiCloseAll();
		//}

		//if( null != MainValue.mxLuaWorldGui )
		//{
		//	MainValue.mxLuaWorldGui.CloseAllBuildingMenu();
		//}
	}


	void OnDestroy()
	{
		//MainValue.UnInit();
		luaMain.Dispose();
		luaMain = null;

	}



	float duration = 0;

	void Update()
	{
		duration += Time.deltaTime;
		if( duration > 1.0f )
		{
			UpdatePreSecond();
			duration -= 1.0f;
		}

		if( Input.GetKeyDown(KeyCode.Escape) )
		{
			Debug.Log("KeyEscape");
			//MainValue.mxLuaUiManager.OnKeyBack();
		}

#if UNITY_EDITOR
		if( Input.GetKeyDown(KeyCode.F1) )
		{
			Debug.LogError("Resources.UnloadUnusedAssets");

			Resources.UnloadUnusedAssets();
			System.GC.Collect();
			System.GC.WaitForPendingFinalizers();
		}
		else if( Input.GetKeyDown(KeyCode.F2) )
		{
			Debug.LogError("F2");
			//MainState.Reset();

			//C2S._capital.OnRequest_CapitalsOccupyInfoRequest();

		}

		//重连测试
		if( Input.GetKeyDown(KeyCode.F9) )
		{
			//network.NetworkController.getInstance().Socket.shutdown();
		}

		//debug
		if( Input.GetKeyDown(KeyCode.F8) )
		{
			//FPSCounter fps = gameObject.GetComponent<FPSCounter>();
			//if( null == fps )
			//{
			//	fps = gameObject.AddComponent<FPSCounter>();
			//}

			//fps.enabled = !fps.enabled;
		}


		if( Input.GetKeyDown(KeyCode.F4) )
		{
			luaMain.ShowMemory();
		}
#endif


#if UNITY_STANDALONE || UNITY_EDITOR
		if( Input.GetKeyDown(KeyCode.F5) )
		{
			//GameObject popCanvas = GameObject.Find("Popup_Canvas");

			//System.Text.StringBuilder sb = new System.Text.StringBuilder();
			//int count = popCanvas.transform.GetChildCount();

			//for( int i = 0 ; i < count ; i++ )
			//{
			//	string x = Standalone.Win.ExportFontStyle(popCanvas.transform.GetChild(i));
			//	sb.Append(x);
			//	sb.Append("\n\n");
			//}

			//TextEditor te = new TextEditor();
			//te.content = new GUIContent(sb.ToString());
			//te.SelectAll();
			//te.Copy();

			//System.IO.File.WriteAllText("tmp.txt" , sb.ToString());
			//UIManager.Instance.ShowTip("Copy To Clipboard");
		}

#endif


		//MainValue.Update(Time.deltaTime);

		//MainValue.mxLuaMain.Update();

	}



	//void LateUpdate()
	//{
	//	MainValue.mxLuaMain.LateUpdate();
	//}



	//public void LoadScene( params string[] sceneName )
	//{
	//	GameObject x = new GameObject("load scene helper");
	//	x.transform.SetParent(this.transform);
	//	LoadSceneHelper panel = x.AddComponent<LoadSceneHelper>();
	//	panel.SetLoadSceneName(sceneName[0] , sceneName);
	//}

	//public void LoadAssetBundle( params string[] sceneName )
	//{
	//	GameObject x = new GameObject("load assetbundle helper");
	//	x.transform.SetParent(this.transform);
	//	LoadSceneHelper panel = x.AddComponent<LoadSceneHelper>();
	//	panel.SetLoadSceneName(sceneName[0] , sceneName);
	//}




	//public static bool IsBootup { get { return TypeScene.Bootup == GetCurrentTypeScene(); } }
	//public static bool IsMainCity { get { return TypeScene.City == GetCurrentTypeScene(); } }
	//public static bool IsWorld { get { return TypeScene.World == GetCurrentTypeScene(); } }



	//public static TypeScene GetCurrentTypeScene()
	//{
	//	MainState.GameStateType currentSceneName = MainState.GameState;
	//	switch( currentSceneName )
	//	{
	//		//case MainState.GameStateType.LoadBootup:
	//		case MainState.GameStateType.BootupComplete:
	//			return TypeScene.Bootup;
	//		//case MainState.GameStateType.LoadCity:
	//		case MainState.GameStateType.CityComplete:
	//			return TypeScene.City;
	//		//case MainState.GameStateType.LoadWorld:
	//		case MainState.GameStateType.WorldComplete:
	//			return TypeScene.World;
	//		default:
	//			return TypeScene.Unknown;
	//	}
	//}



	//// 重置启动状态
	//public void Reset()
	//{
	//	luaMain.UnInitLuaEvent();
	//	MainValue.Reset();
	//	luaMain.InitLuaEvent();

	//	if( MainState.GameState != MainState.GameStateType.LoadBootup )
	//	{
	//		MainState.GameState = MainState.GameStateType.LoadBootup;
	//		LoadScene("Bootup");
	//	}
	//}



	//重新加载游戏
	public void ReLoadGame()
	{
		OnNetDisonnected(false);

		//if( MainState.GameState != MainState.GameStateType.LoadBootup )
		//{
		//	MainState.GameState = MainState.GameStateType.LoadBootup;
		//	LoadScene("Bootup");
		//}
	}

	// 是否可以重连
	public void OnNetDisonnected( bool canReConnect = true )
	{
		Debug.LogError("App.OnNetDisonnected : " + canReConnect);
		luaMain.UnInitLuaEvent();
		//MainValue.Reset();
		luaMain.InitLuaEvent();
		//MainValue.mxLuaMain.OnNetDisonnected(canReConnect);
	}



	private const int HeartBeatInterval = 20;
	//每秒调用一次
	private void UpdatePreSecond()
	{
		//MainValue.UpdatePreSecond();

		luaMain.UpdatePreSecond();

		heartBeat += 1;
		if( heartBeat > HeartBeatInterval )
		{
			//if( MainValue.mxDataManager.HostUserInfoData.isLogin )
			//{
			//	C2S._heartbeat.OnRequest_HeartBeat();
			//	Debug.LogFormat(" HeartBeat {0}" , Time.time);

			//}
			heartBeat -= HeartBeatInterval;
		}
	}


	private int heartBeat = 0;





	private void OnApplicationFocus( bool hasFocus )
	{
		Debug.LogFormat(" OnApplicationFocus( {0} )" , hasFocus);
		if( hasFocus )
		{

		}
		else
		{

		}
	}



	internal void SetPlayMovie( bool value )
	{
		playMovie = value;
	}
	private bool playMovie = false;

	private bool isConnectedOnPause;

	void OnApplicationPause( bool pause )
	{
	}


	void OnApplicationQuit()
	{
	}

	internal void Coroutine( IEnumerator parm )
	{
		StartCoroutine(parm);
	}
}

