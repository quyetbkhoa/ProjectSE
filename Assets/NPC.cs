using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class NPC : MonoBehaviour
{
    public CameraController camera;
    public Canvas canvasLevel;
    public Canvas canvasChoice;
    public GameObject player;
    public Animator   animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(player != null)
        transform.LookAt(player.transform.position);
    }
    //NPC will hello when player enter the trigger and after 3s the main camera is camera
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            StartCoroutine(Hello());
        }
    }
    IEnumerator Hello()
    {   
        //play hello animation
        if(animator!= null)
        animator.Play("Hello");
        player.GetComponent<PlayerController>().canMove = false;
        yield return new WaitForSeconds(3);
        //camera transform move right 1000
        camera.GetComponent<CameraController>().enabled = false;
        camera.transform.position += new Vector3(1000, 0, 0);
        //camera rotation is 0
        camera.transform.rotation = Quaternion.Euler(0, 0, 0);
        canvasLevel.gameObject.SetActive(false);
        canvasChoice.gameObject.SetActive(true);

    }
}
