using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackerMenu : MonoBehaviour
{
    private bool Openstate = false;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Openstate)
            {
                menu.SetActive(false);
                Time.timeScale = 1;
                Openstate = false;
            }
            else
            {
                menu.SetActive(true);
                Time.timeScale = 0;
                Openstate = true;
            }
        }
    }
}
