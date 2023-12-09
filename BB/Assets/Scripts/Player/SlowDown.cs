using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{

    public PlayerMovement1 playmov;
    public float slowness = 5.0f;
    public GameObject arrow;
    public GameObject player;
    Rigidbody2D rb;
    float timer;

    public float dashSpeed = 10.0f;
    public float rotspeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += (Time.deltaTime);
        
        arrow.transform.RotateAround(player.transform.position, new Vector3(0, 0, 1), Time.deltaTime * rotspeed);
        if (timer > 15.0f)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Time.timeScale = 1f / slowness;
                playmov.enabled = false;

                arrow.SetActive(true);
            }

            if (Input.GetButtonUp("Jump"))
            {
                // playmov.isJumping=false;
                Time.timeScale = 1.0f;

                playmov.enabled = true;
                arrow.SetActive(false);

                //transform.rotation = arrow.transform.rotation;
                //rb.velocity = arrow.transform.up * dashSpeed;
                rb.AddForce(arrow.transform.up * dashSpeed, ForceMode2D.Impulse);
                timer = 0;
            }
        }

    }
}