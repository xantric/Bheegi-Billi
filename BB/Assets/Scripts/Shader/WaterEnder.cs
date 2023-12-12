using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnder : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform transformer,player;
    float timer;
    float factor;
    void Start()
    {
        timer = 0;
        factor = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (player.position.y <= 43.5f)
        {
            factor = timer;
        }
        else if (player.position.y <= 63f)
        {
            factor = 2.0f * timer;
        }
        else if (player.position.y <= 150f)
        {
            factor = Mathf.Pow(timer, 2);
        }
        else if (player.position.y <= 167f)
        {
            factor = Mathf.Pow(timer, 3);
        }
        else
        {
            factor = Mathf.Exp(timer);
        }
        transformer.localScale = new Vector3(transformer.localScale.x, factor, 0f);
    }
    int determine_region(float y)
    {
        if (y < 43.5)
        {
            return 1;
        }
        else if (y < 63)
        {
            return 2;
        }
        else if (y < 150)
        {
            return 3;
        }
        else if (y < 167)
        {
            return 4;
        }
        else
        {
            return 5;
        }
    }
}
