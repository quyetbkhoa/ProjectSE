using System.Collections;
using UnityEngine;

public class NPCQuestion: NPC
    {
        private bool isanimatorNotNull;
        private PlayerController playerController;
        public Animator   animator;
        public CameraController camera;
        public Canvas canvasLevel;
        public Canvas canvasChoice;
        private void Awake()
        {
            playerController = player.GetComponent<PlayerController>();
            isanimatorNotNull = animator!= null;
        }
        public override void Interact(GameObject _player)
        {
            if (_player.CompareTag("Player"))
            {
                player = _player;
                StartCoroutine(Hello());
            } 
        }
        IEnumerator Hello()
        {   
            //play hello animation
            
            if(isanimatorNotNull)
                animator.Play("Hello");
            playerController.canMove = false;
            
            yield return new WaitForSeconds(2);
            
            //set Question
            camera.SetCameraToQuesTion();
            canvasLevel.gameObject.SetActive(false);
            canvasChoice.gameObject.SetActive(true);
    
        }
    }
