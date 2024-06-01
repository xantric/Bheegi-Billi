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
    bool isnotempty = false;
    private readonly string key = "GameDevIITK";
    void Awake()
    {
        string savePath = Path.Combine(Application.streamingAssetsPath, "scores" + level_number);
        if (File.Exists(savePath))
        {
            json = File.ReadAllText(savePath);
            json = EncryptDecrypt(json);
            sd = JsonUtility.FromJson<ScoreData>(json);
            isnotempty = true;
        }
    }

    private string EncryptDecrypt(string data)
    {
        string ModifiedData = "";
        for (int i = 0; i < data.Length; i++)
        {
            ModifiedData += (char)(data[i] ^ key[i % key.Length]);
        }
        return ModifiedData;
    }
    private void Start()
    {
        if (isnotempty)
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