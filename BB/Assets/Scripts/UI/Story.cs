using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    VideoPlayer vp;

    public Animator transition;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
       vp = GetComponent<VideoPlayer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Submit") != 0 && vp.frame < 1500)
        {
            vp.frame = 1500;
        }
        if (vp.frame > 1500)
        {
            text.SetActive(false);
        }
        if (vp.frame > 1620)
        {
            StartCoroutine(LoadLevel(2));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(levelIndex);
    }
}
