﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class transitionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene("Main Scene");

		}
		if(Input.GetKeyDown(KeyCode.B))
		{
			SceneManager.LoadScene("Home");

		}
	}
}
