using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
   private GameObject currentLevel;
   public int starCount = 0; 
   public int indexLevel => PlayerPrefs.GetInt("current_level",1) ;
   public int maxLevel => PlayerPrefs.GetInt("max_level",1) ;
   // public int maxLevel => PlayerPrefs.GetInt("current_level",1) ;
   public CameraController camera;
   public bool reset = false;
   [SerializeField] private GameObject winPopup;
   [SerializeField] private PlayerAnim playerAnim;
   [SerializeField] private GameObject pauseMenu;
   
   //if winPopup is null then find it by name in scene
 
   public GameObject joystick;
   private void Awake()
   {  
      DontDestroyOnLoad(gameObject);
   }
   public void OnWinGame()
   {  
      //set star count is maximum of star count
      if (starCount > PlayerPrefs.GetInt("stars" + indexLevel, 0))
      {
         PlayerPrefs.SetInt("stars" + indexLevel, starCount);
      }
      if(indexLevel+1>maxLevel) PlayerPrefs.SetInt("max_level", indexLevel+1);
      AudioManager.Instance.Stop("Background");
      AudioManager.Instance.Play("Win");
      playerAnim.playerState = PlayerState.Dance;
      //zoom camera x2 slowly in 1s
      camera.Zoom(1.6f,1);
      joystick.SetActive(false);
      winPopup.SetActive(true);
      print(1);
      //PlayerPrefs.SetInt("current_level", indexLevel +1);
      
   }
   //OnNewGame function
   public void OnNewGame(AsyncOperation scene)
   {  
      
      AudioManager.Instance.Play("Background");
      if (joystick == null)
      {
         joystick = GameObject.Find("Fixed Joystick");
      }
      joystick.SetActive(true);
      playerAnim = GameObject.FindObjectOfType<PlayerAnim>();
      //get camera
      camera = GameObject.FindObjectOfType<CameraController>();
      //find inactive pause menu
      // pauseMenu = GameObject.Find("Pause Menu");
   }
   private void Update()
   {  
      if (reset)
      {  
         PlayerPrefs.SetInt("current_level",1);
         PlayerPrefs.SetInt("max_level",1);
         //reset stars
         for (int i = 1; i <= 5; i++)
         {
            PlayerPrefs.SetInt("stars" + i, 0);
         }
      }
      reset = false;
      //if playerAnim null then find it by name in scene
   }
   public void LoadLevel(int index)
   {  
      starCount =0;
      if (index == 1)
         starCount = 3;
      PlayerPrefs.SetInt("current_level", index);
      string sceneName = $"Level {index}";
      if (SceneUtility.GetBuildIndexByScenePath(sceneName) ==-1)
      {
         SceneManager.LoadScene("Menu");
         Debug.LogError($"Scene {sceneName} not found!");
         return;
      }
      var scene = SceneManager.LoadSceneAsync(sceneName);
      //After finish load scene, OnprepareLevel will be called
      scene.completed += OnNewGame;
     
   }
   //change LoadLevel to LoadScene
   
   public void LoadNextLevel()
   {  
      if(indexLevel+1>4)
         SceneManager.LoadScene("Menu");
      LoadLevel(indexLevel+1);
   }
   public void PauseGame()
   {
      //pause game
      Time.timeScale = 0;
      pauseMenu.SetActive(true);
   }

   public void ContinueGame()
   {
      //continue
      Time.timeScale = 1;
      pauseMenu.SetActive(false);
   }

}

