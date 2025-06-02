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
    public float interval
    {
        get => IceGameManager.interval;
        set => IceGameManager.interval = value;
    }
    float increase_ = 10f;


    private void Start()
    {
        IceGameManager.rand_ice[0] = 80;
        IceGameManager.rand_ice[1] = 20;
        IceGameManager.rand_ice[2] = 0;
        IceGameManager.rand_ice[3] = 0;
    }
    private void Update()
    {
        if (PlayerManager.Instance.playerEXP >= PlayerManager.Instance.nextLevel_EXP)
        {
            LevelUp();
        }
    }


    void LevelUp()
    {
        PlayerManager.Instance.playerLevel++;
        PlayerManager.Instance.playerATK += PlayerManager.Instance.playerATK_increase;

        GameManager.Instance.SoundManager.PlaySFX(LevelUp_sound);

        //임시 수식... 밸런스르르 고려하여 증가율 수식 설정하기! ------------------------------------------------------------------------
        //PlayerManager.Instance.playerATK_increase = PlayerManager.Instance.playerATK_increase;
        PlayerManager.Instance.nextLevel_EXP += (int)(increase_ * 1.5f);

        if (interval > 1)
            interval -= 0.5f;
        else
            interval = 0.8f;
        
        switch(PlayerManager.Instance.playerLevel)
        {
            case 0:
                GameUIScript.sunBarspeed += 0.05f;
                break;
            case 1:
                GameUIScript.sunBarspeed += 0.1f;
                break;
            case 2:
                GameUIScript.sunBarspeed += 0.1f;
                IceGameManager.rand_ice[0] = 80;
                IceGameManager.rand_ice[1] = 20;
                IceGameManager.rand_ice[2] = 0;
                IceGameManager.rand_ice[3] = 0;
                break;
            case 3:
                GameUIScript.sunBarspeed += 0.1f;
                IceGameManager.rand_ice[0] = 80;
                IceGameManager.rand_ice[1] = 20;
                IceGameManager.rand_ice[2] = 5;
                IceGameManager.rand_ice[3] = 0;
                break;
            case 4:
                GameUIScript.sunBarspeed += 0.1f;
                IceGameManager.rand_ice[0] = 70;
                IceGameManager.rand_ice[1] = 20;
                IceGameManager.rand_ice[2] = 5;
                IceGameManager.rand_ice[3] = 5;
                break;
            case 5:
                GameUIScript.sunBarspeed += 0.1f;
                break;
            case 6:
                GameUIScript.sunBarspeed += 0.1f;
                IceGameManager.rand_ice[0] = 70;
                IceGameManager.rand_ice[1] = 30;
                IceGameManager.rand_ice[2] = 10;
                IceGameManager.rand_ice[3] = 10;
                break;
            case 7:
                GameUIScript.sunBarspeed += 0.1f;
                break;
            case 8:
                GameUIScript.sunBarspeed += 0.1f;
                IceGameManager.rand_ice[0] = 70;
                IceGameManager.rand_ice[1] = 30;
                IceGameManager.rand_ice[2] = 15;
                IceGameManager.rand_ice[3] = 15;
                break;
            case 9:
                GameUIScript.sunBarspeed += 0.1f;
                break;
            case 10:
                GameUIScript.sunBarspeed += 0.1f;
                IceGameManager.rand_ice[0] = 50;
                IceGameManager.rand_ice[1] = 40;
                IceGameManager.rand_ice[2] = 20;
                IceGameManager.rand_ice[3] = 20;
                break;
            case 11:
                GameUIScript.sunBarspeed += 0.1f;
                break;
            case 12:
                GameUIScript.sunBarspeed += 0.1f;
                break;
            case 13:
                GameUIScript.sunBarspeed += 0.1f;
                break;
            case 15:
                GameUIScript.sunBarspeed += 0.1f;
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
