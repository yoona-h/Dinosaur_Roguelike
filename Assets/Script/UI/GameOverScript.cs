using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour
{
    public Image sunBar;
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
        yield return new WaitForSeconds(0.5f);
        GameOverPanel.SetActive(true);
    }

    public void gameclear()
    {
        GameClearPanel.SetActive(true);
    }
}
