using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public GameObject intro1;
    public GameObject intro2;
    public GameObject intro3;
    public float timer;
    private bool PlayingIntro;

    public InputField mainInputField;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        PlayingIntro = true;
        intro1.SetActive(true);
        textComponent.text = string.Empty;
        StartDialogue();
        mainInputField.DeactivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayingIntro)
        {
            Time.timeScale = 0;
            if (Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer <= 3f)
            {
                intro1.SetActive(true);
            }
            if (timer <= 6f && timer >= 3f)
            {
                intro1.SetActive(false);
                intro2.SetActive(true);
            }
            if(timer >= 9f && timer <= 12f)
            {
                intro2.SetActive(false);
                intro3.SetActive(true);
            }
            if (timer >= 12f)
            {
                intro2.SetActive(false);
                intro3.SetActive(false);
                PlayingIntro = false;
                mainInputField.ActivateInputField();
            }
        }

    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine() {         
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
