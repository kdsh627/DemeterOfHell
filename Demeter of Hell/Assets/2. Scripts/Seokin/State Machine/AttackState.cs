using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    Transform monsterTransform;
    MonsterController monster;
    public virtual void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster = animator.GetComponent<MonsterController>();
        monsterTransform = animator.GetComponent<Transform>();
    }

    public virtual void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //어택쿨타임이 다 찼으면 어택
        if(monster.attackDelay <=0 )
        {
            animator.SetTrigger("Attack");
        }
        //플레이어와 거리가 일정 수치 이상 멀어지면 다시 런 상태
        if (Vector2.Distance(monster.player.position, monster.transform.position) > 1f)
        {
            animator.SetTrigger("Run");
        }
        monster.DirectionMonster(monster.player.position.x, monsterTransform.position.x);
    }

    public virtual void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        monster.attackDelay = monster.attackCooltime;
    }
}
