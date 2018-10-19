using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class CameraControl : MonoBehaviour {

	public GameObject player;

	public float xPos = - 2.5f;
	public float yPos = 21.7f;
	public float zPos = 8.1f;
	

	void Start()
	{
		//transform.GetComponent<Rigidbody>().freezeRotation = true;

	}
	
	// Update is called once per frame
	void Update () {
		

		this.transform.position = new Vector3(player.transform.position.x +xPos, player.transform.position.y + yPos, player.transform.position.z + zPos);
		
		
		if (player.GetComponent<FirstPerson>().isDead)
		{
			//unlink
		}
	}
}
