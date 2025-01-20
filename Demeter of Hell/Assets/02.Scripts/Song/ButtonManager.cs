using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameManager;

    public GameObject optionCanvas; // 옵션 캔버스
    //public GameObject gameManager;

    

    // 게임 스타트 버튼 클릭 - 게임 화면 이동
    public void PressedGameStart()
    {
        SceneManager.LoadScene("Round1");
    }

    // 옵션 버튼 클릭 - 옵션 화면 띄우기(팝업 캔버스 예정)
    public void PressedOption()
    {
       optionCanvas.SetActive(true);
    }

    // 나가기 버튼 클릭 - 프로그램 종료
    public void PressedExit()
    {
        // 유니티 에디터에서 실험할 때 - 빌드 되고 난 후에는 삭제
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 프로그램 빌드되면 실행
        Application.Quit();
#endif
    }

    public void CloseOption() // 옵션 팝업 끄기
    {
        optionCanvas.SetActive(false);
    }

    public void BackTitle() // 타이틀로 돌아오기(임시, 바뀔 수 있음, 나중에 Song 빼기)
    {
        SceneManager.LoadScene("Title_Song");
    }

    public void WaveStart() // 웨이브 스타트 버튼 클릭 시 GameManager에서 웨이브 스타트 함수 호출
    {
        gameManager.GetComponent<GamaManager>().WaveStart();
    }

    
    public void NextRound() // 클리어 시 팝업에서 다음 라운드로 이동
    {
        string roundCount = gameManager.GetComponent<GamaManager>().roundCount.ToString(); // 게임매니저에서 현재 라운드 변수 string으로 변환
        SceneManager.LoadScene("Round" + roundCount +"_Song");  // 씬 이름 + 변수로 다른 라운드로 이동, 나중에 Song 빼기
    }

    public void LevelUp()
    {
        gameManager.GetComponent<GamaManager>().characterLevel++;
    }

    public void FixedPointUp() // 능력치 고정값 증가 버튼
    {
        gameManager.GetComponent<GamaManager>().state += 5;
        gameManager.GetComponent<GamaManager>().CloseEnforcePopUp();
        gameManager.GetComponent<GamaManager>().enforceCount++;
    }

    public void RandomPointUp() // 능력치 랜덤값 증가 버튼
    {
        gameManager.GetComponent<GamaManager>().state += Random.Range(1, 10);
        gameManager.GetComponent<GamaManager>().CloseEnforcePopUp();
        gameManager.GetComponent<GamaManager>().enforceCount++;
    }
}
