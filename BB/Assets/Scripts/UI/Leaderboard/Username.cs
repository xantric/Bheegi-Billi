using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Username: MonoBehaviour
{

    public TMP_InputField user_input;

    public Animator transition;

    private void Start()
    {
        if(PlayerPrefs.HasKey("username"))
        user_input.text = PlayerPrefs.GetString("username");
    }
    public void OnClick()
    {
        if (!string.IsNullOrEmpty(user_input.text))
        {
            PlayerPrefs.SetString("username", user_input.text);
            StartCoroutine(LoadLevel(2));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelIndex);
    }
}
