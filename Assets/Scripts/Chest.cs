using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{   
    [SerializeField] private Tutorial tutorial;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject chat;
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
            else
            {
                //set chat Active true in 3s
                chat.SetActive(true);
                StartCoroutine(ShowChat());
            }
        }
    }

    IEnumerator ShowChat()
    {
        yield return  new WaitForSeconds(1f);
        chat.SetActive(false);
    }
}
