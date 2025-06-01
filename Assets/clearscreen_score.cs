using UnityEngine;
using UnityEngine.UI;

public class clearscreen_score : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public Text score_text;
    public Text maxscore_text;
    public GameObject new_text;

    void OnEnable()
    {
        if (GameManager.Instance.GameData.MaxScore < PlayerManager.playerEXP)
        {
            GameManager.Instance.GameData.MaxScore = PlayerManager.playerEXP;
            new_text.SetActive(true);
        }
        
        score_text.text = "점수 : " + PlayerManager.playerEXP.ToString();
        maxscore_text.text = "최고점수 : " + GameManager.Instance.GameData.MaxScore.ToString();
    }
}
