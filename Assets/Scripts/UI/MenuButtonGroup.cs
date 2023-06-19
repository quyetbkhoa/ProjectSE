using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonGroup : MonoBehaviour
{
   public void OnClickStart()
   {
      SceneManager.LoadScene("Gameplay");
   }
   public void OnClickLevel()
   {
      print("hehe");
   }
   public void OnClickQuit()
   {
      Application.Quit();
   }
}
