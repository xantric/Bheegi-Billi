using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Camera mainCam;
    public Rigidbody2D rb;
    private Vector3 MousPos;
    public float timer;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        timer = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        MousPos = mainCam.ScreenToWorldPoint(Input.mousePosition); 
        Vector3 rotation = MousPos - transform.position;
        float rotZ = Mathf.Atan2(-rotation.x, rotation.y)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotZ);
        timer += (Time.deltaTime);

    }
}
