using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InGameUI GameUI;
    private GameObject Planet;
    private GameObject PlayerCar;
    private PlayerController PlayerInstance;

    // Start is called before the first frame update
    void Start()
    {
        GameUI = GetComponent<InGameUI>();
        PlayerCar = GameObject.Find("PlayerCar");
        PlayerInstance = PlayerCar.GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if(!PlayerInstance.PlayerDead)
            GameUI.PrintPlanetRadius();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if(PlayerInstance.PlayerDead)
        {
        }
    }
}
