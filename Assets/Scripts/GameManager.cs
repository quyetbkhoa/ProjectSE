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
   [SerializeField] private GameObject winPopup;
   [SerializeField] private PlayerAnim playerAnim;
   
   //if winPopup is null then find it by name in scene
 
   public GameObject joystick;
 
   
   private void Awake()
   {  
      DontDestroyOnLoad(gameObject);
   }
   public void OnWinGame()
   {  
      
      playerAnim.playerState = PlayerState.Win;
      joystick.SetActive(false);
      winPopup.SetActive(true);
      print(1);
      //PlayerPrefs.SetInt("current_level", indexLevel +1);
   }
   //OnNewGame function
   public void OnNewGame(AsyncOperation scene)
   {  
      if (joystick == null)
      {
         joystick = GameObject.Find("Fixed Joystick");
      }
      joystick.SetActive(true);
      playerAnim = GameObject.FindObjectOfType<PlayerAnim>();
   }
   private void Update()
   {  
      if (reset)
      {  
         PlayerPrefs.SetInt("current_level",1);
         //restart game
         // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         // AudioManager.instance.Play("Background");
      }
      reset = false;
      //if playerAnim null then find it by name in scene
   }
   public void LoadLevel(int index)
   {  
      starCount =0;
      PlayerPrefs.SetInt("current_level", index);
      
      string sceneName = $"Level {index}";
      if (SceneUtility.GetBuildIndexByScenePath(sceneName) ==-1)
      {
         Debug.LogError($"Scene {sceneName} not found!");
         return;
      }
      var scene = SceneManager.LoadSceneAsync(sceneName);
      //After finish load scene, OnprepareLevel will be called
      scene.completed += OnNewGame;
     
   }
   public void LoadNextLevel()
   {
      LoadLevel(indexLevel+1);
   }

}

