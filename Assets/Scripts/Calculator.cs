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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CalcularDaCTPS(TMP_InputField valor)
    {
        print(valor.text);
        string valorReal = RemoveNonNumericCharacters(valor.text);
        valorReal = (float.Parse(valorReal) / 100).ToString();
        print(valorReal);

        valoresCTPS.text = "R$" + valorReal + //valor CTPS
                           "/n/n R$" + float.Parse(valorReal) * inssEmpregador + //valor INSS Empregador
                           "/n R$" + ((float.Parse(valorReal) / 12) + ((float.Parse(valorReal) / 3) / 12)) +  //ferias
                           "/n R$" + ((float.Parse(valorReal) / 12)) + "/n" + //13
                           "/n /n R$" + "total";



    }

    public string RemoveNonNumericCharacters(string input)
    {
        return Regex.Replace(input, "[^0-9]", "");
    }
}
