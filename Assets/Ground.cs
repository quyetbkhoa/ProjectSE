using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private BoxCollider collider;
    [SerializeField] private PlayerController player;
    private float leftMax;
    private float rightMax;
    private float upMax;

    private float downMax;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 center = collider.center;
        float sizeX = collider.size.x;
        float sizeZ = collider.size.z;
        leftMax = center.x - sizeX;
        rightMax = center.x + sizeX;
        upMax = center.z + sizeZ;
        downMax = center.z - sizeZ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // player.transform.position = 
        //     new Vector3( Mathf.Clamp(leftMax.x)
        //         
        //         )
    }
}
