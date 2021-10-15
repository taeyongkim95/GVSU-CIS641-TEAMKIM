using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomButton : MonoBehaviour
{
    public TextMeshProUGUI priceText;
    
    void Start()
    {
    }

    private void updatePrice()
    {
        priceText.text = "ok";
    }
}
