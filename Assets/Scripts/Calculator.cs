using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.Windows;

public class Calculator : MonoBehaviour
{
    float inssEmpregador = 0.2f;
    float fgts = 0.08f;

    [SerializeField] TMP_Text valoresCTPS;
    
    void Start() {}
    void Update() {}

    public void CalcularDaCTPS(TMP_InputField valor)
    {
        //print(valor.text);
        string valorReal = RemoveNonNumericCharacters(valor.text);
        valorReal = (float.Parse(valorReal) / 100).ToString("F");
        
        string inssValor = (float.Parse(valorReal) * inssEmpregador).ToString("F");
        string fgtsValor = (float.Parse(valorReal) * fgts).ToString("F");
        string feriasValor = ((float.Parse(valorReal) / 12) + ((float.Parse(valorReal) / 3) / 12)).ToString("F");
        string decimo3 = ((float.Parse(valorReal) / 12)).ToString("F");
        string total = (float.Parse(valorReal)+float.Parse(inssValor)+float.Parse(fgtsValor)+float.Parse(feriasValor)+float.Parse(decimo3)).ToString("F");

        valoresCTPS.text = "R$" + valorReal + 
                           "\n \n \n \n" + "R$" + inssValor +
                           "\n \n"       + "R$" + fgtsValor +
                           "\n \n \n"    + "R$" + feriasValor +
                           "\n \n \n \n" + "R$" + decimo3 +
                           "\n \n \n"    + "R$" + total;
    }

    public string RemoveNonNumericCharacters(string input)
    {
        return Regex.Replace(input, "[^0-9]", "");
    }
}
