using System;

public class ScoreManager
{
    #region Singleton
    private static ScoreManager m_Instance;

    public static ScoreManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new ScoreManager();
            }

            return m_Instance;
        }
    }
    #endregion

    public Action ScoreChanged;

    public int Score { get; private set; }
    public int MaxScore => CollectibleController.COUNT;

    public void AddScore()
    {
        Score++;
        ScoreChanged?.Invoke();
    }

    public void Reset()
    {
        Score = 0;
    }
}