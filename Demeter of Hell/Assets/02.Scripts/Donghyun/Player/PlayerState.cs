using UnityEngine;
using Types;

public interface IPlayerState
{
    void Input(Player player, string input);
    void Update(Player player);
}

public class StateInfo
{
    protected float direction;
    protected Vector2 translateVector;

    /// <summary>
    /// 움직일 방향과 거리를 계산
    /// </summary>
    /// <param name="currentDirection">풀레이어의 현재 방향</param>
    /// <param name="speed">플레이어의 스피드</param>
    protected void SetTranslateVector(PlayerDirection currentDirection, float speed)
    {
        switch (currentDirection)
        {
            case PlayerDirection.LEFT:
                direction = -1.0f;
                translateVector = new Vector2(direction * Time.fixedDeltaTime * speed, 0);
                break;
            case PlayerDirection.RIGHT:
                direction = 1.0f;
                translateVector = new Vector2(direction * Time.fixedDeltaTime * speed, 0);
                break;
            case PlayerDirection.UP:
                direction = 1.0f;
                translateVector = new Vector2(0, direction * Time.fixedDeltaTime * speed);
                break;
            case PlayerDirection.DOWN:
                direction = -1.0f;
                translateVector = new Vector2(0, direction * Time.fixedDeltaTime * speed);
                break;
        }
    }
}

//플레이어 상태 - Idle
public class Idle_State : StateInfo, IPlayerState
{
    public void Input(Player player, string input) //입력 시 한 번 실행
    {
        //입력 처리
        player.AnimatorChange(input);
    }

    public void Update(Player player) //입력 들어왔을 때 Player 스크립트의 Update
    {
        //행동 처리
    

    }
}

//플레이어 상태 - Walk
public class Walk_State : StateInfo, IPlayerState
{
    public void Input(Player player, string input) //입력 시 한 번 실행
    {
        //입력 처리
        player.AnimatorChange(input);
        SetTranslateVector(player.CurrentDirection, player.Speed);
    }

    public void Update(Player player) //입력 들어왔을 때 Player 스크립트의 Update
    {
        //행동 처리
        player.transform.Translate(translateVector);
    }
}

//플레이어 상태 - Attack
public class Attack_State : StateInfo, IPlayerState
{
    public void Input(Player player, string input) //입력 시 한 번 실행
    {
        //입력 처리
        player.AnimatorChange(input);
    }

    public void Update(Player player) //입력 들어왔을 때 Player 스크립트의 Update
    {
        //행동 처리
        SetTranslateVector(player.CurrentDirection, player.Speed);
        player.transform.Translate(translateVector);
    }
}
