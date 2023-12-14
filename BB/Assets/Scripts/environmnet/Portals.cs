using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Portals : MonoBehaviour
{
    public Transform destination;//the position where the player will be teleported to
    GameObject player;
    public Vector2 velocityScale;
    Rigidbody2D rb;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    
        rb = player.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Vector2.Distance(player.transform.position, transform.position) > 0.75f)
            { //value must be changed as per the game dimensions to avoid infinite teleports
                collision.gameObject.GetComponent<TrailRenderer>().enabled = false;
                StartCoroutine(Portal_In());
                StartCoroutine(MoveInPortal());
            }
            
            Destroy(gameObject, 0.5f);
        }
    }
    IEnumerator Portal_In()
    {

        
        yield return new WaitForSeconds(0f);
        Vector2 velocity = rb.velocity;

        player.transform.position = destination.position;


        rb.velocity = new Vector2(Mathf.Sign(velocityScale.x) * velocity.x, Mathf.Sign(velocityScale.y) * velocity.y);

    }
    IEnumerator MoveInPortal()
    {
        yield return new WaitForSeconds(0.3f);
        rb.GetComponent<TrailRenderer>().enabled = true;
    }
}