using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField]
    private float ShrinkForce;
    [SerializeField]
    private float MeteoRadius;
    [SerializeField]
    private float MeteoTime;

    private ObjectManager MeteoInstance;
    private Vector3 ShrinkVector;
    private IEnumerator MeteoCoroutine;
    private WaitForSeconds MeteoTimer;

    private void Awake()
    {
        ShrinkVector = new Vector3(1, 1, 1) * ShrinkForce;
        MeteoTimer = new WaitForSeconds(MeteoTime);
    }

    private void Start()
    {
        MeteoInstance = ObjectManager.instance;
        MeteoCoroutine = StartMeteoCoroutine();
        StartCoroutine(MeteoCoroutine);
    }

    public void ShrinkingPlanet()
    {
        transform.localScale -= ShrinkVector;
    }

    private IEnumerator StartMeteoCoroutine()
    {
        Vector3 pos;
        while (true)
        {
            GameObject _meteo = MeteoInstance.PopMeteo();
            if(_meteo != null)
            {
                pos = Random.onUnitSphere * MeteoRadius;
                _meteo.transform.position = pos;
                _meteo.transform.LookAt(Vector3.zero);
                _meteo.SetActive(true);
            }
            yield return MeteoTimer;
        }
    }

    public void StopMeteoCoroutine()
    {
        StopCoroutine(MeteoCoroutine);
    }
}
