using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField]
    private float ShrinkForce;
    [SerializeField]
    private float MinShrink;
    [SerializeField]
    private GameObject DefaultMeteo;
    [SerializeField]
    private float MeteoRadius;

    private Vector3 ShrinkVector;
    private WaitForSeconds ShrinkTimer = new WaitForSeconds(1f);

    private void Start()
    {
        ShrinkVector = new Vector3(1, 1, 1) * ShrinkForce;
        StartCoroutine(ShrinkPlanetCoroutine());
        StartCoroutine(StartMeteoCoroutine());
    }

    private void Update()
    {
        if (transform.localScale.x < MinShrink)
            StopAllCoroutines();
    }

    private IEnumerator ShrinkPlanetCoroutine()
    {
        while(transform.localScale.x > MinShrink)
        {
            transform.localScale -= ShrinkVector;
            yield return null;
        }       
    }

    private IEnumerator StartMeteoCoroutine()
    {
        Vector3 pos;
        while (true)
        {
            pos = Random.onUnitSphere * MeteoRadius;
            Instantiate(DefaultMeteo, pos, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
