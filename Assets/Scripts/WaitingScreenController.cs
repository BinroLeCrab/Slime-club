using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WaitingScreenController : MonoBehaviour
{
    [SerializeField] public GameObject m_WaitingText;
    [SerializeField] public GameObject m_SpriteSlime;

    [SerializeField] public GameObject m_DeviceIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDeviceIcon(string device)
    {
        Debug.Log("Device : " + device);

        //KeyboardMouse
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
