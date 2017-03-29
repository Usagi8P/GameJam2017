using UnityEngine;
using System.Collections;

public class Inverter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioSource aud = GetComponent<AudioSource>();
		bool allFloatsAreZero = true;
		float[] samples = new float[aud.clip.samples * aud.clip.channels];
		aud.clip.GetData(samples, 0);
		int i = 0;
		while (i < samples.Length) {
			samples[i] = samples[i] * 0.5F;
			++i;
		}
		aud.clip.SetData(samples, 0);
		Debug.Log (allFloatsAreZero);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
