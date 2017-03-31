using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLogic : MonoBehaviour {

	// Use this for initialization
	Animator playeranim;
	Animator switchanim;
	void Awake() {
		playeranim = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
		switchanim = GetComponent<Animator> ();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
