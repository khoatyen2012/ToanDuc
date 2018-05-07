using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class Grade : MonoBehaviour {

    public tk2dUIItem btnLop1;
    public tk2dUIItem btnLop2;
    public tk2dUIItem btnLop3;
    public tk2dUIItem btnLop4;
    public tk2dUIItem btnLop5;
    public tk2dUIItem btnBack;
    public tk2dTextMesh txtLoading;


    BannerView bannerView;


    private void RequestBanner()
    {
        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(Config.adsInIDBanner, AdSize.Banner, AdPosition.TopRight);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    public void setData()
    {
       
        if (GameController.instance.checkvip != 10)
        {
            RequestBanner();
            bannerView.Show();
        }
    }


    void btnLop1_onClick()
    {
        xuLy(1);
    }
    void btnLop2_onClick()
    {
        txtLoading.gameObject.SetActive(true);
      StartCoroutine(WaitTimeLop2(0.1f));
    }
    IEnumerator WaitTimeLop2(float time)
    {
        yield return new WaitForSeconds(time);
         xuLy(2);
         txtLoading.gameObject.SetActive(false);
    }
    void btnLop3_onClick()
    {
        xuLy(3);
    }
    void btnLop4_onClick()
    {
        xuLy(4);
    }
    void btnLop5_onClick()
    {
        xuLy(5);
    }
    void btnBack_onClick()
    {
        PopUpController.instance.HideGrade();
        PopUpController.instance.ShowMainGame();

        if (GameController.instance.checkvip != 10)
        {
            bannerView.Hide();
        }
    }



    void xuLy(int lv)
    {
        GameController.instance.setGrade(lv);
        PopUpController.instance.ShowLevel();
        PopUpController.instance.HideGrade();
        SoundManager.Instance.PlayAudioClickUI();

        if (GameController.instance.checkvip != 10)
        {
            bannerView.Hide();
        }
    }

	// Use this for initialization
	void Start () {

        btnLop1.OnClick += btnLop1_onClick;
        btnLop2.OnClick += btnLop2_onClick;
        btnLop3.OnClick += btnLop3_onClick;
        btnLop4.OnClick += btnLop4_onClick;
        btnLop5.OnClick += btnLop5_onClick;
        btnBack.OnClick += btnBack_onClick;
        btnLop1.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doLop1();
        btnLop2.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doLop2();
        btnLop3.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doLop3();
        btnLop4.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doLop4();
        btnLop5.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doLop5();
        txtLoading.text = ClsLanguage.doLoading();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
