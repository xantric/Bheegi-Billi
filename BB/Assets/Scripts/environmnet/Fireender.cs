using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireender : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject water;
    void Start()
    {
        water = GameObject.FindGameObjectWithTag("Water");
    }

    // Update is called once per frame
    void Update()
    {
        if (water.transform.localScale.y - 1.0f > gameObject.transform.position.y)
        {
            //Debug.Log(100);
            Destroy(gameObject.GetComponentInChildren<ParticleSystem>());
        }
    }

}
