﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.eulerAngles += new Vector3(.1f, 0, 0);
		
	}
}
