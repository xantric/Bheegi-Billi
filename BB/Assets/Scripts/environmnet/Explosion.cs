using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Explosion : MonoBehaviour
{
    public float error = 30f;
    public float jumpForce = 12f;
    Rigidbody2D rb;
    public Dash ds;
    public bool isSideWall = false;

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


