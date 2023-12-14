using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonColorChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   
    public TMPro.TextMeshProUGUI button;
    public Color normalColor; // Default color of the text
    public Color hoverColor;  // Color when hovering

    void Start()
    {
       // Get the Text component of the button
       button.color = normalColor;
       // buttonText.color = normalColor; // Set the initial color
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.color = hoverColor; // Change color on hover
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.color = normalColor; // Change back to normal color when not hovering
    }
}
