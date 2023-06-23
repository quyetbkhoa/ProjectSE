using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public int index = 0;

    public GameObject[] popUpTutorial;

    void Update()
    {   
        if(GameManager.Instance.indexLevel == 1)
           for (int i = 0; i < popUpTutorial.Length; ++i)
           {
                    if (i == index)
                    {
                        popUpTutorial[i].SetActive(true);
                    }
                    else
                    {
                        popUpTutorial[i].SetActive(false);
                    }
           }   
    }
    
    
}
