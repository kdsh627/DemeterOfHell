using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    public float HP; //체력
    public float RgenerativePower; //체력재생력
    public float MeleeAttackPower; //근거리 공격력
    public float RangedAttackPower; //원거거리 공격력
    public float MeleeAttackSpeed; //근거리 공격속도
    public float RangedAttackSpeed; //원거리 공격속도
}
