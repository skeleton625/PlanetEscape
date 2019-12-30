using UnityEngine;

public class MenuGameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject StartGameObjects;
    [SerializeField]
    private GameObject StartUI;
    [SerializeField]
    private GameObject ChooseGameObjects;
    [SerializeField]
    private GameObject ChooseUI;

    public void ActivateGameStartObjects(bool activate)
    {
        if (activate)
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
