using UnityEngine;

public class SideJump : MonoBehaviour
{
    public float jumpForce = 10f; // The force applied for wall jumping
    public float wallSlideSpeed = 1f; // Speed at which the character slides down the wall

    private Rigidbody2D rb;
    bool isTouchingWall = false;
    private Vector2 wallNormal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Detect wall touch here using raycasts or collision detection
        // Set isTouchingWall and wallNormal accordingly
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            // Check if the collision is happening on the sides (walls)
            if (Vector2.Dot(contact.normal, Vector2.up) < 0.1f) // Change the threshold as needed
            {
                // The contact.normal gives the normal vector of the collided wall
                wallNormal = contact.normal;
                isTouchingWall = true;
                break;
            }
        }
    }
    void FixedUpdate()
    {
        if (isTouchingWall)
        {
            Debug.Log(isTouchingWall);
            // Slide down the wall (optional)
            rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);

            // Wall jump logic when a jump input is detected
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log(true);
                Vector2 jumpDirection = Vector2.zero;

                // Determine the direction to jump away from the wall
                if (wallNormal.x >= 0.5f)
                {
                    jumpDirection = Vector2.left;
                }
                else if (wallNormal.x <= -0.5f)
                {
                    jumpDirection = Vector2.right;
                }

                // Apply the jump force
                rb.velocity = new Vector2(rb.velocity.x, 0); // Clear vertical velocity
                rb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}