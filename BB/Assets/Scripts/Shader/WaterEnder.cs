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
    public Movement movement;
    public Dash dash;
    float timer,contact_timer=0f;
    float factor;
    public float growthRate = 3f;
    bool a = true, isInContact = false;
    [SerializeField] Animator anime;
    void Start()
    {
        timer = 0f;
        factor = 0f;
    }

    // Update is called once per frame
    void Update()
    {   if (SceneManager.GetActiveScene().name == "Level 2")
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
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            timer += Mathf.Min(growthRate * Time.deltaTime, 3.0f);
            factor = timer * 2.0f;
        }
        if (transformer.localScale.y + 0.3f > player.position.y)
        {
            contact_timer += Time.deltaTime;
        }
        else contact_timer = 0f;
        if (contact_timer > 1f)
        {
            anime.SetInteger("state", -3);
            movement.enabled = false;
            dash.enabled = false;
        }

    }

}
