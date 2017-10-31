using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaMainBase
{

	protected LuaEnv luaenv = new LuaEnv();


	protected void InitCodePath()
	{
#if UNITY_EDITOR
		EditorInitLuaRootPath();
		luaenv.AddLoader(EditorLuaCodeLoader);
#elif UNITY_STANDALONE
		InitMobileLuaRootPath();
		luaenv.AddLoader(LuaStandaloneCodeLoader);
#elif UNITY_ANDROID || UNITY_IOS
		InitMobileLuaRootPath();
		luaenv.AddLoader(LuaMobileCodeLoader);
#endif
	}



	#region editor

	private string luaRootPath;


	private void EditorInitLuaRootPath()
	{
		luaRootPath = System.IO.Path.Combine(Application.dataPath , "Lua");
		Debug.Log("luaRootPath : " + luaRootPath);
	}


	private byte[] FixBOM( byte[] text )
	{
		if( text[0] == 0XEF && text[1] == 0xBB && text[2] == 0XBF )
		{
			byte[] ret = new byte[text.Length - 3];
			System.Array.Copy(text , 3 , ret , 0 , text.Length - 3);
			return ret;
		}
		else
		{
			return text;
		}
	}


	private byte[] EditorLuaCodeLoader( ref string fileName )
	{
		string filePath = System.IO.Path.Combine(luaRootPath , fileName + ".lua");
		if( System.IO.File.Exists(filePath) )
		{
			return FixBOM(System.IO.File.ReadAllBytes(filePath));
		}

		// require 文件带 . 符号的需要替换成文件夹
		string relaceFileName = fileName.Replace('.' , System.IO.Path.DirectorySeparatorChar);

		filePath = System.IO.Path.Combine(luaRootPath , relaceFileName + ".lua");
		if( System.IO.File.Exists(filePath) )
		{
			return FixBOM(System.IO.File.ReadAllBytes(filePath));
		}

		return null;
	}

	#endregion


	#region standalone

	private byte[] LuaStandaloneCodeLoader( ref string fileName )
	{
		//加载可执行文件路径
		{
			string luaFileName = fileName;
			if( System.IO.File.Exists(luaFileName + ".lua") )
			{
				return FixBOM(System.IO.File.ReadAllBytes(luaFileName + ".lua"));
			}
			luaFileName = luaFileName.Replace('.' , System.IO.Path.DirectorySeparatorChar);

			if( System.IO.File.Exists(luaFileName + ".lua") )
			{
				return FixBOM(System.IO.File.ReadAllBytes(luaFileName + ".lua"));
			}
		}

		{
			string codeFileName = string.Format(assetLuaCode , fileName);
			TextAsset text = (TextAsset)assetBundle.LoadAsset(codeFileName , typeof(TextAsset));
			if( null != text )
			{
				return text.bytes;
			}

			string relaceFileName = fileName.Replace('.' , '/');
			codeFileName = string.Format(assetLuaCode , relaceFileName);
			text = (TextAsset)assetBundle.LoadAsset(codeFileName , typeof(TextAsset));

			if( null != text )
			{
				return text.bytes;
			}

			Debug.LogFormat("Lua Loader = {0} , Fail!" , codeFileName);
		}
		return null;
	}

	#endregion


	#region android and ios

	private AssetBundle assetBundle;


	private void InitMobileLuaRootPath()
	{
		//Debug.LogFormat("dataPath:{0}" , Application.dataPath);
		//Debug.LogFormat("streamingAssetsPath:{0}" , Application.streamingAssetsPath);
		//Debug.LogFormat("persistentDataPath:{0}" , Application.persistentDataPath);
		//string path = Application.dataPath + "!assets/luacode.unity3d";

		//string hotfix = System.IO.Path.Combine(MainValue.HotfixPath , MainValue.LuaCodeFileName);
		//assetBundle = AssetBundle.LoadFromFile(hotfix);
		//if( null != assetBundle )
		//{
		//	return;
		//}

		//string path = System.IO.Path.Combine(Application.streamingAssetsPath , MainValue.LuaCodeFileName);
		//assetBundle = AssetBundle.LoadFromFile(path);
	}


	private const string assetLuaCode = "Assets/LuaCode/{0}.bytes";


	private byte[] LuaMobileCodeLoader( ref string fileName )
	{
		string codeFileName = string.Format(assetLuaCode , fileName);
		TextAsset text = (TextAsset)assetBundle.LoadAsset(codeFileName , typeof(TextAsset));
		if( null != text )
		{
			return text.bytes;
		}

		string relaceFileName = fileName.Replace('.' , '/');
		codeFileName = string.Format(assetLuaCode , relaceFileName);
		text = (TextAsset)assetBundle.LoadAsset(codeFileName , typeof(TextAsset));

		if( null != text )
		{
			return text.bytes;
		}

		Debug.LogFormat("Lua Loader = {0} , Fail!" , codeFileName);

		return null;
	}

	#endregion


	protected void Dispose()
	{

		if( null != assetBundle )
		{
			assetBundle.Unload(true);
			assetBundle = null;
		}
		luaenv.Dispose();
		luaenv = null;

	}


}
