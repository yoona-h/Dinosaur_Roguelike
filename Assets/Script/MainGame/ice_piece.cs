using UnityEngine;

public class ice_piece : MonoBehaviour
{
    float delay = 0.4f;                 // 이동 시작 전 딜레이
    float baseSpeed = 7f;               // 시작 속도
    float currentSpeed;
    float speedMultiplier = 1.008f;      // 매 프레임 속도 증가 비율
    float maxSpeed = 50f;               // 최고 속도 제한

    float absorbDistance = 1.0f;        // 플레이어와 흡수 거리
    int expValue = 1;                   // 경험치 양

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

        // 속도 증가
        currentSpeed = Mathf.Min(currentSpeed * speedMultiplier, maxSpeed);

        // 이동
        transform.position = Vector3.MoveTowards(transform.position, player.position, currentSpeed * Time.deltaTime);

        // 흡수 거리 도달 시
        if (Vector3.Distance(transform.position, player.position) <= absorbDistance)
        {
            PlayerManager.Instance.playerEXP += expValue;

            // 이펙트 재생
            // 사운드 재생

            Destroy(gameObject);
        }
    }
}
