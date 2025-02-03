using UnityEngine;

public class AttackDecision : MonoBehaviour
{
    public Collider2D attackCollider; // 공격 판정을 위한 콜라이더
    private void Start()
    {
        attackCollider = GetComponent<Collider2D>();
        attackCollider.enabled = false; // 초기에는 비활성화
    }

    // 애니메이션 이벤트에서 호출될 함수
    public void AttackHit()
    {
        attackCollider.enabled = true;  // 특정 프레임에서 공격 활성화
        Invoke(nameof(DisableAttack), 0.1f); // 짧은 시간 후 비활성화
    }

    void DisableAttack()
    {
        attackCollider.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Flower"))
        {
            MonsterController mc = collision.gameObject.GetComponent<MonsterController>();

            mc.OnDamaged(100);
        }
    }
}
