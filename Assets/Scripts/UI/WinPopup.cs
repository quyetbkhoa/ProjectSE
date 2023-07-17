using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPopup : Popup
{
  public override void OnClick()
  { 
    base.OnClick();
    print("continue");
    //Find canvas level and set it to true
    GameManager.Instance.joystick.SetActive(true);
    // GameManager.Instance.canvasLevel.gameObject.SetActive(true);
    TurnOff();
    GameManager.Instance.starCount = 0;
    GameManager.Instance.LoadNextLevel();
  }
}
