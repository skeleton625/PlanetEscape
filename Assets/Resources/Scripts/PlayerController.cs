using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed;
    [SerializeField]
    private float RotateSpeed;
    [SerializeField]
    private GameObject ExplosionEffect;
    [SerializeField]
    private bool IsGameStart;

    private float rotation;
    private Rigidbody rb;
    private Animator PlayerAnim;
    private Camera PlayerCamera;
    private GameObject Planet;
    private bool playerDead;
    public bool PlayerDead
        { get { return playerDead; } }

    private void Awake()
    {
        playerDead = false;
        Planet = GameObject.Find("Planet");
        rb = GetComponent<Rigidbody>();
        PlayerAnim = GetComponent<Animator>();

        if (IsGameStart)
        {
            PlayerCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
            PlayerCamera.transform.parent = transform;
        }
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
        PlayerAnim.SetFloat("Rotate", rotation);
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

    // 메테오 충돌 시 이벤트 함수
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Explo")
            return;
        PlayerCamera.transform.parent = null;
        // 충돌 효과 생성 후, 차 오브젝트 제거
        GameObject _clone = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(_clone, 3f);
        gameObject.SetActive(false);
        playerDead = true;
    }
}
