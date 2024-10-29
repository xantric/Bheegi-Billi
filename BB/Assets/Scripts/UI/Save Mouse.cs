using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMouse : MonoBehaviour
{
    public static SaveMouse instance;
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
