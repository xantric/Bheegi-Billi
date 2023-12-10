using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;
    public ScoreUi scoreUi;
    public string level_number;
    void Awake()
    {
        var json = PlayerPrefs.GetString("scores"+ level_number, "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
        //sd.scores.Clear();
    }

    private void Start()
    {
        string username = PlayerPrefs.GetString("username");
        int new_score = PlayerPrefs.GetInt("Score" + level_number);
        var scores = GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i].name == username)
            {
                if(new_score> scores[i].score)
                {
                    scores[i].score = new_score;
                }
                scoreUi.instantiate();
                return;
            }
        }
        AddScore(new Score(username, new_score));
        scoreUi.instantiate();
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(x => x.score);
    }

    public void AddScore(Score score)
    {
        if(score.score != 0)
        sd.scores.Add(score);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        Debug.Log(json);
        PlayerPrefs.SetString("scores" + level_number, json);
    }
}