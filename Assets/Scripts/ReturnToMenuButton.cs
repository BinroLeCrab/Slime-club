using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenuButton : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0); //Charge la scène du menu principal

    }
}
