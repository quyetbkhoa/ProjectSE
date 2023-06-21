using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
   private GameObject currentLevel;
   private int indexLevel;
   public int level;
   public bool Load = false;

   public int GetCurrentLevel()
   {
      return PlayerPrefs.GetInt("current_level",1);
   }

   public void SetCurrentLevel(int index)
   {
      PlayerPrefs.SetInt("current_level", index);
   }
   public void OnWinGame()
   {
      PlayerPrefs.SetInt("current_level", indexLevel +1);
      LoadLevel(indexLevel);
   }
   
   public void Awake()
   {  
      indexLevel = PlayerPrefs.GetInt("current_level",1);
      LoadLevel(indexLevel);
   }

   private void Update()
   {
      if(Load) LoadLevel(level);
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
         Debug.LogError("Scene not found!");
      }
   }
   
}
