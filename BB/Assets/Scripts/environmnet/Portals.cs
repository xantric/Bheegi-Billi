using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
            if (Vector2.Distance(player.transform.position, transform.position) > 0.75f) //value must be changed as per the game dimensions to avoid infinite teleports
                StartCoroutine(Portal_In());
        }
    }
    IEnumerator Portal_In()
    {

        //I set two animations for the portal, one for the player to go in and one for the player to go out
        //"Portals" is the name of the parameter in the animator, which toggles between the two animations and the idle animation
        Vector2 velocity = rb.velocity;
        //rb.simulated = false;
    
        //StartCoroutine(MoveInPortal());
        //yield return new WaitForSeconds(0.5f);
        player.transform.position = destination.position;

        //yield return new WaitForSeconds(0.5f);
        rb.velocity = new Vector2(velocityScale.x * velocity.x, velocityScale.y * velocity.y); //velocity must be changed as per the portals dimensions and requirements
        yield return new WaitForSeconds(0);
   
        //rb.simulated = true;
    }
    IEnumerator MoveInPortal()
    {
        float timer = 0;
        while (timer < 0.5f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, Time.deltaTime * 3);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}