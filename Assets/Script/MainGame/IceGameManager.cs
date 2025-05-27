using UnityEngine;
using System.Collections.Generic;

public class IceGameManager : MonoBehaviour
{
    [Header("맵 크기 입력 (얼음 생성 범위)")]
    public Vector2 MapSize;

    [Header("얼음 생성 주기")]
    public float interval = 3f;
    private float timer;

    [Header("얼음 종류별 확률 설정")]
    [Tooltip("IcePoolManager스크립트에 있는 얼음 종류 저장 변수에서, 인덱스 개수와 순서를 똑같게 설정해주어야 한다.")]
    public float[] rand_ice;

    [Header("풀 매니저 참조")]
    public IcePoolManager poolManager;

    float rand_end;
    List<float> rand_ice_rand = new List<float>();
    private void Awake()
    {
        foreach (float num in rand_ice)
            rand_ice_rand.Add(0);
    }
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
        float total = 0f;
        foreach (float v in rand_ice) total += v;

        List<float> cumulative = new List<float>();
        float sum = 0f;
        for (int i = 0; i < rand_ice.Length; i++)
        {
            sum += rand_ice[i] / total;
            cumulative.Add(sum);
        }

        float rand = Random.value;
        int index = 0;
        for (int i = 0; i < cumulative.Count; i++)
        {
            if (rand <= cumulative[i])
            {
                index = i;
                break;
            }
        }
        print(index);

        // 무작위 크기
        float randomScale = Random.Range(1f, 2f);

        // 맵 내 무작위 위치
        Vector3 spawnPos = new Vector3(
            Random.Range(-MapSize.x / 2f, MapSize.x / 2f),
            0.49f * (randomScale-1f),
            Random.Range(-MapSize.y / 2f, MapSize.y / 2f)
        );

        // 풀에서 얼음 가져오기
        poolManager.GetIceFromPool(index, spawnPos, randomScale);
    }
}
