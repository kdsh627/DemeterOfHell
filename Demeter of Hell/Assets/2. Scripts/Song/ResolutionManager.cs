using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ResolutionManager : MonoBehaviour
{
    FullScreenMode fullScreenMode;
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullScreenToggle;
    List<Resolution> resolutions = new List<Resolution>();
    public int resolutionNum;

    void Start()
    {
        InitUI();
    }

    void InitUI()
    {
        for(int i = 0; i< Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].width % 16 == 0 &&  Screen.resolutions[i].height % 16 == 0)
            {
                resolutions.Add(Screen.resolutions[i]);
            }
        }

        resolutionDropdown.options.Clear();
        int optionNum = 0;
        foreach(Resolution item in resolutions)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = item.width + " x " + item.height;
            resolutionDropdown.options.Add(option);
        
            if(item.width == Screen.width && item.height == Screen.height)
            {
                resolutionDropdown.value = optionNum;
                optionNum++;
            }
            resolutionDropdown.RefreshShownValue();

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