using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLocker : MonoBehaviour
{
    private ScoreData sd;
    public Button Level2_Button;
    void Awake()
    {
        Level2_Button.enabled = false;
        Level2_Button.image.color = Color.grey;
        var json = PlayerPrefs.GetString("scores" + 1, "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
        foreach (Score score in sd.scores)
        {
            if (score.name == PlayerPrefs.GetString("username") || PlayerPrefs.HasKey("Time" + 1))
            {
                Level2_Button.enabled = true;
                Level2_Button.image.color = Color.black;
            }
        }
    }
}
