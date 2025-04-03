using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TriggerDangerZone : MonoBehaviour
{
    [SerializeField] private float m_Damage;

    private const string PLAYER_TAG = "Player";
    private GameObject currentOject;

    private void OnTriggerEnter(Collider other)
    {
        currentOject = other.gameObject;
        if (currentOject.tag == PLAYER_TAG)
        {
            Debug.Log("Player entre dans la zone dangereuse");
            currentOject.GetComponent<PlayerController>().TakeDamage(m_Damage, transform.position, 0, 0);
            currentOject.GetComponent<PlayerController>().setSpawn();
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
