using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPCQuestion: MonoBehaviour
    {
        private bool isanimatorNotNull;
        private PlayerController playerController;
        public Animator   animator;
        public CameraController camera;
        public Canvas canvasLevel;
        public Canvas canvasChoice;
        [SerializeField] private GameObject chatBox;
        private void Awake()
        {   
            if(playerController == null)
                playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        
        //if click on chatbox play to Question
        public void OnTriggerEnter(Collider other)
        {   
            if (other.CompareTag("Player"))
            {
                chatBox.SetActive(true);
                if(animator != null)
                    animator.Play("Hello");
            }
        }
        public void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                chatBox.SetActive(false);
                //stop hello animation
                if(animator != null)
                    animator.Play("Idle");
            }
        }
        public void Interact()
        {   
            print("Interact");
            StartCoroutine(ToQuestion());
        }
        
        IEnumerator ToQuestion()
        {
            playerController.canMove = false;
            
            yield return new WaitForSeconds(.5f);
            
            //set Question
            camera.SetCameraToQuesTion();
            canvasLevel.gameObject.SetActive(false);
            canvasChoice.gameObject.SetActive(true);
            
        }
    }
