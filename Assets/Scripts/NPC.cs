using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class NPC : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player.transform.position);
        }
    }
    public bool canQuestion = true;
    //NPC will hello when player enter the trigger and after 3s the main camera is camera
    private void OnTriggerEnter(Collider other)
    {
        if (canQuestion)
        {
            // canQuestion = false;
             Interact(other.gameObject);
        }
            
    }
    // public void SetCanQuestion()
    // {
    //     StartCoroutine(ActiveAfter3s());
    // }
    // IEnumerator ActiveAfter3s()
    // {
    //     yield return new WaitForSeconds(3);
    //     canQuestion = true;
    // }

    public virtual void Interact(GameObject _player)
    {
        
    }
   
}


