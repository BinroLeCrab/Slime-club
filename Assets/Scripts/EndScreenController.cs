using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenController : MonoBehaviour
{
    [Header("Won Screen Variants")]
    [SerializeField] public GameObject m_J1WonScreen;
    [SerializeField] public GameObject m_J2WonScreen;

    private void OnEnable()
    {
        if (PlayerManager.Instance == null || m_J1WonScreen == null || m_J1WonScreen == null) return;

        if (PlayerManager.Instance.FirstPlayer != null && PlayerManager.Instance.SecondPlayer != null)
        {
            // Display Won Screen variant depending on winner

            if (PlayerManager.Instance.FirstPlayer.GetScore() > PlayerManager.Instance.SecondPlayer.GetScore())
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
