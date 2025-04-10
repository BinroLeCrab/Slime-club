using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StartButton : MonoBehaviour
{
    public GlobalInput inputActions;

    [Header("UI Objects")]
    [SerializeField] private GameObject WaitingScreen;
    [SerializeField] private GameObject PvScreen;

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
        if (PlayerManager.Instance.FirstPlayer != null && PlayerManager.Instance.SecondPlayer != null) // If 2 players exist
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        if (WaitingScreen != null && PvScreen != null)
        {
            // Resume game
            Time.timeScale = 1; 

            // Manage UI
            WaitingScreen.SetActive(false);
            PvScreen.SetActive(true);

            // Hidden mouse
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Set players at spawn position
            PlayerManager.Instance.FirstPlayer.SetSpawn();
            PlayerManager.Instance.SecondPlayer.SetSpawn();
        }
    }
}
