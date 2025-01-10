using UnityEngine;

public class RunState : StateMachineBehaviour
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
        //플레이어와 일정거리 이상 가까워 지면 공격
        if(Vector2.Distance(monster.player.position, monster.transform.position) < 1f)
        {
            animator.SetTrigger("Attack");
        }
        animator.SetTrigger("Run");
        monster.DirectionMonster(monster.player.position.x, monsterTransform.position.x);
    }

    public virtual void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
