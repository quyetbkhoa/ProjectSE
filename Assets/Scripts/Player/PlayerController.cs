using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController: MonoBehaviour
{
    public float speed = 7f;
    public float jumpForce = 10f;
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
        //if fixed jpystick null
        if (joystick == null)
        {
            joystick = FindObjectOfType<FixedJoystick>();
        }
    }

    public void Crabpush()
    {   
        //joystick cant move for 1s
        joystick.OnPointerUp(null);
        joystick.enabled = false;
        playerRb.AddForce(transform.forward * -2000, ForceMode.Impulse);
        //AddForce slow but smooth
        
        StartCoroutine(EnableJoystick());
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
    
    //reset joystick
    public void ResetJoystick()
    {   
       joystick.OnPointerUp(null);
    }
    IEnumerator EnableJoystick()
    {
        yield return new WaitForSeconds(.5f);
        joystick.enabled = true;
    }

    private bool CheckCanMove(Vector3 forward)
    {
        Vector3 startRay = transform.position + Vector3.up * 2 + forward.normalized *1.2f;
        
        // if (!Physics.Raycast(startRay, Vector3.down * 10))
        // {
        //     //print("Landing");
        //     return true;
        // }
        //if Physics.Raycast(startRay, Vector3.down * 10) is tag river

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