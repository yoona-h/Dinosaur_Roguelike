using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public bool test_Infinity = false; //테스트용, 클리어 판별용 변수로 대체
    public GameObject InfinityButton;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (test_Infinity == true)
        {
            InfinityButton.SetActive(true);
        }
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
