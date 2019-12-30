using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] CarObjects;
    public static int PreCarNumber;

    private void Awake()
    {
        ObjectManager.PreCarNumber = 0;
    }

    public void ActivateCarObject(bool _isRight)
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
    }
}
