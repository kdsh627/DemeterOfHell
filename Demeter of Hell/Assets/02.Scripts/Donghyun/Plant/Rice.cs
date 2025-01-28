using UnityEngine;

public class Rice : MonoBehaviour
{
    [SerializeField] private PlantDataSO riceData;

    private float hp;

    public float HP => hp;
    public float Production => riceData.Production;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        hp = riceData.Hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHp(float value)
    {
        hp = hp - value;
    }

    
}
