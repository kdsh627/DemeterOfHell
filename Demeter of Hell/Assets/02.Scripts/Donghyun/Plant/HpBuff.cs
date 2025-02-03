using UnityEngine;

public class HpBuff : CreatureController
{
    [SerializeField] private PlantDataSO hpBuffData;

    void Start()
    {
        Hp = hpBuffData.Hp;
        MaxHp = hpBuffData.Hp;
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
