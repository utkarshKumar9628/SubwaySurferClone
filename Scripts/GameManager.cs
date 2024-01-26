using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text scoreText;
    private int score = 0;

    void Awake()
    {
        // Singleton pattern to ensure there is only one instance of GameManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            
        }
    }

    void Start()
    {
        // Initialize the score and update the UI
        score = 0;
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        // Add the specified amount to the score
        score += amount;

        // Update the UI
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        // Update the score text on the UI
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogError("ScoreText is not assigned in the GameManager script.");
        }
    }
}