using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;


public class SpawnManager : MonoBehaviour
{
    private Player playerClass;
    private float spawnRange = 13.5f;
    private int totalScore;

    public GameObject enemyPrefab;
    public GameObject switchPrefab;
    public GameObject playerPrefab;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    
    public int switchCount;
   
    public int gameTimer;
    
    public bool isGameActive;
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        isGameActive = true;
        playerClass = GameObject.Find("Player").GetComponent<Player>();
        totalScore = 0;
        
        SpawnEnemyWave(1);
        SpawnSwitch(1);
        UpdateScore(0);
        
        StartCoroutine(TimeCountDown());


    }

    // Update is called once per frame
    void Update()
    {

    }


    public void UpdateScore(int score)
    {
        totalScore += score;
        scoreText.text = "Score: " + totalScore;
    }

    public Vector3 PlayerSpawnPosition()
    {

        Vector3 vector3 = new Vector3(0, 9, 0);
        return vector3;

    }



    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-17, 19);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 5, spawnPosZ);

        return randomPos;
    }

    public void SpawnEnemyWave(int enemyToSpawn)
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

        }

    }

    public void SpawnSwitch(int switchToSpawn)
    {
        Instantiate(switchPrefab, GenerateSpawnPosition(), switchPrefab.transform.rotation);
    }

    public void SpawnPlayer(int playerToSpawn)
    {
        
        Instantiate(playerPrefab, new Vector3(0, 6, 0), playerPrefab.transform.rotation);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

  
   


    IEnumerator TimeCountDown()
    { 

        while (isGameActive && gameTimer > 0)
        {

            timeText.text = "Time: " + gameTimer;
            yield return new WaitForSeconds(1);
            gameTimer--;

            if (gameTimer == 0)
            {
                timeText.text = "Time: " + gameTimer;
                GameOver();
            }
        }
    }


}
