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
      //set max level is 3
      if (index > 3)
      {
         index = UnityEngine.Random.Range(1, 4);
      }
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
   //change LoadLevel to LoadScene
   
   public void LoadNextLevel()
   {
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

