using UnityEngine;

public class AttackTest : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Monster"))
        {
            MonsterController mc = collision.gameObject.GetComponent<MonsterController>();

            mc.OnDamaged(100);
        }
    }
}
