using System;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float speed = 7f;
    public float jumpForce = 10f;
    [SerializeField] private Rigidbody playerRb;
    private float verticalInput;
    private float horizontalInput;
    [HideInInspector] public bool isMove;
    public bool hasKey = false;
    private void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0 || verticalInput != 0)
        {
            transform.LookAt(transform.position + new Vector3(horizontalInput, 0f, verticalInput));
            isMove = true;
        }
        else isMove = false;
    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector3(horizontalInput * speed, playerRb.velocity.y,verticalInput * speed);
        
    }
}