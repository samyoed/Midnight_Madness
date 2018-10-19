using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Score2Script : MonoBehaviour {

	
	public Text score;
	
	
	// Update is called once per frame
	void Update ()
	{

		score.text = ( ScoreScript.score + " Meters");
	}
}
