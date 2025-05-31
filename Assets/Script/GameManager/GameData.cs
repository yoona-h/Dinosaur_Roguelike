using UnityEngine;

public class GameData : MonoBehaviour
{
    [HideInInspector] public bool GameStop = false;
    [HideInInspector] public Weapon StartWeapon;

    [HideInInspector] public int MaxScore = 0;

    [HideInInspector] public float BackGroundMusic_Volume = 0.5f;
    [HideInInspector] public float EffectSound_Volume = 0.5f;
    [HideInInspector] public float mouseSensitivity = 5f;

    private void Awake()
    {
        LoadData();
    }

    public void LoadData()
    {
        MaxScore = PlayerPrefs.GetInt("MaxScore", 0);

        BackGroundMusic_Volume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        EffectSound_Volume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        mouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 5f);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("MaxScore", MaxScore);
        PlayerPrefs.SetFloat("BGMVolume", BackGroundMusic_Volume);
        PlayerPrefs.SetFloat("SFXVolume", EffectSound_Volume);
        PlayerPrefs.SetFloat("MouseSensitivity", mouseSensitivity);
        PlayerPrefs.Save();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveData(); // 브라우저 포커스가 나갔을 때 저장
        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            SaveData(); // 포커스 잃을 때 저장 (WebGL 대응)
        }
    }

    // OnApplicationQuit는 WebGL에선 작동하지 않지만, 다른 플랫폼 호환을 위해 유지
    private void OnApplicationQuit()
    {
        SaveData();
    }
}
