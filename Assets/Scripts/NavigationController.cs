using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class NavigationController : MonoBehaviour
{
    public GlobalInput inputActions;

    [Header("Params")]
    [SerializeField] private bool m_IsMain;

    [Header("UI Object")]
    [SerializeField] private GameObject UI_Info;

    private void Awake()
    {
        inputActions = new GlobalInput(); 
    }

    private void OnEnable()
    {
        // Set input action for gamepad
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
        // Unset input action for gamepad
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

        // Back to menu
        SceneManager.LoadScene(0); 

    }

    public void ExitGame()
    {
        // Close the game
        Application.Quit();
    }

    public void LoadMain()
    {
        // Load Main Scene
        SceneManager.LoadScene("Main");
    }

    public void OpenInfo()
    {

        if (UI_Info == null) return;

        // Open/close Info popup
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

