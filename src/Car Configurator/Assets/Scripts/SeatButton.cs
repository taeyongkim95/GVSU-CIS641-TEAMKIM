using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatButton : MonoBehaviour
{
    [SerializeField]
    private GameObject carSeat;

    public void SetSeatMat(Material dashMat)
    {
        carSeat.GetComponent<MeshRenderer>().material = dashMat;
    }
}
