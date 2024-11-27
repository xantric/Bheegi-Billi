using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LevelLocker : MonoBehaviour
{
    private ScoreData sd;
    public Button Level2_Button;
    public ButtonColorChange button;
    private readonly string key = "GameDevIITK";
    void Awake()
    {
        Level2_Button.enabled = false;
        button.enabled = false;
        string savePath = Path.Combine(Application.streamingAssetsPath, "scores" + 1);
        if (File.Exists(savePath))
        {
            var json = File.ReadAllText(savePath);
            json = EncryptDecrypt(json);
            sd = JsonUtility.FromJson<ScoreData>(json);
        foreach (Score score in sd.scores)
        {
            if (score.name == PlayerPrefs.GetString("username"))
            {
                Level2_Button.enabled = true;
                button.enabled = true;
            }
        }
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
}
