using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveScript : MonoBehaviour
{
	public MeshRenderer myRenderer;
	private Material myMaterial;

	private bool pressedKey;
	private float dissolveOverTime;

	public float speed = 0.75f;


	// Use this for initialization
	void Start()
	{
		myMaterial = myRenderer.material;
		print(myMaterial);

		myMaterial.SetFloat("Vector1_648518FD", -1);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			pressedKey = !pressedKey;

			if (pressedKey)
			{
				dissolveOverTime = -1;
			}
			else
			{
				dissolveOverTime = 1;
			}
		}

		if (pressedKey)
			{
				dissolveOverTime += Time.deltaTime * speed;
				myMaterial.SetFloat("Vector1_648518FD", dissolveOverTime);

			}
			else
			{
				dissolveOverTime -= Time.deltaTime * speed;
				myMaterial.SetFloat("Vector1_648518FD", dissolveOverTime);
			}


		}
	
}
