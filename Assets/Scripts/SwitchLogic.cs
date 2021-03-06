﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLogic : MonoBehaviour {

	// Use this for initialization
	Animator playeranim;
	Animator switchanim;
	GameObject player;
	bool on = false;


	void Awake() {
		playeranim = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ();
		switchanim = GetComponentInParent<Animator> ();
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.CompareTag ("PlayerFoot") && !on) {
			player = collision.gameObject.transform.parent.gameObject;
			GameObject.FindGameObjectWithTag ("GOD").GetComponent<Switcher>().Switch();
			player.GetComponent<PlayerController> ().resetWalk ();
			switchanim.SetTrigger ("On");
			playeranim.SetTrigger ("TurnOn");

			on = true;
		}

	}
}
