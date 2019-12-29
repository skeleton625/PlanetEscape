using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InGameUI GameUI;
    private GameObject Planet;
    private GameObject PlayerCar;
    private PlayerController PlayerInstance;
    private PlanetController PlanetInstance;

    // Start is called before the first frame update
    void Start()
    {
        GameUI = GetComponent<InGameUI>();
        Planet = GameObject.Find("Planet");
        PlayerCar = GameObject.Find("PlayerCar");
        PlanetInstance = Planet.GetComponent<PlanetController>();
        PlayerInstance = PlayerCar.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!PlayerInstance.PlayerDead)
        {
            GameUI.PrintPlanetRadius();
            PlanetInstance.ShrinkingPlanet();
        }
        else
        {
            GameUI.ActivateGameOverUI();
            PlanetInstance.StopMeteoCoroutine();
        }   
    }
}
