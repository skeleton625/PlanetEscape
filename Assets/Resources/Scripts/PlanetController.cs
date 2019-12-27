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
    [SerializeField]
    private float MeteoTime;

    private Vector3 ShrinkVector;
    private WaitForSeconds MeteoTimer;

    private void Awake()
    {
        MeteoTimer = new WaitForSeconds(MeteoTime);
        ShrinkVector = new Vector3(1, 1, 1) * ShrinkForce;
    }

    public void ShrinkingPlanet()
    {
        transform.localScale -= ShrinkVector;
    }

    public IEnumerator StartMeteoCoroutine()
    {
        Vector3 pos;
        while (true)
        {
            pos = Random.onUnitSphere * MeteoRadius;
            Instantiate(DefaultMeteo, pos, Quaternion.identity);
            yield return MeteoTimer;
        }

        yield return null;
    }
}
