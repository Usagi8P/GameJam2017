using UnityEngine;
using System.Collections;

public class Inverter : MonoBehaviour {

	GameObject[] gravities;
	bool inverted = false;

	// Use this for initialization
	void Awake () {
		InvertSong ();
	}
	
	// Update is called once per frame
	void Update () {
		gravities = GameObject.FindGameObjectsWithTag ("Gravity");
	}

	void InvertSong() {
		AudioSource aud = GetComponent<AudioSource>();
		float[] samples = new float[aud.clip.samples * aud.clip.channels];
		aud.clip.GetData(samples, 0);
		int i = 0;
		while (i < samples.Length) {
			samples[i] = samples[i] * 0.5F;
			++i;
		}
		aud.clip.SetData(samples, 0);

	}

	public void Invert(){
		inverted = !inverted;
		//when called, flips all objects with a child with tag "Gravity"
		foreach (GameObject grav in gravities) {
			Debug.Log (grav.transform.parent.gameObject.ToString ());
			if (inverted != grav.GetComponent<InverterChecker> ().isInverted)
				
				grav.GetComponent<InverterChecker>().FlipY();


		}
		GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().inverting = false;

	}
}
