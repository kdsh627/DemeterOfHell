using UnityEngine;
using System.Collections;

public class MonsterAttackController : NavAgent2D
{
    public GameObject projectilePrefab; // 투사체 프리팹
    public float attackRange = 10f;     // 공격 범위
    bool isDead = false;
    public CircleCollider2D attackCollider;

    bool isAttack = false;

    private void Start()
    {/*
        attackCollider = GetComponent<CircleCollider2D>();
       
        
        attackCollider.enabled = false; // 초기에는 비활성화
        */
    }
    public void OnEnable()
    {
        isDead = false;
        attackCollider = GetComponent<CircleCollider2D>();


        attackCollider.enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
        if (1 <= GameManager.Instance.CurrentWave && GameManager.Instance.CurrentWave < 5)
        {
            MaxHp = 1;
            Hp = MaxHp;
            attackDamage = 1;
        }
        else if(5 <= GameManager.Instance.CurrentWave && GameManager.Instance.CurrentWave < 10)
        {
            MaxHp = 5;
            Hp = MaxHp;
            attackDamage = 2;
        }
        else if(10 == GameManager.Instance.CurrentWave)
        {
            MaxHp = 9;
            Hp = MaxHp;
            attackDamage = 3;
        }
        
    }
    public void Update()
    {
        base.Update();
        if (isDead)
        {
            agent.isStopped = true;
            return;
        }
        else
            agent.isStopped = false;
         
        
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
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.MonsterAttack);
        currentCooltime = attackCooltime;
    
    }

    protected override void OnDead()
    {
        if(!isDead)
        {
            isDead = true;
            base.OnDead();
            anim.SetTrigger("Dead");
            gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(DelayTime());

            AudioManager.Instance.PlaySfx(AudioManager.Sfx.MonsterDead);
            if (Spawner.Instance.monsterCount >= Spawner.Instance.maxMonsterCount)
            {

                if (AllMonstersDead())
                {
                    GameManager.Instance.WaveEnd();
                }

            }
        }
    }
 
    IEnumerator DelayTime()
    {
        isDead = true;
        yield return new WaitForSeconds(1f);
        PoolManager.Instance.Push(gameObject);

    }

    public void MeleeAttack()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.MonsterAttack);
        attackCollider.enabled = true;  // 특정 프레임에서 공격 활성화
        Invoke(nameof(DisableAttack), 0.1f); // 짧은 시간 후 비활성화
    }

    void DisableAttack()
    {
        attackCollider.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Flower"))
        {
            if(!isAttack)
            {
                isAttack = true;
                Debug.Log("플레이어 때림");
                CreatureController mc = other.GetComponent<CreatureController>();
                if (mc != null)
                {
                    Debug.Log("if 문" + attackDamage);
                    mc.OnDamaged(attackDamage); // 데미지 처리
                                                //AudioManager.Instance.PlaySfx(AudioManager.Sfx.MonsterAttack);
                }
                isAttack = false;
            }
        }
    }
    

    public bool AllMonstersDead()
    {
        Spawner.Instance.killMonsterCount++;
        if(Spawner.Instance.killMonsterCount == Spawner.Instance.maxMonsterCount)
        {
            Spawner.Instance.killMonsterCount = 0;
            return true;
        }
        return false;

    }

}