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
        SceneManager.LoadScene(10);
    }
}
