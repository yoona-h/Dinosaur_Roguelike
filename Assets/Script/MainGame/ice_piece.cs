using UnityEngine;

public class ice_piece : MonoBehaviour
{
    float delay = 0.4f;                 // �̵� ���� �� ������
    float baseSpeed = 7f;               // ���� �ӵ�
    float currentSpeed;
    float speedMultiplier = 1.008f;      // �� ������ �ӵ� ���� ����
    float maxSpeed = 50f;               // �ְ� �ӵ� ����

    float absorbDistance = 1.0f;        // �÷��̾�� ��� �Ÿ�
    int expValue = 1;                   // ����ġ ��

    private Transform player;
    private bool canMove = false;

    void Start()
    {
        player = PlayerManager.Instance.gameObject.transform;
        currentSpeed = baseSpeed;
        Invoke(nameof(StartMoving), delay);
    }

    void StartMoving()
    {
        canMove = true;
    }

    void Update()
    {
        if (!canMove || player == null) return;

        // �ӵ� ����
        currentSpeed = Mathf.Min(currentSpeed * speedMultiplier, maxSpeed);

        // �̵�
        transform.position = Vector3.MoveTowards(transform.position, player.position, currentSpeed * Time.deltaTime);

        // ��� �Ÿ� ���� ��
        if (Vector3.Distance(transform.position, player.position) <= absorbDistance)
        {
            PlayerManager.Instance.playerEXP += expValue;

            // ����Ʈ ���
            // ���� ���

            Destroy(gameObject);
        }
    }
}
