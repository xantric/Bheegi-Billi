using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class JumpTime : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    public SlowDown sl;


    private int maxStamina = 5;
    private int currentStamina;

    public static JumpTime instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentStamina = maxStamina;
        slider.maxValue= maxStamina;
        slider.value = maxStamina;
    }

    private void Update()
    {
        slider.value = sl.timer;
    }
    public void UseStamina()
    {
        slider.value = 0;
    }
}
