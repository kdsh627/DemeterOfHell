using System.Collections;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }
    public float timer=0;
    public int maxMonsterCount;
    public int monsterCount=0;
    public Transform[] spawnPoint;
    public GameObject[] monsters;
    public float spawnRadius = 1f;
    public int killMonsterCount;
    public bool isWaveStart = false;
    private void Awake()
    {
        // 싱글톤 초기화
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //게임 매니져에서 게임이 실행되고 있는지를 알려주는 불ㅂ값이 true일떄만 흐르게 하기
        //if (!GameManager.instance.isLive)
        //        return;

        if (isWaveStart == false ) return;

        timer += Time.deltaTime;

        if (timer > 0.2f && monsterCount < maxMonsterCount)
        {
            timer = 0;
            Spawn();
            monsterCount++;
        }
    }

    public void Spawn()
    {
        

        Vector3 RandomPosition = Random.insideUnitCircle * spawnRadius;


        GameObject monster = PoolManager.Instance.Pop(monsters[Random.Range(0,monsters.Length)]);
        //데미지 설정
        MonsterController mc = monster.GetComponent<MonsterController>();
        mc.MaxHp = 100;
        mc.attackDamage = 10; 
        
        monster.transform.position = spawnPoint[Random.Range(1,spawnPoint.Length)].position + RandomPosition;
    }

    public void NewRound()
    {
        if (1 <= GameManager.Instance.CurrentWave && GameManager.Instance.CurrentWave < 3)
        {
            maxMonsterCount = 16;
        }
        else if(3 <= GameManager.Instance.CurrentWave && GameManager.Instance.CurrentWave < 5)
        {
            maxMonsterCount = 28;
        }
        else if (5 <= GameManager.Instance.CurrentWave && GameManager.Instance.CurrentWave < 7)
        {
            maxMonsterCount = 40;
        }
        else if (7 <= GameManager.Instance.CurrentWave && GameManager.Instance.CurrentWave < 9)
        {
            maxMonsterCount = 52;
        }
        else if (9 <= GameManager.Instance.CurrentWave && GameManager.Instance.CurrentWave < 10)
        {
            maxMonsterCount = 64;
        }
        monsterCount = 0;
        
        //체력, 공격력 받기
        StartCoroutine(StartWave(30f));
    }

    

    public IEnumerator StartWave(float time)
    {
        isWaveStart = true;
        yield return new WaitForSeconds(time);
        isWaveStart = false;
    }
}
