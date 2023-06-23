using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePopup : Popup
{
    public override void OnClick()
    { 
        TurnOff();
        GameManager.Instance.LoadLevel(GameManager.Instance.indexLevel);
    }
}
