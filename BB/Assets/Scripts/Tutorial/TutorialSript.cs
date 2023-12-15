using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialSript : MonoBehaviour
{
    public GameObject first;
    public GameObject second;
    public GameObject third;
    public GameObject fourth;
    public GameObject fifth;
    public GameObject sixth;

    public GameObject p1;
    public GameObject p2;
    

    public GameObject banner1;
    public GameObject banner2;
    public GameObject banner3;
    public GameObject banner4;
    public GameObject banner5;

    public GameObject platform1;

    public GameObject afterLevel;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == banner1)
        {
            banner1.SetActive(false);
            banner2.SetActive(true);

            first.SetActive(false);
            second.SetActive(true);
        }

        if (collision.gameObject == banner2)
        {
            banner2.SetActive(false);
            banner3.SetActive(true);

            second.SetActive(false);
            third.SetActive(true);
        }

        if (collision.gameObject == banner3)
        {
            banner3.SetActive(false);
            banner4.SetActive(true);

            third.SetActive(false);
            fourth.SetActive(true);
        }

        if (collision.gameObject == banner4)
        {
            banner4.SetActive(false);
            banner5.SetActive(true);

            Destroy(p1);
            Destroy(p2);

            platform1.SetActive(true);

            fourth.SetActive(false);
            fifth.SetActive(true);
        }

        if (collision.gameObject == banner5)
        {
            banner5.SetActive(false);
            afterLevel.SetActive(true);

            fifth.SetActive(false);
            sixth.SetActive(true);
        }

    }
}
