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
        
            if(item.width == Screen.width && item.height == Screen.height)
            {
                resolutionDropdown.value = resolutionNum;
                resolutionNum++;
            }
            resolutionDropdown.RefreshShownValue(); // 드롭다운에서 나타나는 값 새로고침

            fullScreenToggle.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
        }

        
    }

    public void ResolutionChange(int x)
    {
        resolutionNum = x;
    }

    public void FullScreenToogle(bool isFull)
    {
        fullScreenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    public void SetResolution()
    {
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, fullScreenMode);
    }
}