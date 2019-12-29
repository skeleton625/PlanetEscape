using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    private GameObjectArray ObjectInstance;
    private static int CarNum = 0;
    private void Start()
    {
        ObjectInstance = GameObject.Find("GameObjectArray").GetComponent<GameObjectArray>();
    }

    public void OnArrowButtonClick()
    {
        // 현재 선택된 차 오브젝트 비활성화
        ObjectInstance.GetCarObject(CarNum).SetActive(false);
        if (gameObject.name == "Right")
        {
            --CarNum;
            if (CarNum < 0)
                CarNum = ObjectInstance.GetCarArrayLength() - 1;
        }
        else if(gameObject.name == "Left")
        {
            ++CarNum;
            if (CarNum >= ObjectInstance.GetCarArrayLength())
                CarNum = 0;
        }
        // 다음 선택된 차 오브젝트 활성화
        ObjectInstance.GetCarObject(CarNum).SetActive(true);
    }

    public void OnGameStartButtonClick()
    {
        ObjectInstance.ActivateGameStartObjects(true);
    }
}
