using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollMenuController : MenuController
{
    // Reference to scroll content used for adding objects
    public Scrollbar ScrollBar;

    private float keyPressTimer;
    private bool fastScrollDown, fastScrollUp;
 
    protected void Update()
    {
        if (DisableKeyInput) {
            for (int i = 0; i < availableOptions.Count; i++)
                availableOptions[i].SetColor(Color.white);
            return;
        }

        base.Update();

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {           
            ScrollBar.value -= 1f / availableOptions.Count;

            keyPressTimer = 0.5f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            keyPressTimer -= Time.deltaTime;
            if(keyPressTimer < 0 && !fastScrollDown)
            {
                fastScrollDown = true;
                keyPressTimer = 0.1f;
            }
            if (keyPressTimer < 0 && fastScrollDown)
            {
                availableOptions[selectedOption].SetColor(Color.white);
                if (selectedOption + 1 < availableOptions.Count)
                    selectedOption++;

                ScrollBar.value -= 1f / availableOptions.Count;
                CanvasController.Instance.PlaySound(CanvasController.Instance.ScrollSound);
                keyPressTimer = 0.1f;
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            fastScrollDown = false;
        }


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {            
            ScrollBar.value += 1f / availableOptions.Count;

            keyPressTimer = 0.5f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            keyPressTimer -= Time.deltaTime;
            if (keyPressTimer < 0 && !fastScrollUp)
            {
                fastScrollUp = true;
                keyPressTimer = 0.1f;
            }
            if (keyPressTimer < 0 && fastScrollUp)
            {
                availableOptions[selectedOption].SetColor(Color.white);
                if (selectedOption > 0)
                    selectedOption--;

                ScrollBar.value += 1f / availableOptions.Count;
                CanvasController.Instance.PlaySound(CanvasController.Instance.ScrollSound);

                keyPressTimer = 0.1f;
            }
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            fastScrollUp = false;
        }        

    }

    /// <summary>
    /// This method is invoked by the element that populates this menu. The method 
    /// returns an onclick handler which can be used by the invoker to process the 
    /// option click/selection events.
    /// </summary>
    /// <param name="text">Title/text of the menu option</param>
    /// <param name="color">Color of the item in the list</param>
    /// <param name="icon">Icon of the item</param>
    /// <param name="iconAspect">Aspect ratio of the icon image</param>
    /// <returns>OnClick event handler to be used by the invoker</returns>
    public Button.ButtonClickedEvent AddMenuOption(string text, Color color, Sprite icon, float iconAspect = 1)
    {
        GameObject listItem = Instantiate(CanvasController.Instance.Elements.ClickableImageText);
        listItem.name = text;

        RectTransform rt = listItem.GetComponent<RectTransform>();
        rt.SetParent(OptionContainer.transform);

        ClickableIconText nli = listItem.GetComponent<ClickableIconText>();
        nli.SetText(text);
        nli.Icon.color = color;
        nli.Icon.sprite = icon;
        nli.Icon.GetComponent<AspectRatioFitter>().aspectRatio = iconAspect;
        nli.OwnerMenu = this.gameObject;

        availableOptions.Add(nli);

        return nli.GetButtonOnClick();
    }

    #region component-specific functions   

    protected override void OnOptionSelected(int option)
    {
        if (SubMenu != null)
            return;

        CanvasController.Instance.PlaySound(CanvasController.Instance.SelectSound);

        availableOptions[option].GetButtonOnClick().Invoke();

    }

    #endregion component-specific functions
}
