using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private int currentLevel;
   public int level;
   public bool Load = false;
   public void OnWinGame()
   {
      PlayerPrefs.SetInt("current_level", currentLevel +1);
      //sound
   }
   
   public void Awake()
   {  
      currentLevel = PlayerPrefs.GetInt("current_level",1);
      LoadLevel(currentLevel);
   }

   private void Update()
   {
      if(Load) LoadLevel(level);
   }

   public void LoadLevel(int index)
   {
      string levelName = $"Levels/Level {index}";
      print(levelName);
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
