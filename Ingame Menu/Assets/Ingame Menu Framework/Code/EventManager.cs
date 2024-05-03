using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Class handling events such as unit destruction and spawning. This class
/// provides static methods for easy subscription of objects.
/// </summary>
public class EventManager : MonoBehaviour {

    public static event EventHandler PointerEntry;
    public static event EventHandler PointerExit;
    public static event EventHandler CloseClicked;
    public static event EventHandler MenuOpened;

    /// <summary>
    /// Used by ClickableText to let MenuControllers know to which menu
    /// the invoking clickable text is assigned.
    /// </summary>
    public class MenuEventArgs : EventArgs
    {
        public GameObject Menu;
    }

    // Invoked by: ClickableText, ClickableImage
    // Listened to by: SimpleMenuController
    public static void OnPointerEnter(EventArgs e, GameObject sender)
    {
        PointerEntry(sender, e);        
    }

    // Invoked by: ClickableImage
    // Listened to by: SimpleMenuController
    public static void OnPointerExit(EventArgs e, GameObject sender)
    {
        PointerExit(sender, e);
    }

    // Invoked by: Menu controllers
    // Listened to by: CanvasController
    public static void OnCloseClicked(EventArgs e, GameObject sender)
    {
        CloseClicked(sender, e);
    }

    // Invoked by: Menu controllers
    // Listened to by: CanvasController
    public static void OnMenuOpened(EventArgs e, GameObject sender)
    {
        MenuOpened(sender, e);
    }

}
