using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Controllers
{
    public class LevelButtonController : MonoBehaviour
    {
        [SerializeField] Button m_Button;
        [SerializeField] TMP_Text m_Label;
        string m_SceneName;

        public void Bind(string sceneName)
        {
            m_Button.onClick.RemoveAllListeners();
            m_Button.onClick.AddListener(LoadLevel);

            m_SceneName = sceneName;
            m_Label.text = sceneName;
        }

        void LoadLevel()
        {
            SceneManager.LoadScene(m_SceneName);
        }
    }
}