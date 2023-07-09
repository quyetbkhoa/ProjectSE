using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Animator playerAnimator;
    public PlayerState playerState;
    // Start is called before the first frame update
    // Update is called once per frame
    void LateUpdate()
    {
        UpdatePlayerState();
        SetPlayerAnim();
    }

    void UpdatePlayerState()
    {
        if (playerController.isMove)
        {
            playerState = PlayerState.Walk;
        }
        else
        {
            playerState = PlayerState.Idle;
        }
    }

    void SetPlayerAnim()
    {
        switch (playerState)
        {
            case PlayerState.Idle:
                playerAnimator.Play("Idle");
                break;
            case PlayerState.Walk:
                playerAnimator.Play("Walk");
                break;
            case  PlayerState.Win:
                playerAnimator.Play("Win");
                break;
        }
    }
}
public enum PlayerState
{
    Idle,
    Walk,
    Win,
}   
