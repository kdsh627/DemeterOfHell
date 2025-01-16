using System;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{ 
    Idle,
    Walk,
    Attack
}

public enum PlayerDirection
{
    RIGHT,
    LEFT,
    UP,
    DOWN,
    IDLE
}

public class Player : MonoBehaviour
{
    [SerializeField] private List<GameObject> playerImage;
    [SerializeField] private List<Animator> animator;
    [SerializeField] private float speed;

    private Animator currentAnimator;
    private IPlayerState currentState;
    private PlayerDirection currentDirection;
    private bool isAttack;

    public float Speed => speed;
    public PlayerDirection CurrentDirection => currentDirection;
    public bool IsAttack { get; set; }

    private void Start()
    {
        currentDirection = PlayerDirection.RIGHT;
        ImageChange();
        SetState(new Idle_State(), PlayerState.Idle);
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
        if(Input.GetKey(KeyCode.RightArrow))
        {
            currentDirection = PlayerDirection.RIGHT;
            ImageChange();
            SetState(new Walk_State(), PlayerState.Walk);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            currentDirection = PlayerDirection.LEFT;
            ImageChange();
            SetState(new Walk_State(), PlayerState.Walk);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            currentDirection = PlayerDirection.DOWN;
            ImageChange();
            SetState(new Walk_State(), PlayerState.Walk);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            currentDirection = PlayerDirection.UP;
            ImageChange();
            SetState(new Walk_State(), PlayerState.Walk);
        }
        else
        {
            currentDirection = PlayerDirection.IDLE;
            SetState(new Idle_State(), PlayerState.Idle);
        }
    }

    public void AnimatorChange(string temp)
    {
        if(temp == "Attack")
        {
            currentAnimator.SetTrigger("temp");
            return;
        }

        currentAnimator.SetBool("IsWalk", false);
        currentAnimator.SetBool("IsIdle", false);

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
