using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour
{
    public Image sunBar;
    public Text Score;
    public PlayerMove PlayerMoveScript;
    public PlayerAttack PlayerAttackScript;
    public ThirdPersonCamera ThirdPersonCameraScript;
    public GameObject GameClearPanel;
    public GameObject GameOverPanel;

    public Animator PlayerAnimator;

    void Start()
    {

    }

    void Update()
    {
        if (sunBar.fillAmount <= 0f)
        {
            sunBar.fillAmount = 0f;
            gameover();
        }
        else if (sunBar.fillAmount >= 1f)
        {
            sunBar.fillAmount = 1f;
            gameclear();
        }
    }

    public void gameover()
    {
        PlayerMoveScript.enabled = false;
        PlayerAttackScript.enabled = false;
        ThirdPersonCameraScript.enabled = false;
        PlayerAnimator.SetTrigger("Die");
        StartCoroutine(ShowGameOverPanelDelayed());
    }

    private IEnumerator ShowGameOverPanelDelayed()
    {
        yield return new WaitForSeconds(2f);

        Cursor.visible = true;                    // 커서 보이기
        Cursor.lockState = CursorLockMode.None;   // 커서 자유롭게 이동

        GameOverPanel.SetActive(true);
        Score.text = string.Format("점수 : {0}", GameManager.Instance.PlayerManager.playerEXP * 10);

        Time.timeScale = 0f;
    }

    public void gameclear()
    {
        GameClearPanel.SetActive(true);

        Cursor.visible = true;                    // 커서 보이기
        Cursor.lockState = CursorLockMode.None;   // 커서 자유롭게 이동

        Time.timeScale = 0f;
    }
}
