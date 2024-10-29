using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAudio : MonoBehaviour
{
    public static SaveAudio instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
}
