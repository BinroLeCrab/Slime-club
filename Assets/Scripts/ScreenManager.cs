using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject WaitingScreen;
    [SerializeField] private GameObject PvScreen;

    // Start is called before the first frame update
    void Start()
    {
        if (WaitingScreen != null)
        {
            WaitingScreen.SetActive(true);
            Time.timeScale = 0;
        }

        if (PvScreen != null)
        {
            PvScreen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (WaitingScreen == null | PvScreen == null) { return; }

        if (PlayerManager.Instance.FirstPlayer != null && PlayerManager.Instance.SecondPlayer != null)
        {
            WaitingScreen.SetActive(false);
            PvScreen.SetActive(true);
            Time.timeScale = 1;
        }
    }
}
