using UnityEngine;
using System.Collections;

public class Inverter : MonoBehaviour {

	// Use this for initialization
	void Start () {
			AudioSource aud = GetComponent<AudioSource>();
		float[] samples = new float[aud.clip.samples * aud.clip.channels];
		aud.clip.GetData(samples, 0);
		int i = 0;
		while (i < samples.Length) {
			Debug.Log (samples [i]);
			samples[i] = samples[i] * -1F;
			Debug.Log (samples [i]);
			++i;
		}
		aud.clip.SetData(samples, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
