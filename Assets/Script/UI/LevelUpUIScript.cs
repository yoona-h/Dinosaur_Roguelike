using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelUpUIScript : MonoBehaviour
{
    public Text LevelText; //게임화면 좌상단 텍스트
    public Text pauseLevelText; //퍼즈화면 텍스트
    public Text WeaponText; //퍼즈화면 텍스트
    public Text ChangeweaponText; // 레벨업화면 새무기 텍스트
    public Text UpgradeweaponText; // 레벨업화면 무기 업그레이드 텍스트

    public Image levelUi; // 레벨 ui 배경색 이미지
    public GameObject LevelUpPanel; //레벨업화면
    // private int playerlastLevel = 0; //플레이어레벨카운팅 
    int randomIndex; // 랜덤으로 뽑은 무기 인덱스
    float fillAmount = 0f;
    Weapon randomWeapon; // 랜덤으로 뽑은 무기

    [Header("무기")]
    public Weapon Chainsaw;
    public Weapon fish;
    public Weapon Flint;
    public Weapon pickaxe;
    public Weapon Pistol;
    [Header("무기이미지")]
    public GameObject Chainsaw_Image;
    public GameObject fish_Image;
    public GameObject Flint_Image;
    public GameObject pickaxe_Image;
    public GameObject Pistol_Image;

    [Space]
    public LevelManager LevelManager;

    private List<Weapon> weaponList = new List<Weapon>();
    private List<GameObject> weaponImageList = new List<GameObject>();
    void Start()
    {
        weaponList.Add(Chainsaw);
        weaponList.Add(fish);
        weaponList.Add(Flint);
        weaponList.Add(pickaxe);
        weaponList.Add(Pistol);

        weaponImageList.Add(Chainsaw_Image);
        weaponImageList.Add(fish_Image);
        weaponImageList.Add(Flint_Image);
        weaponImageList.Add(pickaxe_Image);
        weaponImageList.Add(Pistol_Image);

        StartCoroutine(DelayedInit());
    }

    private IEnumerator DelayedInit()
    {
        yield return null; // 한 프레임 대기
        // LV EXP UI 초기화
        fillAmount = Mathf.Clamp01((float)GameManager.Instance.PlayerManager.playerEXP / GameManager.Instance.PlayerManager.nextLevel_EXP);
        levelUi.fillAmount = fillAmount;
        // 텍스트 초기화
        // playerlastLevel = PlayerManager.Instance.playerLevel;
        Debug.Log(GameManager.Instance.PlayerManager.playerLevel);
        LevelText.text = GameManager.Instance.PlayerManager.playerLevel + "Lv";
        pauseLevelText.text = string.Format("공룡 : {0} Lv", GameManager.Instance.PlayerManager.playerLevel);
        WeaponText.text = string.Format("{0} : {1} Lv", GameManager.Instance.PlayerManager.PlayerAttack.PlayerWeapon.Weapon_name, GameManager.Instance.PlayerManager.PlayerAttack.PlayerWeapon.weaponLevel);

    }

    void Update()
    {
        // LV EXP UI 업데이트
        fillAmount = Mathf.Clamp01((float)GameManager.Instance.PlayerManager.playerEXP / GameManager.Instance.PlayerManager.nextLevel_EXP);
        levelUi.fillAmount = fillAmount;

        /*
        // 레벨업 판별
        if (PlayerManager.Instance.playerLevel != playerlastLevel && !GameManager.Instance.GameData.GameStop)
        {
            LevelUp();
        }
        */
    }

    public void LevelUp()
    {
        Cursor.visible = true;                    // 커서 보이기
        Cursor.lockState = CursorLockMode.None;   // 커서 자유롭게 이동
        GameManager.Instance.GameData.GameStop = true; // 게임화면 퍼즈
        Time.timeScale = 0f;

        LevelUpPanel.SetActive(true); //레벨업화면 활성화

        randomIndex = Random.Range(0, weaponList.Count);
        randomWeapon = weaponList[randomIndex];
        do
        {
            randomIndex = Random.Range(0, weaponList.Count);
            randomWeapon = weaponList[randomIndex];
        }
        while (randomWeapon == PlayerManager.Instance.PlayerAttack.PlayerWeapon);

        weaponImageList[randomIndex].SetActive(true); // 선별 무기 이미지 활성화

        // playerlastLevel++;
        //레벨 텍스트 재표기
        LevelText.text = GameManager.Instance.PlayerManager.playerLevel + "Lv";
        pauseLevelText.text = string.Format("공룡 : {0} Lv", GameManager.Instance.PlayerManager.playerLevel);
    }

    public void UpgradeButton()
    {
        //무기 레벨업 신호 보내는 코드 필요?할?듯?
        LevelManager.WeaponLevelUp();//무기 레벨업

        // 무기 텍스트 업데이트
        WeaponText.text = string.Format("{0} : {1} Lv", GameManager.Instance.PlayerManager.PlayerAttack.PlayerWeapon.Weapon_name, GameManager.Instance.PlayerManager.PlayerAttack.PlayerWeapon.weaponLevel);

        // 무기 이미지, 레벨업 판넬 비활성화
        weaponImageList[randomIndex].SetActive(false);
        LevelUpPanel.SetActive(false);

        Time.timeScale = 1f;
        Cursor.visible = false;                   // 커서 숨기기
        Cursor.lockState = CursorLockMode.Locked; // 커서 화면 중앙 고정

        PlayerManager.Instance.apply_ATK();

        GameManager.Instance.GameData.GameStop = false;
    }

    public void ChangeButton()
    {
        //무기 변경
        GameManager.Instance.PlayerManager.PlayerAttack.ChangeWeapon(randomWeapon);

        // 무기 텍스트 업데이트
        WeaponText.text = string.Format("{0} : {1} Lv", GameManager.Instance.PlayerManager.PlayerAttack.PlayerWeapon.Weapon_name, GameManager.Instance.PlayerManager.PlayerAttack.PlayerWeapon.weaponLevel);

        // 무기 이미지, 레벨업 판넬 비활성화
        weaponImageList[randomIndex].SetActive(false);
        LevelUpPanel.SetActive(false);

        Time.timeScale = 1f;
        Cursor.visible = false;                   // 커서 숨기기
        Cursor.lockState = CursorLockMode.Locked; // 커서 화면 중앙 고정

        PlayerManager.Instance.apply_ATK();

        GameManager.Instance.GameData.GameStop = false;
    }

}
