using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartGame()
    {
        Debug.Log("coucou");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
