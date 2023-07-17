using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonController : MonoBehaviour
{
    [SerializeField] private StarHandler starHandler;
    [SerializeField] private int level;
    private void OnEnable()
    {   
        if (level > GameManager.Instance.maxLevel)
        {
            // get button and make it un interactable
            GetComponent<UnityEngine.UI.Button>().interactable = false;
        }
        int starCount = PlayerPrefs.GetInt("stars" + level, 0);
        if(starHandler == null) //find in childs
            starHandler = GetComponentInChildren<StarHandler>();
            if(starHandler != null)
            starHandler.StarUpdate(starCount);
    }
}
