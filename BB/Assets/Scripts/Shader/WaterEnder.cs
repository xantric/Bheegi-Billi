using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] AudioSource death;
    [SerializeField] AudioSource bg;

    void Start()
    {
        timer = 0f;
        factor = 0f;
    }

    // Update is called once per frame
    void Update()
    {   if (SceneManager.GetActiveScene().name == "Level 2")
        {
            if (player.position.y < 125f)
            {
                timer += Mathf.Min(growthRate * Time.deltaTime, 2.7f);
                factor = Mathf.Pow(timer, 1.465f);
            }

            else if (player.position.y > 125f)
            {
                if (a)
                {
                    factor = 140f;
                    a = false;
                    timer = 0;
                }
                timer += Mathf.Min(growthRate * Time.deltaTime, 2.7f);
                factor = Mathf.Pow(timer, 1.35f) + 140f;
            }
        }
        if (SceneManager.GetActiveScene().name=="Level 1")
        {
            Debug.Log("Level 1 reached");
            // timer += Time.deltaTime;
            factor+=Time.deltaTime*4.0f;
        }
        if (transformer.localScale.y + 0.3f > player.position.y)
        {
            contact_timer += Time.deltaTime;
        }
        else contact_timer = 0f;
        if (contact_timer > 1f)
        {
            death.Play();
            anime.SetInteger("state", -3);
            movement.enabled = false;
            dash.enabled = false;
            Invoke("Death", 2f);
            
        }
        transformer.localScale = new Vector3(transformer.localScale.x, factor, 0f);
    }
    void Death()
    {
        SceneManager.LoadScene(11);
    }

}
