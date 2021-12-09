using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PriceManager : MonoBehaviour
{
    public double basePrice;
    public double paintPrice;
    public double seatPrice;
    public double rimPrice;
    public double totalPrice;

    [SerializeField]
    private TextMeshProUGUI priceText;

    void Start()
    {
        basePrice = 54000;
        UpdatePrice();
    }

    private double GetPaintPrice()
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

    private double GetSeatPrice()
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

    private double GetRimPrice()
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
        UpdatePrice();
        priceText.text = "Price: $ " + totalPrice;

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void UpdatePrice()
    {
        totalPrice = basePrice + GetPaintPrice() + GetSeatPrice() + GetRimPrice();
    }
}
