using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] CarObjects;
    [SerializeField]
    private GameObject DefaultMeteo;
    [SerializeField]
    private int AllMeteoCount;
    [SerializeField]
    private Vector3 MeteoPos;

    private static int PreCarNumber;
    public static ObjectManager instance;
    private Queue<GameObject> MeteoQueue;

    private void Awake()
    {
        instance = this;
        MeteoQueue = new Queue<GameObject>();
        for(int i = 0; i < AllMeteoCount; i++)
        {
            GameObject _meteo = Instantiate(DefaultMeteo, MeteoPos, Quaternion.identity);
            _meteo.transform.parent = transform;
            MeteoQueue.Enqueue(_meteo);
            _meteo.SetActive(false);
        }
            
    }

    public void SelectCarObject(bool _isRight)
    {
        CarObjects[PreCarNumber].SetActive(false);
        CarObjects[PreCarNumber].transform.rotation = Quaternion.identity;

        if (_isRight)
        {
            ++PreCarNumber;
            if (PreCarNumber >= CarObjects.Length)
                PreCarNumber = 0;
        }
        else
        {
            --PreCarNumber;
            if (PreCarNumber < 0)
                PreCarNumber = CarObjects.Length - 1;
        }

        CarObjects[PreCarNumber].SetActive(true);
        Debug.Log(PreCarNumber);
    }

    public void GetActivateCarObject()
    {
        CarObjects[PreCarNumber].SetActive(true);
    }

    public void PushMeteo(GameObject _meteo)
    {
        MeteoQueue.Enqueue(_meteo);
        _meteo.SetActive(false);
    }

    public GameObject PopMeteo()
    {
        if (MeteoQueue.Count > 0)
            return MeteoQueue.Dequeue();
        else
            return null;
    }
}
