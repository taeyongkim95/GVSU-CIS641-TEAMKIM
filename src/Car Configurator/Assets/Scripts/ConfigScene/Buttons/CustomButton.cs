using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomButton : MonoBehaviour
{
    public double price;
    public bool isSelected;

    private CheckoutManager checkoutScript;

    void Awake()
    {
        GameObject checkoutObject = GameObject.Find("CheckoutPanel");
        checkoutScript = checkoutObject.GetComponent<CheckoutManager>();
    }

    public void UpdatePriceCalculation()
    {
        checkoutScript.UpdatePrices();
    }

    public void ToggleSelected() { 
    //Child classes
    }
}
