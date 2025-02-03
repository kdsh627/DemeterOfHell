using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "TreeDataSO", menuName = "Scriptable Objects/TreeDataSO")]
public class TreeDataSO : ScriptableObject
{
    public int Hp;


    public void Init()
    {
        Hp = 10;
    }
}
