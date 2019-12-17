using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed;
    [SerializeField]
    private float RotateSpeed;

    private float rotation;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        InputMove();
    }

    private void FixedUpdate()
    {
        ActiveMove();
    }

    private void InputMove()
    {
        rotation = Input.GetAxisRaw("Horizontal");
    }

    private void ActiveMove()
    {
        // 플레이어 차의 위치 + 프레임 당 이동량
        rb.MovePosition(rb.position + transform.forward * MoveSpeed * Time.fixedDeltaTime);
        // 플레이어 좌 우 입력에 의한 좌 우 회전
        Quaternion deltaRotate = Quaternion.Euler(Vector3.up * rotation * RotateSpeed * Time.fixedDeltaTime);
        Quaternion targetRotate = rb.rotation * deltaRotate;
        // 플레이어 차의 부드러운 회전 적용
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotate, 50f * Time.deltaTime));
    }
}
