using UnityEngine;
using System.Collections.Generic;

public class IceGameManager : MonoBehaviour
{
    [Header("�� ũ�� �Է� (���� ���� ����)")]
    public Vector2 MapSize;

    [Header("���� ���� �ֱ�")]
    public float interval = 3f;
    private float timer;

    [Header("���� ������ Ȯ�� ����")]
    [Tooltip("IcePoolManager��ũ��Ʈ�� �ִ� ���� ���� ���� ��������, �ε��� ������ ������ �Ȱ��� �������־�� �Ѵ�.")]
    public float[] rand_ice;

    [Header("Ǯ �Ŵ��� ����")]
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
        // ������ ���� ����
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

        // ������ ũ��
        float randomScale = Random.Range(1f, 2f);

        // �� �� ������ ��ġ
        Vector3 spawnPos = new Vector3(
            Random.Range(-MapSize.x / 2f, MapSize.x / 2f),
            0.49f * (randomScale-1f),
            Random.Range(-MapSize.y / 2f, MapSize.y / 2f)
        );

        // Ǯ���� ���� ��������
        poolManager.GetIceFromPool(index, spawnPos, randomScale);
    }
}
