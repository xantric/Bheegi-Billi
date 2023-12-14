using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Endscene : MonoBehaviour
{
    // Start is called before the first frame update
    public Timer timer;
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        PlayerPrefs.SetFloat("Time" + MainMenuController.level,timer.timer);
        if (MainMenuController.level == 1)
        {
            SceneManager.LoadScene(9);
        }
        else
        {
            SceneManager.LoadScene(12);
        }
    }
}
