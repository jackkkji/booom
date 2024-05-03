using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleMenuController : MenuController
{

    protected void Update()
    {
        base.Update();

        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
        {
            // Close click-menu
            RectTransform rectTransform = GetComponent<RectTransform>();
            if (!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition, null))
            {
                if (SubMenu != null)
                {
                    // If there is a sub-menu of this menu, close it only
                    rectTransform = SubMenu.GetComponent<RectTransform>();
                    if (!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition, null))
                        GameObject.Destroy(SubMenu);
                }
                else if (IsSubMenu)
                {
                    GameObject.Destroy(this.gameObject);
                    return;
                }
                else
                {
                    EventManager.OnCloseClicked(System.EventArgs.Empty, gameObject);
                }
            }
        }
    }

    #region component-specific functionality


    protected override void OnOptionSelected(int option)
    {
        if (SubMenu != null)
            return;

        CanvasController.Instance.PlaySound(CanvasController.Instance.SelectSound);

        availableOptions[option].GetButtonOnClick().Invoke();

    }   
 
    #endregion component-specific functionality

}
