using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PvManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
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
            Debug.Log("Joueur non trouvé");
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
            Debug.Log("Ajoutez un deuxième joueur.");
        }
    }

    private void DisplayPv()
    {
        if (PlayerManager.Instance.FirstPlayer != null && FirstPlayerPvText != null)
        {
            FirstPlayerPvText.text = "J1: " + PlayerManager.Instance.FirstPlayer.getPv() + " pv";
        }

        if (PlayerManager.Instance.SecondPlayer != null && SecondPlayerPvText != null)
        {
            SecondPlayerPvText.text = "J2: " + PlayerManager.Instance.SecondPlayer.getPv() + " pv";
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

            // Réactive la souris
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Debug.Log("PV du joueur :" + PlayerManager.Instance.FirstPlayer.getPv());
            GameOverScreen.SetActive(false);
            Time.timeScale = 1;

            // Cache la souris
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
