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

    new public void toggleSelected()
    {
        GameObject[] allPaintButtons = GameObject.FindGameObjectsWithTag("PaintSwatch");
        foreach(GameObject button in allPaintButtons)
        {
            button.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            button.GetComponent<PaintButton>().isSelected = false;
        }

        this.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        this.isSelected = true;
    }
}
