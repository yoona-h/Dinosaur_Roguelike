using UnityEngine;

public class IceManager : MonoBehaviour
{
    [SerializeField] private float maxHP = 100f;
    [Space] public CapsuleCollider collider_;
    public Ice_HPbar Ice_HPbar;

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

    // 폴링 관련 필드
    private IcePoolManager poolManager;
    private int typeIndex;

    void Start()
    {
        CurrentHP = maxHP;
    }

    #region 크기설정을 하는 것과 안하는 것 둘을 오버라이딩함.
    public void Init(IcePoolManager pool, int index)
    {
        poolManager = pool;
        typeIndex = index;
        isDead = false;
        collider_.enabled = true;
        CurrentHP = maxHP;
        Ice_HPbar.SetHealth(1f);
        gameObject.SetActive(true);
    }
    public void Init(IcePoolManager pool, int index, float scale)
    {
        poolManager = pool;
        typeIndex = index;
        isDead = false;
        collider_.enabled = true;
        CurrentHP = maxHP;
        Ice_HPbar.SetHealth(1f);

        transform.localScale = Vector3.one * scale; // 크기 반영
        gameObject.SetActive(true);
    }
    #endregion

    public void TakeDamage(float amount)
    {
        if (isDead) return;
        CurrentHP -= amount;
        Ice_HPbar.SetHealth(CurrentHP / maxHP);
    }

    private void Die()
    {
        isDead = true;
        collider_.enabled = false;
        // TODO: 사운드, 애니메이션 재생
        // 애니메이션 이벤트나 일정 시간 후에 다음 함수 호출
        ReturnToPool(); // 예: 1.5초 후 복귀
    }

    private void ReturnToPool()//애니메이션에서 타이밍맞게 부르기. 
    {
        if (poolManager != null)
        {
            poolManager.ReturnIceToPool(gameObject, typeIndex);
        }
        else
        {
            Debug.LogWarning("PoolManager not assigned!");
            Destroy(gameObject); // 예외 상황 대비
        }
    }
}
