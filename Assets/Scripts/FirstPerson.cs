using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;



public class FirstPerson : MonoBehaviour {

	public float moveSpeed = 10f;
	public float carSpeed = .1f;
	public float speedMultiplier = 1;
	public float carSlowSpeed = .1f;

	private Collider[] playerColliders;
	private Collider[] ignoreColliders;
	
	public TextMesh speedText;

	public GameObject car1;
	
	void Awake () {
		//Gets all the Colliders attatched to the player
		playerColliders = GetComponents<Collider>();
		//Gets all other colliders in the scene that are active. 
		
		ignoreColliders = FindObjectsOfType<Collider>();
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

		//makes it so that the car doesn't go out of bounds
		if(-4.01f <transform.position.z && transform.position.z < 4.01f)
		transform.position += transform.forward * -vertical * moveSpeed* Time.deltaTime;
		
		//multiplying by time.delta time makes it more consistent between machines
		//transform.position += transform.forward * horizontal * moveSpeed* Time.deltaTime;
		this.GetComponent<Rigidbody>().velocity = new Vector3(-carSpeed ,0f ,0f);
		
		Debug.Log("Car Speed: " + carSpeed);
		//freezes rotation
		transform.GetComponent<Rigidbody>().freezeRotation = true;

		//sets speedometer text
		float speedRound = (int) carSpeed;
		speedText.text = ("MPH: " + speedRound);
	}
	
	private void OnTriggerEnter(Collider other)
	{
		//spawn a new car every time player triggers carSpawn trigger
		
		float randomX;
		float randomNum2;
		if (other.gameObject.CompareTag("carSpawn"))
		{
			for (int k = 0; k < 3; k++)
			{
				randomX = Random.Range(-3f, 3f);
				randomNum2 = Random.Range(20f, 70f);
				Instantiate(car1, new Vector3(transform.position.x - randomNum2, transform.position.y, randomX),
					transform.rotation);
			}
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("vehicle"))
		{
			
			//lose game
			
		}
	}
	
	
	
	
}
