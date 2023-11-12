using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
    public void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Access the GameManager and call the EarnScore method
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.EarnScore(1);

            // Perform other actions if needed (e.g., play a sound, show an animation)

            // Destroy the coin
            Destroy(gameObject);
        }
    }
}