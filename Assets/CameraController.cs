using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // [SerializeField] private Camera camera;
    private Vector3 offset;
    private Vector3 offsetRotation;
    private void Start()
    {
        // offset = camera.transform.position - player.transform.position;
        offset = new Vector3(-1.6f, 27.13f, -30.23f);
        offsetRotation = new Vector3(40, 0, 0);
        print(offset);
    }

    public void ResetCamera()
    {
        //camera tranform and rotation is offset
         transform.position = player.transform.position + offset;
         transform.rotation = Quaternion.Euler(offsetRotation);
         enabled = true;
    }
        

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
