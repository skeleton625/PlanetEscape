using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InGameUI GameUI;
    private PlayerController PlayerInstance;
    private PlanetController PlanetInstance;



    // Start is called before the first frame update
    private void Awake()
    {
        GameUI = GetComponent<InGameUI>();
    }

    private void Start()
    {
        ObjectManager.instance.GetActivateCarObject();
        PlanetInstance = GameObject.Find("Planet").GetComponent<PlanetController>();
        PlayerInstance = GameObject.Find("PlayerCar").GetComponent<PlayerController>();
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
