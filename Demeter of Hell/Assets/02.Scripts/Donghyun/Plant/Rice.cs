using UnityEngine;

public class Rice : CreatureController
{
    [SerializeField] private PlantDataSO riceData;

    public static int Production;
    public static int Price;

    void Awake()
    {
        Production = riceData.Production;
        Price = riceData.Price;
        Hp = riceData.Hp;
        MaxHp = riceData.Hp;
        TargetManager.Instance.targets.Add(transform);
    }

    public void UpdateProduction(int value)
    {
        riceData.Production += value;
        Production = riceData.Production;
    }

    protected override void OnDead()
    {
        //타겟매니저에서 제거
        TargetManager.Instance.targets.Remove(transform);

        //임시로 파괴
        TargetManager.Instance.targets.Remove(transform);
        Destroy(gameObject);
    }
}
