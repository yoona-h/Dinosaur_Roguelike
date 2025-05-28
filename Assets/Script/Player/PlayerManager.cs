using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    [Header("Managers")]
    public PlayerAttack PlayerAttack;
    public PlayerMove PlayerMove;
    public attack_area attack_area;


    public int playerATK;//현재 플레이어의 공격력 저장
    private int playerATK_default = 2;
    public int playerATK_increase;

    public int playerLevel = 0;//현재 플레이어의 레벨 저장
    public int playerEXP = 0;//플레이어가 현재 획득한 경험치
    public int nextLevel_EXP = 0;//다음 레벨이 되기 위해 필요한 경험치 량. 레벨업 할 때마다 일정한 규칙으로 증가시킨다.


    private void Awake()
    {
        Instance = this;//게임을 새로 시작할 때마다 초기화해주기 위함
        playerATK = playerATK_default;

        //PlayerAttack.ChangeWeapon(GameManager.Instance.GameData.StartWeapon);//시작무기로 초기화
    }


    public void apply_ATK()
    {
        playerATK = PlayerAttack.PlayerWeapon.ATK + playerATK_default + playerATK_increase * playerLevel;
    }

    public void Die_from_Ice()//얼음에 맞아죽었을 때 호출하기
    {
        print("플레이어 얼음에 맞아죽음...");
    }
    
}
