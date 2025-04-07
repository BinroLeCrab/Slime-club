using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private PvController PvBarJ1;
    [SerializeField] private PvController PvBarJ2;
    [SerializeField] private TextMeshProUGUI LooserText;
    [SerializeField] private TextMeshProUGUI RoundText;
    [SerializeField] private int m_MaxRoundNumber;

    [SerializeField] private int m_CurrentRound;


    // Start is called before the first frame update
    void Start()
    {
        m_CurrentRound = 1;

        if (GameOverScreen != null)
        {
            GameOverScreen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Instance == null) return;
    
        if (PlayerManager.Instance.FirstPlayer != null && PlayerManager.Instance.SecondPlayer != null)
        {
            DisplayPv();
            IfPlayerKo();

            if (RoundText != null)
            {
                RoundText.text = "Manche " + m_CurrentRound;
            }
        } else
        {
            Debug.Log("Ajoutez un deuxième joueur.");
        }

    }

    private void DisplayPv()
    {
        if (PlayerManager.Instance.FirstPlayer != null && PvBarJ1 != null)
        {
            PvBarJ1.DisplayPV(PlayerManager.Instance.FirstPlayer.getPv(), PlayerManager.Instance.FirstPlayer.m_PvOrigin);
            PvBarJ1.UpdateScore(PlayerManager.Instance.FirstPlayer.getScore());
        }

        if (PlayerManager.Instance.SecondPlayer != null && PvBarJ2 != null)
        {
            PvBarJ2.DisplayPV(PlayerManager.Instance.SecondPlayer.getPv(), PlayerManager.Instance.SecondPlayer.m_PvOrigin);
            PvBarJ2.UpdateScore(PlayerManager.Instance.SecondPlayer.getScore());
        }
    }

    private void IfPlayerKo()
    {
        
        if (PlayerManager.Instance.FirstPlayer.getPv() <= 0 || PlayerManager.Instance.SecondPlayer.getPv() <= 0)
        {
            if (m_CurrentRound >= m_MaxRoundNumber)
            {
                gameOver();
            } 
            else if (PlayerManager.Instance.FirstPlayer.getPv() <= 0)
            {
                Debug.Log("Joueur 1 KO");
                LooserText.text = "Joueur 1 KO";
                PlayerManager.Instance.FirstPlayer.restart(false);
                PlayerManager.Instance.SecondPlayer.restart(true);
            }
            else
            {
                Debug.Log("Joueur 2 KO");
                LooserText.text = "Joueur 2 KO";
                PlayerManager.Instance.FirstPlayer.restart(true);
                PlayerManager.Instance.SecondPlayer.restart(false);
            }

            if (m_CurrentRound < m_MaxRoundNumber)
            { 
                m_CurrentRound++;
            }

        }
    }

    private void gameOver()
    {

        if (PlayerManager.Instance.FirstPlayer.getPv() <= 0)
        {
            Debug.Log("Joueur 1 KO");
            LooserText.text = "Joueur 1 KO";
        }
        else
        {
            Debug.Log("Joueur 2 KO");
            LooserText.text = "Joueur 2 KO";
        }

        GameOverScreen.SetActive(true);
        Time.timeScale = 0;

        // Réactive la souris
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
