using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Endscene : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        SceneManager.LoadScene(9);
    }
}
