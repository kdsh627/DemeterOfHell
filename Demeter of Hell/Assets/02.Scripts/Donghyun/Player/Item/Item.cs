using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemDataSO itemData;

    public ItemDataSO Data => itemData;
}
