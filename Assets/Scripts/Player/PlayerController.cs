using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController: MonoBehaviour
{
    public float speed = 7f;
    [SerializeField] private Rigidbody playerRb;
    private float verticalInput;
    private float horizontalInput;
    private Vector3 dir;
    [SerializeField] private FixedJoystick joystick;
     public bool isMove;
    public bool hasKey = false;
    public bool Phone = true;
    public bool canMove = true;
    private void Update()
    {
        if (!Phone)
        {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
        }
        else
        {
            verticalInput = joystick.Vertical;
            horizontalInput = joystick.Horizontal;
        }
        if(horizontalInput == 0 && verticalInput == 0)
        {
            playerRb.velocity=Vector3.zero;
        }
        if (horizontalInput != 0 || verticalInput != 0)
        {
            dir =new  Vector3(horizontalInput, 0f, verticalInput);
            transform.LookAt(transform.position + dir);
            isMove = true;
        }
        else isMove = false;
    }

    private void Awake()
    {
        if (joystick == null)
        {
            joystick = FindObjectOfType<FixedJoystick>();
        }
    }
    private void FixedUpdate()
    {
        if (!canMove)
        {
            playerRb.velocity = Vector3.zero;
        }
        else if (CheckCanMove(dir))
        {   
            //move by addforce
            //playerRb.AddForce(dir * speed * Time.deltaTime, ForceMode.VelocityChange);
            playerRb.velocity = new Vector3(horizontalInput * speed * Time.deltaTime, playerRb.velocity.y,
                verticalInput * speed * Time.deltaTime);
        }
    }
    public void ResetJoystick()
    {   
       joystick.OnPointerUp(null);
    }
    private bool CheckCanMove(Vector3 forward)
    {
        Vector3 startRay = transform.position + Vector3.up * 2 + forward.normalized *1.2f;
        RaycastHit hit;
        Ray ray = new Ray(startRay, Vector3.down * 10);
        Debug.DrawRay(startRay,Vector3.down * 10, Color.red);
        
        if (Physics.Raycast(ray, out hit, 10f))
        {
            return true;
        }
        else
        {
            playerRb.velocity = Vector3.zero;
            return false;
        }
    }
}