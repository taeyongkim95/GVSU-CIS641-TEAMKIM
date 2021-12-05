using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckoutManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI basePriceText;

    [SerializeField]
    private TextMeshProUGUI paintPriceText;

    [SerializeField]
    private TextMeshProUGUI seatMatPriceText;

    [SerializeField]
    private TextMeshProUGUI rimsPriceText;

    [SerializeField]
    private TextMeshProUGUI totalPriceText;

    private PriceManager priceScript;
    private CarDataManager carScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject priceObject = GameObject.Find("PricePanel");
        priceScript = priceObject.GetComponent<PriceManager>();

        GameObject carObject = GameObject.Find("Car");
        carScript = carObject.GetComponent<CarDataManager>();

        basePriceText = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        paintPriceText = gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        seatMatPriceText = gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        rimsPriceText = gameObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        totalPriceText = gameObject.transform.GetChild(5).GetComponent<TextMeshProUGUI>();

        gameObject.SetActive(false);
    }

    // Update prices by grabbing the currently selected options
    public void UpdatePrices()
    {
        basePriceText.text = "Base Price: $ " + priceScript.basePrice;
        paintPriceText.text = "Paint Price: $ " + priceScript.paintPrice + " || " + carScript.GetPaintMatString();
        seatMatPriceText.text = "Seat Material Price: $ " + priceScript.seatPrice + " || " + carScript.GetSeatMatString();
        rimsPriceText.text = "Rims Price: $ " + priceScript.rimPrice + " || " + carScript.GetRimMatString();
        totalPriceText.text = "Total Price: $ " + priceScript.totalPrice;
    }
}
z