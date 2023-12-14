using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    VideoPlayer vp;
    public GameObject text;
    private void Awake()
    {
        //PlayerPrefs.DeleteKey("NotFirstTime");
        vp = GetComponent<VideoPlayer>();
        if (PlayerPrefs.HasKey("NotFirstTime"))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    private void Update()
    {
        if(Input.GetAxisRaw("Submit") != 0)
        {
            vp.frame = 1500;
        }
        if (vp.frame > 1500)
        {
            text.SetActive(false);
        }
        
        if(vp.frame > 1620)
        {
            SceneManager.LoadScene("First Tutorial");
        }

    }
}
