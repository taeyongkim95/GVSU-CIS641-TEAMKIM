using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    [SerializeField]
    private GameObject checkoutPanel;

    [SerializeField]
    private GameObject confirmPanel;

    public void showConfirm() {
        checkoutPanel.SetActive(false);
        confirmPanel.SetActive(true);
    }
}
