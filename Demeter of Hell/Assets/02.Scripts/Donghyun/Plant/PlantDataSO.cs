using UnityEngine;
using Types;

[CreateAssetMenu(fileName = "PlantData", menuName = "Scriptable Objects/PlantData")]
public class PlantDataSO : ScriptableObject
{
    public PlantType PlantType;
    public int Hp; //체력
    public int Damage; //공격력
    public int DamageBuff; //공격력 버프
    public int HpBuff; //체력 회복량
    public int Production; //웨이브당 생산량
    public int Price;

    public void Init()
    {
        Hp = 10;
        Damage = 0;
        HpBuff = 0;
        DamageBuff = 0;
        Production = 0;

        switch (PlantType)
        {
            case PlantType.Rice:
                Production = 1;
                break;
            case PlantType.Attack:
                Damage = 1;
                break;
            case PlantType.HpBuff:
                HpBuff = 1;
                break;
        }
    }
}
