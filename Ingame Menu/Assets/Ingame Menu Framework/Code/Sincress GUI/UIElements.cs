using UnityEngine;

/// <summary>
/// Class containing prefab references
/// </summary>
[CreateAssetMenu(menuName = "DataHolders/UIElements")]
public class UIElements : ScriptableObject {

    [Header("Menus")]
    public GameObject ScrollMenu;
    public GameObject ScrollText;
    public GameObject SimpleMenu;

    [Header("Dialogs")]
    public GameObject SliderDialog;
    public GameObject InputDialog;
    public GameObject ConfirmDialog;

    [Header("Elements")]
    public GameObject ClickableText;
    public GameObject ClickableTextChoice;
    public GameObject ClickableImageText;
    public GameObject TextPanel;
    public GameObject TwoTextPanel;

    [Space(20)]
    public Sprite Icon;
}
