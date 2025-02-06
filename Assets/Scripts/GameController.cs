using UnityEngine;

public class GameController : MonoBehaviour
{
    private void OnEnable()
    {
        ScoreManager.Instance.ScoreChanged += CheckLevelCompletion;
    }

    private void OnDisable()
    {
        ScoreManager.Instance.ScoreChanged -= CheckLevelCompletion;
    }

    private void CheckLevelCompletion()
    {
        if (ScoreManager.Instance.Score < ScoreManager.Instance.MaxScore)
        {
            return;
        }

        LevelManager.Instance.LoadNextLevel();
    }
}