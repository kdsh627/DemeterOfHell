using UnityEngine;

public class HpBuff : CreatureController
{
    [SerializeField] private PlantDataSO hpBuffData;

    public static int Production;
    public static int Price;

    void Start()
    {
        Production = hpBuffData.Price;
        Price = hpBuffData.Price;
        Hp = hpBuffData.Hp;
        MaxHp = hpBuffData.Hp;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    protected override void OnDead()
    {
        //타겟매니저에서 제거
        TargetManager.Instance.targets.Remove(transform);

        //임시로 파괴
        Destroy(gameObject);
    }
}
