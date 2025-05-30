using UnityEngine;

public class IcePiece_in_IceOBJ : MonoBehaviour
{
    public GameObject expShardPrefab;       // ����ġ ���� ������ (= ���� ����)

    public void BreakAndSpawn(int shardCount)
    {
        for (int i = 0; i < shardCount; i++)
        {
            // ���� ���� (���� ȸ��)
            GameObject shard = Instantiate(expShardPrefab, gameObject.transform.position, Random.rotation);

            // Rigidbody�� Ƣ�� �����
            Rigidbody rb = shard.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 randomDir = Random.onUnitSphere + Vector3.up;
                rb.AddForce(randomDir * Random.Range(100f, 280f));
            }

            // ����ġ ������ ������ �������� ó���ǹǷ� ���� ���� X
        }
    }
}