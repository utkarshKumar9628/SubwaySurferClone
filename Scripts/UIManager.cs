using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the UI is disabled at the start
        DisableGameOverUI();
    }

    // Call this method when you want to disable the game over UI
    public void DisableGameOverUI()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    // Call this method when you want to enable the game over UI
    public void EnableGameOverUI()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}