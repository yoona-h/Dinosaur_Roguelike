using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    public void StartInfinityGame()
    {
        //비활성화, 게임 클리어시 활성화 구현 필요
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
