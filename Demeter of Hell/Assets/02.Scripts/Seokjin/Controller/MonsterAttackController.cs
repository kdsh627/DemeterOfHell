using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.U2D;

public class MonsterAttackController : NavAgent2D
{
    public GameObject projectilePrefab; // 투사체 프리팹
    public float attackRange = 10f;     // 공격 범위
    
    
      

    

    private void Start()
    {
        
        
        
    }

    public void Update()
    {
        base.Update();
        
        //가장 가까운 타겟 찾기
        Transform closestTarget = GetClosestTarget();
        if (closestTarget != null)
        {
            target = closestTarget;

            // 타겟이 공격 범위 내에 있고 
            if (Vector3.Distance(transform.position, target.position) <= attackRange)
            {
                //쿨타임도 됐다면 공격
                if(currentCooltime <= 0)
                {
                    Attack();

                    

                }
                //안됐다면 가만히 있기
                else
                {
                    agent.isStopped = true;
                    anim.SetTrigger("Idle");

                }
            }
            //범위 내에 없다면 달려가기
            else
            {
                agent.isStopped = false;
                anim.SetTrigger("Run");
            }
            AfterAttack();
        }
        agent.SetDestination(target.position);


        sprite.flipX = transform.position.x > target.position.x;
        //쿨타임 감소
        if (currentCooltime > 0)
        {
            currentCooltime -= Time.deltaTime;
        }
        
        
    }

    private Transform GetClosestTarget()
    {
        Transform closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform potentialTarget in TargetManager.Instance.targets)
        {
            if (potentialTarget == null) continue; //타겟이 제거되었으면 스킵

            float distance = Vector3.Distance(transform.position, potentialTarget.position);
            if (distance < closestDistance)
            {
                closest = potentialTarget;
                closestDistance = distance;
            }
        }

        return closest;
    }

    public void ShootProjectile()
    {
        GameObject projectile = PoolManager.Instance.Pop(projectilePrefab);
        projectile.transform.position = transform.position;
       
        Vector3 direction = (target.position - transform.position).normalized;

        if (projectile.TryGetComponent(out Rigidbody2D rb))
        {
            rb.linearVelocity = direction * 5f; //투사체 속도 조정
        }

        
    }

    protected virtual void AfterAttack() { }
    
    protected virtual void Attack() {
        anim.SetTrigger("Attack");
        
        currentCooltime = attackCooltime;
    
    }
}