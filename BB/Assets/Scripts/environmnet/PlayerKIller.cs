using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKIller : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    float timer, contact_timer = 0f;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {   if (collision.gameObject.CompareTag("Player"))
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
        }
    }
}
