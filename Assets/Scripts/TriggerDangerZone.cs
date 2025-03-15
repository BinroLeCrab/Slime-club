using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TriggerDangerZone : MonoBehaviour
{
    [SerializeField] private float m_Damage;

    private const string PLAYER_TAG = "Player";
    private GameObject currentOject;
    private float m_NewPv;

    private void OnTriggerEnter(Collider other)
    {
        currentOject = other.gameObject;
        if (currentOject.tag == PLAYER_TAG)
        {
            Debug.Log("Player entre dans la zone dangereuse");
            m_NewPv = currentOject.GetComponent<PlayerManger>().getPv() - m_Damage;
            currentOject.GetComponent<PlayerManger>().setPv(m_NewPv);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == PLAYER_TAG)
        {
            Debug.Log("Player quitte la zone du dangereuse");
        }
    }
}
