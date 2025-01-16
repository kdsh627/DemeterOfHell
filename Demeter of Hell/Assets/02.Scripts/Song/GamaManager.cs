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
    public int bossMonsterCount; // 보스몬스터 잡혔는지 여부 변수
    public int roundCount; // 라운드 수(스테이지)
    public int characterLevel; // 캐릭터 레벨(최대 60)
    public int state; // 캐릭터 스텟(임시)
    public int enforceCount;

    public TMP_Text waveCountText; // 현재 웨이브 표시
    public TMP_Text gameResultText; // 게임 결과 텍스트



    public GameObject bossMonster; // 보스몬스터 프리팹
    public GameObject bossSpawnPoint; //  보스몬스터용 스폰 지점(몬스터 스폰 지점 나중에 생기면 바꿀 예정 - 테스트용)
    public GameObject resultPopUpCanvas; // 클리어 또는 플레이어 사망시 띄울 팝업 캔버스
    public GameObject enforcePopUpCanvas; // 5레벨업 당 강화창 띄우기

    void Start()
    {
        waveCount = 1; // 맵 입장시 시작 웨이브는 1
        roundCount = 1;
        characterLevel = 1;
        state = 1; // 임시
        enforceCount = 0;
        bossMonsterCount = 1; // 보스몹 카운트, 보스몹 클리어시 다음 라운드로 가기 위한 변수
        waveCountText.text = "Wave " + waveCount.ToString() + " / " + maxWaveCount.ToString() ; // 시작 웨이브를 표기

    }

    void Update()
    {
        int tempEnforceCount = enforceCount;
        if(characterLevel % 5 == 0) // 5레벨업 시 강화창 팝업 띄우기 및 게임 정지
        {
            enforcePopUpCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        if(tempEnforceCount != enforceCount)
        {
            CloseEnforcePopUp();
        }
    }


    // 보스 스폰
    public void BossSpawn()
    {
        //Instantiate(bossMonster, bossSpawnPoint.transform.position, bossSpawnPoint.transform.rotation);
        bossMonsterCount = 0; // 다음 라운드 넘기는 테스트용
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

        // 보스몬스터가 죽는다면 클리어 팝업(추후 죽었을 때도 띄울 것)
        if (bossMonsterCount == 0)
        {
            roundCount += 1;
            BoseClear();
        }
    }

    // 보스 클리어시 다음 라운드 진행
    public void BoseClear()
    {
        resultPopUpCanvas.SetActive(true); // 결과 팝업 띄움
        gameResultText.text = "Round Clrear!"; 
        Time.timeScale = 0; // 게임 멈춤
    }

    // 플레이어 죽었을 때 팝업 띄우기 BoseClear과 합칠 것
    public void PlayerDie()
    {
        resultPopUpCanvas.SetActive(true); // 결과 팝업 띄움
        gameResultText.text = "You Die!";
        Time.timeScale = 0; // 게임멈춤
    }
    
    public void CloseEnforcePopUp() // 강화완료 시 팝업 닫기
    {
        enforcePopUpCanvas.SetActive(false);
        Time.timeScale = 1f;
    }


}
