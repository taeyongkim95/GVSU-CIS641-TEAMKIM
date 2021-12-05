using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintButton : CustomButton
{
    [SerializeField]
    private GameObject carBody;

    public void SetCarMaterial(Material paintMat) {
        CarDataManager.instance._paintMat = paintMat;
    }

    new public void ToggleSelected()
    {
        GameObject[] allPaintButtons = GameObject.FindGameObjectsWithTag("PaintSwatch");
        foreach(GameObject button in allPaintButtons)
        {
            button.GetComponent<PaintButton>().isSelected = false;
        }

        this.isSelected = true;
    }
}
