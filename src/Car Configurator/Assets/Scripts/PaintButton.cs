using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintButton : CustomButton
{
    [SerializeField]
    private GameObject carBody;

    void Start()
    {
        carBody = GameObject.FindGameObjectsWithTag("CarBody")[0];
    }

    public void setCarMaterial(Material paintMat) {
        carBody.GetComponent<MeshRenderer>().material = paintMat;
    }
}
