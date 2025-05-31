using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public LevelUpUIScript LevelUpUIScript;
    public IceGameManager IceGameManager;
    public WeaponSelect_manager WeaponSelect_manager;
    public GameUIScript GameUIScript;
    public PlayerAttack PlayerAttack;
    [Space]
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


    private void Start()
    {
        IceGameManager.rand_ice[0] = 80;
        IceGameManager.rand_ice[1] = 20;
        IceGameManager.rand_ice[2] = 0;
        IceGameManager.rand_ice[3] = 0;
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
        nextLevel_EXP = (int)(nextLevel_EXP * 1.5f);

        if (interval > 1)
            interval -= 0.2f;
        else
            interval = 0.8f;
        
        switch(playerLevel)
        {
            case 0:
                GameUIScript.sunBarspeed += 0.05f;
                break;
            case 1:
                GameUIScript.sunBarspeed += 0.05f;
                break;
            case 2:
                GameUIScript.sunBarspeed += 0.05f;
                IceGameManager.rand_ice[0] = 80;
                IceGameManager.rand_ice[1] = 20;
                IceGameManager.rand_ice[2] = 0;
                IceGameManager.rand_ice[3] = 0;
                break;
            case 3:
                GameUIScript.sunBarspeed += 0.05f;
                IceGameManager.rand_ice[0] = 80;
                IceGameManager.rand_ice[1] = 20;
                IceGameManager.rand_ice[2] = 5;
                IceGameManager.rand_ice[3] = 0;
                break;
            case 4:
                GameUIScript.sunBarspeed += 0.05f;
                IceGameManager.rand_ice[0] = 70;
                IceGameManager.rand_ice[1] = 20;
                IceGameManager.rand_ice[2] = 5;
                IceGameManager.rand_ice[3] = 5;
                break;
            case 5:
                GameUIScript.sunBarspeed += 0.05f;
                break;
            case 6:
                GameUIScript.sunBarspeed += 0.05f;
                break;
            case 7:
                GameUIScript.sunBarspeed += 0.05f;
                IceGameManager.rand_ice[0] = 70;
                IceGameManager.rand_ice[1] = 30;
                IceGameManager.rand_ice[2] = 10;
                IceGameManager.rand_ice[3] = 10;
                break;
            case 8:
                GameUIScript.sunBarspeed += 0.05f;
                break;
            case 9:
                GameUIScript.sunBarspeed += 0.05f;
                break;
            case 10:
                GameUIScript.sunBarspeed += 0.05f;
                IceGameManager.rand_ice[0] = 70;
                IceGameManager.rand_ice[1] = 30;
                IceGameManager.rand_ice[2] = 15;
                IceGameManager.rand_ice[3] = 15;
                break;
            case 11:
                GameUIScript.sunBarspeed += 0.05f;
                break;
            case 12:
                GameUIScript.sunBarspeed += 0.05f;
                break;
            case 13:
                GameUIScript.sunBarspeed += 0.05f;
                break;
            case 15:
                GameUIScript.sunBarspeed += 0.05f;
                IceGameManager.rand_ice[0] = 50;
                IceGameManager.rand_ice[1] = 40;
                IceGameManager.rand_ice[2] = 20;
                IceGameManager.rand_ice[3] = 20;
                break;
            default:
                GameUIScript.sunBarspeed += 0.1f;
                break;
        }

        LevelUpUIScript.LevelUp();

        PlayerManager.Instance.apply_ATK();
    }

    public void WeaponLevelUp(int increase_level = 1)
    {
        PlayerAttack.PlayerWeapon.weaponLevel += increase_level;
        PlayerAttack.PlayerWeapon.ATK += PlayerAttack.PlayerWeapon.ATK_increase * increase_level;
        PlayerAttack.PlayerWeapon.AttackSpeed += PlayerAttack.PlayerWeapon.AttackSpeed_increase * increase_level;

    }
}
