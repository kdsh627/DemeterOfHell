using System.Collections.Generic;
using UnityEngine;
using Types;

public class Player : MonoBehaviour
{
    [SerializeField] private List<GameObject> playerImage;
    [SerializeField] private List<Animator> animator;
    [SerializeField] private Item item;
    [SerializeField] private float speed;
    [SerializeField] private PlayerDataSO playerData; //플레이어 데이터

    private Animator currentAnimator;
    private IPlayerState currentState;
    private PlayerDirection currentDirection;
    private bool isAttack;

    public float Speed => speed;
    public PlayerDirection CurrentDirection => currentDirection;
    public bool IsAttack { get; set; }
    public PlayerDataSO PlayerData { get; set; }

    private void Start()
    {
        currentDirection = PlayerDirection.UP;
        ImageChange(PlayerDirection.RIGHT);
        SetState(new Idle_State(), PlayerState.Idle);
        item = GetComponent<Item>();
        item.Data.UpdateSeed(0);
        item.Data.UpdateRice(0);
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
        if(currentAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            SetState(new Attack_State(), PlayerState.Attack);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ImageChange(PlayerDirection.RIGHT);
            SetState(new Walk_State(), PlayerState.Walk);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            ImageChange(PlayerDirection.LEFT);
            SetState(new Walk_State(), PlayerState.Walk);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            ImageChange(PlayerDirection.DOWN);
            SetState(new Walk_State(), PlayerState.Walk);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            ImageChange(PlayerDirection.UP);
            SetState(new Walk_State(), PlayerState.Walk);
        }
        else
        {
            SetState(new Idle_State(), PlayerState.Idle);
        }
    }

    public void AnimatorChange(string temp)
    {
        if (temp == "Attack")
        {
            currentAnimator.SetTrigger(temp);
            return;
        }

        currentAnimator.SetBool("IsWalk", false);
        currentAnimator.SetBool("IsIdle", false);

        currentAnimator.SetBool("Is" + temp, true);
    }

    public void ImageChange(PlayerDirection direction)
    {
        if (currentDirection == direction)
        {
            return;
        }

        currentDirection = direction;

        for (int i = 0; i < playerImage.Count; ++i)
        {
            playerImage[i].SetActive(false);
        }

        playerImage[(int)currentDirection].SetActive(true);

        currentAnimator = animator[(int)currentDirection];
    }
}
