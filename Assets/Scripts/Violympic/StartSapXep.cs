using UnityEngine;
using System.Collections;

public class StartSapXep : MonoBehaviour {

    public tk2dTextMesh txtTitle;
    public tk2dTextMesh txtContent;
    public tk2dUIItem btnPlay;


    void btnPlay_OnClick()
    {
        SoundManager.Instance.PauseBGMusic();
        PopUpController.instance.HideStartSapXep();
        if (GameController.instance.mGrade == 1)
        {
            PopUpController.instance.ShowQuestionSapXepL1();
        }
        else
        {
            PopUpController.instance.ShowQuestionSapXep();
        }
        SoundManager.Instance.PlayAudioClick();
    }

	// Use this for initialization
	void Start () {


        btnPlay.OnClick += btnPlay_OnClick;

        txtTitle.text = ClsLanguage.doTileSapXep();
        txtContent.text = ClsLanguage.doSapXep();
        btnPlay.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doVaoThi();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
