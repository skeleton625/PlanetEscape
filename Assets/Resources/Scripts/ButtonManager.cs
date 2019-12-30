using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private bool IsMenu;
    private ObjectManager ObjectInstance;
    private MenuGameUI UIInstance;
    private void Awake()
    {
        if(IsMenu)
        {
            GameObject _manager = GameObject.Find("ObjectManager");
            UIInstance = _manager.GetComponent<MenuGameUI>();
            ObjectInstance = _manager.GetComponent<ObjectManager>();
        }
    }

    public void OnArrowButtonClick()
    {
        if (gameObject.name == "Right")
            ObjectInstance.ActivateCarObject(true);
        else if(gameObject.name == "Left")
            ObjectInstance.ActivateCarObject(false);
    }

    public void OnGameStartButtonClick()
    {
        UIInstance.ActivateGameStartObjects(true);
    }

    public void InGameStartButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void InMenuStartButtonClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
