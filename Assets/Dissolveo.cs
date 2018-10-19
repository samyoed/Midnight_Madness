using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolveo : MonoBehaviour {
	
	public MeshRenderer myRenderer;
	private Material myMaterial;

	private bool pressedKey;
	private float dissolveOverTime;

	public float speed = 0.75f;
	// Use this for initialization
	void Start () {
		myMaterial = myRenderer.material;
		print(myMaterial);

		myMaterial.SetFloat("Vector1_648518FD", -1);
        
		dissolveOverTime = 1;
	}
	
	// Update is called once per frame
	void Update () {
		dissolveOverTime -= Time.deltaTime * speed;
		myMaterial.SetFloat("Vector1_648518FD", dissolveOverTime);
	}
}
