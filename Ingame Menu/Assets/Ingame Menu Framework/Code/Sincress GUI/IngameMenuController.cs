using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameMenuController : MonoBehaviour {

    private int selectedItem = -1;
    private List<ClickableImage> menuItems;

    private CanvasController canvasController;
    private GameObject[] OpenedMenus;   // Tracks which menus are currently open

    private System.EventHandler entryDelegate, exitDelegate;

    void Awake () {
        canvasController = transform.parent.gameObject.GetComponent<CanvasController>();
        menuItems = new List<ClickableImage>();        

        foreach (Transform child in transform)
        {
            menuItems.Add(child.gameObject.GetComponent<ClickableImage>());
        }

        OpenedMenus = new GameObject[menuItems.Count];

        entryDelegate = new System.EventHandler(OnPointerEntry);
        exitDelegate = new System.EventHandler(OnPointerExit);
    }
	
	void Update () {
        // Ignore input if a menu is open
        if (canvasController.GetNumberOfOpenMenus() > 0)
            return;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selectedItem <= 0)
            {
                selectedItem = 0;
            }
            else
            {
                menuItems[selectedItem].SetColor(Color.white);
                selectedItem--;
                CanvasController.Instance.PlaySound(CanvasController.Instance.ScrollSound);
            }
            menuItems[selectedItem].SetColor(Color.blue);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selectedItem == -1) { 
                selectedItem = 0;
            }
            else if(selectedItem+1 < menuItems.Count){
                menuItems[selectedItem].SetColor(Color.white);
                selectedItem++;
                CanvasController.Instance.PlaySound(CanvasController.Instance.ScrollSound);
            }
            menuItems[selectedItem].SetColor(Color.blue);
        }
        if (Input.GetKeyDown(KeyCode.Return)){
            OnItemSelected();
        }
    }

    private void OnEnable()
    {
        GetComponent<Animator>().SetTrigger("OpenIngameMenu");

        selectedItem = 0;
        menuItems[0].SetColor(Color.blue);
        for (int i=1; i<menuItems.Count; i++)
            menuItems[i].SetColor(Color.white);

        EventManager.PointerEntry += entryDelegate;
        EventManager.PointerExit += exitDelegate;
    }

    private void OnDisable()
    {
        EventManager.PointerEntry -= entryDelegate;
        EventManager.PointerExit -= exitDelegate;
    }

    private void OnPointerEntry(object sender, System.EventArgs e)
    {
        ClickableImage textComponent;
        if ((textComponent = ((GameObject)sender).GetComponent<ClickableImage>()) == null)
            return;
        if (canvasController.GetNumberOfOpenMenus() > 0)
            return;

        // Set all (other) items to unselected (white)
        foreach (ClickableImage ci in menuItems)
        {
            ci.SetColor(Color.white);
        }

        textComponent.SetColor(Color.blue);
        selectedItem = menuItems.IndexOf(textComponent);
    }

    private void OnPointerExit(object sender, System.EventArgs e)
    {
        if (((GameObject)sender).GetComponent<ClickableImage>() == null)
            return;
        if (canvasController.GetNumberOfOpenMenus() > 0)
            return;

        // Set all (other) items to unselected (white)
        foreach (ClickableImage ci in menuItems)
        {
            ci.SetColor(Color.white);
        }

        selectedItem = -1;
    }

    /// <summary>
    /// This method contains the functionality of the menu, and performs the 
    /// desired operation depending on which option was selected by the user.
    /// </summary>
    public void OnItemSelected()
    {
        if (OpenedMenus[selectedItem] != null)
            return;

        if (selectedItem == 0)
        {
            OpenedMenus[0] = canvasController.OpenMenu(CanvasController.Instance.Elements.ScrollText);
            ScrollTextController menu = OpenedMenus[0].GetComponent<ScrollTextController>();

            menu.HeaderText.text = "ScrollText Menu";
            menu.AddMenuItem("This is a textual scroll view with scrollable text content", false, Color.white);
            menu.AddMenuItem("Content can be bolded and coloured", true, Color.yellow);
            for(int i=0; i<3; i++)
                menu.AddMenuItem("Lorem ipsum dolor sit amet, vivendo accumsan voluptaria ne vix, te elitr nominavi sit. " +
                "Vis omnes deserunt laboramus ad, liber accumsan at sit. Duo munere aperiri ei, et sea vitae senserit. Te reque docendi sea, vim eros vulputate no." +
                "Aperiam offendit sadipscing mel cu, diam evertitur his te.Ei qui utamur dolorem civibus." +
                "Mutat fastidii ex sea.Oratio patrioque cu est, duo facer fierent ut.An vim sale reque. Cibo erat principes nam ea," +
                " ei nulla labitur mentitum qui.Vix ea unum copiosae invidunt, nominavi disputationi ex usu, hinc eius posidonium pro ex." +
                "Cum id homero ancillae propriae, his ad noster detraxit, pro te maiorum fuisset.Est epicuri instructior in, ex eum eius reque appellantur, " +
                "facete dolores definiebas ei eum.In tamquam admodum evertitur cum, no tacimates suavitate eloquentiam vim," +
                " iusto postulant ullamcorper id nec.Atqui assentior constituam his ut. " +
                "No tempor quaeque adolescens duo, no salutandi periculis democritum cum.Nam decore meliore ea.No duo odio praesent." +
                "Vis ei clita laudem.Possim omnium ne cum, vix affert aperiri pertinax ex.Labitur perfecto ea his, paulo iisque" +
                " definiebas et nec.Cum no summo impetus, sit at agam exerci.Eu labore accusata intellegam his," +
                " ius ad vidisse dolorem, munere indoctum ex mel.", false, Color.white);
        }
        if (selectedItem == 1)  
        {
            OpenedMenus[1] = canvasController.OpenMenu(CanvasController.Instance.Elements.ScrollMenu);
            ScrollMenuController menu = OpenedMenus[1].GetComponent<ScrollMenuController>();

            menu.HeaderText.text = "ScrollMenu";
            menu.AddMenuOption("Textual menu option (opens a SimpleMenu)").AddListener(() =>
            {
                // Example of opening a sub-menu (last argument is true)
                menu.SubMenu = canvasController.OpenMenuAtPosition(
                    CanvasController.Instance.Elements.SimpleMenu,
                    new Vector2(Screen.width / 2, Screen.height / 2),
                    false, true);


                var subMenu = menu.SubMenu.GetComponent<SimpleMenuController>();
                // Mark this menu as a subMenu so that it doesn't close both menus when clicking outside of it
                subMenu.IsSubMenu = true;
                subMenu.HeaderText.text = "This is a sub-menu of the ScrollMenu with clickable options";
                subMenu.AddMenuOption("Do nothing");
                subMenu.AddMenuOption("Close both menus").AddListener(() => {
                    subMenu.OnCloseClicked();
                    canvasController.CloseMenu();
                });
            });
            menu.AddMenuChoice("Textual menu choice ", new string[] { "Choice One", "Choice Two", "Choice Three"});
            menu.AddMenuOption("Clickable icon and text", Color.yellow, CanvasController.Instance.Elements.Icon);
        }
        if (selectedItem == 2)  
        {
            // For simple menus, open using OpenMenuAtPosition due to anchors
            OpenedMenus[2] = canvasController.OpenMenuAtPosition(CanvasController.Instance.Elements.SimpleMenu, new Vector2(Screen.width/2, Screen.height/2));
            SimpleMenuController menu = OpenedMenus[2].GetComponent<SimpleMenuController>();

            menu.HeaderText.text = "Simple menu with popup menus";
            menu.AddMenuOption("InputField popup").AddListener(() =>
            {
                if (menu.SubMenu != null)    // Destroy existing submenu
                    GameObject.Destroy(menu.SubMenu);

                menu.SubMenu = canvasController.OpenMenuAtPosition(
                    CanvasController.Instance.Elements.InputDialog,
                    new Vector2(-Screen.width/4, 0), false, true);


                var subMenu = menu.SubMenu.GetComponent<PopupInputMenuController>();
                subMenu.SetTextFields("Input field dialog", "Enter name");
            });
            menu.AddMenuOption("Slider popup").AddListener(() =>
            {
                if (menu.SubMenu != null)    // Destroy existing submenu
                    GameObject.Destroy(menu.SubMenu);

                menu.SubMenu = canvasController.OpenMenuAtPosition(
                    CanvasController.Instance.Elements.SliderDialog,
                    new Vector2(-Screen.width / 4, 0), false, true);


                var subMenu = menu.SubMenu.GetComponent<PopupSliderMenuController>();
                subMenu.SetTextFields("Slider dialog", "Set amount");
                subMenu.Slider.maxValue = 10;
            });
            menu.AddMenuOption("Confirm dialog").AddListener(() =>
            {
                if (menu.SubMenu != null)    // Destroy existing submenu
                    GameObject.Destroy(menu.SubMenu);

                menu.SubMenu = canvasController.OpenMenuAtPosition(
                    CanvasController.Instance.Elements.ConfirmDialog,
                    new Vector2(-Screen.width / 4, 0), false, true);


                var subMenu = menu.SubMenu.GetComponent<PopupConfirmMenuController>();
                subMenu.HeaderText.text = "Are you sure you wish to proceed?";
            });
        }
        CanvasController.Instance.PlaySound(CanvasController.Instance.SelectSound);
    }

    public void OnItemSelected(int itemID)
    {
        selectedItem = itemID;
        OnItemSelected();
    }
}
