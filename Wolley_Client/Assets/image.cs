using DG.Tweening;
using UnityEngine;

public class image : MonoBehaviour {

	// Use this for initialization
	void Start () {
	 
		transform.DOLocalMove(new Vector3(200 , 200 , 0) , 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
