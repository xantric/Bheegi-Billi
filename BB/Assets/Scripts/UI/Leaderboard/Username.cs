using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Username : MonoBehaviour
{

    public TMP_InputField user_input;


    public void OnClick()
    {
        PlayerPrefs.SetString("username", user_input.text);
        int leveller = MainMenuController.level;

        if (leveller == 1)
            SceneManager.LoadScene(7);

        if (leveller == 2)
            SceneManager.LoadScene(8);

        if (leveller == 3)
            SceneManager.LoadScene(9);
    }
}
