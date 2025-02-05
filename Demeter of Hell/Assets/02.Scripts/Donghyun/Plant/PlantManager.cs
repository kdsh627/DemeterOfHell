using UnityEngine;
using Types;
using System;
using UnityEngine.Tilemaps;

[Serializable]
public struct PlantInfo
{
    public int maxValue;
    public int count;
    public GameObject plant;
}

public class PlantManager : MonoBehaviour
{
    [Header("----- Data -----")]
    [SerializeField] private PlantDataSO riceData;
    [SerializeField] private PlantDataSO peaShootData;
    [SerializeField] private PlantDataSO hpBuffData;

    [Header("----- Plants -----")]
    [SerializeField] private GameObject plantGroup;
    [SerializeField] private PlantInfo[] plants;

    private PlantType currentType;
    private static PlantManager instance;

    public PlantType CurrentPlantType => currentType;

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

    private void Update()
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
                currentType = PlantType.HpBuff;
            }
            UIManager.Instance.ChangeCurrentPlantUI(currentType);
        }
    }

    public void SetPlantManagerInit()
    {
        currentType = PlantType.Rice;
        UIManager.Instance.ChangeCurrentPlantUI(currentType);
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

    public void InitPlantData()
    {
        riceData.Init();
        peaShootData.Init();
        hpBuffData.Init();
    }

    public bool PaySeed()
    {
        int Price = 0;
        switch (currentType)
        {
            case PlantType.Rice:
                Price = riceData.Price;
                break;
            case PlantType.Attack:
                Price = peaShootData.Price;
                break;
            case PlantType.HpBuff:
                Price = hpBuffData.Price;
                break;
        }

        return GameManager.Instance.Item.PaySeed(Price);
    }


    //해당 라운드 식물을 정산
    public void SettlePlant(ItemDataSO item)
    {
        for(int i = 0; i < plants.Length; i++) 
        {
            switch ((PlantType)i)
            {
                case PlantType.Rice:
                    item.UpdateSeed(plants[i].count * riceData.Price);
                    break;
                case PlantType.Attack:
                    item.UpdateSeed(plants[i].count * peaShootData.Price);
                    break;
                case PlantType.HpBuff:
                    item.UpdateSeed(plants[i].count * hpBuffData.Price);
                    break;
            }
            plants[i].count = 0;
        }
        for(int i = plantGroup.transform.childCount - 1; i >= 0; --i)
        {
            Destroy(plantGroup.transform.GetChild(i));
        }
    }

    //벼 수확
    public void HarvestRice()
    {
        GameManager.Instance.Item.UpdateRice(plants[(int)PlantType.Rice].count * riceData.Price);
    }

    public void ActivateHpBuff()
    {
        
    }
}
