using System.Globalization;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;

public class MascaraInputField : MonoBehaviour
{
    CultureInfo culture = new CultureInfo("pt-BR");
    NumberFormatInfo currencyFormat;
    TMP_InputField inputField;

    void Start()
    {
        currencyFormat = culture.NumberFormat;
        currencyFormat.CurrencySymbol = "R$";

        inputField = GetComponent<TMP_InputField>();

        inputField.onEndEdit.AddListener(OnEndEdit);
        inputField.onSelect.AddListener(OnSelect);
    }

    private void OnSelect(string value)
    {
        TouchScreenKeyboard keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad, false, false, false, false, "");
        inputField.text = keyboard.text;
    }

    private void OnEndEdit(string value)
    {
        if (!value.StartsWith(currencyFormat.CurrencySymbol))
        {
            // Adiciona o símbolo "R$" no início do valor
            value = currencyFormat.CurrencySymbol + value;
        }

        value = value.Replace(".", ",");

        decimal amount;
        if (Decimal.TryParse(value, NumberStyles.Currency, currencyFormat, out amount))
        {
            inputField.text = currencyFormat.CurrencySymbol + amount.ToString("N2", currencyFormat);
        }
    }
}