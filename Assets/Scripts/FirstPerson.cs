using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;


public class FirstPerson : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float carSpeed = .1f;
    public float speedMultiplier = 1;
    public float carSlowSpeed = .1f;

    public float exploPower;
    public float exploRadius;

    public bool isDead;

    public float currentSpeedLimit;
    public float supiidorimeto;


    public TextMesh speedText;
    public TextMesh speedLimit;
    public TextMesh distText;

    public GameObject car1;

    private Vector3 origin;
    
    //For the dissolve effect.
    public MeshRenderer myRenderer;
    private Material myMaterial;

    private bool pressedKey;
    private float dissolveOverTime;

    public float speed = 0.75f;
    public int intMeters;

    public GameObject scoreKeeper;
    
   
    

    void Awake()
    {
        //Gets all the Colliders attatched to the player
        //playerColliders = GetComponents<Collider>();
        //Gets all other colliders in the scene that are active. 

        //ignoreColliders = FindObjectsOfType<Collider>();

        //Sets speed limit to 60, all other cars will be going at that speed
        StartCoroutine("Change60");
        origin = transform.position;
        
        

        myMaterial = myRenderer.material;
        print(myMaterial);

        myMaterial.SetFloat("Vector1_648518FD", -1);
        
        dissolveOverTime = 1;
    }

    // Update is called once per frame
    void Update()
    {

        ScoreScript.score = intMeters;
        if (ScoreScript.score > ScoreScript.highScore)
            ScoreScript.highScore = ScoreScript.score; 
        
        
        if (!isDead)
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            //if left or right keys are pressed, then slow down a lot or speed up, 
            //else gradually slow down car

            if (Input.GetButton("Horizontal") && carSpeed > 4)
            {
                carSpeed += horizontal * speedMultiplier;
            }
            else if (carSpeed > 5)
                carSpeed -= carSlowSpeed;
            else carSpeed += carSlowSpeed;

            //makes it so that the car doesn't go out of bounds
            if (-4.01f < transform.position.z && transform.position.z < 4.01f)
                transform.position += transform.forward * -vertical * moveSpeed * Time.deltaTime;

            //transform.position += transform.forward * horizontal * moveSpeed* Time.deltaTime;
            this.GetComponent<Rigidbody>().velocity = new Vector3(-carSpeed, 0f, 0f);

            Debug.Log("Car Speed: " + carSpeed);


            //freezes rotation
            transform.GetComponent<Rigidbody>().freezeRotation = true;
            //dissolve on enter
            dissolveOverTime -= Time.deltaTime * speed;
            myMaterial.SetFloat("Vector1_648518FD", dissolveOverTime);
            
        }
        else
        {
            carSpeed = -GetComponent<Rigidbody>().velocity.x;
            transform.GetComponent<Rigidbody>().freezeRotation = false;
            //dissolve on death
            dissolveOverTime += Time.deltaTime * speed;
            myMaterial.SetFloat("Vector1_648518FD", dissolveOverTime);

           
        }

        if (supiidorimeto < currentSpeedLimit)
            supiidorimeto++;
        if (supiidorimeto > currentSpeedLimit)
            supiidorimeto--;

        float meters = Vector3.Distance(origin, transform.position);
        
        
        
        //sets speedometer text
        float speedRound = (int) carSpeed;
        intMeters = Mathf.RoundToInt(meters);
        speedText.text = ("MPH: " + speedRound);
        speedLimit.text = ("Limit: " + supiidorimeto);
        distText.text = ("Meters: \n" + intMeters);

    }

    private void OnTriggerEnter(Collider other)
    {
        //spawn a new car every time player triggers carSpawn trigger

        float randomX;
        float randomNum2;
        if (other.gameObject.CompareTag("carSpawn"))
        {
            for (int k = 0; k < 3; k++)
            {
                randomX = Random.Range(-3f, 3f);
                randomNum2 = Random.Range(20f, 70f);
                Instantiate(car1, new Vector3(transform.position.x - randomNum2, transform.position.y, randomX),
                    transform.rotation);
            }
        }
        
        //if player clips through the road, teleport back to road
        if (other.gameObject.CompareTag("goBack"))
        {
            transform.position += new Vector3(transform.position.x, 10, transform.position.y);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("vehicle"))
        {
            Vector3 explosionPos = new Vector3();
            explosionPos = (transform.position + other.gameObject.transform.position) / 2;
            isDead = true;
            GetComponent<Rigidbody>().AddExplosionForce(exploPower, explosionPos, exploRadius, .5f);
            //lose game
            StartCoroutine("DeadSequence");


        }

       
    }

    //speed limit will switch back and forth between 60 and 30 every 5-15 seconds
    IEnumerator Change60()
    {
        currentSpeedLimit = 60;
        yield return new WaitForSeconds(Random.Range(5, 15));
        StartCoroutine("Change30");
    }

    IEnumerator Change30()
    {
        currentSpeedLimit = 30;
        yield return new WaitForSeconds(Random.Range(5, 15));
        StartCoroutine("Change60");
    }

    IEnumerator DeadSequence()
    {
        yield return new WaitForSeconds(.5f);
        
        GetComponent<BoxCollider>().enabled = false;
        dissolveOverTime = -1;
        StartCoroutine("SwitchScene");
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Replay");

    }
    
}