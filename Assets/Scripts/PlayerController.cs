using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rb2D;
	Animator animator;
	float moveX;

	//publicly editable stuff :)
	[SerializeField]
	float velocity = 5.0f;
	[SerializeField]
	float jumpHeight = 5.0f;
	[SerializeField]
	string xaxis = "horizontal_K1";
	[SerializeField]
	string jump = "jump_K1";
	[SerializeField]
	string walkString = "colguywalk";
	[SerializeField]
	string idleString = "colguyidle";

	//OPTIMIZATION :-)
	int walkHash;
	int idleHash;



	//Animation stuff
	bool isWalk;

	// Use this for initialization
	void Awake () {
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		walkHash = Animator.StringToHash ("colguywalk");
		idleHash = Animator.StringToHash ("colguyidle");
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void FixedUpdate(){
		moveX = Input.GetAxis (xaxis);
		animator.SetFloat ("Speed", Mathf.Abs (moveX));
	}
}
