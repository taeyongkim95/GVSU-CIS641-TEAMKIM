using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimButton : CustomButton
{
    [SerializeField]
    private GameObject[] carRims;

    public void SetRimMat(Material rimMat)
    {
        foreach(GameObject rims in carRims)
        {
            rims.GetComponent<MeshRenderer>().material = rimMat;
        }
    }
}
