using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class NumericTMPInputField : MonoBehaviour
{
    private TMP_InputField inputField;
    private CultureInfo culture = new CultureInfo("pt-BR"); // Define a cultura para exibição do valor (no caso, português do Brasil)
    private bool valueChanged = false;

    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.contentType = TMP_InputField.ContentType.DecimalNumber; // Define o tipo de conteúdo do Input Field como número decimal
        inputField.text = "R$ 0,00"; // Define o valor inicial do campo como R$ 0,00
        inputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); }); // Adiciona um listener para detectar alterações no valor do Input Field
    }

    private void Update()
    {
        if (valueChanged)
        {
            valueChanged = false;
            string valueString = inputField.text.Substring(3); // Remove o prefixo "R$ " antes de formatar o valor

            if (!string.IsNullOrEmpty(valueString))
            {
                if (valueString.Contains("."))
                {
                    valueString = valueString.Replace(".", ",");
                }

                float value = float.Parse(valueString, culture.NumberFormat);
                inputField.text = string.Format(culture, "R$ {0:N2}", value);
            }
            else
            {
                inputField.text = "R$ 0,00";
            }
        }
    }

    private void ValueChangeCheck()
    {
        if (inputField.text.Length < 3) // Verifica se o usuário tentou apagar o prefixo "R$ "
        {
            inputField.text = "R$ ";
        }
        else if (inputField.text.Substring(0, 3) != "R$ ") // Verifica se o prefixo foi modificado pelo usuário e o corrige
        {
            inputField.text = "R$ " + inputField.text.Substring(3);
        }

        valueChanged = true;
    }
}