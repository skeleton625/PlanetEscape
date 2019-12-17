using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualGravityBody : MonoBehaviour
{
    // 중력 적용 객체
    private VirtualGravityAttractor attractor;
    // 중력을 적용 받는 오브젝트
    private Rigidbody rb;
    // 중력을 적용 받는 오브젝트가 중력 적용 객체 표면에 있는지 여부 파악 변수
    [SerializeField]
    private bool IsPlaceOnSurface = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        attractor = VirtualGravityAttractor.instance;
    }

    private void FixedUpdate()
    {
        if (IsPlaceOnSurface)
            attractor.PlaceOnSurface(rb);
        else
            attractor.Attract(rb);
    }
}
