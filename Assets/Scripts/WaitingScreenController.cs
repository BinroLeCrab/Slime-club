using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaitingScreenController : MonoBehaviour
{
    [Header("Child Object")]
    [SerializeField] public GameObject m_WaitingText;
    [SerializeField] public GameObject m_SpriteSlime;
    [SerializeField] public GameObject m_DeviceIcon;


    public void SetDeviceIcon(string device)
    {
        //Active the good device icon

        //If device is a KeyboardMouse
        if (device == "KeyboardMouse")
        {
            m_DeviceIcon.transform.Find("Keyboard Initial").gameObject.SetActive(false);
            m_DeviceIcon.transform.Find("Keyboard Active").gameObject.SetActive(true);
        }

        //Gamepad
        if (device == "Gamepad")
        {
            m_DeviceIcon.transform.Find("Gamepad Initial").gameObject.SetActive(false);
            m_DeviceIcon.transform.Find("Gamepad Active").gameObject.SetActive(true);
        }
    }
}
