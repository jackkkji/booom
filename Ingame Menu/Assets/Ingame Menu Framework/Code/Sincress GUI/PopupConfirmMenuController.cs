using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupConfirmMenuController : MonoBehaviour {
    public Text HeaderText;
    public Button AcceptButton, CancelButton;

    private void Update()
    {         
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnAcceptClicked();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnCloseClicked();
        }
    }

    #region button callbacks
    public void OnAcceptClicked()
    {
        GameObject.Destroy(this.gameObject);
    }

    public void OnCloseClicked()
    {
        GameObject.Destroy(this.gameObject);
    }
    #endregion button callbacks

}
