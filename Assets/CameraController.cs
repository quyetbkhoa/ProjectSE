using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public Camera camera;
    
    private Vector3 offset;
    private Vector3 offset1;
    private Vector3 offsetRotation;
    private void Start()
    {   
        //offset = transform.position - player.transform.position;
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        offset = new Vector3(-0f, 27.13f, -30.23f);
        offsetRotation = new Vector3(40, 0, 0);
        offset1 = transform.position - player.transform.position;
        ResetCamera();
    }
    private bool isFollowPlayer = true;
    [SerializeField] private float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    public float smoothSpeed = 5f;
    public float vari= 5f;
    
    public void ResetCamera()
    {       
        print("reset");
        isFollowPlayer= true;
        //camera tranform and rotation is offset
         camera.transform.position = player.transform.position + offset;
         print(player.transform.position + offset);
         camera.transform.rotation = Quaternion.Euler(offsetRotation);
         
    }

    public void SetCameraToQuesTion()
    {   
        isFollowPlayer = false;
        camera.transform.position= new Vector3(1000f, 0f, 0f);
        camera.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    void LateUpdate()
    {
        if(isFollowPlayer)
        transform.position = player.transform.position + offset1;
    }
    // void FixedUpdate()
    // {
    //     Vector3 targetPosition = player.transform.position + offset1;
    //     Vector3 desiredPosition;
    //     if(player.GetComponent<PlayerController>().isMove)
    //         desiredPosition = targetPosition - player.transform.forward * vari; // Đặt vị trí mong muốn của camera
    //     else
    //         desiredPosition = targetPosition - player.transform.forward * 0; // Đặt vị trí mong muốn của camera
    //     transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
    //     
    // }

}
