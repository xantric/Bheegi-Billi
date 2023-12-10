using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class Explosion : MonoBehaviour
{
    public float error = 30f;

    async void OnTriggerEnter2D(Collider2D otherCollider)
    {
       
   
        {
            Vector2 relativePosition = otherCollider.transform.position - transform.position;

     
            float horizontalDistance = Mathf.Abs(relativePosition.x);
            float verticalDistance = Mathf.Abs(relativePosition.y);

            
          
                if (relativePosition.y > 0)
                {   
                    GetComponent<Collider2D>().isTrigger = false;
                    await Task.Delay(500);
                    float RandomAngle = Random.Range(-error, error);
                    Quaternion randomRotation = Quaternion.Euler(0f, 0f, RandomAngle);
                    Vector2 dir = randomRotation * Vector2.up;
                    dir.Normalize();
                    otherCollider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    otherCollider.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * 12, ForceMode2D.Impulse);
                    Destroy(gameObject);

            }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }
}

   


