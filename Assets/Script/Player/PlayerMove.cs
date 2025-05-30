using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 20f;
    public ThirdPersonCamera cameraController;
    public Animator animator; // 추가

    private Rigidbody rb;
    private Vector3 movementInput;
    private Vector3 lastMoveDir;

    void Start()
    {
        Cursor.visible = false;                   // 커서 숨기기
        Cursor.lockState = CursorLockMode.Locked; // 커서 화면 중앙 고정
        /*
        Cursor.visible = true;                    // 커서 보이기
        Cursor.lockState = CursorLockMode.None;   // 커서 자유롭게 이동
        */
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 1. 입력 받기 (카메라 기준)
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = new Vector3(h, 0f, v).normalized;
        Quaternion camRot = cameraController.GetCameraYawRotation();
        movementInput = camRot * inputDir;

        if (inputDir.magnitude > 0.1f)
        {
            lastMoveDir = movementInput;
            animator.SetBool("Walk", true); // 추가, 걷기 애니메이션 ON
        }
        else
        {
            animator.SetBool("Walk", false); // 추가, 걷기 애니메이션 OFF
        }
    }

    void FixedUpdate()
    {
        // 2. Rigidbody 이동
        Vector3 move = movementInput * moveSpeed;
        Vector3 newVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z); // y는 중력 유지
        rb.linearVelocity = newVelocity;

        // 3. 부드러운 회전
        if (lastMoveDir.magnitude > 0.1f)
        {
            Quaternion targetRot = Quaternion.LookRotation(lastMoveDir);
            Quaternion smoothed = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(smoothed);
        }
    }
}