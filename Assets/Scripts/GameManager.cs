using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
   private GameObject currentLevel;
   [HideInInspector] public int starCount = 0; 
   public int indexLevel => PlayerPrefs.GetInt("current_level",1) ;
   // public int maxLevel => PlayerPrefs.GetInt("current_level",1) ;

   public bool reset = false;
   [SerializeField] private GameObject losePopup;
   [SerializeField] private GameObject winPopup;
   public void OnWinGame()
   {  
      //Show Win Popup
      winPopup.SetActive(true);
      //PlayerPrefs.SetInt("current_level", indexLevel +1);
   }

   private void Update()
   {
      if(reset) PlayerPrefs.SetInt("current_level",1);
      reset = false;
   }
   public void LoadLevel(int index)
   {  
      PlayerPrefs.SetInt("current_level", index);
      
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

