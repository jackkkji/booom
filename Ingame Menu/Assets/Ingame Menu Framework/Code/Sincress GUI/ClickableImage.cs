using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

    private Image image;

	void Awake () {
        image = GetComponent<Image>();
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        EventManager.OnPointerEnter(System.EventArgs.Empty, gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        EventManager.OnPointerExit(System.EventArgs.Empty, gameObject);
    }
   
    public void SetColor(Color color)
    {
        if (image == null)
            image = GetComponent<Image>();
        image.color = color;
    }
    
}
