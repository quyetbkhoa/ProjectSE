using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // [SerializeField] private Camera camera;
    private Vector3 offset;
    private void Start()
    {
        // offset = camera.transform.position - player.transform.position;
        offset = new Vector3(-1.6f, 27.13f, -30.23f);
        print(offset);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
