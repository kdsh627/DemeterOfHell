using UnityEngine;

public class Attack : CreatureController
{
    [SerializeField] private PlantDataSO attackData;

    void Start()
    {
        Hp = attackData.Hp;
        MaxHp = attackData.Hp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    protected override void OnDead()
    {
        //임시로 파괴
        Destroy(gameObject);
    }
}
