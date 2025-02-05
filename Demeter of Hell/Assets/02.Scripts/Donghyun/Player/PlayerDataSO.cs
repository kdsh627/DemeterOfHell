using UnityEngine;

public enum PlayerDataType
{
    Hp,
    RegenerativePower,
    MeleeAttackPower
}

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerDataSO : ScriptableObject
{
    public int Hp; //체력
    public int Level; //레벨
    public int ExperienceAmount; //필요 경험치 량
    public int CurrentExperienceAmount; //현재 경험치 량
    public int RegenerativePower; //체력재생력
    public int MeleeAttackPower; //근거리 공격력
    public int RangedAttackPower; //원거리 공격력
    //public float MeleeAttackSpeed; //근거리 공격속도
    //public float RangedAttackSpeed; //원거리 공격속도

    public void Init()
    {
        Hp = 20;
        Level = 1;
        ExperienceAmount = 10;
        CurrentExperienceAmount = 0;
        RegenerativePower = 1;
        MeleeAttackPower = 1;
        RangedAttackPower = 1;
    }

    public void UpdateExperience(int value)
    {
        CurrentExperienceAmount += value;
        if (ExperienceAmount == CurrentExperienceAmount)
        {
            Level++;
            ExperienceAmount++;
            CurrentExperienceAmount = 0;
            UIManager.Instance.LevelUIUpdate(Level);

            //5레벨 단위로 강화창 오픈
            if(Level % 5 == 0) 
            { 
                UIManager.Instance.OpenEnforce();
            }
        }
        UIManager.Instance.ExperienceUIUpdate(CurrentExperienceAmount / (float)ExperienceAmount);
    }
}
