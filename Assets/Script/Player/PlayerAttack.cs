using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerAttack : MonoBehaviour
{
    [Header("테스트용 무기")]
    public Weapon testWeapon; // 무기 변경 테스트용 코드, 나중에 삭제

    [Header("Weapon")]
    public Weapon PlayerWeapon;
    public Transform weaponHolder; // 추가, 손 위치
    public GameObject currentWeapon; // 추가, 현재 장착된 무기 오브젝트

    [Header("Animator")]
    public Animator PlayerAnimator;

    [Header("Attack Area")]
    public BoxCollider AttackArea_collider;
    public attack_area attack_area;

    Action Attack_function;

    bool Attackable = true;



    private void Start()
    {
        ChangeWeapon(testWeapon);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !GameManager.Instance.GameData.GameStop && Attackable)
        {
            Attack();
            print("공격!");
        }

        /*
        // 무기 변경 테스트용 코드, 나중에 삭제
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            ChangeWeapon(testWeapon);
        }
        */
    }

    public void Attack()//마우스 클릭시 실행되는 함수. 애니메이션 시작, 공격 사운드 재생 등 시작할 때 필요한 동작을 실행한다.
    {
        PlayerManager.Instance.apply_ATK();
        Attack_function?.Invoke();

        // 추가
        PlayerAnimator.SetTrigger("Attack");

        //Damage();//나중에 애니메이션에서 호출하도록 바꾸기 - 완료
        StartCoroutine(AttackTimer(PlayerWeapon.AttackSpeed));
    }

    public void Damage()//애니에이션에서 적절한 타이밍에 호출해야하는 함수. 범위 내의 얼음에게 총 공격력만큼 데미지를 입히고 공격 이펙트를 재생한다.
    {
        attack_area.Activate(PlayerManager.Instance.playerATK);
    }

    public void ChangeWeapon(Weapon weapon = null)
    {
        int level = PlayerWeapon.weaponLevel-1;

        PlayerWeapon = weapon;
        Attack_function = weapon.Attack_function;
        AttackArea_collider.size = weapon.AttackArea*weapon.AttackRange;
        if (weapon.weaponID == 5)
            AttackArea_collider.center = new Vector3(0, 0, 40);
        else
            AttackArea_collider.center = Vector3.zero;

        // 추가, 무기 프리팹 교체 처리
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        if (weapon.Weapon_prefab != null && weaponHolder != null)
        {
            currentWeapon = Instantiate(weapon.Weapon_prefab, weaponHolder, false);
            PlayerAnimator.SetInteger("WeaponID", PlayerWeapon.weaponID);
            PlayerWeapon.weaponLevel = level;
            print("무기 변경");
        }

        PlayerManager.Instance.apply_ATK();
    }

    IEnumerator AttackTimer(float time = 0.01f)
    {
        if (time <= 0)
        {
            yield break;
        }
        Attackable = false;
        yield return new WaitForSeconds(time);
        Attackable = true;
        yield break;
    }

}
