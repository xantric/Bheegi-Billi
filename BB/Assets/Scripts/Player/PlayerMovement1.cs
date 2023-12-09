using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public Transform player;
    Rigidbody2D rb;
    public float speed = 10.0f;
    float jump;
    float move;
    public bool isJumping = false;
    public float jumpForce = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        player.position += new Vector3(move, 0, 0);
        // if(Input.GetButtonDown("Jump") && isInAir())
        // {
        //     isJumping=true;

        //     rb.velocity = new Vector3(0, 1, 0) * jumpForce;
        // }
    }
    bool isInAir()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector3.up, 10f);

        int layerMask = LayerMask.GetMask("Ground");
        if (Physics2D.Raycast(transform.position, Vector3.down, 1f, layerMask))
        {
            return true;
        }
        else return false;
    }
}
