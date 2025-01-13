using UnityEngine;

public class RangeMonsterController : MonsterAttackController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if(Vector3.Distance(transform.position, target.position)<=attackRange)
        {
            agent.isStopped = true;
        }
        else
            agent.isStopped = false;

    }
}
