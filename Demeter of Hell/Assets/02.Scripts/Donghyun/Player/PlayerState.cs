using UnityEngine;
using Types;

public interface IPlayerState
{
    void Input(Player player, string input);
    void Update(Player player);
}


//플레이어 상태 - Idle
public class Idle_State : IPlayerState
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
public class Walk_State : IPlayerState
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

//플레이어 상태 - Attack
public class Attack_State : IPlayerState
{
    public void Input(Player player, string input) //입력 시 한 번 실행
    {
        //입력 처리
        player.AnimatorChange(input);
    }

    public void Update(Player player) //입력 들어왔을 때 Player 스크립트의 Update
    {
 
    }
}
