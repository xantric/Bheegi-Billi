using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndStory : MonoBehaviour
{
    VideoPlayer vp;

    public Animator transition;

    private void Start()
    {
        vp = GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        if (vp.frame > 940)
        {
            StartCoroutine(LoadLevel(1));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelIndex);
    }
}
