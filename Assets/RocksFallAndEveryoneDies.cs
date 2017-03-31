using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksFallAndEveryoneDies : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.CompareTag ("Floor")) {
			transform.GetComponentInParent<playerHit> ().Death ();
		}

	}
}
