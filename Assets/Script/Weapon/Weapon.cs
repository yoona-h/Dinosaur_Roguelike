using UnityEngine;
using UnityEngine.InputSystem.Interactions;

/*
 *  장착된 무기마다 다른 공격방식 → 무기 데이터에 공격방식관련 함수 넣어놓고 공격이벤트에 연결하기 (그냥 휘두르기, 총 쏘기, 등등… → 애니메이션 만들어두고 어떤 애니메이션에 연결할지 무기에 변수로 저장하기(string))
 *  무기마다 다른 공격속도 → 무기의 공격속도 변수 공격모션에 포함시키기
 *  무기마다 다른 공격력 → 공격시 계산하기
 *  무기마다 다른 공격범위 → 무기 교체 또는 강화시 공격범위 크기 재지정
 *  무기마다 다른 모양 → 무기 프리팹 변경하기
 *  무기마다 다른 상승치 → 무기강화 할 때 참고하기
 */

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon/WeaponData")]
public class Weapon : ScriptableObject
{
    public void Attack_function()
    {
        if (Bullet != null)//원거리 공격일 때
        {
            //총알발사???
        }

        if (weaponID == 4)
        {
            PlayerManager.Instance.PlayerAttack.currentWeapon.GetComponent<Animator>().SetTrigger("Rotation");
        }
    }

    [Header("무기 오브젝트 프리팹")]
    public GameObject Weapon_prefab;
    public GameObject Bullet;//원거리 공격일 때 총알 필요하면 넣기

    [Header("무기 레벨")]
    public int weaponLevel = 0;

    [Header("강화 없을 때의 기본 스텟 (실제로 증가하는 값, 참조하는 값)")]
    public int ATK;
    public float AttackSpeed;//실제로 공격 사이에 걸리는 시간(초). 낮을수록 빠름
    public float AttackRange;

    [Header("1렙 올라갈 때마다 증가하는 수치")]
    public int ATK_increase;
    public float AttackSpeed_increase;
    public float AttackRange_increase;

    //공격 매커니즘은 추후에 변경할수도 있음. 일단은 이렇게!
    [Header("공격 범위 콜라이더 설정")]
    public Vector3 AttackArea;

    // 추가
    [Header("무기 고유 ID")]
    public int weaponID;

    [Header("무기 이름")]
    public string Weapon_name;
    [Header("무기 설명")]
    [TextArea]
    public string Weapon_description;
}
