using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRb;
    private SpawnManager spawnManager;

    
    public float speed = 10.0f;
    public float gravity;
    public int scoreAmount = 5;

    public bool switchIsHit;
    public bool playerFall;
    


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        spawnManager = GameObject.Find("Game Manager").GetComponent<SpawnManager>();
        Physics.gravity *= gravity;
        switchIsHit = false;
        
        
    }

   

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward * speed * forwardInput);

        float horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(-Vector3.left * speed * horizontalInput);

        if (transform.position.y < -12)
        {
            
            Destroy(gameObject);
            spawnManager.GameOver();

        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            spawnManager.GameOver();

        }


    }

    
    

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.CompareTag("switch"))
        {

            Destroy(collision.gameObject);
            spawnManager.SpawnEnemyWave(1);
            spawnManager.SpawnSwitch(1);
            spawnManager.UpdateScore(scoreAmount);
            switchIsHit = true;
            

        }




    }


}
