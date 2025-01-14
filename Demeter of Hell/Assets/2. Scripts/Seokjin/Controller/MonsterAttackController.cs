using UnityEngine;
using System.Collections.Generic;
using System.Collections;

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

        // 가장 가까운 타겟 찾기
        Transform closestTarget = GetClosestTarget();
        if (closestTarget != null)
        {
            target = closestTarget;

            // 타겟이 공격 범위 내에 있고 쿨타임이 0 이하라면 투사체 발사
            if (Vector3.Distance(transform.position, target.position) <= attackRange && currentCooltime <= 0)
            {
                // 애니메이션 트리거
                anim.SetTrigger("Attack");

                currentCooltime = attackCooltime;
            }
            AfterAttack();
        }

        // 쿨타임 감소
        if (currentCooltime > 0)
        {
            currentCooltime -= Time.deltaTime;
        }
        // 범위 안에 있으면 공격 안하게 됨
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

    private Transform GetClosestTarget()
    {
        Transform closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform potentialTarget in TargetManager.Instance.targets)
        {
            if (potentialTarget == null) continue; // 타겟이 제거되었으면 스킵

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
        // 투사체 생성 및 방향 설정
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector3 direction = (target.position - transform.position).normalized;

        if (projectile.TryGetComponent(out Rigidbody2D rb))
        {
            rb.linearVelocity = direction * 5f; // 투사체 속도 조정
        }

        
    }

    protected virtual void AfterAttack() { }
    
    
}