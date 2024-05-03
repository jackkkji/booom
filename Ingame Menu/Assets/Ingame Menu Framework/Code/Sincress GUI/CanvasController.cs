using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : Singleton<CanvasController> {

    public GameObject IngameMenu;
    public AudioClip ScrollSound, SelectSound;
    public UIElements Elements;

    // The item position that was selected on the map, if open for selection
    private Transform mapSelectedItem;
    private Vector3 mapSelectedPos;

    private Stack<GameObject> openMenus;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        openMenus = new Stack<GameObject>();

        EventManager.CloseClicked += ((sender, e) =>
        {
            CloseMenu();
        });
    }

    private void Start()
    {
        // Open the welcome menu
        var welcomeMenu = OpenMenu(CanvasController.Instance.Elements.ScrollText).GetComponent<ScrollTextController>();
        welcomeMenu.HeaderText.text = "Sincress InGame Menu System";
        welcomeMenu.AddMenuItem("Welcome to the Sincress Menu System\n", true, Color.white);
        welcomeMenu.AddMenuItem("Press Esc or click Cancel to exit this menu", false, Color.white);
        welcomeMenu.AddMenuItem("Press Enter or hover at the top of the screen to open the In-Game Menu", false, Color.white);
        welcomeMenu.AddMenuItem("Right click to open a context menu", false, Color.white);
        welcomeMenu.AddMenuItem("Select a menu item to preview some menu configurations and options\n", false, Color.white);
        welcomeMenu.AddMenuItem("See the IngameMenuController script for an example of adding menus and working with menu options", false, Color.white);
    }

    // Either the ingame menu or popup menus can be open
    void Update () {

        if (Input.GetKeyDown(KeyCode.Return) && openMenus.Count == 0)
        {
            IngameMenu.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(openMenus.Count == 0) { 
                IngameMenu.SetActive(false);
            }
        }

        if(Input.mousePosition.x > 0.25*Screen.width && Input.mousePosition.x < 0.75 * Screen.width && Input.mousePosition.y > Screen.height - 10)
            if (openMenus.Count == 0)
            {
                IngameMenu.SetActive(true);
            }

        if (Input.GetMouseButtonDown(1))
        {
            var menu = OpenMenuAtPosition(CanvasController.Instance.Elements.SimpleMenu, Input.mousePosition);
            menu.GetComponent<RectTransform>().pivot = Vector2.zero;
            menu.GetComponent<SimpleMenuController>().HeaderText.text = "Context menu (Simple Menu)";
        }
    }

    /// <summary>
    /// Opens a requested menu and returns the reference to the UI gameobject.
    /// </summary>
    /// <param name="menu">Menu prefab from the UIElements object</param>
    /// <returns>UI element gameobject</returns>
    public GameObject OpenMenu(GameObject menu, bool isSubMenu = false)
    {
        GameObject menuInstance = GameObject.Instantiate(menu, this.transform);

        if (isSubMenu)
            return menuInstance;

        // Set currently open menu to inactive
        if (openMenus.Count > 0)
            openMenus.Peek().SetActive(false);
        // Add new open menu
        openMenus.Push(menuInstance);

        return menuInstance;
    }

    /// <summary>
    /// Opens a requested menu at a given 2D position (usually mousePosition) 
    /// and returns the reference to the UI gameobject.
    /// </summary>
    /// <param name="menu">Menu prefab from the UIElements object</param>
    /// <param name="position">2D screen position of UI element's upper-right corner</param>
    /// <returns>UI element gameobject</returns>
    public GameObject OpenMenuAtPosition(GameObject menu, Vector2 position, bool hideMenuBelow = true, bool isSubMenu = false)
    {
        GameObject menuInstance = null;

        if (!hideMenuBelow)
        {
            menuInstance = GameObject.Instantiate(menu, this.transform);

            // Add new open menu
            if(!isSubMenu)
                openMenus.Push(menuInstance);
        }
        else
            menuInstance = OpenMenu(menu, isSubMenu);

        menuInstance.GetComponent<RectTransform>().anchoredPosition = position;

        return menuInstance;
    }

    /// <summary>
    /// Closes the currently visible (open) menu (and opens a menu one layer below, if such
    /// exists)
    /// </summary>
    public void CloseMenu()
    {
        if(openMenus.Count > 0) {

            GameObject menu = openMenus.Pop();
            GameObject.Destroy(menu);
        }
    }

    public int GetNumberOfOpenMenus()
    {
        return openMenus.Count;
    }

    /// <summary>
    /// Closes all opened menus, including the special menus (ingame menu and map)
    /// </summary>
    public void CloseAllMenus()
    {
        while (GetNumberOfOpenMenus() > 0)
            CloseMenu();
    }



    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

}
