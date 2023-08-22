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
   public CameraController camera;
   public int Test=0;
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
      if (starCount > PlayerPrefs.GetInt("stars" + indexLevel, 0))
      {
         PlayerPrefs.SetInt("stars" + indexLevel, starCount);
      }
      if(indexLevel+1>maxLevel) PlayerPrefs.SetInt("max_level", indexLevel+1);
      AudioManager.Instance.Stop("Background");
      AudioManager.Instance.Play("Win");
      playerAnim.playerState = PlayerState.Dance;
      camera.Zoom(1.6f,1);
      joystick.SetActive(false);
      winPopup.SetActive(true);
      print(1);

   }
   public void OnNewGame(AsyncOperation scene)
   {  
      
      AudioManager.Instance.Play("Background");
      if (joystick == null)
      {
         joystick = GameObject.Find("Fixed Joystick");
      }
      joystick.SetActive(true);
      playerAnim = GameObject.FindObjectOfType<PlayerAnim>();
      camera = GameObject.FindObjectOfType<CameraController>();
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
      scene.completed += OnNewGame;
     
   }
   public void LoadNextLevel()
   {  
      if(indexLevel+1>4)
         SceneManager.LoadScene("Menu");
      LoadLevel(indexLevel+1);
   }
   public void PauseGame()
   {
      Time.timeScale = 0;
      pauseMenu.SetActive(true);
   }

   public void ContinueGame()
   {
      Time.timeScale = 1;
      pauseMenu.SetActive(false);
   }

}

