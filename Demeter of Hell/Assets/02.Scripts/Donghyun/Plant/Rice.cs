using UnityEngine;

public class Rice : CreatureController
{
    [SerializeField] private PlantDataSO riceData;

    void Awake()
    {
        Hp = riceData.Hp;
        MaxHp = riceData.Hp;
    }

    public void UpdateProduction(int value)
    {
        riceData.Production += value;
    }

    protected override void OnDead()
    {
        //타겟매니저에서 제거
        TargetManager.Instance.targets.Remove(transform);
        Destroy(gameObject);
    }
}
