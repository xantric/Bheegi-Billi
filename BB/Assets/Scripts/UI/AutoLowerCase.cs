using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class AutoLowerCase : MonoBehaviour
{
    public TMP_InputField input;

    public void OnValueChanged()
    {
        if(input != null)
        {
            input.text = input.text.ToLower();
        }
    }
}
