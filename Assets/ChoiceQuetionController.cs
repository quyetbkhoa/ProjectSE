using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceQuetionController : MonoBehaviour
{
    // public Button A;
    // public Button B;
    // public Button C;
    // public Button D;
    public Button[] buttons;
    public int clicked = 0;
    public int answer = 3;
    public Canvas canvas;
    [SerializeField] private Canvas canvasLevel;
    public Gate gate;
    [SerializeField] GameObject npc;
    [SerializeField] private Animator animator;
    [SerializeField] private CameraController camera;
    [SerializeField] private PlayerController player;
    public void OnClickA()
    {
        clicked = 1;
        Check();
    }
    public void OnClickB()
    {
        clicked = 2;
        Check();
    }
    public void OnClickC()
    {
        clicked = 3;
        Check();
    }
    public void OnClickD()
    {
        clicked = 4;
        Check();
    }

    void Check()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }
        buttons[answer - 1].GetComponent<Image>().color = Color.green;
 
        if (clicked == answer)
        {   
            
            //print  Yes and after 1s canvas is disabled
             animator.Play("Yes");
             
             StartCoroutine(ToGameplay());
                
        }
        else
        {   
            
            animator.Play("No");
            StartCoroutine(ToGameplay());
        }
    }

    IEnumerator ToGameplay()
    {
        yield return new WaitForSeconds(1);
        camera.ResetCamera();
        canvasLevel.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
        player.canMove = true;
        player.ResetJoystick();
        if (clicked == answer)
        {
            gate.Rotate();
            Destroy(npc.gameObject);
        } 
        Reset();
    }

    //reset choice question
    public void Reset()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
            button.GetComponent<Image>().color = Color.white;
        }
        clicked = 0;
    }
    
}
