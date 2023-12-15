using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndT : MonoBehaviour
{
    public GameObject text;

    public GameObject DtEXT;

    public Animator transition;

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        DtEXT.SetActive(false);
        text.SetActive(true);

        if (collision.gameObject.tag == "Player")
        {
            Invoke("NextLevel", 2f);
        }
    }

    public void NextLevel()
    {
        StartCoroutine(LoadLevel(2));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(levelIndex);
    }
}
