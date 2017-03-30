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


	//OPTIMIZATION :-)
	int walkHash;




	//Animation stuff
	bool isWalk;
	bool isJump = false;
	[HideInInspector]
	public bool grounded = false;
	bool inverted = false;
	bool inverting = false;
	float invertTimer = 0f;

	// Use this for initialization
	void Awake () {
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		walkHash = Animator.StringToHash ("isWalk");
		gravities = GameObject.FindGameObjectsWithTag ("Gravity");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown (invertkey)){
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
			objrb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
			objrb2d.MoveRotation (180);
			objrb2d.gravityScale *= -1;

		}

	}

	void InvertEnd(){
		//checks if inversion is now over and then unlocks everything if so
		foreach (GameObject grav in gravities) {
			GameObject obj = grav.transform.parent.gameObject;
			Rigidbody2D objrb2d = obj.GetComponent<Rigidbody2D> ();
				objrb2d.constraints = RigidbodyConstraints2D.None;
		}
	}
	void Jump(float speed){
		rb2D.AddForce (new Vector2 (0f, speed), ForceMode2D.Impulse);
		isJump = false;
		grounded = false;
	}


	void Walk(float speed){
		rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
	}


}
