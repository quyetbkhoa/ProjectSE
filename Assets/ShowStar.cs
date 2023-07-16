using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStar : MonoBehaviour
{
    [SerializeField] private StarHandler starHandler;
    [SerializeField] private int level;
    private void OnEnable()
    {   
        int starCount = PlayerPrefs.GetInt("stars" + level, 0);
        starHandler.StarUpdate(starCount);
    }
}
