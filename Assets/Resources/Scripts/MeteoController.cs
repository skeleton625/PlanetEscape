using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoController : MonoBehaviour
{
    [SerializeField]
    private GameObject MeteoEffect;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject _effect = Instantiate(MeteoEffect, collision.contacts[0].point, Quaternion.identity);
        Destroy(_effect, 2f);
        ObjectManager.instance.PushMeteo(gameObject);
    }
}
