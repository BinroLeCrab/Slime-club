using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StartButton : MonoBehaviour
{
    public GlobalInput inputActions;

    [SerializeField] private GameObject WaitingScreen;
    [SerializeField] private GameObject PvScreen;

    private void Awake()
    {
        inputActions = new GlobalInput();
    }

    private void OnEnable()
    {
        inputActions.Navigation.EnterGame.Enable();
        inputActions.Navigation.EnterGame.performed += OnEnterGame;
    }

    private void OnDisable()
    {
        inputActions.Navigation.EnterGame.Disable();
        inputActions.Navigation.EnterGame.performed -= OnEnterGame;
    }

    private void OnEnterGame(InputAction.CallbackContext context)
    {
        if (PlayerManager.Instance.FirstPlayer != null && PlayerManager.Instance.SecondPlayer != null)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        if (WaitingScreen != null && PvScreen != null)
        {
            Time.timeScale = 1;
            WaitingScreen.SetActive(false);
            PvScreen.SetActive(true);
            // Cache la souris
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            PlayerManager.Instance.FirstPlayer.setSpawn();
            PlayerManager.Instance.SecondPlayer.setSpawn();
        }
    }
}
