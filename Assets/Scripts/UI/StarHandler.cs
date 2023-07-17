using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarHandler : MonoBehaviour
{
    [SerializeField] private GameObject Star1;
    [SerializeField] private GameObject Star2;
    [SerializeField] private GameObject Star3;

    public void StarUpdate(int starCount)
    {
        //turn on star by for
        for (int i = 1; i <= starCount; i++)
        {
            if (i == 1) Star1.SetActive(true);
            if (i == 2) Star2.SetActive(true);
            if (i == 3) Star3.SetActive(true);
        }
    }
    //when acitve gameobject, call star update
    public void OnEnable()
    {
        StarUpdate(GameManager.Instance.starCount);
    }

    public void OnDisable()
    {
        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false); 
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
