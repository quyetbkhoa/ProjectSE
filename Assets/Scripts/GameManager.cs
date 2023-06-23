using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
   private GameObject currentLevel;
   public int indexLevel => PlayerPrefs.GetInt("current_level",1) ;

   public bool reset = false;
   [SerializeField] private GameObject losePopup;
   [SerializeField] private GameObject winPopup;
   // public int GetCurrentLevel()
   // {
   //    return PlayerPrefs.GetInt("current_level",1);
   // }
   
   public void SetCurrentLevel(int index)
   {  
      PlayerPrefs.SetInt("current_level", index);
   }
   
   public void OnWinGame()
   {  
      //Show Win Popup
      winPopup.SetActive(true);
      //PlayerPrefs.SetInt("current_level", indexLevel +1);
   }
   
   // public void Awake()
   // {
   //    indexLevel = PlayerPrefs.GetInt("current_level",1);
   // }
   
   private void Update()
   {
      if(reset) SetCurrentLevel(1);
      reset = false;
   }
   public void LoadLevel(int index)
   {
      string sceneName = $"Level {index}";
      if (SceneUtility.GetBuildIndexByScenePath(sceneName) != -1)
      {
         SceneManager.LoadScene(sceneName);
      }
      else
      {
         Debug.LogError($"Scene {index} not found!");
      }
   }
   public void LoadNextLevel()
   {
      LoadLevel(indexLevel+1);
   }
}

