using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenController : MonoBehaviour
{
    [SerializeField] public GameObject m_J1WonScreen;
    [SerializeField] public GameObject m_J2WonScreen;
    private void OnEnable()
    {
        if (PlayerManager.Instance == null || m_J1WonScreen == null || m_J1WonScreen == null) return;


        if (PlayerManager.Instance.FirstPlayer != null && PlayerManager.Instance.SecondPlayer != null)
        {
            if (PlayerManager.Instance.FirstPlayer.getScore() > PlayerManager.Instance.SecondPlayer.getScore())
            {
                m_J1WonScreen.SetActive(true);
                m_J2WonScreen.SetActive(false);
            }
            else
            {
                m_J1WonScreen.SetActive(false);
                m_J2WonScreen.SetActive(true);
            }
        }
    }
}
