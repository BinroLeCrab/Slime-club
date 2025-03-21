using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private const string SCORE_FORMAT = "Score: {0}/{1}";

    [SerializeField] private TextMeshProUGUI m_ScoreLabel;

    private void OnEnable()
    {
        ScoreManager.Instance.ScoreChanged += UpdateScoreDisplay;
    }

    private void OnDisable()
    {
        ScoreManager.Instance.ScoreChanged -= UpdateScoreDisplay;
    }

    private void Start()
    {
        UpdateScoreDisplay();
    }

    public void UpdateScoreDisplay()
    {
        Debug.Log("MAX:" + ScoreManager.Instance.MaxScore);
        m_ScoreLabel.text = string.Format(SCORE_FORMAT, ScoreManager.Instance.Score, ScoreManager.Instance.MaxScore);
    }
}