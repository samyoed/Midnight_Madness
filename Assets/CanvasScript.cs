using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour {
	Animator animator;
	public GameObject player;
	
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if(player.GetComponent< FirstPerson >().isDead )
		animator.SetBool("IsDead", true);
	}
}
