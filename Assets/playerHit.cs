using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnCollision(Collider2D collision){
		if (collision.CompareTag ("Bad"))
			Death ();
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Death(){

	}
}
