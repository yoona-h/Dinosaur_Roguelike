using UnityEngine;

public class IceGameManager : MonoBehaviour
{
    [Header("맵 크기 입력 (얼음 생성 범위)")]
    public Vector2 MapSize;

    [Header("얼음 생성 주기")]
    public float interval = 3f;
    private float timer;

    [Header("풀 매니저 참조")]
    public IcePoolManager poolManager;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            generate_ice();
            timer = interval;
        }
    }

    void generate_ice()
    {
        // 무작위 종류 선택
        int index = Random.Range(0, poolManager.icePools.Count);

        // 맵 내 무작위 위치
        Vector3 spawnPos = new Vector3(
            Random.Range(-MapSize.x / 2f, MapSize.x / 2f),
            0f,
            Random.Range(-MapSize.y / 2f, MapSize.y / 2f)
        );

        float randomScale = Random.Range(1f, 2f);

        // 풀에서 얼음 가져오기
        poolManager.GetIceFromPool(index, spawnPos, randomScale);
    }
}
