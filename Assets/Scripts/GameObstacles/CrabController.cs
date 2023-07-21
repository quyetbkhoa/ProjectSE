using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CrabController : MonoBehaviour
{
    [SerializeField] private bool isMoveToFront = true;
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject posUp;
    [SerializeField] private GameObject posDown;
    void Move()
    {
        if (isMoveToFront)
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
    }

    void Rotate()
    {
        if (transform.position.z > posUp.transform.position.z)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (transform.position.z < posDown.transform.position.z)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void FixedUpdate()
    {
        Move();
        Rotate();
    }
}
