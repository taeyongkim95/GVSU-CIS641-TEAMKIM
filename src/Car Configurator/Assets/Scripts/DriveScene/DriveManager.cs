using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class DriveManager : MonoBehaviour
{
    [SerializeField]
    private GameObject carObject;

    public CinemachineVirtualCamera CinemachineVirtualCameraBase;

    // Start is called before the first frame update
    void Start()
    {
        carObject = GameObject.FindGameObjectsWithTag("Player")[0];
        CinemachineVirtualCameraBase.Follow = carObject.transform;
        CinemachineVirtualCameraBase.LookAt = carObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("ConfigScene");
        }
    }

    void LateUpdate()
    {
        //transform.position = car.transform.position + cameraOffset;
    }
}
