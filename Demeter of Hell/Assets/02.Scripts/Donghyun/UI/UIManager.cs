using System;
using UnityEngine;
using TMPro;
using Types;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text waveText;
    [SerializeField] private TMP_Text seedText;
    [SerializeField] private TMP_Text riceText;
    [SerializeField] private GameObject MainUI;

    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null) instance = new UIManager();
            return instance;
        }
    }

    private void Awake()
    {
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //시간 UI 업데이트
    public void TimerUIUpdate(float currentTime)
    {
        string textTime = currentTime.ToString("F2");
        string[] parts = textTime.Split('.');

        int integer = Int32.Parse(parts[0]);

        int minutePart = integer / 60;
        int integerPart = integer - minutePart * 60;
        int decimalPart = Int32.Parse(parts[1]);

        textTime = string.Format("{0:D2}:{1:D2}:{2:D2}", minutePart, integerPart, decimalPart);

        timerText.text = textTime;
    }

    //웨이브 UI 업데이트
    public void WaveUIUpdate(int currentWave, int maxWave)
    {
        waveText.text = string.Format("Wave {0} / {1}", currentWave, maxWave);
    }

    public void SetActiveMainUI()
    {
        MainUI.SetActive(true);
    }

    public void RiceUIUpdate(int rice)
    {
        riceText.text = rice.ToString();
    }

    public void SeedUIUpdate(int seed)
    {
        seedText.text = seed.ToString();
    }
}
