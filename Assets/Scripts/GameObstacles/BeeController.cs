using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{

    [SerializeField] private Transform player;
   [SerializeField] private float speed=3f;
   [SerializeField] private float range = 2;
   private Vector3 rootPos;
   private void Start()
   {
       rootPos = transform.position;
   }
   private void Update()
    {
         if (Vector3.Distance(player.position, rootPos) <= range)
         {
             Vector3 newPos = new Vector3(player.position.x, transform.position.y, player.position.z);
              transform.position = Vector3.MoveTowards(transform.position, newPos , speed * Time.deltaTime);
              transform.LookAt(newPos, Vector3.up);
         }
         else
         {
              transform.position = Vector3.MoveTowards(transform.position, rootPos, speed * Time.deltaTime);
              transform.LookAt(rootPos, Vector3.up);
         }
    }

}
