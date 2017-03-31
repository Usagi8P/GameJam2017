using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoinstantiate : MonoBehaviour {
	[SerializeField]
	GameObject god;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
		if (GameObject.FindGameObjectWithTag ("GOD") == null) //if god didn't exist, we would have to create Him
			Instantiate (god);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
