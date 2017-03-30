using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rb2D;
	Animator animator;
	float moveX;
	GameObject[] gravities;

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
	bool invert;

	// Use this for initialization
	void Awake () {
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		walkHash = Animator.StringToHash ("isWalk");
		gravities = GameObject.FindGameObjectsWithTag ("Gravity");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton (invertkey))
			Invert (200);

	}

	void FixedUpdate(){
		moveX = Input.GetAxis (xaxis);
		animator.SetFloat ("Speed", Mathf.Abs (moveX));

	}

	void Invert(float speed){
		//when called, flips all objects with a child with tag "Gravity"
		foreach (GameObject grav in gravities) {
			GameObject obj = grav.transform.parent.gameObject;
			Rigidbody2D objrb2d = obj.GetComponent<Rigidbody2D> ();
			objrb2d.gravityScale *= -1;
			objrb2d.MoveRotation (Mathf.Lerp(objrb2d.rotation, objrb2d.rotation + 180, speed));
		}
	}
}
