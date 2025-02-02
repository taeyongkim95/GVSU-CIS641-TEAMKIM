using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FreeLookCamera : MonoBehaviour
{
    [SerializeField] GameObject freeLookCamera;
    private CinemachineFreeLook freeLookComponent;

    [SerializeField]
    private GameObject carObject;

    private void Awake()
    {
        freeLookComponent = freeLookCamera.GetComponent<CinemachineFreeLook>();
        carObject = GameObject.FindGameObjectsWithTag("Player")[0];
        freeLookComponent.Follow = carObject.transform;
        freeLookComponent.LookAt = carObject.transform;
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // use the following line for mouse control of zoom instead of mouse wheel
            freeLookComponent.m_XAxis.m_MaxSpeed = 500;
        }
        if (Input.GetMouseButtonUp(1))
        {
            // use the following line for mouse control of zoom instead of mouse wheel
            // be sure to change Input Axis Name on the Y axis from to "Mouse Y"
            freeLookComponent.m_XAxis.m_MaxSpeed = 0;
        }
    }
}
