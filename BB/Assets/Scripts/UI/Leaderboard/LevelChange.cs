using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    
    [SerializeField] GameObject level1;
    [SerializeField] GameObject level2;
    public void next()
    {
        level1.SetActive(false);
        level2.SetActive(true);
    }

    public void back()
    {
        level1.SetActive(true);
        level2.SetActive(false);
    }
}
