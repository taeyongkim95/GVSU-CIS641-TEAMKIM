using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestDriveButton : MonoBehaviour
{ 
    void Start()
    {
    }

    public void StartDrive()
    {
        SceneManager.LoadScene("DriveScene");
    }    
}
