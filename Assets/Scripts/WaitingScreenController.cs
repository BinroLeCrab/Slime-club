using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaitingScreenController : MonoBehaviour
{
    [Header("Childs Objects")]
    [SerializeField] public GameObject m_WaitingText;
    [SerializeField] public GameObject m_SpriteSlime;
    [SerializeField] public GameObject m_DeviceIcon;


    public void SetDeviceIcon(string device)
    {
        //Active the good icon depending on device

        //If device is a KeyboardMouse
        if (device == "KeyboardMouse")
        {
            m_DeviceIcon.transform.Find("Keyboard Initial").gameObject.SetActive(false);
            m_DeviceIcon.transform.Find("Keyboard Active").gameObject.SetActive(true);
        }

        //If device is a KeyboardMouse
        if (device == "Gamepad")
        {
            m_DeviceIcon.transform.Find("Gamepad Initial").gameObject.SetActive(false);
            m_DeviceIcon.transform.Find("Gamepad Active").gameObject.SetActive(true);
        }
    }
}
