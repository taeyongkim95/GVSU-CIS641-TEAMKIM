using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PriceManager : MonoBehaviour
{
    private double totalPrice;
    [SerializeField]
    private TextMeshProUGUI priceText;

    void Start()
    {
        totalPrice = 55000;
    }

    void Update()
    {
        priceText.text = "Price: $ " + totalPrice;
    }

    void addPrice(double valueToAdd)
    {
        totalPrice = totalPrice + valueToAdd;
    }
}
