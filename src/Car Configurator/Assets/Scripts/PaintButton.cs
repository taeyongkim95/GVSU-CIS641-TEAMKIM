using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintButton : CustomButton
{
    [SerializeField]
    private GameObject carBody;

    public void SetCarMaterial(Material paintMat) {
        carBody.GetComponent<MeshRenderer>().material = paintMat;
        carBody.GetComponent<MeshRenderer>().material.SetFloat("_Metallic", GlossySlider.glossyVal);
    }
}
