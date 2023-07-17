using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
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
    //xoay vong
    private void Update()
    {
        transform.Rotate(Vector3.up, 50 * Time.deltaTime);
    }
    //phat sang
    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawSphere(transform.position, 5f);
    // }
}
