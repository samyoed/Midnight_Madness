using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;


public class FirstPerson : MonoBehaviour {

	public float moveSpeed = 10f;
	public float carSpeed = .1f;
	public float speedMultiplier = 1;
	public float carSlowSpeed = .1f;

	public TextMesh speedText;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		

		float vertical = Input.GetAxis("Vertical");
		float horizontal = Input.GetAxis("Horizontal");


//if left or right keys are pressed, then slow down a lot or speed up, 
		//else gradually slow down car

		if (Input.GetButton("Horizontal") && carSpeed > 4)
		{ 
			carSpeed += horizontal * speedMultiplier;
		}
		else if (carSpeed > 5)
			carSpeed -= carSlowSpeed;
		else carSpeed += carSlowSpeed;


if(-4.01f <transform.position.z && transform.position.z < 4.01f)
		transform.position += transform.forward * -vertical * moveSpeed* Time.deltaTime;
		//multiplying by time.delta time makes it more consistent between machines
		//transform.position += transform.forward * horizontal * moveSpeed* Time.deltaTime;
		this.GetComponent<Rigidbody>().velocity = new Vector3(-carSpeed ,0f ,0f);
		
		Debug.Log("Car Speed: " + carSpeed);
//freezes rotation
		transform.GetComponent<Rigidbody>().freezeRotation = true;

		float speedRound = (int) carSpeed;
		speedText.text = ("MPH: " + speedRound);
	}
}
