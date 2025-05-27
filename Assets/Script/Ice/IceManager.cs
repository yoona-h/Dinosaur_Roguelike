using UnityEngine;

public class IceManager : MonoBehaviour
{
    [SerializeField] private float maxHP = 100f;
    [SerializeField] private int dropPiece_min = 0;
    [SerializeField] private int dropPiece_max = 0;
    [Space]
    public CapsuleCollider collider_;
    public Animator animator_;
    public Ice_HPbar Ice_HPbar;
    public GameObject Ice_body;
    public GameObject warning_area;


    float attackRadius = 1f;
    public LayerMask playerLayer;


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
    [HideInInspector] public bool inPool = false;


    void Start()
    {
        CurrentHP = maxHP;
    }


    private void OnEnable()
    {
        //처음 생성시 생성범위에 경고하기
        warning_area.SetActive(true);
        Ice_body.SetActive(false);
        animator_.SetTrigger("start");

        //경고가 끝나고 생성되었을 때도 

        //얼음 자라나는 애니메이션 재생하기
    }
    public void Attack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, attackRadius, playerLayer);

        foreach (var hit in hits)
        {
            PlayerManager player = hit.GetComponent<PlayerManager>();
            if (player != null)
            {
                player.Die_from_Ice();
            }
        }
    }
    public void finish_warning()
    {
        warning_area.SetActive(false);
        Ice_body.SetActive(true);
    }


    public void Init(IcePoolManager pool, int index, float scale = 1f)
    {
        // 초기화 코드...
        inPool = false;
        poolManager = pool;
        typeIndex = index;
        isDead = false;
        collider_.enabled = true;
        CurrentHP = maxHP;
        Ice_HPbar.SetHealth(1f);
        attackRadius = gameObject.transform.localScale.x * 0.8f;

        transform.localScale = Vector3.one * scale; // 크기 반영
        gameObject.SetActive(true);
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;
        CurrentHP -= amount;
        print("얼음 TakeDamage : " + CurrentHP);
        Ice_HPbar.SetHealth(CurrentHP / maxHP);
    }

    private void Die()
    {
        isDead = true;
        collider_.enabled = false;
        // TODO: 사운드, 애니메이션 재생

        //----------------------------------------------------------------------얼음조각 랜덤 드랍 구현하기 + 경험치 획득, 레벨업, 레벨업에 따른 확률변동과 시간간격 감소까지 구현하기---------

        // 애니메이션 이벤트에서 타이밍 맞게 부르도록 로직 바꾸기
        ReturnToPool(); // 예: 1.5초 후 복귀
    }

    private void ReturnToPool()//애니메이션에서 타이밍맞게 부르기. 오브젝트를 아예 없애버리는거임
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
