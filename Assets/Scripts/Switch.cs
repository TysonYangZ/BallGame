using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private Rigidbody switchRb;
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        switchRb = GetComponent<Rigidbody>();
        spawnManager = GameObject.Find("Game Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -12)
        {
            spawnManager.SpawnSwitch(1);
            Destroy(gameObject);
            
        }
    }
}
