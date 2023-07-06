using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{   
    [SerializeField] private float speedRotate = 100f;
    [SerializeField] private  StarHandler starHandler;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.starCount++;
            starHandler.StarUpdate(GameManager.Instance.starCount);
            Destroy(gameObject);
        }
    }

    public void Awake()
    {
        if (starHandler == null) starHandler = FindObjectOfType<StarHandler>();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, speedRotate * Time.deltaTime);
    }

}
