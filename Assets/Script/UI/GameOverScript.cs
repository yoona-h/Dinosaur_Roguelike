using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Image sunBar;

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

    }

    public void gameclear()
    {

    }
}
