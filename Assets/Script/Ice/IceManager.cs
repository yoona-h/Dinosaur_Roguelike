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
        print("���� ü�� : " + currentHP);
    }

    private void Die()
    {
        isDead = true;
        collider_.enabled = false;
        // �ִϸ��̼�, ����
        // ������Ʈ �ı�(�Ǵ� ����)�� �ִϸ��̼��� ���� �� �̷������ �ϹǷ� ���� �ı� �Լ� ���� �ִϸ��̼ǿ� �Լ� �߰��ϱ�
        Destroy(gameObject);//������Ʈ ���� �����ϱ�
    }
}

