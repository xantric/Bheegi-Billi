using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

   public ParticleSystem flame;
   ParticleSystem fire;
   public Color color;
   public float max_time;
    // Start is called before the first frame update
    void Start()
    {
        Transform pos=GetComponent<Transform>();
        fire=Instantiate(flame,pos);   
        fire.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D coli){

    
        fire.Play();
        var col=fire.colorOverLifetime;
        float t=(Time.timeSinceLevelLoad)/max_time;
        Gradient grad=new Gradient();
        grad.SetKeys( new GradientColorKey[] 
        { new GradientColorKey(color, 1.0f), new GradientColorKey(color, 1.0f) }, 
        new GradientAlphaKey[] 
        { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) } );
        col.color=grad;
    }
}
