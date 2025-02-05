using UnityEngine;

public class Attack : CreatureController
{
    [SerializeField] private PlantDataSO attackData;

    public static int Production;
    public static int Price;
    void Start()
    {
        Production = attackData.Production;
        Price = attackData.Price;
        Hp = attackData.Hp;
        MaxHp = attackData.Hp;
    }

    protected override void OnDead()
    {
        //타겟매니저에서 제거
        TargetManager.Instance.targets.Remove(transform);

        //임시로 파괴
        Destroy(gameObject);
    }
}
