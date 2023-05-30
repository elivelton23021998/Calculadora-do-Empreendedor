using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class Calculator : MonoBehaviour
{
    float inssEmpregador = 0.2f;
    float fgts = 0.08f;
    int mesesAno=12;
    int tercoFerias=3;

    TMP_Text tabelaAlvo;
    
    void Start() {}
    void Update() {}

    public void CalcularDaCTPS(TMP_InputField valor) //pega o valor que ta na carteira e calcula tods os custos mensais
    {
        string valorReal = RemoveNonNumericCharacters(valor.text);
        valorReal = (float.Parse(valorReal) / 100).ToString("N2");

        string inssValor = (float.Parse(valorReal) * inssEmpregador).ToString("N2");
        string fgtsValor = (float.Parse(valorReal) * fgts).ToString("N2");
        string feriasValor = ((float.Parse(valorReal) / mesesAno) + ((float.Parse(valorReal) / tercoFerias) / mesesAno)).ToString("N2");
        string decimo3 = ((float.Parse(valorReal) / mesesAno)).ToString("N2");
        string total = (float.Parse(valorReal)+float.Parse(inssValor)+float.Parse(fgtsValor)+float.Parse(feriasValor)+float.Parse(decimo3)).ToString("N2");

        total = string.Format("<b><color=red>R$ {0:N2}</color></b>", float.Parse(total));
        valorReal = string.Format("<b>R$ {0:N2}</b>", float.Parse(valorReal));

        tabelaAlvo.text = valorReal + 
                           "\n \n \n \n" + "R$ " + inssValor +
                           "\n \n \n" + "R$ " + fgtsValor +
                           "\n \n \n"    + "R$ " + feriasValor +
                           "\n \n \n \n" + "R$ " + decimo3 +
                           "\n \n \n"    +  total;
    }

    public void QuantoPagar(TMP_InputField valor) // pega o valor em PJ e passa para CLT
    {
        
        string valorReal = RemoveNonNumericCharacters(valor.text);
        valorReal = (float.Parse(valorReal) / 100).ToString("N2");

        double valorFinal = float.Parse(valorReal) * 67.8221552373778 / 100;

        string inssValor = (valorFinal * inssEmpregador).ToString("N2");
        string fgtsValor = (valorFinal * fgts).ToString("N2");
        string feriasValor = ((valorFinal / mesesAno) + ((valorFinal / tercoFerias) / mesesAno)).ToString("N2");
        string decimo3 = ((valorFinal / mesesAno)).ToString("N2");
        string total = (float.Parse(valorReal) - float.Parse(inssValor) - float.Parse(fgtsValor) - float.Parse(feriasValor) - float.Parse(decimo3)).ToString("N2");
        total = string.Format("<b><color=red>R$ {0:N2}</color></b>", float.Parse(total));
        valorReal = string.Format("<b>R$ {0:N2}</b>", float.Parse(valorReal));

        tabelaAlvo.text = valorReal +
                           "\n \n \n \n" + "R$ -" + inssValor +
                           "\n \n \n" + "R$ -" + fgtsValor +
                           "\n \n \n" + "R$ -" + feriasValor +
                           "\n \n \n \n" + "R$ -" + decimo3 +
                           "\n \n \n" + total;
    }
    public void TabelaAlvo(TMP_Text tabela)
    {
        tabelaAlvo = tabela;
    }

    public string RemoveNonNumericCharacters(string input)
    {
        return Regex.Replace(input, "[^0-9]", "");
    }
}
