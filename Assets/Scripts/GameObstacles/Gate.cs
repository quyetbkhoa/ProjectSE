using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool button = false;

    private void Update()
    {
        if(button) Rotate();
        button = false;
    }
    public void Rotate()
    {
        GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(RotateCoroutine());  
    }
    IEnumerator RotateCoroutine()
    {
        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime;
            transform.Rotate(0, -90 * Time.deltaTime, 0);
            yield return null;
        }
    }
}
