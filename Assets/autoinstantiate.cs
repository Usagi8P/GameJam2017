using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoinstantiate : MonoBehaviour {
	[SerializeField]
	GameObject god;
	[SerializeField]
	GameObject player;

	// Use this for initialization
	void Awake () {
		if (GameObject.FindGameObjectWithTag ("GOD") == null)
			Instantiate (god);
		if (GameObject.FindGameObjectWithTag ("Player") == null)
			Instantiate (player);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
