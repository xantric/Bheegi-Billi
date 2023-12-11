using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnder : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform transformer;
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
        factor = Mathf.Exp(timer)/(Mathf.Exp(timer) + 1);
        transformer.localScale += new Vector3(0f, 0.5f * Time.deltaTime, 0f);
    }
}
