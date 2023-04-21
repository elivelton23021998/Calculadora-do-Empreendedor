using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class MonetizationManager : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

    [SerializeField] string _adGameId = "5251522"; // This will remain null for unsupported platforms.
    [SerializeField] string _adUnitId = "Banner_Android"; // This will remain null for unsupported platforms.

    void Start()
    {
        // Cria um objeto initializationListener
        var initializationListener = this as IUnityAdsInitializationListener;

        // Verifica se o objeto initializationListener n�o est� nulo
        if (initializationListener != null)
        {
            // Inicializa o Unity Advertisement com o initializationListener atribu�do
            Advertisement.Initialize(_adGameId, true, initializationListener);
        }
    }

    public void OnInitializationComplete()
    {
        // Implemente aqui o c�digo a ser executado ap�s a inicializa��o do Advertisement
        Advertisement.Banner.SetPosition(_bannerPosition);
        Advertisement.Banner.Show(_adUnitId);
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        // Implemente aqui o c�digo a ser executado em caso de falha na inicializa��o do Advertisement
    }
}