using UnityEngine;
using GoogleMobileAds.Api;

public class MonetizationManager : MonoBehaviour
{
    [SerializeField] enum AdSizeBanner
    {
        Banner,
        IABBanner,
        Leaderboard,
        MediumRectangle,
        SmartBanner,
    };  

    BannerView bannerView;
    AdSize bannerSize;
    [SerializeField] string adUnitId;
    [SerializeField] AdSizeBanner tamanhoBanner;
    [SerializeField] AdPosition posicaoBanner;


    // Start is called before the first frame update
    public void Start()
    {
        switch (tamanhoBanner)
        {
            case AdSizeBanner.Banner: bannerSize = AdSize.Banner;
                break;

            case AdSizeBanner.IABBanner: bannerSize = AdSize.IABBanner;
                break;

            case AdSizeBanner.Leaderboard:bannerSize = AdSize.Leaderboard;
                break;

            case AdSizeBanner.MediumRectangle: bannerSize = AdSize.MediumRectangle;
                break;

            case AdSizeBanner.SmartBanner:
                bannerSize = AdSize.SmartBanner;
                break;
        }

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
    }
    private void Update()
    {
    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
            // adUnitId = "ca-app-pub-3940256099942544/6300978111";
            adUnitId = "ca-app-pub-8255768500301892/8157342294";
#elif UNITY_IPHONE
            adUnitId = "ca-app-pub-8255768500301892/8157342294"; 
#else
            adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, bannerSize, posicaoBanner);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }
}