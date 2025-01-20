using UnityEngine;

public class BossMonsterController : MonsterAttackController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Attack()
    {
        anim.SetTrigger("Idle");
        int index = Random.Range(0, 2); //패턴의 수 만큼 넣어주세요
        anim.SetInteger("Pattern Index", index);
        Debug.Log(index);
        currentCooltime = attackCooltime;
    }

    public void PatternEnd()
    {
        anim.SetTrigger("Pattern End");
        
    }

    
}
