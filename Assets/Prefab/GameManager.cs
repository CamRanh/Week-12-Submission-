using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int lives;
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject cloudPrefab;
    public GameObject coinPrefab;
    public int score;
    public int cloudsMove;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
   


    

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;  // Set the initial number of lives
        UpdateLivesText();  // Update the lives text on start
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("SpawnEnemyOne", 1f, 2f);
        cloudsMove = 1;
        score = 0;
        scoreText.text = "Score: " + score;
        InvokeRepeating("CreateCoin", 5f, 5f);
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameOver()
    {
        CancelInvoke();
        cloudsMove = 0;
        lives = 3;
    }
    public void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
        Debug.Log("Updated lives text: " + livesText.text);
    }
    void SpawnEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8, 8), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

    void CreateSky()
    {
        for (int i = 0; i < 50; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-11f, 11f), Random.Range(-7.5f, 7.5f), 0), Quaternion.identity);
        }
    }

    public void EarnScore(int scoreToAdd)
    {
        score = score + scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void LoseLife()
    {
        lives = lives - 1;
        UpdateLivesText();
        Debug.Log("Lives after taking damage: " + lives);
        if (lives <= 0)
        {
            Debug.Log("Player out of lives");
            GameOver();
        }
    }
    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-11, 11), Random.Range(-4, 0), 0), Quaternion.identity);
    }

}