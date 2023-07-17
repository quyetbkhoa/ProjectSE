using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CrabController : MonoBehaviour
{
    // Start is called before the first frame update
    //animator
    [SerializeField] Animator animator;
    //make crab move to front, if touch boxcollider, crab will move to back
    [SerializeField] private bool isMoveToFront = true;
    //speed of crab
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject posUp;
    [SerializeField] private GameObject posDown;
    void Start()
    {
        
    }
    
    // private void  OnCollisionEnter(Collision other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {   
    //         //get playercontroller
    //         PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
    //         playerController.Crabpush();
    //     }
    // }
    void Move()
    {
        //move
        if (isMoveToFront)
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
    }

    void Rotate()
    {   
       // print(transform.position.z);
        //rotate
        if (transform.position.z > posUp.transform.position.z)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (transform.position.z < posDown.transform.position.z)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Rotate();
    }
}
