using UnityEngine;
using System.Collections;

public class StartBangNhau : MonoBehaviour {


    public tk2dTextMesh txtTitle;
    public tk2dTextMesh txtContent;
    public tk2dUIItem btnPlay;

    public void setData(int lesson)
    {
        txtContent.text = ClsLanguage.doLesson() + lesson + ":" + ClsLanguage.doContentCapBangNhau();
    }

    void onClick_btnPlay()
    {
        PopUpController.instance.HideStartBangNhau();   
        SoundManager.Instance.PauseBGMusic();
        if (GameController.instance.mGrade == 1)
        {
            PopUpController.instance.ShowQuestionBangNhauL1();
        }
        else
        {
            PopUpController.instance.ShowQuestionBangNhau();
        }
        SoundManager.Instance.PlayAudioClick();
    }

	// Use this for initialization
	void Start () {
        btnPlay.OnClick += onClick_btnPlay;

        txtTitle.text = ClsLanguage.doTitleCapBangNhau();
    
        btnPlay.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doStart();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
