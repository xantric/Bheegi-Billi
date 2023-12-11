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
        if(!isInAir())
        {
            move = Input.GetAxisRaw("Horizontal") * speed;
            rb.velocity = new Vector2(move, rb.velocity.y);

            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
    bool isInAir()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector3.up, 10f);

        int layerMask = LayerMask.GetMask("Level");
        if (Physics2D.Raycast(transform.position, Vector3.down, 1f, layerMask))
        {
            return false;
        }
        else return true;
    }
}
