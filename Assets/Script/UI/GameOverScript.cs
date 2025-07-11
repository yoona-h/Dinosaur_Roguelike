using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour
{
    public Image sunBar;
    public Text Score;
    public bool isgameover;
    public bool isgameclear;
    public PlayerMove PlayerMoveScript;
    public PlayerAttack PlayerAttackScript;
    public ThirdPersonCamera ThirdPersonCameraScript;
    public GameObject GameClearPanel;
    public GameObject GameOverPanel;

    public Animator PlayerAnimator;

    void Start()
    {
        isgameover = false;
        isgameclear = false;
    }

    void Update()
    {
        if (sunBar.fillAmount <= 0f && isgameover == false)
        {
            sunBar.fillAmount = 0f;
            isgameover = true;
            gameover();
        }
        else if (sunBar.fillAmount >= 1f && isgameclear == false)
        {
            sunBar.fillAmount = 1f;
            isgameclear = true;
            gameclear();
        }
    }

    public void gameover()
    {
        PlayerMoveScript.audioSource.Stop();
        PlayerMoveScript.enabled = false;
        PlayerAttackScript.enabled = false;
        ThirdPersonCameraScript.enabled = false;
        PlayerAnimator.SetTrigger("Die");
        GameManager.Instance.SoundManager.StopBGM();
        StartCoroutine(ShowGameOverPanelDelayed());
    }

    private IEnumerator ShowGameOverPanelDelayed()
    {
        yield return new WaitForSeconds(2f);

        Cursor.visible = true;                    // 커서 보이기
        Cursor.lockState = CursorLockMode.None;   // 커서 자유롭게 이동

        GameOverPanel.SetActive(true);
        //Score.text = string.Format("점수 : {0}", GameManager.Instance.PlayerManager.playerEXP * 10);

        GameManager.Instance.GameData.GameStop = !GameManager.Instance.GameData.GameStop;
        Time.timeScale = 0f;
    }

    public void gameclear()
    {
        GameClearPanel.SetActive(true);

        Cursor.visible = true;                    // 커서 보이기
        Cursor.lockState = CursorLockMode.None;   // 커서 자유롭게 이동

        GameManager.Instance.GameData.GameStop = !GameManager.Instance.GameData.GameStop;
        Time.timeScale = 0f;
    }
}
