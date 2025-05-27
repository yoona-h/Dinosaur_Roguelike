using UnityEngine;
using System.Collections.Generic;

public class IcePoolManager : MonoBehaviour
{
    [System.Serializable]
    public class IcePool
    {
        public GameObject prefab;
        public int initialSize = 10;
        [HideInInspector] public Queue<GameObject> pool = new Queue<GameObject>();
    }

    public List<IcePool> icePools;

    void Start()
    {
        foreach (var ice in icePools)
        {
            for (int i = 0; i < ice.initialSize; i++)
            {
                GameObject obj = Instantiate(ice.prefab);
                obj.SetActive(false);
                ice.pool.Enqueue(obj);
            }
        }
    }

    public GameObject GetIceFromPool(int typeIndex, Vector3 position)
    {
        if (typeIndex < 0 || typeIndex >= icePools.Count) return null;

        IcePool ice = icePools[typeIndex];
        GameObject obj;

        if (ice.pool.Count > 0)
        {
            obj = ice.pool.Dequeue();
        }
        else
        {
            obj = Instantiate(ice.prefab);
        }

        obj.transform.position = position;

        // IceManager 초기화
        IceManager iceManager = obj.GetComponent<IceManager>();
        if (iceManager != null)
        {
            iceManager.Init(this, typeIndex);
        }

        return obj;
    }
    public GameObject GetIceFromPool(int typeIndex, Vector3 position, float scale)
    {
        if (typeIndex < 0 || typeIndex >= icePools.Count) return null;

        IcePool ice = icePools[typeIndex];
        GameObject obj;

        if (ice.pool.Count > 0)
        {
            obj = ice.pool.Dequeue();
        }
        else
        {
            obj = Instantiate(ice.prefab);
        }

        obj.transform.position = position;

        IceManager iceManager = obj.GetComponent<IceManager>();
        if (iceManager != null)
        {
            iceManager.Init(this, typeIndex, scale); // 크기 전달
        }

        return obj;
    }

    public void ReturnIceToPool(GameObject obj, int typeIndex)
    {
        obj.SetActive(false);
        if (typeIndex >= 0 && typeIndex < icePools.Count)
        {
            icePools[typeIndex].pool.Enqueue(obj);
        }
        else
        {
            Destroy(obj); // 방어 로직
        }
    }
}
