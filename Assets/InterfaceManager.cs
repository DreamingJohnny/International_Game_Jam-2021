using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InterfaceManager : MonoBehaviour
{
    [Header("References")]
    public TMP_Text currencyText;

    private static InterfaceManager instance;
    public static InterfaceManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InterfaceManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        currencyText.text = CurrencyManager.Instance.Currency.ToString("00");
    }

    public void UpdateText()
    {
        currencyText.text = CurrencyManager.Instance.Currency.ToString("00");
    }
}
