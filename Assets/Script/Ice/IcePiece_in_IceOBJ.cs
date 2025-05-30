using UnityEngine;

public class IcePiece_in_IceOBJ : MonoBehaviour
{
    public GameObject expShardPrefab;       // 경험치 조각 프리팹 (= 파편 조각)

    public void BreakAndSpawn(int shardCount)
    {
        for (int i = 0; i < shardCount; i++)
        {
            // 파편 생성 (랜덤 회전)
            GameObject shard = Instantiate(expShardPrefab, gameObject.transform.position, Random.rotation);

            // Rigidbody로 튀게 만들기
            Rigidbody rb = shard.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 randomDir = Random.onUnitSphere + Vector3.up;
                rb.AddForce(randomDir * Random.Range(100f, 280f));
            }

            // 경험치 조각은 스스로 끌려가며 처리되므로 따로 관리 X
        }
    }
}