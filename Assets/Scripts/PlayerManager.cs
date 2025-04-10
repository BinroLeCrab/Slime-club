using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Header("Input Manager")]
    [SerializeField] private PlayerInputManager m_playerInputManager;

    [Header("PV")]
    [SerializeField] private float m_PvOrigin;

    [Header("Spawn position")]
    [SerializeField] private Transform m_FirstPlayerPosition;
    [SerializeField] private Transform m_SecondPlayerPosition;

    [Header("Spawn audio")]
    [SerializeField] private AudioSource m_Sound;

    // Create a instance
    public static PlayerManager Instance { get; private set; }
    public PlayerController FirstPlayer { get; private set; }
    public PlayerController SecondPlayer { get; private set; }

    private void Awake()
    {
        // Set or destroy instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void OnEnable()
    {
        // Follow to event
        if (m_playerInputManager != null)
        {
            m_playerInputManager.onPlayerJoined += OnPlayerJoined;
        }
    }

    public void OnDisable()
    {
        // Unfollow to event
        if (m_playerInputManager != null)
        {
            m_playerInputManager.onPlayerJoined -= OnPlayerJoined;
        }
    }

    private void OnPlayerJoined(PlayerInput playerInput)
    {
        // Catch device using
        string deviceType = playerInput.currentControlScheme;

        if (FirstPlayer == null)
        {
            // Instance & nitialize first player
            FirstPlayer = playerInput.GetComponent<PlayerController>();
            FirstPlayer.InitPlayer(m_PvOrigin, "J1", "Red", deviceType, m_FirstPlayerPosition.position);
            if (m_Sound != null) m_Sound.Play();
        }
        else if (SecondPlayer == null)
        {
            // Instance & initialize second player
            SecondPlayer = playerInput.GetComponent<PlayerController>();
            SecondPlayer.InitPlayer(m_PvOrigin, "J2", "Blue", deviceType, m_SecondPlayerPosition.position);
            if (m_Sound != null) m_Sound.Play();
        }
        else
        {
            Debug.LogError("Nombre maximum de joueur : 2 !");
        }
    }
}
