using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLogic : MonoBehaviour {
	GameObject player;
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
		isOpen = GetComponentInChildren<switched> ().isOn;
		if (isOpen)
			anim.SetTrigger ("Open");			
	}

	void OnTriggerEnter2D(Collider2D collision){
		if (isOpen && collision.gameObject.CompareTag ("Player"))
			SceneManager.LoadScene (nextLevel);
	}

}
