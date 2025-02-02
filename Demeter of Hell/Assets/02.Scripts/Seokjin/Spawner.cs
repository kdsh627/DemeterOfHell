using System.Collections;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timer=0;
    public int maxMonsterCount;
    public int monsterCount=0;
    public Transform[] spawnPoint;
    public GameObject[] monsters;
    public float spawnRadius = 15f;

    public bool isWaveStart = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
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

        if (timer > 0.2f && monsterCount <= maxMonsterCount)
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
        monster.transform.position = spawnPoint[Random.Range(1,spawnPoint.Length)].position + RandomPosition;
        
    }

    public void NewRound(int _maxMonsterCount)
    {
        monsterCount = 0;
        maxMonsterCount = _maxMonsterCount;
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
