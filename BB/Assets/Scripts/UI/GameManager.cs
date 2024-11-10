using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject pauseMenuUI; //the reference to the PauseMenuUI
    public GameObject sceneUI;
    public static bool gameIsPaused=false;

    private Dash dash;
    private Movement playermovement;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] AudioMixer audioMixer;
    GameObject GamepadMouse;
    GameObject mouse;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        GamepadMouse = Resources.Load<GameObject>("Prefab/Gamepad mouse");
    }
    private void Start()
    {
        playermovement = FindAnyObjectByType<Movement>();
        dash = FindAnyObjectByType<Dash>();
        if (PlayerPrefs.HasKey("musicvolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
        if (PlayerPrefs.HasKey("sfxvolume"))
        {
            LoadSFXVolume();
        }
        else
        {
            SetMusicVolume();
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
        playermovement.enabled = true;
        dash.enabled = true;
        Time.timeScale=1f;
        gameIsPaused=false;
        Cursor.visible = false;
        Destroy(mouse);
    }
    public void Pause(){
        sceneUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        playermovement.enabled=false;
        dash.enabled= false;
        Time.timeScale=0f;
        gameIsPaused=true;
        Cursor.visible = true;
        mouse = Instantiate(GamepadMouse);
    }

    public void Restart1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
    public void SetMusicVolume()
    {
        float musicvolume = musicSlider.value;
        audioMixer.SetFloat("music", 20 * Mathf.Log10(musicvolume));
        PlayerPrefs.SetFloat("musicvolume", musicvolume);
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicvolume");

        SetMusicVolume();
    }
    public void SetSFXVolume()
    {
        float sfxvolume = sfxSlider.value;
        audioMixer.SetFloat("sfx", 20 * Mathf.Log10(sfxvolume));
        PlayerPrefs.SetFloat("sfxvolume", sfxvolume);
    }

    public void LoadSFXVolume()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("sfxvolume");

        SetSFXVolume();
    }
}