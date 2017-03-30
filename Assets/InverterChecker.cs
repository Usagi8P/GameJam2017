using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverterChecker : MonoBehaviour {
	public bool isInverted;
	// Use this for initialization
	void Awake () {
		isInverted = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FlipY(){
		//Flips gravity and also makes everyone go upside down :)
		isInverted = !isInverted;
		GameObject obj = transform.parent.gameObject;
		Rigidbody2D objrb2d = obj.GetComponent<Rigidbody2D> ();
		objrb2d.gravityScale *= -1;

		Vector2 theScale = transform.parent.localScale;
		theScale.y *= -1;
		transform.parent.localScale = theScale;
	}
}
