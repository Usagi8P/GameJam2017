using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rb2D;
	Animator animator;
	float moveX;
	GameObject[] gravities;
	GameObject[] limbs;

	//publicly editable stuff :)
	[SerializeField]
	float velocity = 5.0f;
	[SerializeField]
	float jumpHeight = 5.0f;
	[SerializeField]
	string xaxis = "horizontal_K";
	[SerializeField]
	string jumpkey = "jump_K";
	[SerializeField]
	string invertkey = "invert_K";
	[SerializeField]
	string walkString = "isWalk";
	[SerializeField]
	float maxInvertTimer = 5;

	//OPTIMIZATION :-)
	int walkHash;




	//Animation stuff
	bool isWalk;
	bool isJump = false;
	[HideInInspector]
	public bool grounded = false;
	bool inverted = false;
	bool inverting = false;
	bool imInvert = false;
	float invertTimer = 0f;

	// Use this for initialization
	void Awake () {
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		walkHash = Animator.StringToHash ("isWalk");

	}

	// Update is called once per frame
	void Update () {
		gravities = GameObject.FindGameObjectsWithTag ("Gravity");
		if (Input.GetButtonDown (invertkey) && invertTimer < maxInvertTimer){
			inverting = true;
		}
		if (Input.GetButton (jumpkey) && grounded)
			isJump = true;

	}

	void FixedUpdate(){
		moveX = Input.GetAxis (xaxis);
		animator.SetFloat ("WalkSpeed", moveX);

		Walk (velocity * moveX);

		if (isJump) {
			Jump (jumpHeight);
		}
		if (inverting) {
			Invert (0.5f);
		}

	}

	void Invert(float speed){
		inverted = !inverted;
		//when called, flips all objects with a child with tag "Gravity"
		foreach (GameObject grav in gravities) {
			GameObject obj = grav.transform.parent.gameObject;
			Rigidbody2D objrb2d = obj.GetComponent<Rigidbody2D> ();
			if (inverted)
				objrb2d.MoveRotation (0);
			else
				objrb2d.MoveRotation (180);
			objrb2d.gravityScale *= -1;

		}
		inverting = false;

	}

	/*void InvertEnd(){
		//checks if inversion is now over and then unlocks everything if so
		foreach (GameObject grav in gravities) {
			GameObject obj = grav.transform.parent.gameObject;
			Rigidbody2D objrb2d = obj.GetComponent<Rigidbody2D> ();
			if (objrb2d.
				objrb2d.constraints = RigidbodyConstraints2D.None;
		}
		inverting = false;
	}*/
	void Jump(float speed){
		//Jumps, also returns the fact that we no longer can jump
		rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
		rb2D.AddForce (new Vector2 (0f, speed), ForceMode2D.Impulse);
		isJump = false;
		grounded = false;
	}


	void Walk(float speed){
		rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
	}


}
