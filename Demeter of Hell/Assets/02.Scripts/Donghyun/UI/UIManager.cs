using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Types;
using Donghyun.UI.Animation;
public class UIManager : MonoBehaviour
{
    [Header("----- UI -----")]
    [SerializeField] private GameObject MainUI;

    [Header("----- Wave -----")]
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text waveText;
    [SerializeField] private GameObject startButton;

    [Header("----- HP -----")]
    [SerializeField] private TMP_Text playerHpText;
    [SerializeField] private Image playerHpFill;
    [SerializeField] private TMP_Text treeHpText;
    [SerializeField] private Image treeHpFill;

    [Header("----- Player -----")]
    [SerializeField] private TMP_Text seedText;
    [SerializeField] private TMP_Text riceText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Image experienceUI;

    [Header("----- Plant -----")]
    [SerializeField] private GameObject[] plantUI;
    [SerializeField] private GameObject currentPlantUI;

    [Header("----- Enforce -----")]
    [SerializeField] private GameObject enforceCanvas;
    [SerializeField] private UIInformation UIInfo;

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

    public void TreeHpUIUpdate(int hp, int maxHp)
    {
        treeHpText.text = string.Format("Tree HP : {0:D2} / {1:D2}", hp, maxHp);
        treeHpFill.fillAmount = hp / (float)maxHp;
    }

    public void PlayerHpUIUpdate(int hp, int maxHp)
    {
        playerHpText.text = string.Format("Player HP : {0:D2} / {1:D2}", hp, maxHp);
        playerHpFill.fillAmount = hp / (float)maxHp;
    }

    public void ExperienceUIUpdate(float experience)
    {
        experienceUI.fillAmount = experience;
    }

    public void LevelUIUpdate(int level)
    {
        levelText.text = level.ToString();
    }

    public void ChangeCurrentPlantUI(PlantType type)
    {
        foreach(GameObject go in plantUI)
        {
            go.SetActive(false);
        }

        plantUI[(int)type].SetActive(true);
    }

    public void WaveStartButton()
    {
        currentPlantUI.SetActive(false);
        startButton.SetActive(false);
    }

    public void WaveEnd()
    {
        currentPlantUI.SetActive(true);
        startButton.SetActive(true);
    }

    public void OpenEnforce()
    {
        UIAnimationManager.OpenUI(() =>
        {
            enforceCanvas.SetActive(true);
            Time.timeScale = 0.0f;
        }, UIInfo, AnimationType.Slide);
    }

    public void ClosedEnforce()
    {
        UIAnimationManager.OpenUI(() =>
        {
            enforceCanvas.SetActive(false);
            Time.timeScale = 1.0f;
        }, UIInfo, AnimationType.Slide);
    }
}
