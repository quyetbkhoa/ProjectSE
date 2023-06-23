using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
   public TMP_Text textButton1;

   public void Awake()
   {
      int level = PlayerPrefs.GetInt("current_level");
      if (level != 1) textButton1.text = "CONTINUE";
      else textButton1.text = "START";
   }

   public void OnClickButton1()
   {
      int level = PlayerPrefs.GetInt("current_level");
      
      print(level);
      GameManager.Instance.LoadLevel(level);
    
      // SceneManager.LoadScene($"Level + {}");
   }
   public void OnClickLevel()
   {
      print("Clicked Level");
   }
   public void OnClickQuit()
   {
      Application.Quit();
   }
   
   public void OnClickSetting()
   {
         
   }

   
   public void OnClickNextLevel()
   {
      GameManager.Instance.LoadNextLevel();
      
   }
   public void OnClickPlayAgain()
   {
      GameManager.Instance.LoadLevel(GameManager.Instance.indexLevel);   
   }
}
