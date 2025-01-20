using UnityEngine;

public class BossMonsterController : MonsterAttackController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            agent.isStopped = true;
            anim.SetTrigger("Idle");

        }
        else
        {
            agent.isStopped = false;
            anim.SetTrigger("Run");
        }

    }

    public void PatternEnd()
    {
        anim.SetTrigger("Pattern End");
        
    }

    
}
