using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField]
    private float ShrinkForce;
    [SerializeField]
    private float MinShrink;

    private Vector3 ShrinkVector;
    private WaitForSeconds ShrinkTimer = new WaitForSeconds(1f);

    private void Start()
    {
        ShrinkVector = new Vector3(1, 1, 1) * ShrinkForce;
        StartCoroutine(ShrinkPlanetCoroutine());
    }

    private IEnumerator ShrinkPlanetCoroutine()
    {
        while(transform.localScale.x > MinShrink)
        {
            transform.localScale -= ShrinkVector;
            yield return null;
        }       
    }
}
