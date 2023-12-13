using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;


//using System.Diagnostics.Eventing.Reader;
using UnityEngine;

public class WaterEnder : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform transformer,player;
    float timer,contact_timer=0f;
    float factor;
    public float growthRate = 3f;
    bool a = true, isInContact = false;
    void Start()
    {
        timer = 0f;
        factor = 0f;
    }

    // Update is called once per frame
    void Update()
    {   if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            if (player.position.y < 143f)
            {
                timer += Mathf.Min(growthRate * Time.deltaTime, 2.7f);
                factor = Mathf.Pow(timer, 1.465f);
            }

            else if (player.position.y > 143f)
            {
                if (a)
                {
                    factor = 140f;
                    a = false;
                    timer = 0;
                }
                timer += Mathf.Min(growthRate * Time.deltaTime, 2.7f);
                factor = Mathf.Pow(timer, 1.465f) + 140f;
            }


            transformer.localScale = new Vector3(transformer.localScale.x, factor, 0f);
        }
    }

}
