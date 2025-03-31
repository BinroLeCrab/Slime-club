using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject WaitingScreen;
    [SerializeField] private GameObject PvScreen;

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
