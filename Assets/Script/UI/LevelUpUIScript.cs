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
    private int playerlastLevel = 0; //플레이어레벨카운팅
    private int weaponlastLevel = 0; //무기레벨카운팅
    int randomIndex; // 랜덤으로 뽑은 무기 인덱스
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

        //카운팅 레벨 초기화 및 텍스트 초기화
        playerlastLevel = PlayerManager.Instance.playerLevel;
        LevelText.text = playerlastLevel + "Lv";
        pauseLevelText.text = string.Format("공룡 : {0} Lv", playerlastLevel);
        WeaponText.text = string.Format("{0} : {1} Lv", GameManager.Instance.PlayerManager.PlayerAttack.PlayerWeapon.Weapon_name, weaponlastLevel);
    }

    void Update()
    {
        if (PlayerManager.Instance.playerLevel != playerlastLevel && !GameManager.Instance.GameData.GameStop)
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

        playerlastLevel++;
        //레벨 텍스트 재표기
        LevelText.text = playerlastLevel + "Lv";
        pauseLevelText.text = string.Format("공룡 : {0} Lv", playerlastLevel);

        LevelUpPanel.SetActive(true); //레벨업화면 활성화
        randomIndex = Random.Range(0, weaponList.Count); // 무작위 무기 선별
        randomWeapon = weaponList[randomIndex];
        weaponImageList[randomIndex].SetActive(true); // 선별 무기 이미지 활성화
    }

    public void UpgradeButton()
    {
        //무기 레벨업 신호 보내는 코드 필요?할?듯?
        weaponlastLevel++;

        // 무기 텍스트 업데이트
        WeaponText.text = string.Format("{0} : {1} Lv", GameManager.Instance.PlayerManager.PlayerAttack.PlayerWeapon.Weapon_name, weaponlastLevel);

        // 무기 이미지, 레벨업 판넬 비활성화
        weaponImageList[randomIndex].SetActive(false);
        LevelUpPanel.SetActive(false);

        Time.timeScale = 1f;
        Cursor.visible = false;                   // 커서 숨기기
        Cursor.lockState = CursorLockMode.Locked; // 커서 화면 중앙 고정

        GameManager.Instance.GameData.GameStop = false;
    }

    public void ChangeButton()
    {
        //무기 변경
        GameManager.Instance.PlayerManager.PlayerAttack.ChangeWeapon(randomWeapon);

        // 무기 텍스트 업데이트
        WeaponText.text = string.Format("{0} : {1} Lv", GameManager.Instance.PlayerManager.PlayerAttack.PlayerWeapon.Weapon_name, weaponlastLevel);

        // 무기 이미지, 레벨업 판넬 비활성화
        weaponImageList[randomIndex].SetActive(false);
        LevelUpPanel.SetActive(false);

        Time.timeScale = 1f;
        Cursor.visible = false;                   // 커서 숨기기
        Cursor.lockState = CursorLockMode.Locked; // 커서 화면 중앙 고정

        GameManager.Instance.GameData.GameStop = false;
    }

}
