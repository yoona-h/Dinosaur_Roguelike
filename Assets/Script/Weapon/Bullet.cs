using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float maxDistance = 100f;

    Vector3 startPos;


    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        if (Vector3.Distance(startPos, transform.position) >= maxDistance)
            Destroy(gameObject);
    }
}
