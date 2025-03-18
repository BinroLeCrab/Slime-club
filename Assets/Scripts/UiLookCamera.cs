using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiLookCamera : MonoBehaviour
{
    private Quaternion initialRotation;

    private void Start()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        transform.rotation = initialRotation;
    }
}