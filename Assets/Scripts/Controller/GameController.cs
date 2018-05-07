using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    #region Singleton
    private static GameController _instance;

    public static GameController instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<GameController>();
            return _instance;
        }
    }
    #endregion

    public int sumCoin = 0;
    public int sumTime;
    public int level = 1;
    public int vuotqua = 0;
    public bool tienganh = true;
    public List<DinhNui> lstSumTam = new List<DinhNui>();   
    public List<DinhNui> lstSum5 = new List<DinhNui>();
    public List<DinhNui> lstSum4 = new List<DinhNui>();
    public List<DinhNui> lstSum3 = new List<DinhNui>();
    public List<DinhNui> lstSum2 = new List<DinhNui>();   
    public List<PhepToan> lstPhepToan5 = new List<PhepToan>();
    public List<PhepToan> lstPhepToan4 = new List<PhepToan>();
    public List<PhepToan> lstPhepToan3 = new List<PhepToan>();
    public List<PhepToan> lstPhepToan2 = new List<PhepToan>();
    public List<PhepToan> lstPhepToan1 = new List<PhepToan>();

    public string stSumcoin = "";
    public string[] mangTong;
    public bool ckResetLv = true;
    public int checkvip = 0;
    public bool ckClickPlay = false;
    public int mGrade = 1;

    void Awake()
    {
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = -1;
    
        tienganh = CheckNgonNgu();
     
        
     
        checkvip = DataManager.GetVip();

    }

    public void setGrade(int mg)
    {
        mGrade = mg;
        switch (mGrade)
        {
            case 2:

                if (lstPhepToan2.Count < 1)
                {
                    TextAsset txtBang = (TextAsset)Resources.Load("violympic2", typeof(TextAsset));
                    string data = txtBang.text;
                    GetDaTaBang(data, ref lstPhepToan2);
                }

                 if (lstSum2.Count < 1)
                {
                    TextAsset txt;
                    if (tienganh)
                    {
                        txt = (TextAsset)Resources.Load("violympica2", typeof(TextAsset));
                    }
                    else
                    {
                        txt = (TextAsset)Resources.Load("violympicv2", typeof(TextAsset));
                    }
                    string content = txt.text;
                    GetDaTa(content, ref lstSum2);
                }
                lstSumTam = lstSum2;
                vuotqua = DataManager.GetHightLevel2();
                stSumcoin = DataManager.GetHightStringCoin2();
                break;
            case 3:

                if (lstPhepToan3.Count < 1)
                {
                    TextAsset txtBang = (TextAsset)Resources.Load("violympic3", typeof(TextAsset));
                    string data = txtBang.text;
                    GetDaTaBang(data, ref lstPhepToan3);
                }

                if (lstSum3.Count < 1)
                {
                    TextAsset txt;
                    if (tienganh)
                    {
                        txt = (TextAsset)Resources.Load("violympica3", typeof(TextAsset));
                    }
                    else
                    {
                        txt = (TextAsset)Resources.Load("violympicv3", typeof(TextAsset));
                    }
                    string content = txt.text;
                    GetDaTa(content, ref lstSum3);
                }
                lstSumTam = lstSum3;
                vuotqua = DataManager.GetHightLevel3();
                stSumcoin = DataManager.GetHightStringCoin3();
                break;
            case 4:
                if (lstPhepToan4.Count < 1)
                {
                    TextAsset txtBang = (TextAsset)Resources.Load("violympic4", typeof(TextAsset));
                    string data = txtBang.text;
                    GetDaTaBang(data, ref lstPhepToan4);
                }

                if (lstSum4.Count < 1)
                {
                    TextAsset txt;
                    if (tienganh)
                    {
                        txt = (TextAsset)Resources.Load("violympica4", typeof(TextAsset));
                    }
                    else
                    {
                        txt = (TextAsset)Resources.Load("violympicv4", typeof(TextAsset));
                    }
                    string content = txt.text;
                    GetDaTa(content, ref lstSum4);
                }
                lstSumTam = lstSum4;
                vuotqua = DataManager.GetHightLevel4();
                stSumcoin = DataManager.GetHightStringCoin4();

                break;
            case 5:
                if (lstPhepToan5.Count < 1)
                {
                    TextAsset txtBang = (TextAsset)Resources.Load("violympic5", typeof(TextAsset));
                    string data = txtBang.text;
                    GetDaTaBang(data, ref lstPhepToan5);
                }

                if (lstSum5.Count < 1)
                {
                    TextAsset txt;
                    if (tienganh)
                    {
                        txt = (TextAsset)Resources.Load("violympica5", typeof(TextAsset));
                    }
                    else
                    {
                        txt = (TextAsset)Resources.Load("violympicv5", typeof(TextAsset));
                    }
                    string content = txt.text;
                    GetDaTa(content, ref lstSum5);
                }
                lstSumTam = lstSum5;
                vuotqua = DataManager.GetHightLevel5();
                stSumcoin = DataManager.GetHightStringCoin5();

                break;
            default:
                if (lstPhepToan1.Count < 1)
                {
                    TextAsset txtBang = (TextAsset)Resources.Load("violympic1", typeof(TextAsset));
                    string data = txtBang.text;
                    GetDaTaBang(data, ref lstPhepToan1);
                }
                vuotqua = DataManager.GetHightLevel1();
                stSumcoin = DataManager.GetHightStringCoin1();
                break;
        }
        level = vuotqua + 1;
        mangTong = stSumcoin.Split('+');
    }

    void GetDaTaBang(string tmg, ref List<PhepToan> lstPhep)
    {
        string[] mang = tmg.Trim().Split('#');
        //Debug.Log("KK:"+mang[mang.Length-2]);


        for (int i = 0; i < mang.Length - 1; i++)
        {
            string[] items = mang[i].Split('*');

            PhepToan pt = new PhepToan(items[0], items[1], items[2]);

            lstPhep.Add(pt);
        }


        // Debug.Log("1:" + lst1.Count + "2:" + lst2.Count + "3:" + lst3.Count + "4:" + lst4.Count + "5:" + lst5.Count + "6:" + lst6.Count);

    }

 

    public bool CheckNgonNgu()
    {
        bool ok = true;
        string ngonngu = Application.systemLanguage.ToString().ToLower().Trim();
        if (ngonngu.Equals("vietnamese"))
        {
            ok = false;
        }
        return ok;
    }

    public void ShowLevel3()
    {
        PopUpController.instance.ShowStartThongThai();
    }

    public void ShowLevel2()
    {
        switch (GameController.instance.mGrade)
        {
            case 2:
                if (level < 4)
                {

                    PopUpController.instance.ShowStartDinhNui(2);
                }
                else
                {
                    int chon = UnityEngine.Random.Range(0, 3);
                    if (chon == 0)
                    {
                        PopUpController.instance.ShowStartSapXep();
                    }
                    else
                    {
                        PopUpController.instance.ShowStartBangNhau(2);
                    }
                }
                break;
            case 3:
                if (level < 4)
                {

                    PopUpController.instance.ShowStartDinhNui(2);
                }
                else
                {
                    int chon = UnityEngine.Random.Range(0, 3);
                    if (chon == 0)
                    {
                        PopUpController.instance.ShowStartSapXep();
                    }
                    else
                    {
                        PopUpController.instance.ShowStartBangNhau(2);
                    }
                }
                break;
            case 4:
                PopUpController.instance.ShowStartDinhNui(2);
                break;
            case 5:
                PopUpController.instance.ShowStartDinhNui(2);
                break;
            default:
                PopUpController.instance.ShowStartDinhNui(2);
                break;
        }

       
      
    }

    public void ShowLevel1()
    {
        int chon;
        switch (GameController.instance.mGrade)
        {
            case 2:
                if (level < 4)
                {
                    PopUpController.instance.ShowStartBangNhau(1);
                }
                else
                {
                    PopUpController.instance.ShowStartDinhNui(1);
                }
                break;
            case 3:
                if (level < 4)
                {
                    PopUpController.instance.ShowStartBangNhau(1);
                }
                else
                {
                    PopUpController.instance.ShowStartDinhNui(1);
                }

                break;
            case 4:
                if (GameController.instance.level == 5 || GameController.instance.level == 15)
                {
                    PopUpController.instance.ShowStartSapXep();
                }
                else if (GameController.instance.level == 14 || GameController.instance.level == 19 || GameController.instance.level == 20)
                {
                    PopUpController.instance.ShowStartBangNhau(1);
                }
                else
                {
                    chon = UnityEngine.Random.Range(0, 3);
                    if (chon == 0)
                    {
                        PopUpController.instance.ShowStartSapXep();
                    }
                    else
                    {
                        PopUpController.instance.ShowStartBangNhau(1);
                    }
                }
                break;
            case 5:
                chon = UnityEngine.Random.Range(0, 4);
                if (chon == 0)
                {
                    PopUpController.instance.ShowStartSapXep();
                }
                else
                {
                    PopUpController.instance.ShowStartBangNhau(1);
                }
                break;
            default:
                if (level < 4)
                {
                    PopUpController.instance.ShowStartBangNhau(1);
                }
                else
                {
                    chon = UnityEngine.Random.Range(0, 4);
                    if (chon == 0)
                    {
                        PopUpController.instance.ShowStartSapXep();
                    }
                    else
                    {
                        PopUpController.instance.ShowStartBangNhau(1);
                    }
                }
                break;
        }


       // PopUpController.instance.ShowStartThongThai();
       // PopUpController.instance.ShowStartBangNhau(1);
       // PopUpController.instance.ShowStartSapXep();
      //  PopUpController.instance.ShowStartDinhNui(1);
       
    }

    //IEnumerator WaitTimeLoading(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    PopUpController.instance.HideLoading();
    //    PopUpController.instance.HideLevel();
    //}
    void GetDaTa(string tmg, ref List<DinhNui> lstSum)
    {
        string[] mang = tmg.Trim().Split('#');
        //Debug.Log("KK:"+mang[mang.Length-2]);


        for (int i = 0; i < mang.Length - 1; i++)
        {

           
            string[] items = mang[i].Split('*');
         
            DinhNui dn = new DinhNui(items[1], items[2], items[3], items[4], items[5], int.Parse(items[6]), items[7], int.Parse(items[8]));
            lstSum.Add(dn);
         
           
        }

        
       
        
      }

	// Use this for initialization
	void Start () {


     

 
        

        PopUpController.instance.HideLevel();
        StartCoroutine(WaitTimeLoadData(3f));
      
    
	}

    IEnumerator WaitTimeLoadData(float mtime)
    {
        yield return new WaitForSeconds(mtime);

        PopUpController.instance.HideLoading();
       
        ckClickPlay = true;
    }



    // Update is called once per frame
    void Update()
    {
	
	}
}
