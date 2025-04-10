using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PvController : MonoBehaviour
{
    [Header("UI Objects")]
    [SerializeField] private Image m_PvBar;
    [SerializeField] private TextMeshProUGUI m_PvBarText;
    [SerializeField] private GameObject m_Score;

    public void DisplayPV (float actualPv, float originPv)
    {
        m_PvBarText.text = actualPv.ToString() + "/" + originPv.ToString();
        m_PvBar.fillAmount = actualPv / originPv;
    }

    public void UpdateScore(int score)
    {
        // Display a number of icon depending on score
        if (score >= 1)
        {
            Debug.Log("Score 1");
            m_Score.transform.Find("Score 1").gameObject.SetActive(true);
        }
        if (score >= 2)
        {
            Debug.Log("Score 2");
            m_Score.transform.Find("Score 2").gameObject.SetActive(true);
        }
        if (score >= 3)
        {
            Debug.Log("Score 3");
            m_Score.transform.Find("Score 3").gameObject.SetActive(true);
        }
    }
}
