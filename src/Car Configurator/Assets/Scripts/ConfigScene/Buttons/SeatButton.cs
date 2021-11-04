using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatButton : CustomButton
{
    [SerializeField]
    private GameObject carSeat;

    public void SetSeatMat(Material dashMat)
    {
        CarDataManager.instance._seatMat = dashMat;
    }

    new public void toggleSelected()
    {
        GameObject[] allSeatButtons = GameObject.FindGameObjectsWithTag("SeatSwatch");
        foreach (GameObject button in allSeatButtons)
        {
            button.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            button.GetComponent<SeatButton>().isSelected = false;
        }

        this.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
        this.isSelected = true;
    }
}
