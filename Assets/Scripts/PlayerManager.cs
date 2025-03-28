using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float m_PvOrigin;
    [SerializeField] private Transform m_FirstPlayerPosition;
    [SerializeField] private Transform m_SecondPlayerPosition;

    public static PlayerManager Instance { get; private set; }
    public PlayerController FirstPlayer { get; private set; }
    public PlayerController SecondPlayer { get; private set; }

    private PlayerInputManager m_playerInputManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        m_playerInputManager = GetComponent<PlayerInputManager>();
    }

    public void OnEnable()
    {
        if (m_playerInputManager != null)
        {
            m_playerInputManager.onPlayerJoined += OnPlayerJoined;
        }
    }

    public void OnDisable()
    {
        if (m_playerInputManager != null)
        {
            m_playerInputManager.onPlayerJoined -= OnPlayerJoined;
        }
    }

    private void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Player Joined");

        string deviceType = playerInput.currentControlScheme;
        Debug.Log($"Joueur rejoint avec : {deviceType}");

        if (FirstPlayer == null)
        {
            FirstPlayer = playerInput.GetComponent<PlayerController>();
            FirstPlayer.initPlayer(m_PvOrigin, "J1", "Red", deviceType, m_FirstPlayerPosition.position);
        }
        else if (SecondPlayer == null)
        {
            SecondPlayer = playerInput.GetComponent<PlayerController>();
            SecondPlayer.initPlayer(m_PvOrigin, "J2", "Blue", deviceType, m_SecondPlayerPosition.position);
        }
        else
        {
            Debug.LogError("Nombre maximum de joueur : 2 !");
        }
    }
}
