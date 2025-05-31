using UnityEngine;
using UnityEngine.UI;
public class GameUIScript : MonoBehaviour
{
    //public GameObject iceBar;
    public Image sunBar;
    public Image BarIcon;
    public float maxsunBar;
    public float currentsunBar;
    [HideInInspector] public float sunBarspeed = 1f;
    private int getice = 0;
    public RectTransform sunBarRect;
    public RectTransform barIconRect;

    void Start()
    {
        currentsunBar = maxsunBar / 2;
        sunBarspeed = 1f;
    }


    void Update()
    {
        currentsunBar -= Time.deltaTime * sunBarspeed * 10f;
        /*
                if (currentsunBar <= 0f)
                {
                    currentsunBar = 0f;
                    Debug.Log("게임 오버"); //게임오버 추가
                }
                else if (currentsunBar >= maxsunBar)
                {
                    currentsunBar = maxsunBar;
                    Debug.Log("게임 클리어"); //클리어 추가
                }
        */
        UpdatesunBar();
        IncreaseSunBar(); // 얼음조각 습득 감지시 함수 호출

    }
    public void IncreaseSunBar()
    {
        // 조각 얻을 시 게이지 업
        if (getice != GameManager.Instance.PlayerManager.playerEXP)
        {
            currentsunBar += (GameManager.Instance.PlayerManager.playerEXP - getice) * 20;
            getice = GameManager.Instance.PlayerManager.playerEXP;
            //print("게이지 up : " + currentsunBar);
            UpdatesunBar();
        }

    }
    void UpdatesunBar()
    {
        float fillAmount = currentsunBar / maxsunBar;
        sunBar.fillAmount = Mathf.Clamp01(fillAmount);

        // sunBar 길이에 맞게 icon x축 위치 조절
        float barWidth = sunBarRect.rect.width;
        float iconX = barWidth * fillAmount;

        Vector2 newPos = barIconRect.anchoredPosition;
        newPos.x = iconX - (maxsunBar / 2);
        barIconRect.anchoredPosition = newPos;

    }
}
