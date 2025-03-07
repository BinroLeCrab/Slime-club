using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvManager : MonoBehaviour
{

    [SerializeField] private float m_PvOrigin;
    [SerializeField] private GameObject GameOverScreen;

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
        if (m_PvOrigin <= 0)
        {
            Debug.Log("Joueur KO");
            GameOverScreen.SetActive(true);
            Time.timeScale = 0;
        } else {
            Debug.Log("PV du joueur :" + m_PvOrigin);
        }
    }
}
