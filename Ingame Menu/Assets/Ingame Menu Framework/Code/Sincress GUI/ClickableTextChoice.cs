using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableTextChoice : ClickableText {

    public Text ValueText;

    private string[] options;
    private int selectedOption;

	void Start () {
        selectedOption = 0;

        // When this button is clicked cycle the options
        button.onClick.AddListener(() =>
        {
            selectedOption = (selectedOption + 1) % options.Length;
            ValueText.text = options[selectedOption];
        });
	}
	
	void Update () {
        // Disregard input if item not selected
        if (text.color != Color.blue)
            return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            selectedOption = (selectedOption - 1) % options.Length;
            ValueText.text = options[selectedOption];
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            selectedOption = (selectedOption + 1) % options.Length;
            ValueText.text = options[selectedOption];
        }
        
    }

    public void SetOptions(string[] givenOptions)
    {
        options = givenOptions;
        ValueText.text = options[selectedOption];
    }

    override public Button.ButtonClickedEvent GetButtonOnClick()
    {
        return button.onClick;
    }
}
