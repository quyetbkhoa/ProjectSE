using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (collision.transform.GetComponent<PlayerController>().hasKey)
            {
                Debug.Log("WIN");
            }
            else Debug.Log("Need Key");
        }
    }
}
