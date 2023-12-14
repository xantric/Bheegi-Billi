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
    public int level_number;
    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        var json = PlayerPrefs.GetString("scores"+ level_number, "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    private void Start()
    {
        var scores = GetHighScores().ToArray();     
        scoreUi.instantiate();
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderBy(x => x.score);
    }    
}