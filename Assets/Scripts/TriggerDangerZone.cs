using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TriggerDangerZone : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float m_Damage;

    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter(Collider other)
    {
        GameObject currentObject = other.gameObject;
        if (currentObject.tag == PLAYER_TAG)
        {
            currentObject.GetComponent<PlayerController>().TakeDamage(m_Damage, transform.position, 0, 0); //Inflict damage on currentplayer
            currentObject.GetComponent<PlayerController>().SetSpawn(); //Respawn player
        }
    }
}
