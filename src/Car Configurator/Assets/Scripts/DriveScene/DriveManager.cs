using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class DriveManager : MonoBehaviour
{
    [SerializeField]
    private GameObject carObject;

    public CinemachineVirtualCamera cinemachineVirtualCamera;

    public CinemachineTransposer cameraBase;

    // Start is called before the first frame update
    void Start()
    {
        carObject = GameObject.FindGameObjectsWithTag("Player")[0];
        cinemachineVirtualCamera.Follow = carObject.transform;
        cinemachineVirtualCamera.LookAt = carObject.transform;

        cameraBase = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("ConfigScene");
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            cameraBase.m_FollowOffset = new Vector3(-2.5f, 1.0f, -2.0f);
        }

        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            cameraBase.m_FollowOffset = new Vector3(0f, 2.0f, -3.5f);
        }
    }
}
