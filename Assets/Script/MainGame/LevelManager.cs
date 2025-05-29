using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public IceGameManager IceGameManager;
    public AudioClip LevelUp_sound;
    public int playerLevel
    {
        get => PlayerManager.Instance.playerLevel;
        set => PlayerManager.Instance.playerLevel = value;
    }
    public int playerEXP
    {
        get => PlayerManager.Instance.playerEXP;
        set => PlayerManager.Instance.playerEXP = value;
    }
    public int nextLevel_EXP
    {
        get => PlayerManager.Instance.nextLevel_EXP;
        set => PlayerManager.Instance.nextLevel_EXP = value;
    }

    public int playerATK
    {
        get => PlayerManager.Instance.playerATK;
        set => PlayerManager.Instance.playerATK = value;
    }
    public int playerATK_increase
    {
        get => PlayerManager.Instance.playerATK_increase;
        set => PlayerManager.Instance.playerATK_increase = value;
    }

    public float interval
    {
        get => IceGameManager.interval;
        set => IceGameManager.interval = value;
    }


    private void Update()
    {
        if (playerEXP >= nextLevel_EXP)
        {
            LevelUp();
        }
    }


    void LevelUp()
    {
        playerLevel++;
        playerATK += playerATK_increase;

        GameManager.Instance.SoundManager.PlaySFX(LevelUp_sound);

        //임시 수식... 밸런스르르 고려하여 증가율 수식 설정하기! ------------------------------------------------------------------------
        playerATK_increase = playerATK_increase;
        nextLevel_EXP = nextLevel_EXP * 2;
        if (interval > 1)
            interval -= 0.1f;
        else
            interval = 0.8f;

        PlayerManager.Instance.apply_ATK();
    }
}
