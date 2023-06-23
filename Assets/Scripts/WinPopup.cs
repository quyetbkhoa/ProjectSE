using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPopup : Popup
{
  public override void OnClick()
  { 
    base.OnClick();
    print("continue");
    TurnOff();
    GameManager.Instance.LoadNextLevel();
  }
}
