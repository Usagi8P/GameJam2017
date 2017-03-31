using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rb2D;
	Animator animator;
	float moveX;
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
	string walkString = "isWalk";
	[SerializeField]
	float flipTime = 5;


	//OPTIMIZATION :-)
	int walkHash;




	//Animation stuff
	bool isWalk;
	bool isJump = false;
	[HideInInspector]
	public bool grounded = false;
	[HideInInspector]
	public bool inverting = false;
	bool midInvert = false;
	bool facingRight = false;

	// Use this for initialization
	void Awake () {
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		walkHash = Animator.StringToHash ("isWalk");

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown (invertkey)){
			midInvert = true;
			inverting = true;
			grounded = false;
		}
		if (Input.GetButton (jumpkey) && grounded)
			isJump = true;

		animator.SetBool ("isJump", !grounded);


	}

	void FixedUpdate(){
		moveX = Input.GetAxis (xaxis);
		animator.SetFloat ("WalkSpeed", Mathf.Abs(moveX));

		Walk (velocity * moveX);

		if (isJump) {
			Jump (jumpHeight);
		}
		if (inverting) {
			GameObject.FindGameObjectWithTag("GOD").GetComponent<Inverter>().Invert ();
		}
		if (moveX < 0 && !facingRight)
			FlipX (flipTime);
		else if (moveX > 0 && facingRight)
			FlipX (flipTime);

		conditionalFreeze ();

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
		//animator.SetTrigger ("isJump");
		rb2D.AddForce (new Vector2 (0f, speed), ForceMode2D.Impulse);
		isJump = false;
		grounded = false;
	}


	void Walk(float speed){
		rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
	}

	void FlipX(float flipTime){
		//flips player :)
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		Mathf.Lerp(theScale.x, theScale.x *= -1, flipTime);
		transform.localScale = theScale;
	}

	void conditionalFreeze(){
		//BAD FUNCTION THAT FREEZES BASED ON A BUNCH OF GLOBAL VARS AAA
		if (!grounded && midInvert) {
			rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;
			moveX = 0;

		} else if (grounded) {
			midInvert = false;
			rb2D.constraints = RigidbodyConstraints2D.None;
			rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
		}
	}

	public void evenMoreConditionalFreeze(bool condition){
		if (condition)
			rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
		else {
			rb2D.constraints = RigidbodyConstraints2D.None;
			rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
		}

	}
		

	public void resetWalk(){
		//pointless function to make sure death always works :)
		animator.SetFloat("WalkSpeed", 1);
	}

}
