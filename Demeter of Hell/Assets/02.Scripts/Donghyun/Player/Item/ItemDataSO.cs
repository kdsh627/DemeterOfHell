using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ItemDataSO", menuName = "Scriptable Objects/ItemDataSO")]
public class ItemDataSO : ScriptableObject
{
    public int RiceValue; //쌀
    public int SeedValue; //씨앗

    public void Init()
    {
        RiceValue = 0;
        SeedValue = 5;
    }

    public void UpdateRice(int value)
    {
        RiceValue += value;
        if(RiceValue % 5 == 0)
        {
            UpdateSeed(RiceValue / 5);
            RiceValue = 0;
        }
        UIManager.Instance.RiceUIUpdate(RiceValue);
    }

    public void UpdateSeed(int value)
    {
        SeedValue += value;
        UIManager.Instance.SeedUIUpdate(SeedValue);
    }

    public bool PaySeed(int value)
    {
        if(SeedValue - value >= 0)
        {
            UpdateSeed(-value);
            return true;
        }
        else
        {
            return false;
        }
    }
}
