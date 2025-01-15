using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public interface IPlayerState
{
    void Input(Player player, string input);
    void Update(Player player);
}

//플레이어 상태 - Idle
public class IDLE_State : IPlayerState
{
    public void Input(Player player, string input) //입력 시 한 번 실행
    {
        //입력 처리
        player.AnimatorChange("IsIdle");
    }

    public void Update(Player player) //입력 들어왔을 때 Player 스크립트의 Update
    {
        //행동 처리

    }
}

//플레이어 상태 - Walk
public class Walk_State : IPlayerState
{
    private float direction;
    private Vector3 translateVector;

    public void Input(Player player, string input) //입력 시 한 번 실행
    {
        //입력 처리
        player.AnimatorChange("IsWalk");

        switch (player.CurrentDirection)
        {
            case PlayerDirection.UP:
                direction = 1.0f;
                translateVector = new Vector3(0, direction * Time.fixedDeltaTime * player.Speed, 0);
                break;
            case PlayerDirection.DOWN:
                direction = -1.0f;
                translateVector = new Vector3(0, direction * Time.fixedDeltaTime * player.Speed, 0);
                break;
            case PlayerDirection.RIGHT:
                direction = 1.0f;
                translateVector = new Vector3(direction * Time.fixedDeltaTime * player.Speed, 0, 0);
                break;
            case PlayerDirection.LEFT:
                direction = -1.0f;
                translateVector = new Vector3(direction * Time.fixedDeltaTime * player.Speed, 0, 0);
                break;
        }
    }

    public void Update(Player player) //입력 들어왔을 때 Player 스크립트의 Update
    {
        //행동 처리
        player.transform.Translate(translateVector);
    }
}

//플레이어 상태 - Attack
public class Attack_State : IPlayerState
{
    public void Input(Player player, string input) //입력 시 한 번 실행
    {
        //입력 처리
        player.AnimatorChange("Attack");
    }

    public void Update(Player player) //입력 들어왔을 때 Player 스크립트의 Update
    {
        //행동 처리
    }
}
