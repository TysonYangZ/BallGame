using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletForward;
    public GameObject bulletBack;
    public GameObject bulletLeft;
    public GameObject bulletRight;

    public float spawnRate = 1.0f;
    private SpawnManager spawnManager;
    


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBullets", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //Shoot in four directions
        if (transform.position.y < -12)
        {
            Destroy(gameObject);
            
        }



    }

    void SpawnBullets()
    {
        Instantiate(bulletForward, transform.position, bulletForward.transform.rotation);
        Instantiate(bulletBack, transform.position, bulletBack.transform.rotation);
        Instantiate(bulletLeft, transform.position, bulletLeft.transform.rotation);
        Instantiate(bulletRight, transform.position, bulletRight.transform.rotation);
    }



}
