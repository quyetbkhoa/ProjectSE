using System;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float speed = 7f;
    public float jumpForce = 10f;
    [SerializeField] private Rigidbody playerRb;
    private float verticalInput;
    private float horizontalInput;
    [SerializeField] private FloatingJoystick joystick;
    [HideInInspector] public bool isMove;
    public bool hasKey = false;
    private void Update()
    {   
        
#if UNITY_EDITOR
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
#else
        verticalInput = joystick.Vertical;
        horizontalInput = joystick.Horizontal;
#endif
        if (horizontalInput != 0 || verticalInput != 0)
        {
            transform.LookAt(transform.position + new Vector3(horizontalInput, 0f, verticalInput));
            isMove = true;
        }
        else isMove = false;
    }

    private void FixedUpdate()
    {
        // playerRb.velocity = new Vector3(horizontalInput * speed, playerRb.velocity.y,verticalInput * speed);
        Vector3 move = new Vector3(horizontalInput, 0f, verticalInput) * (speed * Time.deltaTime);
        playerRb.MovePosition(transform.position + move);
    }
}