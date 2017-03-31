using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHit : MonoBehaviour {
	//Todo, make full animation play before scene is reloaded.
	Animator anim;
	bool isDead = false;
	Animation death;
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
	
	// Update is called once per frame
	void Update () {
		if(isDead)
		{
			PlayerController cc = GetComponent<PlayerController>();
			cc.enabled = false; 
			if (!death.isPlaying) { //once anims stopped
				Debug.Log("I AM DEAD");
				//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}

	}

	public void Death(){
		Debug.Log ("im dead");
		anim.SetTrigger ("isDead");
		isDead = true;
			


	}
}
