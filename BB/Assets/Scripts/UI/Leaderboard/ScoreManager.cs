using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;
    public ScoreUi scoreUi;
    public int level_number;
    string json;
    bool isempty = false;
    void Awake()
    {
        string savePath = Path.Combine(Application.streamingAssetsPath, "scores" + level_number);
        if (File.Exists(savePath))
        {
            json = File.ReadAllText(savePath);
            sd = JsonUtility.FromJson<ScoreData>(json);
            isempty = true;
        }
    }

    private void Start()
    {
        if (isempty)
        {
            var scores = GetHighScores().ToArray();     
            scoreUi.instantiate();
        }
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderBy(x => x.score);
    }    
}