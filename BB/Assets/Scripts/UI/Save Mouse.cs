using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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
        var connectedGamepads = Input.GetJoystickNames().Where(name => !string.IsNullOrEmpty(name)).ToArray();
        if (connectedGamepads.Length == 0)
        {
            gamepad.enabled = false;
        }
        else
        {
            gamepad.enabled = true;
        }
        //Debug.Log(connectedGamepads.Length);
    }
}
