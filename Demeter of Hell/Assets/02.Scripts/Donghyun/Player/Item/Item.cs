using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemDataSO itemData;

    private float riceValue;
    private float seedValue;

    private void Awake()
    {
        riceValue = itemData.RiceValue;
        seedValue = itemData.SeedValue;
    }

    public void IncreseRIce(float value)
    {
        riceValue += value;
    }

    public void DecreseRIce(float value)
    {
        riceValue -= value;
    }
    public void IncreseSeed(float value)
    {
        seedValue += value;
    }
    public void DecreseSeed(float value)
    {
        seedValue -= value;
    }
}
