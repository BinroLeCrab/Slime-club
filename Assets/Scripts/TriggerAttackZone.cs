using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TriggerAttackZone : MonoBehaviour
{
    [SerializeField] private float m_Damage;
    [SerializeField] private GameObject m_Me;

    private const string PLAYER_TAG = "Player";

    private GameObject currentObject;
    private PlayerController currentPlayer;

    private void OnTriggerEnter(Collider other)
    {
        currentObject = other.gameObject;
        if (currentObject.tag == PLAYER_TAG && currentObject.GetComponent<PlayerController>() != m_Me.GetComponent<PlayerController>())
        {
            // If enter object is a player and not me, set as current
            currentPlayer = currentObject.GetComponent<PlayerController>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentObject = other.gameObject;
        if (currentObject.tag == PLAYER_TAG && currentObject.GetComponent<PlayerController>() != m_Me.GetComponent<PlayerController>())
        {
            // If exit object is a player and not me, unset as current
            UnsetCurrentPlayer();
        }
    }

    public PlayerController GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public void UnsetCurrentPlayer()
    {
        currentPlayer = null;
    }
}
