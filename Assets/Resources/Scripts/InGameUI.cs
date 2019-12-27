using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOverUI;
    [SerializeField]
    private GameObject RadiusUI;
    [SerializeField]
    private Text RadiusValue;
    [SerializeField]
    private Text LastRadius;

    private GameObject Planet;

    // Start is called before the first frame update
    void Start()
    {
        Planet = GameObject.Find("Planet");
    }

    public void PrintPlanetRadius()
    {
        RadiusValue.text = 
            string.Format("{0:F1}", Planet.transform.localScale.x) + " M";
    }

    public void ActivateGameOverUI()
    {
        RadiusUI.SetActive(false);
        LastRadius.text = RadiusValue.text;
        GameOverUI.SetActive(true);
    }
}
