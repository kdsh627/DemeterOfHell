using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ResolutionManager : MonoBehaviour
{
    FullScreenMode fullScreenMode; // 전체화면 모드 지원 변수
    public TMP_Dropdown resolutionDropdown; // 드롭다운 오브젝트
    public Toggle fullScreenToggle;  // 전체화면 모드 체크박스
    List<Resolution> resolutions = new List<Resolution>(); // 지원 해상도 리스트
    public int resolutionNum;  // 선택한 해상도 리스트 인덱스 값

    void Start()
    {
        InitUI();
    }

    void InitUI()
    {   // 해상도가 1280보다 큰 16:9 화변비의 지원 해상도 출력
        for(int i = 0; i< Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].width >= 1280 && Screen.resolutions[i].width % 16 == 0 &&  Screen.resolutions[i].height % 9 == 0)
            {
                resolutions.Add(Screen.resolutions[i]);
            }
        }

        resolutionDropdown.options.Clear();  // 드롭다운의 요소 값 초기화
        resolutionNum = 0;

        foreach(Resolution item in resolutions)  // 지원해주는 해상도를 ooo x ooo으로 표기
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = item.width + " x " + item.height;
            resolutionDropdown.options.Add(option);
        
            // 현재 해상도의 값을 옵션창에서 보여줌
            if(item.width == Screen.width && item.height == Screen.height)
            {
                resolutionDropdown.value = resolutionNum;
                resolutionNum++;
            }
            resolutionDropdown.RefreshShownValue(); // 드롭다운에서 나타나는 값 새로고침

            fullScreenToggle.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false; // 현재 토글이 눌려 있으면 전체화면, 아니면 창모드
        }

        
    }

    public void ResolutionChange(int x) // 해상도 리스트의 인덱스 값을 setResolution의 값으로 넘겨주기 위한 변수 변경 함수
    {
        resolutionNum = x;
    }

    public void FullScreenToogle(bool isFull) // 토글이눌리면 창모드, 아니면 윈도우 모드
    {
        fullScreenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    public void SetResolution() // 선택된 해상도 리스트 인덱스 값의 길이와 높이를 불러와 현재 해상도를 변경하는 함수
    {
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, fullScreenMode);
    }
}