using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public GameObject Setting_screen;
    public Option_Screen Option_Screen;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OpenAndClose_SettingScreen()
    {
        //화면이 꺼져있으면 키고, 켜져있으면 끄기
        Setting_screen.SetActive(!Setting_screen.activeSelf);
        Option_Screen.apply_data();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
