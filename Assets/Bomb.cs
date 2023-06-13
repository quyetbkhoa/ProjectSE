using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerController>().hasKey = true;
            Destroy(gameObject);
        }
    }
}
