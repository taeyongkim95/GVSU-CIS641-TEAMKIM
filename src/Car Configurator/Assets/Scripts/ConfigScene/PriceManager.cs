using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PriceManager : MonoBehaviour
{
    private double paintPrice;
    private double seatPrice;
    private double rimPrice;
    private double totalPrice;
    [SerializeField]
    private TextMeshProUGUI priceText;

    void Start()
    {
        updatePrice();
    }

    private double getPaintPrice()
    {
        GameObject[] allPaintButtons = GameObject.FindGameObjectsWithTag("PaintSwatch");
        foreach(GameObject button in allPaintButtons)
        {
            if (button.GetComponent<PaintButton>().isSelected)
            {
                paintPrice = button.GetComponent<PaintButton>().price;
            }
        }

        return paintPrice;
    }

    private double getSeatPrice()
    {
        GameObject[] allSeatButtons = GameObject.FindGameObjectsWithTag("SeatSwatch");
        foreach (GameObject button in allSeatButtons)
        {
            if (button.GetComponent<SeatButton>().isSelected)
            {
                seatPrice = button.GetComponent<SeatButton>().price;
            }
        }

        return seatPrice;
    }

    private double getRimPrice()
    {
        GameObject[] allRimButtons = GameObject.FindGameObjectsWithTag("RimSwatch");
        foreach (GameObject button in allRimButtons)
        {
            if (button.GetComponent<RimButton>().isSelected)
            {
                rimPrice = button.GetComponent<RimButton>().price;
            }
        }

        return rimPrice;
    }

    void Update()
    {
        updatePrice();
        priceText.text = "Price: $ " + totalPrice;
    }

    public void updatePrice()
    {
        totalPrice = 54000 + getPaintPrice() + getSeatPrice() + getRimPrice();
    }
}
