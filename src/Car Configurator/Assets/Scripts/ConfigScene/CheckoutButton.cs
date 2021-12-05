using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutButton : MonoBehaviour
{
    [SerializeField]
    private GameObject checkoutPanel;

    //Show checkout panel on click
    public void ShowCheckout() {
        checkoutPanel.GetComponent<CheckoutManager>().UpdatePrices();
        checkoutPanel.SetActive(true);
    }

    //Hide checkout panel on click
    public void HideCheckout() {
        checkoutPanel.SetActive(false);
    }
}
