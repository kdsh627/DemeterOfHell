using System;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{ 
    IDLE,
    WALK,
    ATTACK
}

public enum PlayerDirection
{
    RIGHT,
    LEFT,
    UP,
    DOWN
}

public class Player : MonoBehaviour
{
    [SerializeField] private List<GameObject> playerImage;
    [SerializeField] private List<Animator> animator;
    [SerializeField] private float speed;

    private Animator currentAnimator;
    private IPlayerState currentState;
    private PlayerDirection currentDirection;

    public float Speed => speed;
    public PlayerDirection CurrentDirection => currentDirection;

    private void Start()
    {
        currentDirection = PlayerDirection.RIGHT;
        ImageChange();
        SetState(new IDLE_State(), PlayerState.IDLE);
    }

    private void Update()
    {
        InputHandler();
    }
    private void FixedUpdate()
    {
        currentState.Update(this);
    }

    private void SetState(IPlayerState newState, PlayerState state)
    {
        currentState = newState;
        currentState.Input(this, state.ToString());
    }

    private void InputHandler()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentDirection = PlayerDirection.RIGHT;
            ImageChange();
            SetState(new Walk_State(), PlayerState.WALK);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentDirection = PlayerDirection.LEFT;
            ImageChange();
            SetState(new Walk_State(), PlayerState.WALK);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentDirection = PlayerDirection.DOWN;
            ImageChange();
            SetState(new Walk_State(), PlayerState.WALK);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentDirection = PlayerDirection.UP;
            ImageChange();
            SetState(new Walk_State(), PlayerState.WALK);
        }
        else
        {
            SetState(new IDLE_State(), PlayerState.IDLE);
        }
    }

    public void AnimatorChange(string temp)
    {
        currentAnimator.SetBool("IsIdle", false);
        currentAnimator.SetBool("IsWalk", false);

        currentAnimator.SetBool(temp, true);
    }

    public void ImageChange()
    {
        for(int i = 0; i < playerImage.Count; ++i)
        {
            playerImage[i].SetActive(false);
        }

        playerImage[(int)currentDirection].SetActive(true);
        currentAnimator = animator[(int)currentDirection];
    }
}
