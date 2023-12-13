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
        vp.loopPointReached += Vp_loopPointReached;

    }

    private void Vp_loopPointReached(VideoPlayer source)
    {
        SceneManager.LoadScene("Tutorial");
    }
}
