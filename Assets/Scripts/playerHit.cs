using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHit : MonoBehaviour {
	//Todo, make full animation play before scene is reloaded.
	Animator anim;
	bool isDead = false;
	Animation death;
	public AudioClip deathClip;
	float deathTime = 0;


	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		death = GetComponent<Animation> ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Bad"))
			Death ();
			
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Bad"))
			Death ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Reset_K")) { //once anims stopped
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
			
		if(isDead)
		{
			PlayerController cc = GetComponent<PlayerController>();
			cc.enabled = false; 

		}

	}

	public void Death(){
		Debug.Log ("im dead");
		GetComponent<PlayerController> ().resetWalk ();
		GameObject.FindGameObjectWithTag ("GOD").GetComponent<AudioSource>().clip = deathClip;
		GameObject.FindGameObjectWithTag ("GOD").GetComponent<AudioSource> ().Play ();
		anim.SetTrigger ("isDead");
		isDead = true;
		GetComponent<PlayerController> ().evenMoreConditionalFreeze (isDead);
			


	}
}
