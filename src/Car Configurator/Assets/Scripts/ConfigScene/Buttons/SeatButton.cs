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

    new public void ToggleSelected()
    {
        GameObject[] allSeatButtons = GameObject.FindGameObjectsWithTag("SeatSwatch");
        foreach (GameObject button in allSeatButtons)
        {
            button.GetComponent<SeatButton>().isSelected = false;
        }

        this.isSelected = true;
    }
}
