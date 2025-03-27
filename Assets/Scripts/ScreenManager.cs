using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject WaitingScreen;
    [SerializeField] private GameObject PvScreen;
    [SerializeField] private GameObject StartButton;

    private WaitingScreenController m_WaitingScreenJ1;
    private WaitingScreenController m_WaitingScreenJ2;

    private bool m_IsSecondPlayerReady = false;

    // Start is called before the first frame update
    void Start()
    {
        if (WaitingScreen != null)
        {
            WaitingScreen.SetActive(true);
            Time.timeScale = 0;
            m_WaitingScreenJ1 = WaitingScreen.transform.Find("J1 Wainting Screen").GetComponent<WaitingScreenController>();
            m_WaitingScreenJ2 = WaitingScreen.transform.Find("J2 Wainting Screen").GetComponent<WaitingScreenController>();

            // Réactive la souris
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (PvScreen != null)
        {
            PvScreen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (WaitingScreen == null | PvScreen == null | m_WaitingScreenJ1 == null | m_WaitingScreenJ2 == null) { return; }

        if (PlayerManager.Instance.FirstPlayer != null)
        {
            m_WaitingScreenJ1.m_WaitingText.SetActive(false);
            m_WaitingScreenJ1.m_SpriteSlime.SetActive(true);
            m_WaitingScreenJ1.SetDeviceIcon(PlayerManager.Instance.FirstPlayer.getDevice());

            m_WaitingScreenJ2.GetComponent<CanvasGroup>().alpha = 1;

            if (PlayerManager.Instance.SecondPlayer != null)
            {
                m_WaitingScreenJ2.m_WaitingText.SetActive(false);
                m_WaitingScreenJ2.m_SpriteSlime.SetActive(true);
                m_WaitingScreenJ2.SetDeviceIcon(PlayerManager.Instance.SecondPlayer.getDevice());
                m_IsSecondPlayerReady = true;
                StartButton.SetActive(true);
            }
            
        }
    }
}
