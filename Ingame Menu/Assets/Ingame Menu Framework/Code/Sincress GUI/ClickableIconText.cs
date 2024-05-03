using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableIconText : ClickableText {

    public Image Icon {
        get { return image; }
    }
    protected Image image;

    protected void Awake()
    {
        image = GetComponentInChildren<Image>();
        text = GetComponentInChildren<Text>();
        button = GetComponentInChildren<Button>();
    }

}
