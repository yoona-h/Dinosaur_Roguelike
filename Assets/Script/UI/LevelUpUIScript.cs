using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelUpUIScript : MonoBehaviour
{
    public Text LevelText; //게임화면 좌상단 텍스트
    public Text pauseLevelText; //퍼즈화면 텍스트
    public Text WeaponText; //퍼즈화면 텍스트
    public GameObject LevelUpPanel; //레벨업화면
    private int lastLevel = 0; //레벨카운팅
    public float levelUpCooldown = 0.3f; // 레벨업 패널이 사라진 후 다음 레벨업까지의 쿨다운 시간

    void Start()
    {
        //카운팅 레벨 초기화 및 텍스트 초기화
        lastLevel = PlayerManager.Instance.playerLevel;
        LevelText.text = lastLevel + "Lv";
        pauseLevelText.text = string.Format("공룡 : {0} Lv", lastLevel);
        WeaponText.text = string.Format("{0} : {1} Lv", lastLevel, lastLevel); //무기로 수정
    }

    void Update()
    {
        if (PlayerManager.Instance.playerLevel != lastLevel && !GameManager.Instance.GameData.GameStop)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        Cursor.visible = true;                    // 커서 보이기
        Cursor.lockState = CursorLockMode.None;   // 커서 자유롭게 이동
        GameManager.Instance.GameData.GameStop = true; // 게임화면 퍼즈
        Time.timeScale = 0f;

        lastLevel++;
        //레벨 텍스트 재표기
        LevelText.text = lastLevel + "Lv";
        pauseLevelText.text = string.Format("공룡 : {0} Lv", lastLevel);

        LevelUpPanel.SetActive(true); //레벨업화면
    }

    public void UpgradeButton()
    {
        //무기 레벨업 코드 추가
        WeaponText.text = "무기 : 무기렙 Lv";
        StartCoroutine(LevelUpCooldown());
    }

    public void ChangeButton()
    {
        //무기 변경 코드 추가
        WeaponText.text = "무기 : 무기렙 Lv";
        StartCoroutine(LevelUpCooldown());
    }

    IEnumerator LevelUpCooldown()
    {
        LevelUpPanel.SetActive(false);
        Time.timeScale = 1f;

        Cursor.visible = false;                   // 커서 숨기기
        Cursor.lockState = CursorLockMode.Locked; // 커서 화면 중앙 고정

        yield return new WaitForSecondsRealtime(levelUpCooldown);
        GameManager.Instance.GameData.GameStop = false;
    }
}
