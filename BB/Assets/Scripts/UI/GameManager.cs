using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject pauseMenuUI; //the reference to the PauseMenuUI
    public GameObject sceneUI;
    public static bool gameIsPaused=false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }
    public void Resume(){
        sceneUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
        gameIsPaused=false;
    }
    public void Pause(){
        sceneUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        gameIsPaused=true;
    }
    public void LoadMenu(){
        Time.timeScale=1f;
        Debug.Log("Loading menu...");
        SceneManager.LoadScene(1); //Loads the MainMenu scene
    }
    public void QuitGame(){
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}