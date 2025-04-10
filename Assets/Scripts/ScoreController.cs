using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [Header("UI Objects")]
    [SerializeField] private TextMeshProUGUI m_ScoreLabelJ1;
    [SerializeField] private TextMeshProUGUI m_ScoreLabelJ2;

    void Update()
    {
        if (PlayerManager.Instance == null) return;

        if (PlayerManager.Instance.FirstPlayer != null && PlayerManager.Instance.SecondPlayer != null)
        {
            m_ScoreLabelJ1.text = PlayerManager.Instance.FirstPlayer.GetScore().ToString();
            m_ScoreLabelJ2.text = PlayerManager.Instance.SecondPlayer.GetScore().ToString();
        }
    }
}