using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collevel : MonoBehaviour
{
    // Start is called before the first frame update
    public string num;

 void OnCollisionEnter2D(Collision2D col)
    {   if(num == "exit")
    {
        Application.Quit();
    }else{
        SceneManager.LoadScene(num);
    }
        
    }
}
