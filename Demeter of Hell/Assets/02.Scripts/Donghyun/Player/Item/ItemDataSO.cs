using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ItemDataSO", menuName = "Scriptable Objects/ItemDataSO")]
public class ItemDataSO : ScriptableObject
{
    public int RiceValue; //쌀
    public int SeedValue; //씨앗

    public void init()
    {
        RiceValue = 0;
        SeedValue = 0;
    }

    public void UpdateRice(int value)
    {
        RiceValue += value;
        UIManager.Instance.RiceUIUpdate(RiceValue);
    }

    public void UpdateSeed(int value)
    {
        SeedValue += value;
        UIManager.Instance.SeedUIUpdate(SeedValue);
    }
}
