using UnityEngine;

/*
 *  ������ ���⸶�� �ٸ� ���ݹ�� �� ���� �����Ϳ� ���ݹ�İ��� �Լ� �־���� �����̺�Ʈ�� �����ϱ� (�׳� �ֵθ���, �� ���, �� �� �ִϸ��̼� �����ΰ� � �ִϸ��̼ǿ� �������� ���⿡ ������ �����ϱ�(string))
 *  ���⸶�� �ٸ� ���ݼӵ� �� ������ ���ݼӵ� ���� ���ݸ�ǿ� ���Խ�Ű��
 *  ���⸶�� �ٸ� ���ݷ� �� ���ݽ� ����ϱ�
 *  ���⸶�� �ٸ� ���ݹ��� �� ���� ��ü �Ǵ� ��ȭ�� ���ݹ��� ũ�� ������
 *  ���⸶�� �ٸ� ��� �� ���� ������ �����ϱ�
 *  ���⸶�� �ٸ� ���ġ �� ���Ⱝȭ �� �� �����ϱ�
 */

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon/WeaponData")]
public class Weapon : ScriptableObject
{
    public void Attack_function()
    {
        if (Bullet != null)//���Ÿ� ������ ��
        {
            //�Ѿ˹߻�???
        }
    }

    [Header("���� ������Ʈ ������")]
    public GameObject Weapon_prefab;
    public GameObject Bullet;//���Ÿ� ������ �� �Ѿ� �ʿ��ϸ� �ֱ�

    [Header("��ȭ ���� ���� �⺻ ���� (������ �����ϴ� ��, �����ϴ� ��)")]
    public int ATK;
    public float AttackSpeed;//������ ���� ���̿� �ɸ��� �ð�(��). �������� ����
    public float AttackRange;

    [Header("1�� �ö� ������ �����ϴ� ��ġ")]
    public int ATK_increase;
    public float AttackSpeed_increase;
    public float AttackRange_increase;

    //���� ��Ŀ������ ���Ŀ� �����Ҽ��� ����. �ϴ��� �̷���!
    [Header("���� ���� �ݶ��̴� ����")]
    public Vector3 AttackArea;

    // 추가
    [Header("무기 고유 ID")]
    public int weaponID;

    [Header("���� �̸�")]
    public string Weapon_name;
    [Header("���� ����")]
    [TextArea]
    public string Weapon_description;
}
