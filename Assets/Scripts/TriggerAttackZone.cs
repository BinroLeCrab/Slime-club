using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TriggerAttackZone : MonoBehaviour
{
    [SerializeField] private float m_Damage;
    [SerializeField] private GameObject m_Me;

    private const string PLAYER_TAG = "Player";
    private GameObject currentOject;
    private PlayerController currentPlayer;
    

    private void OnTriggerEnter(Collider other)
    {
        currentOject = other.gameObject;
        if (currentOject.tag == PLAYER_TAG && currentOject.GetComponent<PlayerController>() != m_Me.GetComponent<PlayerController>())
        {
            currentPlayer = currentOject.GetComponent<PlayerController>();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        currentOject = other.gameObject;
        if (currentOject.tag == PLAYER_TAG && currentOject.GetComponent<PlayerController>() != m_Me.GetComponent<PlayerController>())
        {
            currentPlayer = null;
        }
    }

    public PlayerController getCurrentPlayer()
    {
        return currentPlayer;
    }
}
