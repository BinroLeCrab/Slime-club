using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PvManager : MonoBehaviour
{

    [SerializeField] private float m_PvOrigin;

    Vector3 m_Origin;
    CharacterController m_CharacterController;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PV du joueur :" + m_PvOrigin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
