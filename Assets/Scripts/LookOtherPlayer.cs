using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookOtherPlayer : MonoBehaviour
{
    [Header("3D Object")]
    [SerializeField] private PlayerController m_PlayerController;

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Instance.FirstPlayer == null | PlayerManager.Instance.SecondPlayer == null) { return; }

        if (m_PlayerController.IsPlayerOne() == true)
        {
            // Look at the second player
            transform.LookAt(PlayerManager.Instance.SecondPlayer.transform); 

            // Reset the x rotation
            Vector3 currentRotation = transform.eulerAngles;
            currentRotation.x = 0; 
            transform.eulerAngles = currentRotation;

        } 
        else if (m_PlayerController.IsPlayerOne() == false) 
        {
            // Look at the first player
            transform.LookAt(PlayerManager.Instance.FirstPlayer.transform); 

            // Reset the x rotation
            Vector3 currentRotation = transform.eulerAngles;
            currentRotation.x = 0; 
            transform.eulerAngles = currentRotation;
        }
    }
}
