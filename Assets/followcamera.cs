using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcamera : MonoBehaviour {
	GameObject MainCamera;
	// Use this for initialization
	void Awake () {
		MainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = MainCamera.transform.position + new Vector3(0,0,10);
	}
}
