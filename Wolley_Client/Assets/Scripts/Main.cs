using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LoadApp();
	}

    public static void LoadApp()
    {
        Debug.Log("Create App");

        GameObject app = new GameObject();
        app.name = "App";
        app.AddComponent<App>();
        //app.AddComponent<FPSCounter>();

        // GameObject audio = new GameObject("audio");
        // audio.transform.SetParent(app.transform);

    }


    // Update is called once per frame
    void Update () {
		
	}
}
