using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PvManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private PvController PvBarJ1;
    [SerializeField] private PvController PvBarJ2;
    [SerializeField] private TextMeshProUGUI LooserText;
    [SerializeField] private TextMeshProUGUI FirstPlayerPvText;
    [SerializeField] private TextMeshProUGUI SecondPlayerPvText;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerManager.Instance.FirstPlayer != null)
        {
            Debug.Log("PV du joueur 1 :" + PlayerManager.Instance.FirstPlayer.getPv());
        }
        else
        {
            Debug.Log("Joueur non trouv�");
        }

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
            IfGameOver();
        } else
        {
            Debug.Log("Ajoutez un deuxi�me joueur.");
        }
    }

    private void DisplayPv()
    {
        if (PlayerManager.Instance.FirstPlayer != null && PvBarJ1 != null)
        {
            PvBarJ1.DisplayPV(PlayerManager.Instance.FirstPlayer.getPv(), PlayerManager.Instance.FirstPlayer.m_PvOrigin);
        }

        if (PlayerManager.Instance.SecondPlayer != null && PvBarJ2 != null)
        {
            PvBarJ2.DisplayPV(PlayerManager.Instance.SecondPlayer.getPv(), PlayerManager.Instance.SecondPlayer.m_PvOrigin);
        }
    }

    private void IfGameOver()
    {
        if (PlayerManager.Instance.FirstPlayer.getPv() <= 0 || PlayerManager.Instance.SecondPlayer.getPv() <= 0)
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

            // R�active la souris
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
