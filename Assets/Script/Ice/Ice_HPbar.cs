using UnityEngine;
using UnityEngine.UI;

public class Ice_HPbar : MonoBehaviour
{
    public Camera targetCamera;          // 카메라 (null이면 자동으로 Camera.main 사용)
    public GameObject Canvas;
    public Slider healthSlider;          // 연결된 슬라이더 UI
    public CanvasGroup canvasGroup;      // 투명도 조절을 위한 컴포넌트

    
    float maxVisibleDistance = 50f;   // 이 거리 이상이면 안 보이게
    float fadeStartDistance = 20f;    // 이 거리부터 서서히 투명해짐

    void Start()
    {
        if (targetCamera == null)
            targetCamera = Camera.main;

        if (canvasGroup == null)
            canvasGroup = GetComponentInChildren<CanvasGroup>();
    }

    void Update()
    {
        LookAtCamera();
        AdjustAlphaByDistance();
    }

    void LookAtCamera()
    {
        Vector3 lookDirection = transform.position - targetCamera.transform.position;
        Canvas.transform.rotation = Quaternion.LookRotation(lookDirection);
    }

    void AdjustAlphaByDistance()
    {
        float distance = Vector3.Distance(Canvas.transform.position, targetCamera.transform.position);

        if (distance >= maxVisibleDistance)
        {
            canvasGroup.alpha = 0f;
        }
        else if (distance <= fadeStartDistance)
        {
            canvasGroup.alpha = 1f;
        }
        else
        {
            float t = Mathf.InverseLerp(fadeStartDistance, maxVisibleDistance, distance);
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t);  // 가까울수록 1, 멀수록 0
        }
    }


    /// <summary>
    /// 외부에서 체력 값 0~1로 설정
    /// </summary>
    public void SetHealth(float value)
    {
        healthSlider.value = Mathf.Clamp01(value);
    }
}
