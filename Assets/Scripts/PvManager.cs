using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PvManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private TextMeshProUGUI PvText;

    private GameObject PlayerOne;
    private PlayerManger PlayerOneManager;

    // Start is called before the first frame update
    void Start()
    {
        PlayerOne = GameObject.FindWithTag("Player");
        if (PlayerOne != null)
        {
            PlayerOneManager = PlayerOne.GetComponent<PlayerManger>();
            Debug.Log("PV du joueur :" + PlayerOneManager.getPv());
        }
        else
        {
            Debug.Log("Joueur non trouvé");
        }
    }

    // Update is called once per frame
    void Update()
    {
        DisplayPv();
        IfGameOver();
    }

    private void DisplayPv()
    {
        if (PlayerOneManager != null && PvText != null)
        {
            PvText.text = PlayerOneManager.getPv() + " pv";
        }
    }

    private void IfGameOver()
    {
        if (PlayerOneManager.getPv() <= 0)
        {
            Debug.Log("Joueur KO");
            GameOverScreen.SetActive(true);
            Time.timeScale = 0;

            // Réactive la souris
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Debug.Log("PV du joueur :" + PlayerOneManager.getPv());
            GameOverScreen.SetActive(false);
            Time.timeScale = 1;

            // Cache la souris
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
