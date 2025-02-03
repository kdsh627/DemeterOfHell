using UnityEngine;

public class PowerBuff : CreatureController
{
    [SerializeField] private PlantDataSO powerBuffData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hp = powerBuffData.Hp;
        MaxHp = powerBuffData.Hp;
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
