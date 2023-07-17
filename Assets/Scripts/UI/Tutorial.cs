using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public int index = 0;

    [SerializeField] private GameObject[] popUpTutorial;
    [SerializeField] private GameObject wall;

    void Update()
    {
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
        if(index==0)
            wall.SetActive(true);
        else
            wall.SetActive(false);
    }
    
    
}
