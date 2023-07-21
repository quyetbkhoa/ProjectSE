using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPopup : Popup
{
  public override void OnClick()
  { 
    base.OnClick();
    print("continue");
    GameManager.Instance.joystick.SetActive(true);
    TurnOff();
    GameManager.Instance.starCount = 0;
    GameManager.Instance.LoadNextLevel();
  }
}
