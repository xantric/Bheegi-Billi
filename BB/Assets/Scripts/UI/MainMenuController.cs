using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
    // public GameObject mainMenuPanel;
    //public static bool isMainMenuActive;
    public void OpenLevels()
    {
        // Load the main game scene (assuming it's at build index 1)
        SceneManager.LoadScene(2);
    }

    public void OpenTutorials()
    {
        // Load the main game scene (assuming it's at build index 1)
        SceneManager.LoadScene(3);
    }

    public void OpenLeaderboard()
    {
        // Load the main game scene (assuming it's at build index 1)
        SceneManager.LoadScene(4);
    }

    public void OpenSettings()
    {
        // Load the main game scene (assuming it's at build index 1)
        SceneManager.LoadScene(5);
    }

    public void QuitGame()
    {
        // Quit the game (only works in standalone builds)
        Debug.Log("QUIT");
        Application.Quit();
    }
}