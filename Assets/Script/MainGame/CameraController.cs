using UnityEngine;


public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 4, -6);

    private float currentYaw = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * GameManager.Instance.GameData.mouseSensitivity * 50f * Time.deltaTime;
        currentYaw += mouseX;
    }

    void LateUpdate()
    {
        // 회전된 위치 계산
        Quaternion rotation = Quaternion.Euler(0, currentYaw, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        // 위치 적용
        transform.position = desiredPosition;

        // 항상 타겟 바라보기
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }

    public Quaternion GetCameraYawRotation()
    {
        return Quaternion.Euler(0, currentYaw, 0);
    }
}
