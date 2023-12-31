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
   //level popup
   [SerializeField] private Popup levelPopup;
   [SerializeField] private Popup settingPopup;

   public void Awake()
   { 
      if(soundButtonOff ==null || soundButtonOn == null) return;
      if (PlayerPrefs.GetInt("music",1) == 0)
      {
         soundButtonOn.SetActive(false);
         soundButtonOff.SetActive(true);
      }
      else
      {
         soundButtonOn.SetActive(true);
         soundButtonOff.SetActive(false);
      }
   }

   public void OnClickPlay()
   {
      int level = PlayerPrefs.GetInt("current_level",1);
      if (level > 4) level = 4;
      GameManager.Instance.LoadLevel(level);
      AudioManager.Instance.Play("Click");
   }
   public void OnClickLevel()
   {
      levelPopup.TurnOn();
      AudioManager.Instance.Play("Click");
   }
   public void OnClickQuit()
   {
      Application.Quit();
   }
   
   public void OnClickSetting()
   {
      AudioManager.Instance.Play("Click");
      settingPopup.TurnOn();
      
   }
   public void OnClickLevel1()
   {
      GameManager.Instance.LoadLevel(1);
      AudioManager.Instance.Play("Click");
   }
   public void OnClickLevel2()
   {
      GameManager.Instance.LoadLevel(2);
      AudioManager.Instance.Play("Click");
   }
   public void OnClickLevel3()
   {
      GameManager.Instance.LoadLevel(3);
      AudioManager.Instance.Play("Click");
   }
   public void OnClickLevel4()
   {
      GameManager.Instance.LoadLevel(4);
      AudioManager.Instance.Play("Click");
   }
   public void OnClickLevel5()
   {
      GameManager.Instance.LoadLevel(5);
      AudioManager.Instance.Play("Click");
   }
   [SerializeField] private GameObject soundButtonOn;
   [SerializeField] private GameObject soundButtonOff;
   public void OnClickSound()
   {
      if (AudioManager.Instance.music)
      {
         AudioManager.Instance.music = false;
         soundButtonOn.SetActive(false);
         soundButtonOff.SetActive(true);
         PlayerPrefs.SetInt("music",0);
         AudioManager.Instance.StopAll();
      }
      else
      {
         AudioManager.Instance.music = true;
         soundButtonOn.SetActive(true);
         soundButtonOff.SetActive(false);
         PlayerPrefs.SetInt("music",1);
         AudioManager.Instance.Play("Background");
      }
   }
   public void OnClickPause()
   {
      GameManager.Instance.PauseGame();  
   }

   public void OnClickMenu()
   {  
      GameManager.Instance.ContinueGame();
      SceneManager.LoadScene("Menu");
   }

   public void OnClickContinue()
   {
      GameManager.Instance.ContinueGame();
   }
}
