using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int coinValue = 10; // Score value of the coin
    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // The coin is collected by the player
            CollectCoin();
        }
    }

    void CollectCoin()
    {
        PlayerController playerController = GetComponent<PlayerController>();

        // Check if the PlayerController component is present
        if (playerController != null)
        {
            Debug.Log("Coins: " + playerController.numberOfCoins);

            // Add the coin value to the player's score
            playerController.numberOfCoins += coinValue;

            // Destroy the coin object
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("PlayerController component not found on the GameObject with CoinCollector script.");
        }
    }
}