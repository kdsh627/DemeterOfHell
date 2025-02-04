using Donghyun.UI.Animation;
using UnityEngine;
using Types;
using System;
using Unity.VisualScripting;

[Serializable]
public struct PlantInfo
{
    public int maxValue;
    public int count;
    public GameObject plant;
}

public class PlantManager : MonoBehaviour
{
    [SerializeField] private GameObject plantGroup;
    [SerializeField] private PlantInfo[] plants;
    [SerializeField] private int maxRiceValue;
    [SerializeField] private int maxAttackValue;
    [SerializeField] private int maxPowerBuffValue;
    [SerializeField] private int maxHPBuffValue;

    private PlantType currentType;
    private static PlantManager instance;

    public static PlantManager Instance
    {
        get
        {
            if (instance == null) instance = new PlantManager();
            return instance;
        }
    }

    private void Awake()
    {
        currentType = PlantType.Rice;

        //인스턴스가 비어있다면 할당해주고, 
        //해당 오브젝트를 씬 이동간 파괴하지 않게함
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // 인스턴스가 이미 할당돼있다면(2개 이상이라면) 파괴
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(!GameManager.Instance.BeginWave)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                currentType = PlantType.Rice;
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                currentType = PlantType.Attack;
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                currentType = PlantType.PowerBuff;
            }
            else if (Input.GetKey(KeyCode.Alpha4))
            {
                currentType = PlantType.HPBuff;
            }
        }
    }

    public void SpawnPlant(Vector3 Position)
    {
        //최대 식물 개수 제한
        if(plants[(int)currentType].count < plants[(int)currentType].maxValue)
        {
            GameObject go = Instantiate(plants[(int)currentType].plant, plantGroup.transform);

            go.transform.position = Position;

            TargetManager.Instance.targets.Add(go.transform); //타겟 매니저에 해당 타겟 추가

            plants[(int)currentType].count++;
        }
    }

    //벼 수확
    public void HarvestRice()
    {
        GameManager.Instance.Item.UpdateRice(plants[(int)PlantType.Rice].count * Rice.Production);
    }

    public void ActivateAttackBuff()
    {
        
    }

    public void ActivateHpBuff()
    {
        
    }
}
