using UnityEngine;
using System.Collections;

public class Inverter : MonoBehaviour {

	GameObject[] gravities;
	bool inverted = false;

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gravities = GameObject.FindGameObjectsWithTag ("Gravity");
	}

	public void InvertSong() {
		AudioSource aud = GetComponent<AudioSource> ();
		
	}
	public void ReverseSong(){

		AudioSource aud = GetComponent<AudioSource> ();
		aud.timeSamples = aud.clip.samples - 1;
		aud.pitch = -1;
		aud.Play ();

	}

	public void Invert(){
		inverted = !inverted;
		InvertSong ();
		//when called, flips all objects with a child with tag "Gravity"
		foreach (GameObject grav in gravities) {
			Debug.Log (grav.transform.parent.gameObject.ToString ());
			if (inverted != grav.GetComponent<InverterChecker> ().isInverted)
				
				grav.GetComponent<InverterChecker>().FlipY();


		}
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().inverting = false;

	}
}
