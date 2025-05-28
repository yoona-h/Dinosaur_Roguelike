using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    [Header("Managers")]
    public PlayerAttack PlayerAttack;
    public PlayerMove PlayerMove;
    public attack_area attack_area;


    public int playerATK;//���� �÷��̾��� ���ݷ� ����
    private int playerATK_default = 2;
    public int playerATK_increase;

    public int playerLevel = 0;//���� �÷��̾��� ���� ����
    public int playerEXP = 0;//�÷��̾ ���� ȹ���� ����ġ
    public int nextLevel_EXP = 0;//���� ������ �Ǳ� ���� �ʿ��� ����ġ ��. ������ �� ������ ������ ��Ģ���� ������Ų��.


    private void Awake()
    {
        Instance = this;//������ ���� ������ ������ �ʱ�ȭ���ֱ� ����
        playerATK = playerATK_default;

        //PlayerAttack.ChangeWeapon(GameManager.Instance.GameData.StartWeapon);//���۹���� �ʱ�ȭ
    }


    public void apply_ATK()
    {
        playerATK = PlayerAttack.PlayerWeapon.ATK + playerATK_default + playerATK_increase * playerLevel;
    }

    public void Die_from_Ice()//������ �¾��׾��� �� ȣ���ϱ�
    {
        print("�÷��̾� ������ �¾�����...");
    }
    
}
