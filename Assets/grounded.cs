using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounded : MonoBehaviour {
	int i;
	// Use this for initialization
	void Start () {
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.CompareTag ("Floor")) {
			transform.GetComponentInParent<PlayerController> ().grounded = true;
			Debug.Log (i);
			i++;
		}
		
	}
}
