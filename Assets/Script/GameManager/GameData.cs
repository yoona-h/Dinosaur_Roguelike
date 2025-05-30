using UnityEngine;

public class GameData : MonoBehaviour
{
    //게임 진행에 필요한 변수들
    [HideInInspector] public bool GameStop = false;
    [HideInInspector] public Weapon StartWeapon;//플레이어가 들고 시작할 무기를 지정해주고 이를 실제로 적용시키기 위한 변수

    //저장할 데이터들
    [HideInInspector] public int MaxScore = 0;

    //설정들
    [HideInInspector] public float BackGroundMusic_Volume = 0.5f;
    [HideInInspector] public float EffectSound_Volume = 0.5f;
    [HideInInspector] public float mouseSensitivity = 5f;


    private void Awake()
    {
        LoadData();
    }

    public void LoadData()
    {
        //임시
        BackGroundMusic_Volume = 0.5f;
        EffectSound_Volume = 0.5f;
    }

    public void SaveData()
    {

    }
}
