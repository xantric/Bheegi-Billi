using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Camera mainCam;
    public Rigidbody2D rb;
    private Vector3 MousPos;
    public float timer;
    int check = 0;
    public float slowness = 5.0f;
    public GameObject arrow;
    public float dashSpeed = 10.0f;
    public PlayerMovement1 playmov;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        timer = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        MousPos = mainCam.ScreenToWorldPoint(Input.mousePosition); 
        Vector3 rotation = MousPos - transform.position;
        float rotZ = Mathf.Atan2(-rotation.x, rotation.y)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotZ);
        timer += (Time.deltaTime);

        
        if (timer > 3.0f)
        {
            if (Input.GetMouseButtonDown(0) && check == 0)
            {
                Time.timeScale = 1f / slowness;
                playmov.enabled = false;
                check = 1;
                arrow.SetActive(true);
            }

            if (Input.GetMouseButtonUp(0) && check == 1)
            {
                // playmov.isJumping=false;
                Time.timeScale = 1.0f;
                check = 0;
                playmov.enabled = true;
                arrow.SetActive(false);

                //transform.rotation = arrow.transform.rotation;
                //rb.velocity = arrow.transform.up * dashSpeed;
                rb.AddForce(arrow.transform.up * dashSpeed, ForceMode2D.Impulse);
                timer = 0;
                JumpTime.instance.UseStamina();
            }
        }

    }
}
