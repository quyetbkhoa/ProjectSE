using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public Camera camera;

    private Vector3 offsetCamera = new Vector3(-0f, 27.13f, -30.23f);
    [SerializeField] private Vector3 offset = new Vector3(13.2f, 2, 38.7f);
    private Vector3 offsetRotation = new Vector3(40f, 0f, 0f) ;
    [SerializeField] Vector3 offestZoom = new Vector3(13.2f, 0.5f, 38.7f);
    private void Start()
    {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        ResetCamera();
    }

    private bool isFollowPlayer = true;

    public void ResetCamera()
    {
        isFollowPlayer= true;
        camera.transform.position = player.transform.position + offsetCamera;
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
        transform.position = player.transform.position + offset;
    }
    
    public void Zoom(float zoom, float time)
    {
        offset = offestZoom;
        StartCoroutine(ZoomCoroutine(zoom,time));
    }
    IEnumerator ZoomCoroutine(float zoom, float time)
    {
        float elapsedTime = 0;
        float startSize = camera.orthographicSize;
        while (elapsedTime < time)
        {
            camera.orthographicSize = Mathf.Lerp(startSize, startSize/zoom, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
