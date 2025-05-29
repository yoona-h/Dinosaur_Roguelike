using UnityEngine;

public class Destroy_forSecond : MonoBehaviour
{
    public float second;

    private void Update()
    {
        second -= Time.deltaTime;
        if (second <= 0)
            Destroy(gameObject);
    }
}
