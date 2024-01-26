using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartLevel()
    {
        // Get the build index of the currently active scene
        SceneManager.LoadScene("Mainmenu");
        


    }
    public void QuitGame()
    { 
    
    Application.Quit();
    
    }
}
