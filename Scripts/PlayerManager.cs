using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static int numberOfCoins;
    public TMP_Text coinText;
    public static bool gameOver = false;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the UI is disabled at the start
        gameOverPanel.SetActive(false);

        // Initialize other variables
        numberOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the game is over
        if (gameOver)
        {
            // Enable the game over UI
            gameOverPanel.SetActive(true);
        }
        else
        {
            // Disable the game over UI if the game is not over
            gameOverPanel.SetActive(false);

            // Update coin text
            coinText.text = numberOfCoins.ToString();
        }
    }

    // Call this method when you want to restart the game
    public void RestartGame()
    {
        // Reset variables
        numberOfCoins = 0;
        gameOver = false;

        // Ensure the UI is disabled at the restart
        gameOverPanel.SetActive(false);

        // Additional logic for restarting the game, if needed
        // ...
    }
}
