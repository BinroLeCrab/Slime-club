using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class RestartButton : MonoBehaviour
{
    public GlobalInput inputActions;

    private void Awake()
    {
        inputActions = new GlobalInput();
    }

    private void OnEnable()
    {
        // Set input action for gamepad
        inputActions.Navigation.EnterGame.Enable();
        inputActions.Navigation.EnterGame.performed += OnEnterGame;
    }

    private void OnDisable()
    {
        // Unset input action for gamepad
        inputActions.Navigation.EnterGame.Disable();
        inputActions.Navigation.EnterGame.performed -= OnEnterGame;
    }

    private void OnEnterGame(InputAction.CallbackContext context)
    {
        if (PlayerManager.Instance.FirstPlayer != null && PlayerManager.Instance.SecondPlayer != null)
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the Scene at the start
    }
}
