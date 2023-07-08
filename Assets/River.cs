using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
  //make the river flow by material
  public float speed = 0.3f;
  private void Update()
  {
    GetComponent<Renderer>().material.mainTextureOffset -= new Vector2(0, speed * Time.deltaTime);
  }
    
  
}
