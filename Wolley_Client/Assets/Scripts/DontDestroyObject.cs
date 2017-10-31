using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DontDestroyObject : MonoBehaviour
{
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

}
