using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimButton : CustomButton
{
    [SerializeField]
    private GameObject[] carRims;

    public void SetRimMat(Material rimMat)
    {
        CarDataManager.instance._rimMat = rimMat;
    }

    new public void ToggleSelected()
    {
        GameObject[] allRimButtons = GameObject.FindGameObjectsWithTag("RimSwatch");
        foreach (GameObject button in allRimButtons)
        {
            button.transform.GetChild(0).gameObject.SetActive(false);
            button.GetComponent<RimButton>().isSelected = false;
        }

        this.transform.GetChild(0).gameObject.SetActive(true);
        this.isSelected = true;
    }
}
