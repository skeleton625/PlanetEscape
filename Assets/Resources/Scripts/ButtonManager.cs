using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private bool IsMenu;
    private ObjectManager ObjectInstance;
    private MenuGameUI UIInstance;
    private GameObject Objects;
    private void Awake()
    {
        if(IsMenu)
        {
            Objects = GameObject.Find("ObjectManager");
            UIInstance = Objects.GetComponent<MenuGameUI>();
            ObjectInstance = Objects.GetComponent<ObjectManager>();
        }
    }

    public void OnArrowButtonClick()
    {
        if (gameObject.name == "Right")
            ObjectInstance.SelectCarObject(true);
        else if(gameObject.name == "Left")
            ObjectInstance.SelectCarObject(false);
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
