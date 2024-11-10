using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class SaveMouse : MonoBehaviour
{
    public static SaveMouse instance;
    VirtualMouseInput gamepad;
    private void Awake()
    {
        gamepad = GetComponent<VirtualMouseInput>();
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    private void Update()
    {
        if (Gamepad.current!=null)
        {
            gamepad.enabled = true;
        }
        else
        {
            gamepad.enabled = false;
        }
        //Debug.Log(connectedGamepads.Length);
    }

}
