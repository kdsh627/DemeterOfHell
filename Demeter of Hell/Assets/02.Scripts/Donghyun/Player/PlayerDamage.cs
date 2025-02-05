using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Monster"))
        {
            Player player = GetComponentInParent<Player>();
            if (!ReferenceEquals(player, null)) //null처리
            {
                player.AttackMonster(collision);
            }
        }
    }
}
