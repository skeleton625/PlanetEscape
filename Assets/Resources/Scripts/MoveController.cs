using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    private float carSpeed;
    private Rigidbody carRb;
    [SerializeField]
    private Vector3 Planet;

    // Start is called before the first frame update
    void Start()
    {
        carRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 수정 중 . . .
        // Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        RotateAround(Planet, Vector3.right * horizontal * carSpeed, vertical);
    }

    private void RotateAround(Vector3 origin, Vector3 axis, float angle)
    {
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        carRb.MovePosition(q * (carRb.transform.position - origin) + origin);
        carRb.MoveRotation(carRb.transform.rotation * q);
    }
}
