using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timer = 0f;
    public TextMeshProUGUI timerText; //Add reference to the timer TMPro gameObject

    void Update()
    {
        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}