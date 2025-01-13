using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RangeMonsterController : NavAgent2D
{
    public GameObject projectilePrefab; // 투사체 프리팹
    public float attackRange = 10f;     // 공격 범위
    
    public float projectileFireTime=0.5f;    // 공격 선딜 시간
      

    

    private void Start()
    {
        
        
        
    }

    private void Update()
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
            anim.SetTrigger("Run");
        }

        // 쿨타임 감소
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

    
    
    
}