using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectArray : MonoBehaviour
{
    [SerializeField]
    private GameObject[] CarObjects;
    [SerializeField]
    private GameObject StartGameObjects;
    [SerializeField]
    private GameObject StartUI;
    [SerializeField]
    private GameObject ChooseGameObjects;
    [SerializeField]
    private GameObject ChooseUI;

    public GameObject GetCarObject(int _num)
    {
        CarObjects[_num].transform.rotation = Quaternion.identity;
        return CarObjects[_num];
    }

    public int GetCarArrayLength()
    {
        return CarObjects.Length;
    }

    public void ActivateGameStartObjects(bool activate)
    {
        if(activate)
        {
            StartGameObjects.SetActive(false);
            StartUI.SetActive(false);
            ChooseGameObjects.SetActive(true);
            ChooseUI.SetActive(true);
        }
        else
        {
            StartGameObjects.SetActive(true);
            StartUI.SetActive(true);
            ChooseGameObjects.SetActive(false);
            ChooseUI.SetActive(false);
        }
    }
}
