using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public GameObject player;
	
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<FirstPerson>().isDead)
		{
			//unlink
		}
	}
}
