using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
   private int currentLevel;
   public void OnWinGame()
   {
      currentLevel = PlayerPrefs.GetInt("current_level",01);
      PlayerPrefs.SetInt("current_level", currentLevel +1);
      //sound
   }
   
   public void Awake()
   {
      LoadLevel(currentLevel);
   }

   public void LoadLevel(int index)
   {
      string levelName = $"Levels/Level {index}";
      GameObject levelPrefab = Resources.Load<GameObject>(levelName);

      if (levelPrefab != null)
      {
         GameObject levelInstance = Instantiate(levelPrefab);
         // Do something with the loaded level instance
      }
      else
      {
         Debug.LogError("Failed to load level!");
      }
   }
   
}
