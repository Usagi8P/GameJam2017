using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour {
	GameObject player;

	[SerializeField]
	string nextLevel;
	public bool isOpen = false;
	Animator anim;
	// Use this for initialization

	void Awake(){
		anim = GetComponent<Animator> ();
	}
	void Start () {
		//spawning player
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			player = GameObject.FindGameObjectWithTag ("Player");
			player.transform.position = transform.position + Vector2 (0, 0.25);
		} else {
			player = Instantiate (Resources.Load ("Player"),transform.position + Vector2(0, 0.25));



		}
			
	}
		
	// Update is called once per frame
	void Update () {
		if (isOpen)
	}
}
