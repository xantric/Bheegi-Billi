using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Username: MonoBehaviour
{

    public TMP_InputField user_input;

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
            SceneManager.LoadScene(2);
        }
    }
}
