using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBody : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ExplosionBodyCoroutine());
    }

    private IEnumerator ExplosionBodyCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
