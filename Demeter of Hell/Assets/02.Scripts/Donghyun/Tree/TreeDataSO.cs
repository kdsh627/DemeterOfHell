using UnityEngine;

[CreateAssetMenu(fileName = "TreeDataSO", menuName = "Scriptable Objects/TreeDataSO")]
public class TreeDataSO : ScriptableObject
{
    public int Hp;


    public void Init()
    {
        Hp = 100;
    }
}
