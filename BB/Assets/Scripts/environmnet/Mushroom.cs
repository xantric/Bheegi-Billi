using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 MousPos;
    public Transform rotatepoint;
    public GameObject arrow;
    public Rigidbody2D rb;
    public float dashSpeed = 10.0f;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
    }
    public PlayerMovement1 playmov;
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        MousPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = MousPos - transform.position;
        float rotZ = Mathf.Atan2(-rotation.x, rotation.y) * Mathf.Rad2Deg;
        rotatepoint.rotation = Quaternion.Euler(0, 0, rotZ);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("true");

            playmov.enabled = false;
            
            arrow.SetActive(true);
            rb.velocity = Vector2.zero;
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
            
        }
    }
}
