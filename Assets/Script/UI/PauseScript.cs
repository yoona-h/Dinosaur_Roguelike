using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    public GameObject PausePanel; //퍼즈화면
    private bool isPause = false; //퍼즈여부
    public GameObject LevelUpPanel; //레벨업화면

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseButton();
        }
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

            }
            else
            {
                Time.timeScale = 1f;
                Cursor.visible = false;                   // 커서 숨기기
                Cursor.lockState = CursorLockMode.Locked; // 커서 화면 중앙 고정
            }
        }


    }
    public void TitleButton()
    {
        GameManager.Instance.GameData.GameStop = !GameManager.Instance.GameData.GameStop;
        SceneManager.LoadScene("TitleScene");
    }

}
