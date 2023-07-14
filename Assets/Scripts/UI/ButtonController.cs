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
   //level popup
   [SerializeField] private Popup levelPopup;

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
      levelPopup.TurnOn();
   }
   public void OnClickQuit()
   {
      Application.Quit();
   }
   
   public void OnClickSetting()
   {
         
   }
   //OnClickLevel 1 to 5
   public void OnClickLevel1()
   {
      GameManager.Instance.LoadLevel(1);
   }
   public void OnClickLevel2()
   {
      GameManager.Instance.LoadLevel(2);
   }
   public void OnClickLevel3()
   {
      GameManager.Instance.LoadLevel(3);
   }
   public void OnClickLevel4()
   {
      GameManager.Instance.LoadLevel(4);
   }
   public void OnClickLevel5()
   {
      GameManager.Instance.LoadLevel(5);
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
