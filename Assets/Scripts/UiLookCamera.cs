using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiLookCamera : MonoBehaviour
{
    private Quaternion m_InitialRotation;

    private void Start()
    {
        // Get and set UI Element at good rotation
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
        m_InitialRotation = transform.rotation;
    }

    private void Update()
    {
        // Keep element in this rotation
        transform.rotation = m_InitialRotation;
    }
}