using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private Tutorial tutorial;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {   
            AudioManager.Instance.Play("Target");
            collision.transform.GetComponent<PlayerController>().hasKey = true;
            if(tutorial != null)
            tutorial.index++;
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.Rotate(Vector3.up, 50 * Time.deltaTime);
    }
}
