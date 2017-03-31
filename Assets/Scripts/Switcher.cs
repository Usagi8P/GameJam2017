using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour {
	GameObject[] switched;
	// Use this for initialization
	void Awake () {
		switched = GameObject.FindGameObjectsWithTag ("Switched");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Switch(){
		foreach (GameObject toBeActivated in switched) {
			toBeActivated.GetComponent<Switched> ().isOn = true;

		}
		Debug.Log ("hello");
		GetComponent<Inverter> ().ReverseSong ();

	}
}
