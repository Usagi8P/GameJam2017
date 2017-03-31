using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoinstantiate : MonoBehaviour {
	[SerializeField]
	GameObject god;

	GameObject[] clones;
	// Use this for initialization
	void Awake () {
		/*DontDestroyOnLoad(transform.gameObject);
		clones = GameObject.FindGameObjectsWithTag ("MainCamera");
		for (int i = 2; i < clones.Length; i++){
			Destroy (clones [i]);
				}*/
		if (GameObject.FindGameObjectWithTag ("GOD") == null) //if god didn't exist, we would have to create Him
			Instantiate (god);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
