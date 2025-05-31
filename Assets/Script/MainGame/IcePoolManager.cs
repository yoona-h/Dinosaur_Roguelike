using UnityEngine;
using System.Collections.Generic;

public class IcePoolManager : MonoBehaviour
{
    public GameObject ice_pooling_transform;

    [Header("얼음 종류별 프리팹")]
    public List<GameObject> icePrefabs;

    [Header("초기 풀 크기")]
    public int initialSize = 10;

    private List<Queue<GameObject>> icePools = new List<Queue<GameObject>>();

    void Start()
    {
        foreach (var prefab in icePrefabs)
        {
            Queue<GameObject> pool = new Queue<GameObject>();
            for (int i = 0; i < initialSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.transform.SetParent(ice_pooling_transform.transform);
                obj.SetActive(false);
                pool.Enqueue(obj);
            }
            icePools.Add(pool);
        }
    }

    public GameObject GetIceFromPool(int typeIndex, Vector3 position, float scale = 1f)
    {
        if (typeIndex < 0 || typeIndex >= icePools.Count) return null;

        Queue<GameObject> pool = icePools[typeIndex];
        GameObject obj;

        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
        }
        else
        {
            obj = Instantiate(icePrefabs[typeIndex]);
            obj.transform.SetParent(ice_pooling_transform.transform);
        }

        obj.transform.position = position;
        obj.SetActive(true);

        IceManager iceManager = obj.GetComponent<IceManager>();
        if (iceManager != null)
        {
            iceManager.Init(this, typeIndex, scale);
            iceManager.inPool = false;
        }

        PlayerManager.Instance.attack_area.Exit_ice(obj.GetComponentInChildren<Collider>());

        return obj;
    }

    public void ReturnIceToPool(GameObject obj, int typeIndex)
    {
        IceManager iceManager = obj.GetComponent<IceManager>();

        if (iceManager != null && iceManager.inPool)
        {
            Debug.LogWarning("이미 반환된 오브젝트입니다.");
            return;
        }

        obj.SetActive(false);

        if (typeIndex >= 0 && typeIndex < icePools.Count)
        {
            icePools[typeIndex].Enqueue(obj);
            if (iceManager != null)
                iceManager.inPool = true; // 🔄 반환 완료 표시
        }
        else
        {
            Destroy(obj);
        }
    }
}
