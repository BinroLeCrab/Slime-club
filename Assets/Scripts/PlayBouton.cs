using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayBouton : MonoBehaviour
{
    [SerializeField] private string m_SceneName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(m_SceneName);
    }
}
