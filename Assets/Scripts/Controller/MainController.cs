using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {
    
    public tk2dUIItem btnPlay; 
    public tk2dUIItem btnRank;
    public tk2dUIItem btnBuyVip;


   // int mGrade = 0;



    public void setData()
    {
       // mGrade = DataManager.GetGrade();
    }



    void btnBuyVip_OnClick()
    {
        if (GameController.instance.ckClickPlay)
        {
            PopUpController.instance.ShowBuyItem();
            PopUpController.instance.HideMainGame();
            SoundManager.Instance.PlayAudioClickUI();
        }
    }

    void btnRank_OnClick()
    {
        if (GameController.instance.ckClickPlay)
        {
            //int chon = UnityEngine.Random.Range(0, 10);
            //if (mGrade == 0||chon==0)
            //{
            //    PopUpController.instance.HideMainGame();
            //    PopUpController.instance.ShowAdTriger();
            //}
            //else
            //{
               
            //    SceneManager.LoadScene("Rank");
            //}

            PopUpController.instance.HideMainGame();
            PopUpController.instance.ShowAdTriger();

            SoundManager.Instance.PlayAudioClickUI();
        }
    }


    void btnPlay_OnClick()
    {
        if (GameController.instance.ckClickPlay)
        {
           // PopUpController.instance.ShowLevel();
            PopUpController.instance.ShowGrade();
            PopUpController.instance.HideMainGame();
            SoundManager.Instance.PlayAudioClickUI();
            
        }

    }



	// Use this for initialization
	void Start () {
        btnRank.OnClick += btnRank_OnClick;
        btnPlay.OnClick += btnPlay_OnClick;
        btnBuyVip.OnClick += btnBuyVip_OnClick;
 
    
        btnPlay.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doVaoThi();      
        btnBuyVip.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doMuaVip();

        setData();
     
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
