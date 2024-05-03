using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollTextController : MonoBehaviour
{
    // Reference to scroll content used for adding objects
    public GameObject ScrollContentContainer;
    public Scrollbar ScrollBar;
    public Text HeaderText;

    private RectTransform textContainer;
    private float keyPressTimer;
    private bool fastScrollDown, fastScrollUp;

    public void Awake()
    {
        textContainer = ScrollContentContainer.GetComponent<RectTransform>();
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ScrollBar.value -= 0.1f * ScrollBar.size;

            keyPressTimer = 0.5f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            keyPressTimer -= Time.deltaTime;
            if (keyPressTimer < 0 && !fastScrollDown)
            {
                fastScrollDown = true;
                keyPressTimer = 0.05f;
            }
            if (keyPressTimer < 0 && fastScrollDown)
            {
                ScrollBar.value -= 0.1f * ScrollBar.size;
                keyPressTimer = 0.05f;
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            fastScrollDown = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ScrollBar.value += 0.1f * ScrollBar.size;

            keyPressTimer = 0.5f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            keyPressTimer -= Time.deltaTime;
            if (keyPressTimer < 0 && !fastScrollUp)
            {
                fastScrollUp = true;
                keyPressTimer = 0.05f;
            }
            if (keyPressTimer < 0 && fastScrollUp)
            {

                ScrollBar.value += 0.1f * ScrollBar.size;

                keyPressTimer = 0.05f;
            }
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            fastScrollUp = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {            
            EventManager.OnCloseClicked(System.EventArgs.Empty, gameObject);
        }
    }

    /// <summary>
    /// This method is invoked by the element that populates this menu. The method 
    /// allows a text item to be added with optional bolding and color choice.
    /// </summary>
    /// <param name="text">Title/text of the menu option</param>
    /// <returns>OnClick event handler to be used by the invoker</returns>
    public void AddMenuItem(string text, bool isBold, Color color)
    {
        GameObject listItem = Instantiate(CanvasController.Instance.Elements.TextPanel);
        listItem.name = text;

        RectTransform rt = listItem.GetComponent<RectTransform>();
        rt.SetParent(textContainer.transform);
        rt.sizeDelta = new Vector2(GetComponent<RectTransform>().rect.width, rt.rect.height);

        Text t = listItem.GetComponentInChildren<Text>();
        t.text = text;

        if(isBold)
            t.fontStyle = FontStyle.Bold;

        t.color = color;
    }

    /// <summary>
    /// This method is invoked by the element that populates this menu. Adds a text 
    /// item with optional bolding and color choice. This text item
    /// used two text fields, one on the left and one on the right of the panel.
    /// </summary>
    /// <param name="text">Title/text of the menu option</param>
    /// <returns>OnClick event handler to be used by the invoker</returns>
    public void AddMenuItem(string text1, string text2, bool isBold, Color color)
    {
        GameObject listItem = Instantiate(CanvasController.Instance.Elements.TwoTextPanel);
        listItem.name = text1;

        RectTransform rt = listItem.GetComponent<RectTransform>();
        rt.SetParent(textContainer.transform);
        rt.sizeDelta = new Vector2(GetComponent<RectTransform>().rect.width, rt.rect.height);

        Text[] t = listItem.GetComponentsInChildren<Text>();
        t[0].text = text1;
        t[1].text = text2;

        if (isBold) { 
            t[0].fontStyle = FontStyle.Bold;
            t[1].fontStyle = FontStyle.Bold;
        }

        t[0].color = color;
        t[1].color = color;
    }

    public void ClearItems()
    {
        if(textContainer == null)
            textContainer = ScrollContentContainer.GetComponent<RectTransform>();

        for (int i = 0; i < textContainer.childCount; i++)
            GameObject.Destroy(textContainer.GetChild(i).gameObject);
    }

    public void OnCloseClicked()
    {
        EventManager.OnCloseClicked(System.EventArgs.Empty, gameObject);
    }
}
