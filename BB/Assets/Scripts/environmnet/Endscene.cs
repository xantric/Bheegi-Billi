using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class Endscene : MonoBehaviour
{
    // Start is called before the first frame update
    private ScoreData sd;
    public Timer timer;
    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        var json = PlayerPrefs.GetString("scores" + MainMenuController.level, "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        string username = PlayerPrefs.GetString("username");
        for (int i = 0; i < sd.scores.Count; i++)
        {
            if (sd.scores[i].name == username)
            {
                if (timer.timer != 0 && timer.timer < sd.scores[i].score)
                {
                    sd.scores[i].score = timer.timer;
                }
            }
        }
        AddScore(new Score(username, timer.timer));
        SaveScore();
        if (MainMenuController.level == 1)
        {
            SceneManager.LoadScene(9);
        }
        else
        {
            SceneManager.LoadScene(12);
        }
    }

    public void AddScore(Score score)
    {
        if (score.score != 0)
            sd.scores.Add(score);
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        Debug.Log(json);
        PlayerPrefs.SetString("scores" + MainMenuController.level, json);
    }
}
