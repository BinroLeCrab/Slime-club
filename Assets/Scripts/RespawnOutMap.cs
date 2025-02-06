using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class RespawnOutMap : MonoBehaviour
{
    
    [SerializeField] private float m_Threshold;

    Vector3 m_Origin;
    CharacterController m_CharacterController;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        m_Origin = transform.position;
    }

    private void Update()
    {
        //Détecte quand le joueur sort de la map
        if (transform.position.y < m_Threshold)
        {
            //L'affiche dans un Debug.Log
            Debug.Log("Sortie de la map.");
            Respawn();
        }
    }

    public void OnRespawn(InputValue value)
    {
        Debug.Log("OnRespawn");
        Respawn();
    }

    private void Respawn()
    {
        m_CharacterController.enabled = false;
        transform.position = m_Origin;
        m_CharacterController.enabled = true;
    }
}


//[SerializeField] private string m_MyMessage;

//public string MyMessage
//{
//    get { return m_MyMessage; }
//    private set { m_MyMessage = value; }
//}

//void Awake()
//{
//    Debug.Log(m_MyMessage);
//}

//// Start is called before the first frame update
//void Start()
//{
//    Debug.Log("Start");
//}

//// Update is called once per frame
//void Update()
//{
//    Debug.Log("Update " + Time.deltaTime);
//}

//void FixedUpdate()
//{
//    Debug.Log("FixedUpdate " + Time.deltaTime);
//}

//-------------------