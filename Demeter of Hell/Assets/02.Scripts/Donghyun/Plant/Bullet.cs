using UnityEngine;

namespace Donghyun.Plant
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private PlantDataSO attackData;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Monster"))
            {
                collision.GetComponent<CreatureController>().OnDamaged(attackData.Damage);
                transform.parent.GetComponentInChildren<BulletRange>().ShootEnd();
            }
        }
    }
}
