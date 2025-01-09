using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider bgmSlider; // 옵션창 BGM 슬라이더
    public Slider effectSlider; // 옵션창 효과음 슬라이더
    public TMP_Text bgmVolumeText; // BGM 음량 텍스트
    public TMP_Text effectVolumeText; // Effect 음량 텍스트
    
    void Start()
    {
        // PlayerPrefs로 컴퓨터에 저장하여 항상 동일 옵션 유지
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.5f); // 기본 음량값 50%
        effectSlider.value = PlayerPrefs.GetFloat("EffectVolume", 0.5f);

        // 시작 시 볼륨 스타트
        SetBGMVolume(bgmSlider.value);
        SetEffectVolume(effectSlider.value);

        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        effectSlider.onValueChanged.AddListener(SetEffectVolume);
    }

    // BGM 볼륨 설정
    public void SetBGMVolume(float volume)
    {
        // BGM 슬라이더 값 표기용
        int volumePercent = Mathf.RoundToInt(volume * 100);
        bgmVolumeText.text = volumePercent.ToString();

        //볼륨값 0.0001일때 0으로 만들기(0값은 사운드 커지는 오류 발생)
        if (bgmSlider.value <= 0.0001f)
        {
            audioMixer.SetFloat("BGMVolume", -80f);
        }
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(volume) * 20); // 데시벨에 의한 계산
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    // Effect 볼륨 설정
    public void SetEffectVolume(float volume)
    {
        // Effect 슬라이더 값 표기용
        int volumePercent = Mathf.RoundToInt(volume * 100);
        effectVolumeText.text = volumePercent.ToString();

        //볼륨값 0.0001일때 0으로 만들기(0값은 사운드 커지는 오류 발생)
        if (effectSlider.value <= 0.0001f)
        {
            audioMixer.SetFloat("EffectVolume", -80f);
        }
        audioMixer.SetFloat("EffectVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("EffectVolume", volume);
    }

}
