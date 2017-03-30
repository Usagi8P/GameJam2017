using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHit : MonoBehaviour {
	Animator anim;
	bool isDead = false;
	Animation death;
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		death = GetComponent<Animation> ();
	}

	void OnCollision(Collider2D collision){
		if (collision.CompareTag ("Bad"))
			Death ();
			
	}
	
	// Update is called once per frame
	void Update () {
		if(isDead)
		{
			CharacterController cc = GetComponent<CharacterController>();
			cc.enabled = false; 
			if (!death.isPlaying) { //once anims stopped
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}

	}

	void Death(){
		anim.SetTrigger ("isDead");
		isDead = true;
			


	}
}
