using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textScript : MonoBehaviour
{

	public float xOffset = -5;
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3(Camera.main.transform.position.x + xOffset, transform.position.y, transform.position.z);
	}
}
