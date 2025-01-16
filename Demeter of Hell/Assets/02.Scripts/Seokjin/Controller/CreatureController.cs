using UnityEngine;

public class CreatureController : MonoBehaviour
{
    protected float _speed = 1f;
    public float Hp { get; set; } = 100;
    public float MaxHp { get; set; } = 100;

    public virtual void OnDamaged(float damage)
    {
        Hp -= damage;
        if (Hp < 0)
        {
            Hp = 0;
            OnDead();
        }
    }

    protected virtual void OnDead()
    {

    }

}
