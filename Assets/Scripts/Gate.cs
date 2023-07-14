using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    // Start is called before the first frame update
    public bool button = false;

    private void Update()
    {
        if(button) Rotate();
        button = false;
    }
    //rotate 90 degree with 1s
    public void Rotate()
    {
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
