using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Explosion : MonoBehaviour
{
    public float error = 30f;
    public float jumpForce = 12f;
    Rigidbody2D rb;
    Dash ds;
    public bool isSideWall = false;

    void Start()
    {
        GameObject rotatePoint = GameObject.FindGameObjectWithTag("RotatePoint");
        ds = rotatePoint.GetComponent<Dash>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isSideWall)
        {
            if (ds._isDashing)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject, 2.0f);
            }
        }
    }

}  


