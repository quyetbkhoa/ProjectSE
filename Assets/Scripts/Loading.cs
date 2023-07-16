using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
   //sau khi scene.process hoan thanh chuyen den scene Menu
    void Start()
        {
            StartCoroutine(LoadScene());
        }
    
        IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("Menu");
        }
}
