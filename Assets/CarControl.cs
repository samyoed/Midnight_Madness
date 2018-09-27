using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarControl : MonoBehaviour
{
	private Rigidbody rBody;

	private Vector2 inputVector;

	public float turnSpeed = 10f;

	public float moveSpeed = 90f;
	// Use this for initialization
	void Start ()
	{
		rBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		
		inputVector = new Vector2(horizontal, vertical);
		
	}

	void FixedUpdate()
	{
		rBody.AddForce(transform.forward * inputVector.y* moveSpeed );
		rBody.AddTorque(0f, inputVector.x * turnSpeed, 0f);
	}
}
