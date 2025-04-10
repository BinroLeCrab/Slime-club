using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class NavigationController : MonoBehaviour
{
    public GlobalInput inputActions;

    [SerializeField] private bool m_IsMain;

    [Header("UI Element")]
    [SerializeField] private GameObject UI_Info;

    private void Awake()
    {
        inputActions = new GlobalInput(); 
    }

    private void OnEnable()
    {
        inputActions.Navigation.Escape.Enable();
        inputActions.Navigation.Escape.performed += OnEscape;
        inputActions.Navigation.EnterGame.Enable();
        inputActions.Navigation.EnterGame.performed += OnEnterGame;

        if (m_IsMain == false)
        {
            inputActions.Navigation.Info.Enable();
            inputActions.Navigation.Info.performed += OnInfo;
        }
    }

    private void OnDisable()
    {
        inputActions.Navigation.Escape.Disable();
        inputActions.Navigation.Escape.performed -= OnEscape;
        inputActions.Navigation.EnterGame.Disable();
        inputActions.Navigation.EnterGame.performed -= OnEnterGame;

        if (m_IsMain == false)
        {
            inputActions.Navigation.Info.Disable();
            inputActions.Navigation.Info.performed -= OnInfo;
        }
    }

    private void OnEscape(InputAction.CallbackContext context)
    {
        if (m_IsMain)
        {
            BackToMenu();
        }
        else
        {
            ExitGame();
        }
    }

    private void OnEnterGame(InputAction.CallbackContext context)
    {
        if (m_IsMain == false)
        {
            LoadMain();
        }
    }

    private void OnInfo(InputAction.CallbackContext context)
    {
        OpenInfo();
    }

    public void BackToMenu()
    {
        // Reactive cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("Retour au menu !");
        // Back to menu
        SceneManager.LoadScene(0); 

    }

    public void ExitGame()
    {
        Debug.Log("Quitte le jeu !");
        Application.Quit();
    }

    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void OpenInfo()
    {

        if (UI_Info == null) return;

        Debug.Log("info trouvé");

        if (UI_Info.gameObject.activeSelf == false)
        {
            UI_Info.gameObject.SetActive(true);
        }
        else
        {
            UI_Info.gameObject.SetActive(false);
        }
    }

}

