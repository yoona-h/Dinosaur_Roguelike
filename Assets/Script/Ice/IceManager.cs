using UnityEngine;

public class IceManager : MonoBehaviour
{ 
    [SerializeField]
    private float maxHP = 100f;
    [Space]
    public CapsuleCollider collider_;

    private float currentHP;
    public float CurrentHP
    {
        get => currentHP;
        private set
        {
            currentHP = value;
            if (currentHP <= 0f && !isDead)
            {
                Die();
            }
        }
    }

    [HideInInspector] public bool isDead = false;

    void Start()
    {
        CurrentHP = maxHP;
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;
        CurrentHP -= amount;
        print("엄음 체력 : " + currentHP);
    }

    private void Die()
    {
        isDead = true;
        collider_.enabled = false;
        // 애니메이션, 사운드
        // 오브젝트 파괴(또는 폴링)은 애니메이션이 끝난 후 이루어져야 하므로 따로 파괴 함수 만들어서 애니메이션에 함수 추가하기
        Destroy(gameObject);//오브젝트 폴링 구현하기
    }
}

