using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatButton : CustomButton
{
    [SerializeField]
    private GameObject carSeat;

    public void SetSeatMat(Material dashMat)
    {
        carSeat.GetComponent<MeshRenderer>().material = dashMat;
    }
}
