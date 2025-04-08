using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class NavigationController : MonoBehaviour
{
    public GlobalInput inputActions;

    [SerializeField] private bool m_IsMain;

    private void Awake()
    {
        inputActions = new GlobalInput(); 
    }

    private void OnEnable()
    {
        inputActions.Player.Escape.Enable();
        inputActions.Player.Escape.performed += OnEscape;
    }

    private void OnDisable()
    {
        inputActions.Player.Escape.Disable();
        inputActions.Player.Escape.performed -= OnEscape;
    }

    private void OnEscape(InputAction.CallbackContext context)
    {
        if (m_IsMain) { 
            BackToMenu();
        } else
        {
            ExitGame();
        }
    }

    public void BackToMenu()
    {
        
        Debug.Log("Retour au menu !");
        SceneManager.LoadScene(0); 
        //Time.timeScale = 0;

        //if (CharacterManager.CharacterInstance != null)
        //{
        //    Destroy(CharacterManager.CharacterInstance.gameObject);
        //}

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

