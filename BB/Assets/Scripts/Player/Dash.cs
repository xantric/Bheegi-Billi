using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Camera mainCam;
    public Rigidbody2D rb;
    public GameObject player;
    private Vector3 MousPos;
    public float timer;
    int check = 0;
    public float slowness = 5.0f;
    public GameObject arrow;
    public float dashSpeed = 10.0f;
    public PlayerMovement1 playmov;

    public float stamina = 3.0f;

    public float targetMagnitude = 5f;
    public float lerpFactor = 0.5f; // Adjust this value as needed
    public float dashTime = 0.1f;
    Vector2 startPoint, destinationPoint;

    private float _currentDashTime = 0f;
    private bool _isDashing = false;

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

        
        if (timer > stamina)
        {
            if (Input.GetMouseButtonDown(0) && check == 0)
            {
                Time.timeScale = 1f / slowness;
                playmov.enabled = false;
                check = 1;
                arrow.SetActive(true);
                rb.velocity = Vector2.zero;
            }

            if (Input.GetMouseButtonUp(0) && check == 1)
            {
                if (_isDashing == false)
                {
                    Time.timeScale = 1.0f;
                    check = 0;
                    playmov.enabled = true;
                    arrow.SetActive(false);

                    timer = 0;

                    // dash starts
                    _isDashing = true;
                    _currentDashTime = 0;


                    startPoint = player.transform.position;

                    destinationPoint = startPoint + (Vector2)(arrow.transform.up.normalized * targetMagnitude);

                    JumpTime.instance.UseStamina();
                }
            }
        }

        if (_isDashing)
        {
            // incrementing time
            _currentDashTime += Time.deltaTime;

            // a value between 0 and 1
            float perc = Mathf.Clamp01(_currentDashTime / dashTime);

            // updating position
            player.transform.position = Vector3.Lerp(startPoint, destinationPoint, perc);

            if (_currentDashTime >= dashTime)
            {
                // dash finished
                _isDashing = false;
                player.transform.position = destinationPoint;
            }
        }

    }
}
