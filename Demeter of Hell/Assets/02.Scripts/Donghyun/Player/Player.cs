using System.Collections.Generic;
using UnityEngine;
using Types;

public class Player : CreatureController
{
    [SerializeField] private List<GameObject> playerImage;
    [SerializeField] private List<Animator> animator;
    [SerializeField] private ItemDataSO itemData;
    [SerializeField] private float speed;
    [SerializeField] private PlayerDataSO playerData; //플레이어 데이터

    private Animator currentAnimator;
    private IPlayerState currentState;
    private PlayerDirection currentDirection;
    private bool isAttack;

    public float Speed => speed;
    public ItemDataSO ItemData => itemData;
    public PlayerDataSO PlayerData => playerData;
    public PlayerDirection CurrentDirection => currentDirection;
    public bool IsAttack { get; set; }

    private void Start()
    {
        currentDirection = PlayerDirection.UP;
        ImageChange(PlayerDirection.RIGHT);
        SetState(new Idle_State(), PlayerState.Idle);

        //플레이어 체력
        MaxHp = playerData.Hp;
        Hp = playerData.Hp;

        UIManager.Instance.PlayerHpUIUpdate((int)Hp);

        itemData.UpdateSeed(0);
        itemData.UpdateRice(0);
        UIManager.Instance.LevelUIUpdate(playerData.Level);
        UIManager.Instance.ExperienceUIUpdate(0.0f);
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

    public override void OnDamaged(float damage)
    {
        base.OnDamaged(damage);
        UIManager.Instance.PlayerHpUIUpdate((int)Hp); //형변환 다시 한번 체크해야함
    }

    protected override void OnDead()
    {

    }

    //적에게 데미지 주기
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Monster"))
        {
            collision.transform.gameObject.GetComponent<CreatureController>().OnDamaged(playerData.MeleeAttackPower);
        }
    }
}
