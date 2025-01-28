using UnityEngine;
using Types;

[CreateAssetMenu(fileName = "PlantData", menuName = "Scriptable Objects/PlantData")]
public class PlantDataSO : ScriptableObject
{
    public PlantType PlantType;
    public float Hp; //체력
    public float Damage; //공격력
    public float DamageBuff; //공격력 버프
    public float HpBuff; //체력 회복량
    public float Production; //웨이브당 생산량
}
