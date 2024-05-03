using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableText : MonoBehaviour, IPointerEnterHandler {

    public GameObject OwnerMenu;

    public Text Text
    {
        get { return text; }
    }
    protected Text text;
    protected Button button;

    protected void Awake () {
        text = GetComponent<Text>();
        button = GetComponent<Button>();
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        EventManager.MenuEventArgs args = new EventManager.MenuEventArgs();

        // Save the owner menu object of this clickabletext
        args.Menu = OwnerMenu;

        EventManager.OnPointerEnter(args, gameObject);
    }

    public virtual Button.ButtonClickedEvent GetButtonOnClick()
    {
        return button.onClick;
    }

    public void SetText(string newText)
    {
        text.text = newText;
    }

    public void SetColor(Color color)
    {               
        text.color = color;       
    }

    
}
