using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public int index = 0;

    public GameObject[] popUps;
    void Update()
    {   
        for (int i = 0; i < popUps.Length; ++i)
        {
            if (i == index)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }   
    }
}
