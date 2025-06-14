using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public GameObject PausePanel; //퍼즈화면
    public GameObject LevelUpPanel; //레벨업화면
    public GameObject GameOverPanel;
    public GameObject GameClearPanel;
    public Image DinosaurUIImage;
    public Sprite Dinosaur_chainsaw;
    public Sprite Dinosaur_fish;
    public Sprite Dinosaur_flint;
    public Sprite Dinosaur_pickaxe;
    public Sprite Dinosaur_pistol;

    private bool isPause = false; //퍼즈여부



    void Start()
    {
        isPause = false;
    }

    void Update()
    {
        if (!GameOverPanel.activeSelf && !GameClearPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                //pauseButton();
                TogglePause();
            }
        }
        /*else
        {
            isPause = true;
        }*/
    }
    public void Gameclear_ContinueButton()
    {
        GameClearPanel.SetActive(false);

        Cursor.visible = false;                   // 커서 숨기기
        Cursor.lockState = CursorLockMode.Locked; // 커서 화면 중앙 고정

        //GameManager.Instance.GameData.GameStop = !GameManager.Instance.GameData.GameStop;
        GameManager.Instance.GameData.GameStop = false;
        Time.timeScale = 1f;
    }
    public void pauseButton()
    {
        isPause = !isPause;
        Cursor.visible = true;                    // 커서 보이기
        Cursor.lockState = CursorLockMode.None;   // 커서 자유롭게 이동

        PausePanel.SetActive(isPause); //퍼즈화면 활성화


        if (LevelUpPanel.activeSelf == false) // 레벨업 중 퍼즈시 시간흐름제어X
        {
            GameManager.Instance.GameData.GameStop = !GameManager.Instance.GameData.GameStop;

            if (GameManager.Instance.GameData.GameStop)
            {
                Time.timeScale = 0f;
                GameManager.Instance.SoundManager.PauseBGM();

            }
            else
            {
                Time.timeScale = 1f;
                Cursor.visible = false;                   // 커서 숨기기
                Cursor.lockState = CursorLockMode.Locked; // 커서 화면 중앙 고정
                GameManager.Instance.SoundManager.UnPauseBGM();
            }
        }


    }
    public void TitleButton()
    {
        GameManager.Instance.GameData.GameStop = !GameManager.Instance.GameData.GameStop;
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
        GameManager.Instance.SoundManager.PlayBGM(GameManager.Instance.SoundManager.TitleBgmSound);
    }

    public void RestartButton()
    {
        GameManager.Instance.GameData.GameStop = !GameManager.Instance.GameData.GameStop;
        Time.timeScale = 1f;
        Cursor.visible = false;                   // 커서 숨기기
        Cursor.lockState = CursorLockMode.Locked; // 커서 화면 중앙 고정
        SceneManager.LoadScene("MainGame");
        GameManager.Instance.SoundManager.PlayBGM(GameManager.Instance.SoundManager.bgmSound);
    }

    public void TogglePause()
    {
        // 상태 토글
        bool willPause = !GameManager.Instance.GameData.GameStop;
        GameManager.Instance.GameData.GameStop = willPause;

        // Pause UI 토글
        PausePanel.SetActive(willPause);

        // 공룡 이미지 변경
        switch (PlayerManager.Instance.PlayerAttack.PlayerWeapon.Weapon_name)
        {
            case "전기톱":
                DinosaurUIImage.sprite = Dinosaur_chainsaw;
                break;
            case "물고기":
                DinosaurUIImage.sprite = Dinosaur_fish;
                break;
            case "부싯돌":
                DinosaurUIImage.sprite = Dinosaur_flint;
                break;
            case "곡괭이":
                DinosaurUIImage.sprite = Dinosaur_pickaxe;
                break;
            case "권총":
                DinosaurUIImage.sprite = Dinosaur_pistol;
                break;
        }

        // LevelUpPanel이 활성화 중이면 시간정지 상태 변경 금지
        if (!LevelUpPanel.activeSelf)
        {
            if (willPause)
            {
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                GameManager.Instance.SoundManager.PauseBGM();
            }
            else
            {
                Time.timeScale = 1f;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                GameManager.Instance.SoundManager.UnPauseBGM();
            }
        }
    }

}
