using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRotation : MonoBehaviour
{
    [SerializeField]
    private Vector3 RotateVector;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotateVector);
    }
}
