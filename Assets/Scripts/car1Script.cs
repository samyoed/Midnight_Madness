using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class car1Script : MonoBehaviour
{

	public float carSpeed = 30;
	public GameObject player;

	private float lifeSpan;
	
	// Use this for initialization
	void Start () {
		//Destroy (gameObject, 10f);
		
		//will vary car speeds
		
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		float speedLimit = player.GetComponent<FirstPerson>().currentSpeedLimit; 
		float carSpod = speedLimit + Random.Range(-5, 5);
		
		if(carSpod > carSpeed)
			carSpeed = carSpeed +.5f;
		if (carSpod < carSpeed)
			carSpeed = carSpeed -.5f;
		
		
		if (Vector3.Distance(player.transform.position, transform.position) > 200)
		{
			Destroy(gameObject);
		}
			
		//freezes rotation
		transform.GetComponent<Rigidbody>().freezeRotation = true;
		
		
	}
// ignore road
	void FixedUpdate()
	{
		this.GetComponent<Rigidbody>().velocity = new Vector3(-carSpeed ,0f ,0f);

		//Physics.IgnoreCollision(road.gameObject.GetComponent<BoxCollider>(), this.GetComponent<SphereCollider>(), true);
	}

	void OnBecameVisible()
	{
		lifeSpan += Time.deltaTime;
	}

	void OnBecameInvisible()
	{
		if (lifeSpan > 1)
		{
			Destroy (gameObject);
		}
	}

/*	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Road"))
		{
			Physics.IgnoreCollision(other.gameObject.GetComponent<BoxCollider>(), this.GetComponent<SphereCollider>(), true);
		}
	} */
}
