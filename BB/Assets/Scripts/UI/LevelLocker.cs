using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLocker : MonoBehaviour
{
    private ScoreData sd;
    public Button Level2_Button;
    public ButtonColorChange button;
    void Awake()
    {
        Level2_Button.enabled = false;
        button.enabled = false;
        var json = PlayerPrefs.GetString("scores" + 1, "{}");
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
