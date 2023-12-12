using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering;

public class Explosion : MonoBehaviour
{
    ParticleSystem flame;
    ParticleSystem fire1;
    ParticleSystem fire2;
    ParticleSystem fire3;
    public Color color;
    public float error = 30f;
    public float jumpForce = 12f;
    Rigidbody2D rb;
    Dash ds;
    
    public bool isSideWall = false;

    void Start()
    {
        flame = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        Transform pos = GetComponent<Transform>();
        if (gameObject.layer == 6)
        {
            fire1 = Instantiate(flame, gameObject.transform.position + new Vector3(0, 0f, 0.1f), Quaternion.identity, gameObject.transform);
            fire2 = Instantiate(flame, gameObject.transform.position + new Vector3(2f, 0f, 0.1f), Quaternion.identity, gameObject.transform);
            fire3 = Instantiate(flame, gameObject.transform.position + new Vector3(-2f, 0f, 0.1f), Quaternion.identity, gameObject.transform);
        }
        else if (gameObject.layer == 7)
        {
            fire1 = Instantiate(flame, gameObject.transform.position + new Vector3(0, -2f, 0.1f), Quaternion.Euler(0,0,90), gameObject.transform);
            fire2 = Instantiate(flame, gameObject.transform.position + new Vector3(0f, 0f, 0.1f), Quaternion.Euler(0, 0, 90), gameObject.transform);
            fire3 = Instantiate(flame, gameObject.transform.position + new Vector3(0f, 2f, 0.1f), Quaternion.Euler(0, 0, 90), gameObject.transform);
        }

        if (gameObject.layer == 6 || gameObject.layer == 7)
        {
            fire1.Stop();
            fire2.Stop();
            fire3.Stop();
        }
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
            {   if (collision.gameObject.CompareTag("Player"))
                {     //fire.transform.localPosition= new Vector2(0.0f,0.0f);
                    Func(fire1);
                    Func(fire2);
                    Func(fire3);
                }
                Destroy(gameObject, 2f);
                if (collision.gameObject.CompareTag("water"))
                {
                    Destroy(gameObject, .5f);
                }
            }
        }
    }
    private void Func(ParticleSystem fire)
    {
        fire.Play();
        var col = fire.colorOverLifetime;

        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[]
        { new GradientColorKey(color, 1.0f), new GradientColorKey(color, 1.0f) },
        new GradientAlphaKey[]
        { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) });
        col.color = grad;
    }
    
}  


