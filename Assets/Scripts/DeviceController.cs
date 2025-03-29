using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class DeviceController : MonoBehaviour
{
    private PlayerInput m_PlayerInput;

    void Awake()
    {
        m_PlayerInput = GetComponent<PlayerInput>();
    }

    void Start()
    {
        if (m_PlayerInput.user.pairedDevices.Count > 1 && m_PlayerInput.currentControlScheme == "Gamepad")
        {
            m_PlayerInput.user.UnpairDevice(m_PlayerInput.user.pairedDevices[1]);
        }
    }
}
