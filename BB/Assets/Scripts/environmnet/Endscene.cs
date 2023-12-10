using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Endscene : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 0;
    public string TimeText;
    bool over = false;
    private void Update()
    {
        if(!over)
        {
            timer += Time.deltaTime;

            float minutes = Mathf.FloorToInt(timer / 60);
            float seconds = Mathf.FloorToInt(timer % 60);
            TimeText = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        PlayerPrefs.SetString("Time" + MainMenuController.level, TimeText);
        SceneManager.LoadScene(10);
    }
}
