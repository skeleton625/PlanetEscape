using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Cars;

    private InGameUI GameUI;
    private GameObject Planet;
    private GameObject PlayerCar;
    private PlayerController PlayerInstance;
    private PlanetController PlanetInstance;

    private void Awake()
    {
        Cars[ObjectManager.PreCarNumber].SetActive(true);
    }

    // Start is called before the first frame update
    private void Start()
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
