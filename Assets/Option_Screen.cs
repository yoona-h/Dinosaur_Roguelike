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

        // �����̴� ���� ���� �� ����� �Լ� ���
        bgmSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        mouseSensitivitySlider.onValueChanged.AddListener(OnMouseSensitivityChanged);
    }

    public void apply_data()
    {
        // �ʱⰪ�� �����̴��� �ݿ�
        bgmSlider.value = GameManager.Instance.GameData.BackGroundMusic_Volume;
        sfxSlider.value = GameManager.Instance.GameData.EffectSound_Volume;
        mouseSensitivitySlider.value = GameManager.Instance.GameData.mouseSensitivity;
    }
    public void OnBGMVolumeChanged(float value)
    {
        GameManager.Instance.GameData.BackGroundMusic_Volume = value;
        GameManager.Instance.SoundManager.apply_volume();
        // �ʿ��ϴٸ� BGM ������ ���� ����
        // AudioManager.Instance.SetBGMVolume(value);
    }

    public void OnSFXVolumeChanged(float value)
    {
        GameManager.Instance.GameData.EffectSound_Volume = value;
        GameManager.Instance.SoundManager.apply_volume();
        // AudioManager.Instance.SetSFXVolume(value);
    }

    public void OnMouseSensitivityChanged(float value)
    {
        GameManager.Instance.GameData.mouseSensitivity = value;
    }
}
