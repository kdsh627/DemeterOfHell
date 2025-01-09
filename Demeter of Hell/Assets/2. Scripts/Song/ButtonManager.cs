using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject optionCanvas; // 옵션 캔버스
    public GameObject gameManager;

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

    public void BackTitle() // 타이틀로 돌아오기(임시, 바뀔 수 있음)
    {
        SceneManager.LoadScene("Title");
    }

    public void WaveStart() // 웨이브 스타트 버튼 클릭 시 GameManager에서 웨이브 스타트 함수 호출
    {
        gameManager.GetComponent<GamaManager>().WaveStart();
    }
}
