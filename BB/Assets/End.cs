using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject text;

    public Animator transition;

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        text.SetActive(true);

        if (collision.gameObject.tag == "Player")
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
