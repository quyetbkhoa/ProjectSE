using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{   
    [SerializeField] private Tutorial tutorial;
    [SerializeField] private Animator animator;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {   
            if (collision.transform.GetComponent<PlayerController>().hasKey)
            {   
                if(tutorial!=null)
                tutorial.index++;    
                Debug.Log("WIN");
                animator.Play("Chest_Open");
                GameManager.Instance.OnWinGame();
            }
            else Debug.Log("Need Key");
        }
    }

    private void Awake()
    {
        animator.Play("Chest_Close");
    }
}
