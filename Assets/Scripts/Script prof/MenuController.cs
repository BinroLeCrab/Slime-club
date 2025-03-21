using Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] LevelButtonController m_ButtonPrefab;
    [SerializeField] Transform m_Root;

    [Header("Properties")]
    [SerializeField] int m_FirstSceneIndex = 1;
    private void Awake()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        for (int i = m_FirstSceneIndex; i < sceneCount; i++)
        {
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            LevelButtonController button = Instantiate<LevelButtonController>(m_ButtonPrefab, m_Root);
            button.Bind(sceneName);
        }
    }
}
