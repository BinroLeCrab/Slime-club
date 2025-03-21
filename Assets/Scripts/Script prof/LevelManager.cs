using UnityEngine.SceneManagement;

public class LevelManager
{
    #region Singleton
    private static LevelManager m_Instance;

    public static LevelManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new LevelManager();
            }

            return m_Instance;
        }
    }
    #endregion

    public void LoadNextLevel()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        int nextLevelIndex = activeScene.buildIndex + 1;

        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
            ScoreManager.Instance.Reset();
        }
        else
        {
            UnityEngine.Debug.LogErrorFormat("Can't find any level with index {0}. Please add one to the Build Settings", nextLevelIndex);
        }
    }
}