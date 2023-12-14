using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndStory : MonoBehaviour
{
    VideoPlayer vp;

    private void Start()
    {
        vp = GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        if (vp.frame > 940)
        {
            SceneManager.LoadScene(1);
        }
    }
}
