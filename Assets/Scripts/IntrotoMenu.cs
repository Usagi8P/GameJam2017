using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntrotoMenu : MonoBehaviour {
    Animation anim;
    [SerializeField]
    string scene;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animation>();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!anim.isPlaying)
        {
            SceneManager.LoadScene(scene);
        }

    }
}
