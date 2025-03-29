using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookOtherPlayer : MonoBehaviour
{
    [SerializeField] private PlayerController m_PlayerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerManager.Instance.FirstPlayer == null | PlayerManager.Instance.SecondPlayer == null) { return; }

        if (m_PlayerController.isPlayerOne() == true)
        {
            transform.LookAt(PlayerManager.Instance.SecondPlayer.transform); // Look at the second player

            Vector3 currentRotation = transform.eulerAngles;
            currentRotation.x = 0; // Reset the x rotation
            transform.eulerAngles = currentRotation;
        } else if (m_PlayerController.isPlayerOne() == false) {
            transform.LookAt(PlayerManager.Instance.FirstPlayer.transform); // Look at the first player

            Vector3 currentRotation = transform.eulerAngles;
            currentRotation.x = 0; // Reset the x rotation
            transform.eulerAngles = currentRotation;
        }
    }
}
