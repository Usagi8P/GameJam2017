using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour {
	public GameObject player;
	[SerializeField]
	string nextLevel;

	[HideInInspector]
	public bool isOpen = false;
	Animator anim;
	// Use this for initialization

	void Awake(){
		anim = GetComponent<Animator> ();
	}
	void Start () {
		//spawning player
			player = GameObject.FindGameObjectWithTag ("Player");
			player.transform.position = transform.position + new Vector3 (0,0.25f);


			
	}
		
	// Update is called once per frame
	void Update () {
		if (isOpen)
			anim.SetTrigger ("Open");			
	}
}
