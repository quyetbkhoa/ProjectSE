using System;
using UnityEngine;

public class PlayerController: MonoBehaviour
{
    public float speed = 7f;
    public float jumpForce = 10f;
    [SerializeField] private Rigidbody playerRb;
    private float verticalInput;
    private float horizontalInput;
    private Vector3 dir;
    [SerializeField] private FloatingJoystick joystick;
     public bool isMove;
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
            dir =new  Vector3(horizontalInput, 0f, verticalInput);
            transform.LookAt(transform.position + dir);
            isMove = true;
        }
        else isMove = false;
    }

    private void FixedUpdate()
    {
        if (CanMove(dir)) playerRb.velocity = new Vector3(horizontalInput * speed*Time.deltaTime, playerRb.velocity.y,verticalInput * speed*Time.deltaTime);
        //Vector3 move = new Vector3(horizontalInput, 0f, verticalInput) * (speed * Time.deltaTime);
        //playerRb.MovePosition(transform.position + move);
        
    }

    private bool CanMove(Vector3 forward)
    {   
        Ray ray;
        Vector3 startRay = transform.position + Vector3.up * 2 + forward.normalized;
        Debug.DrawRay(startRay,Vector3.down * 10, Color.red);
        if (Physics.Raycast(startRay, Vector3.down * 10))
        {
            //print("Landing");
            return true;
        }
        else
        {
           // print("OnAir");
            playerRb.velocity = Vector3.zero;
            return false;
        }
            
    }
}