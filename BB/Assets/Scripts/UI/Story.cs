using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    VideoPlayer vp;

    // Start is called before the first frame update
    void Start()
    {
       vp = GetComponent<VideoPlayer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(vp.frame > 1620)
        {
            SceneManager.LoadScene(1);
        }
    }
}
