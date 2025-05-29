using UnityEngine;
using UnityEngine.UI;

public class Ice_HPbar : MonoBehaviour
{
    public Camera targetCamera;          // ī�޶� (null�̸� �ڵ����� Camera.main ���)
    public GameObject Canvas;
    public Slider healthSlider;          // ����� �����̴� UI
    public CanvasGroup canvasGroup;      // ���� ������ ���� ������Ʈ

    
    float maxVisibleDistance = 50f;   // �� �Ÿ� �̻��̸� �� ���̰�
    float fadeStartDistance = 20f;    // �� �Ÿ����� ������ ��������

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
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t);  // �������� 1, �ּ��� 0
        }
    }


    /// <summary>
    /// �ܺο��� ü�� �� 0~1�� ����
    /// </summary>
    public void SetHealth(float value)
    {
        healthSlider.value = Mathf.Clamp01(value);
    }
}
