using TMPro;
using UnityEngine;

public class GamaManager : MonoBehaviour
{
    // 구현되어야 할 기능
    // 1. 웨이브
    // 2. 웨이브 단계마다 쉬는시간
    // 3. 웨이브 시작 시 내가 눌러서 실행 버튼
    // 4. 웨이브 10단계가 끝나면 보스방 오픈 이벤트
    // 5. 보스를 물리치면 다음 스테이지로(능력치는 가지고 다음 스테이지)
    // 6. 내가 죽으면 능력치는 리셋
    // 7. 만들어진 스테이지까지 끝나면 엔딩

    public int waveCount; // 웨이브 수
    public int maxWaveCount = 10; // 최대 웨이브 수
    public int monsterCount; // 웨이브당 몬스터 처치해야하는 수(웨이브 밸런스 잡으면 변수값이 아니라 함수나 key, value값으로 받아올 예정
    public GameObject bossMonster; // 보스몬스터 프리팹
    public TMP_Text waveCountText; // 현재 웨이브 표시
    public GameObject bossSpawnPoint; //  보스몬스터용 스폰 지점(몬스터 스폰 지점 나중에 생기면 바꿀 예정 - 테스트용)

    void Start()
    {
        waveCount = 1; // 맵 입장시 시작 웨이브는 1
        waveCountText.text = "Wave " + waveCount.ToString() + " / " + maxWaveCount.ToString() ; // 시작 웨이브를 표기

    }

    // 보스 스폰
    public void BossSpawn()
    {
        Instantiate(bossMonster, bossSpawnPoint.transform.position, bossSpawnPoint.transform.rotation);
    }

    public void WaveStart()
    {
        // 테스트용
        waveCountText.text = "Wave " + waveCount.ToString() + " / " + maxWaveCount.ToString(); // 시작 웨이브를 표기

        // 웨이브당 몬스터 카운트가 0이 된다면 웨이브 수 증가
        if (monsterCount == 0)
        {
            Debug.Log("일반 웨이브");
            waveCount++;
        }

        // 마지막 웨이브까지 클리어하게 된다면 보스 스폰 이벤트
        if(waveCount > maxWaveCount)
        {
            Debug.Log("보스");
            BossSpawn();
        }
    }


}
