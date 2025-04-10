using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundManager : MonoBehaviour
{
    [Header("Round")]
    [SerializeField] private int m_MaxRoundNumber;
    [SerializeField] private int m_CurrentRound;

    [Header("UI Objects")]
    [SerializeField] private GameObject EndScreen;
    [SerializeField] private GameObject PvScreen;
    [SerializeField] private TextMeshProUGUI RoundText;
    [SerializeField] private PvController PvBarJ1;
    [SerializeField] private PvController PvBarJ2;

    [Header("Audio")]
    [SerializeField] private AudioSource m_Sound;

    void Start()
    {
        m_CurrentRound = 1; // Set round at 1

        if (EndScreen != null)
        {
            EndScreen.SetActive(false);
        }
    }

    void Update()
    {
        if (PlayerManager.Instance == null) return;
    
        if (PlayerManager.Instance.FirstPlayer != null && PlayerManager.Instance.SecondPlayer != null)
        {
            DisplayPv();
            IfPlayerKo();

            if (RoundText != null)
            {
                // Display Round number
                RoundText.text = "Manche " + m_CurrentRound;
            }
        }

    }

    private void DisplayPv()
    {
        // Display Players PV & Score

        if (PlayerManager.Instance.FirstPlayer != null && PvBarJ1 != null)
        {
            PvBarJ1.DisplayPV(PlayerManager.Instance.FirstPlayer.GetPv(), PlayerManager.Instance.FirstPlayer.m_PvOrigin);
            PvBarJ1.UpdateScore(PlayerManager.Instance.FirstPlayer.GetScore());
        }

        if (PlayerManager.Instance.SecondPlayer != null && PvBarJ2 != null)
        {
            PvBarJ2.DisplayPV(PlayerManager.Instance.SecondPlayer.GetPv(), PlayerManager.Instance.SecondPlayer.m_PvOrigin);
            PvBarJ2.UpdateScore(PlayerManager.Instance.SecondPlayer.GetScore());
        }
    }

    private void IfPlayerKo()
    {
        // Check if one player is KO

        if (PlayerManager.Instance.FirstPlayer.GetPv() <= 0 || PlayerManager.Instance.SecondPlayer.GetPv() <= 0)
        {
            // Set stats for players and restart

            if (PlayerManager.Instance.FirstPlayer.GetPv() <= 0)
            {
                PlayerManager.Instance.FirstPlayer.Restart(false);
                PlayerManager.Instance.SecondPlayer.Restart(true);
            }
            else
            {
                PlayerManager.Instance.FirstPlayer.Restart(true);
                PlayerManager.Instance.SecondPlayer.Restart(false);
            }

            if (m_CurrentRound >= m_MaxRoundNumber)
            {
                // Stop game if max round
                GameEnd();
            }

            else if (m_CurrentRound < m_MaxRoundNumber)
            { 
                // Increment round and play sound
                m_CurrentRound++;
                if (m_Sound != null) m_Sound.Play();
            }

        }
    }

    private void GameEnd()
    {
        if (EndScreen == null || PvScreen == null) return;

        // Manage UI
        EndScreen.SetActive(true);
        PvScreen.SetActive(false);

        // Stop game
        Time.timeScale = 0;

        // Show Mouse
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
