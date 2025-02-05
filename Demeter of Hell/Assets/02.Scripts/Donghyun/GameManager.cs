using Types;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxWave;
    [SerializeField] private int maxRound;
    [SerializeField] private float waveTimeLimit;
    [SerializeField] private int maxScene;
    [SerializeField] private ItemDataSO itemData;
    [SerializeField] private PlayerDataSO playerData;
    [SerializeField] private TreeDataSO treeData;
    [SerializeField] private TileHighlighter tileHighlighter;

    private int currentScene;
    private int currentRound;
    private int currentWave;
    private float currentTime;
    private bool beginWave;

    private static GameManager instance;

    public bool BeginWave => beginWave;
    public ItemDataSO Item => itemData;
    public int CurrentWave => currentWave;

    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameManager();
            return instance;
        }
    }

    private void Awake()
    {
        //현재 씬 번호
        currentScene = SceneManager.GetActiveScene().buildIndex;

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

    private void Start()
    {
        RoundStart(); //테스트 코드
        AudioManager.Instance.PlayBgm(true);
    }

    private void Update()
    {
        //웨이브 진행 동안만 실행
        if(beginWave)
        {
            TimeUpdate();
        }
    }

    //씬 변경
    public void ChangeScene()
    {
        if(currentScene >= 1)
        {
            PlantManager.Instance.SettlePlant(itemData);
        }

        SceneManager.LoadScene(++currentScene);

        AudioManager.Instance.PlayBgm(true);

        if (currentScene >= 1 && currentScene < maxScene)
        {
            UIManager.Instance.SetActiveMainUI();
            RoundStart();
        }
    }

    //해당 라운드 씬 시작
    public void RoundStart()
    {
        currentWave = 1;
        currentRound = currentScene;
        beginWave = false;
        UIManager.Instance.WaveUIUpdate(currentWave, maxWave);
        PlantManager.Instance.SetPlantManagerInit();
        UIManager.Instance.WaveEnd();
    }

    //웨이브 시작
    public void WaveStart()
    {
        beginWave = true;
        currentTime = waveTimeLimit;

    }

    //웨이브 종료
    public void WaveEnd()
    {
        beginWave = false;
        currentWave += 1;

        PlantManager.Instance.HarvestRice(); //수확

        //해당 라운드 씬 종료
        if(currentWave >= maxWave)
        {
            ChangeScene();
        }
        else
        {
            UIManager.Instance.WaveUIUpdate(currentWave, maxWave);
            UIManager.Instance.WaveEnd();
            PlantManager.Instance.SetPlantManagerInit();
        }
    }

    public void GameOver()
    {
        InitGameData();

        currentScene = 0;
        ChangeScene();
    }
    
    public void InitGameData()
    {
        treeData.Init();
        itemData.Init();
        playerData.Init();
        PlantManager.Instance.InitPlantData();
    }

    //타이머 업데이트
    private void TimeUpdate()
    {
        if(currentTime > Mathf.Epsilon) 
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = 0.0f;
            WaveEnd(); //웨이브 종료
        }
        UIManager.Instance.TimerUIUpdate(currentTime);
    }

}
