using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public static int level;
    // public GameObject mainMenuPanel;
    //public static bool isMainMenuActive;

    public void OpenMenu()
    {
        // Load the main game scene (assuming it's at build index 1)
        SceneManager.LoadScene(1);
    }

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

    public void OpenName()
    {
        // Load the main game scene (assuming it's at build index 1)
        SceneManager.LoadScene(6);
    }

    public void OpenLevel1()
    {
        // Load the main game scene (assuming it's at build index 1)
        level = 1;
        SceneManager.LoadScene(7);
    }

    public void OpenLevel2()
    {
        // Load the main game scene (assuming it's at build index 1)
        level = 2;
        SceneManager.LoadScene(8);
    }

    public void Retry()
    {
        if(level == 1)
            SceneManager.LoadScene(7);
        if(level == 2)
            SceneManager.LoadScene(8);
    }

    public void OpenStory()
    {
        SceneManager.LoadScene(10);
    }

    public void QuitGame()
    {
        // Quit the game (only works in standalone builds)
        Debug.Log("QUIT");
        Application.Quit();
    }
}