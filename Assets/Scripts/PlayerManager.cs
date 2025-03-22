using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float m_PvOrigin;

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

        if (FirstPlayer == null)
        {
            FirstPlayer = playerInput.GetComponent<PlayerController>();
            FirstPlayer.initPlayer(m_PvOrigin, "J1", "Red");
        }
        else if (SecondPlayer == null)
        {
            SecondPlayer = playerInput.GetComponent<PlayerController>();
            SecondPlayer.initPlayer(m_PvOrigin, "J2", "Blue");
        }
        else
        {
            Debug.LogError("Nombre maximum de joueur : 2 !");
        }
    }
}
