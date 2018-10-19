using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class highScoreScript : MonoBehaviour {

	public Text highScore;
	
	
	// Update is called once per frame
	void Update ()
	{

		highScore.text = ( ScoreScript.highScore + " Meters");
	}
}
