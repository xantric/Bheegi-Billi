using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D otherCollider)
    {
       
   
        {
            Vector2 relativePosition = otherCollider.transform.position - transform.position;

     
            float horizontalDistance = Mathf.Abs(relativePosition.x);
            float verticalDistance = Mathf.Abs(relativePosition.y);
          
                if (relativePosition.y > 0)
                {   otherCollider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    otherCollider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 12, ForceMode2D.Impulse);
                    Destroy(gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }


