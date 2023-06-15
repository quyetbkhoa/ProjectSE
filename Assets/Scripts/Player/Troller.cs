using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Key;
    public GameObject Player;
    public Camera cam;

    private void Update()
    {
        Vector3 sz = cam.ScreenToWorldPoint(new Vector3(Screen.height, Screen.width, 0));
        Debug.Log(sz);
    }
}
