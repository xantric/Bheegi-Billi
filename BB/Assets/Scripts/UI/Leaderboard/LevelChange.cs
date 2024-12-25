using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    [SerializeField] GameObject[] levels;
    int currentLevel;

    void Start()
    {
        currentLevel = 0;
        foreach(GameObject level in levels)
        {
            level.SetActive(false);
        }
        levels[currentLevel].SetActive(true);
    }

    public void next()
    {
        if (currentLevel+1 < levels.Length)
        {
            levels[currentLevel].SetActive(false);
            currentLevel++;
            levels[currentLevel].SetActive(true);
        }
    }

    public void back()
    {
        if (currentLevel - 1 >= 0)
        {
            levels[currentLevel].SetActive(false);
            currentLevel--;
            levels[currentLevel].SetActive(true);
        }
    }
}
