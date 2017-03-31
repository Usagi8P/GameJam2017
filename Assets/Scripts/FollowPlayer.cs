using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	public GameObject player;
	Vector3 offset;
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - player.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = offset + player.transform.position;
	}
}
