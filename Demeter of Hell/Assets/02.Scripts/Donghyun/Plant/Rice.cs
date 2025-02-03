using UnityEngine;

public class Rice : CreatureController
{
    [SerializeField] private PlantDataSO riceData;

    public static int Production;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Production = riceData.Production;
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
        //임시로 파괴
        TargetManager.Instance.targets.Remove(transform);
        Destroy(gameObject);
    }
}
