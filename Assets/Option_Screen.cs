using UnityEngine;
using UnityEngine.UI;

public class Option_Screen : MonoBehaviour
{
    [Header("UI Sliders")]
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Slider mouseSensitivitySlider;

    private void Start()
    {
        apply_data();

        // 슬라이더 값이 변할 때 실행될 함수 등록
        bgmSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        mouseSensitivitySlider.onValueChanged.AddListener(OnMouseSensitivityChanged);
    }

    public void apply_data()
    {
        // 초기값을 슬라이더에 반영
        bgmSlider.value = GameManager.Instance.GameData.BackGroundMusic_Volume;
        sfxSlider.value = GameManager.Instance.GameData.EffectSound_Volume;
        mouseSensitivitySlider.value = GameManager.Instance.GameData.mouseSensitivity;
    }
    public void OnBGMVolumeChanged(float value)
    {
        GameManager.Instance.GameData.BackGroundMusic_Volume = value;
        // 필요하다면 BGM 볼륨도 직접 조정
        // AudioManager.Instance.SetBGMVolume(value);
    }

    public void OnSFXVolumeChanged(float value)
    {
        GameManager.Instance.GameData.EffectSound_Volume = value;
        // AudioManager.Instance.SetSFXVolume(value);
    }

    public void OnMouseSensitivityChanged(float value)
    {
        GameManager.Instance.GameData.mouseSensitivity = value;
    }
}
