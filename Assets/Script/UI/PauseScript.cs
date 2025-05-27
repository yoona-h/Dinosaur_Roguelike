using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    bool isPause = false;
    public GameObject PausePanel;

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
        PausePanel.SetActive(isPause);
        if (isPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }
    public void TitleButton()
    {
        isPause = !isPause;
        SceneManager.LoadScene("TitleScene");
    }

}
