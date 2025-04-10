using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ScreenManager : MonoBehaviour
{
    [Header("UI Objects")]
    [SerializeField] private GameObject WaitingScreen;
    [SerializeField] private GameObject PvScreen;
    [SerializeField] private GameObject StartButton;

    private WaitingScreenController m_WaitingScreenJ1;
    private WaitingScreenController m_WaitingScreenJ2;

    void Start()
    {
        if (WaitingScreen != null)
        {
            WaitingScreen.SetActive(true);

            m_WaitingScreenJ1 = WaitingScreen.transform.Find("J1 Wainting Screen").GetComponent<WaitingScreenController>();
            m_WaitingScreenJ2 = WaitingScreen.transform.Find("J2 Wainting Screen").GetComponent<WaitingScreenController>();

            // Stop game
            Time.timeScale = 0;

            // Show Mouse
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (PvScreen != null)
        {
            PvScreen.SetActive(false);
        }
    }

    void Update()
    {
        if (WaitingScreen == null | PvScreen == null | m_WaitingScreenJ1 == null | m_WaitingScreenJ2 == null) { return; }

        if (WaitingScreen.activeSelf)
        {
            // Show Mouse
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (PlayerManager.Instance.FirstPlayer != null)
        {
            // If Player 1 initialised

            // Manage UI
            m_WaitingScreenJ1.m_WaitingText.SetActive(false);
            m_WaitingScreenJ1.m_SpriteSlime.SetActive(true);
            m_WaitingScreenJ1.SetDeviceIcon(PlayerManager.Instance.FirstPlayer.GetDevice());

            m_WaitingScreenJ2.GetComponent<CanvasGroup>().alpha = 1;

            if (PlayerManager.Instance.SecondPlayer != null)
            {
                // If Player 2 initialised

                m_WaitingScreenJ2.m_WaitingText.SetActive(false);
                m_WaitingScreenJ2.m_SpriteSlime.SetActive(true);
                m_WaitingScreenJ2.SetDeviceIcon(PlayerManager.Instance.SecondPlayer.GetDevice());

                // Show Start Button
                StartButton.SetActive(true);
            }
        }
    }
}
