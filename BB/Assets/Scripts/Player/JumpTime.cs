using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class JumpTime : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    [SerializeField] Image i;
    public Dash sl;


    private int maxStamina = 3;
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
        i.type = Image.Type.Filled;
        i.fillMethod = Image.FillMethod.Radial360;
        i.fillOrigin = (int)Image.Origin360.Bottom;
    }

    private void Update()
    {
        slider.value = sl.timer;
       // i.fillAmount = sl.timer;
        float normalizedValue = Mathf.Clamp01(sl.timer);
        // i.fillAmount = normalizedValue;
        float lerpValue = Mathf.Clamp01(sl.timer / 3f);  // 3 seconds fill time
        i.fillAmount = Mathf.Lerp(0f, normalizedValue, lerpValue);
    }
    public void UseStamina()
    {
        slider.value = 0;
    }
}
