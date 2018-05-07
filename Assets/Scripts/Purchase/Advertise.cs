using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class Advertise : MonoBehaviour {

    public tk2dUIItem btnContinute;
    public tk2dUIItem btnCancel;
    public tk2dTextMesh txtTitle;
    public tk2dTextMesh txtContent;
    InterstitialAd interstitial;

    private void LoadAdsInterstitial()
    {
        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(Config.adsInIDTrigger);
        // Create an empty ad request.
        AdRequest requestIN = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("365BCE5DDF729BFD1E6E40D79CE8F42B").Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(requestIN);
    }

    private void ShowAdsInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void HideAdsInterstitial()
    {
        interstitial.Destroy();
    }

    void onClick_Continute()
    {
        ShowAdsInterstitial();
    }
    void onClick_Cancel()
    {
        PopUpController.instance.HideAdTriger();
        PopUpController.instance.ShowMainGame();
    }

    public void setData()
    {
        LoadAdsInterstitial();
    }

	// Use this for initialization
	void Start () {
        btnContinute.OnClick += onClick_Continute;
        btnCancel.OnClick += onClick_Cancel;
        txtTitle.text = ClsLanguage.doQuangCao();
        txtContent.text = ClsLanguage.doContenQuangCao();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
