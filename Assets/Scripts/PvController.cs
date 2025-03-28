using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PvController : MonoBehaviour
{
    [SerializeField] private Image m_PvBar;
    [SerializeField] private TextMeshProUGUI m_PvBarText;

    public void DisplayPV (float actualPv, float originPv)
    {
        m_PvBarText.text = actualPv.ToString() + "/" + originPv.ToString();
        m_PvBar.fillAmount = actualPv / originPv;
    }
}
