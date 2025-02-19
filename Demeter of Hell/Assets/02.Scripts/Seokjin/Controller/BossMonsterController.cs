using System.Collections;
using UnityEngine;

public class BossMonsterController : MonsterAttackController
{

    int index = 0;
    public GameObject[] monsters;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    protected override void Attack()
    {
        anim.SetTrigger("Idle");
        index = Random.Range(0, 3); //패턴의 수 만큼 넣어주세요

        //디버그용
        

        Debug.Log("attack 들어옴");
        anim.SetInteger("Pattern Index", index);
        Debug.Log(index);
        currentCooltime = attackCooltime;

        
    }

    public void PatternEnd()
    {
        anim.SetTrigger("Pattern End");
        anim.SetInteger("Pattern Index", 5);
    }

    public void FiveProjAttack()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.MonsterAttack);
        int projectileCount = 5; // 총 5개의 투사체 발사
        float spreadAngle = 10f; // 좌우로 퍼지는 각도 (각 탄환 간의 각도 차이)

        for (int i = 0; i < projectileCount; i++)
        {
            GameObject projectile = PoolManager.Instance.Pop(projectilePrefab);
            projectile.transform.position = transform.position;

            // 중심 투사체는 i == 2
            float angleOffset = (i - 2) * spreadAngle; // -20, -10, 0, +10, +20

            // 회전 적용
            Vector3 direction = Quaternion.Euler(0, 0, angleOffset) * (target.position - transform.position).normalized;

            if (projectile.TryGetComponent(out Rigidbody2D rb))
            {
                rb.linearVelocity = direction * 5f; // 투사체 속도 조정
            }
        }
    }

    public void StartSummonMonster()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.MonsterAttack);
        StartCoroutine(SummonMonsterCorutine());
    }

    IEnumerator SummonMonsterCorutine()
    {
        for (int i = 0; i < 5; i++)
        {
            SummonMonster(0);
            SummonMonster(1);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void SummonMonster(int index)
    {

        Vector3 RandomPosition = Random.insideUnitCircle * 5f;
        GameObject monster = PoolManager.Instance.Pop(monsters[index]);
        monster.transform.position = transform.position + RandomPosition;

    }

    public void ShootProjtoTargetRandom()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.MonsterAttack);
        int projectileCount = 5; // 총 5개의 투사체 발사
        float minSpreadAngle = -15; // 최소 각도 (왼쪽)
        float maxSpreadAngle = 15;  // 최대 각도 (오른쪽)

        for (int i = 0; i < projectileCount; i++)
        {
            GameObject projectile = PoolManager.Instance.Pop(projectilePrefab);
            projectile.transform.position = transform.position;

            // 랜덤 각도 계산
            float randomAngle = Random.Range(minSpreadAngle, maxSpreadAngle);

            // 회전 적용
            Vector3 direction = Quaternion.Euler(0, 0, randomAngle) * (target.position - transform.position).normalized;

            if (projectile.TryGetComponent(out Rigidbody2D rb))
            {
                rb.linearVelocity = direction * 5f; // 투사체 속도 조정
            }
        }
    }

    public void ShootProjAroundRandom()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.MonsterAttack);
        int projectileCount = 5; // 총 5개의 투사체 발사
        float minSpreadAngle = 0; // 최소 각도 (왼쪽)
        float maxSpreadAngle = 360;  // 최대 각도 (오른쪽)

        for (int i = 0; i < projectileCount; i++)
        {
            GameObject projectile = PoolManager.Instance.Pop(projectilePrefab);
            projectile.transform.position = transform.position;

            // 랜덤 각도 계산
            float randomAngle = Random.Range(minSpreadAngle, maxSpreadAngle);

            // 회전 적용
            Vector3 direction = Quaternion.Euler(0, 0, randomAngle) * (target.position - transform.position).normalized;

            if (projectile.TryGetComponent(out Rigidbody2D rb))
            {
                rb.linearVelocity = direction * 5f; // 투사체 속도 조정
            }
        }
    }
}

