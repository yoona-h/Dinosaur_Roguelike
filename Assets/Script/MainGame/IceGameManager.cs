using UnityEngine;

public class IceGameManager : MonoBehaviour
{
    [Header("�� ũ�� �Է� (���� ���� ����)")]
    public Vector2 MapSize;

    [Header("���� ���� �ֱ�")]
    public float interval = 3f;
    private float timer;

    [Header("Ǯ �Ŵ��� ����")]
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
        // ������ ���� ����
        int index = Random.Range(0, poolManager.icePools.Count);

        // �� �� ������ ��ġ
        Vector3 spawnPos = new Vector3(
            Random.Range(-MapSize.x / 2f, MapSize.x / 2f),
            0f,
            Random.Range(-MapSize.y / 2f, MapSize.y / 2f)
        );

        float randomScale = Random.Range(1f, 2f);

        // Ǯ���� ���� ��������
        poolManager.GetIceFromPool(index, spawnPos, randomScale);
    }
}
