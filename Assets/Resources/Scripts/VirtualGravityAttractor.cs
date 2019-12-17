using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualGravityAttractor : MonoBehaviour
{
    // 가상 중력을 적용할 모든 오브젝트가 접근할 수 있는 instance 객체
    public static VirtualGravityAttractor instance;
    // 해당 중력을 생성하는 구 오브젝트의 충돌 객체
    private SphereCollider col;
    // 가상 중력 값
    [SerializeField]
    private float VirtualGravityForce;

    private void Awake()
    {
        instance = this;
        col = GetComponent<SphereCollider>();
    }

    // body 오브젝트에 중력을 제공하는 함수
    public void Attract(Rigidbody body)
    {
        body.AddForce(CalculateGravityUp(body) * VirtualGravityForce);

        RotateBody(body);
    }

    // body 오브젝트가 중력을 제공하는 구 표면을 회전하도록 하는 함수
    public void PlaceOnSurface(Rigidbody body)
    {
        body.MovePosition(CalculateGravityUp(body) * (transform.localScale.x * col.radius));

        RotateBody(body);
    }

    private void RotateBody(Rigidbody body)
    {
        // 구를 중심으로 한 body 오브젝트 회전 적용
        Quaternion targetRotation = Quaternion.
                                    FromToRotation(body.transform.up, CalculateGravityUp(body)) * body.rotation;
        body.MoveRotation(Quaternion.Slerp(body.rotation, targetRotation, 50f * Time.deltaTime));
    }

    // 구를 중심으로 한 body 오브젝트의 중력 적용 방향 계산 함수
    private Vector3 CalculateGravityUp(Rigidbody body)
    {
        return (body.position - transform.position).normalized;
    }
}
