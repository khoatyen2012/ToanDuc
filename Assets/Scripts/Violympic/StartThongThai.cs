﻿using UnityEngine;
using System.Collections;

public class StartThongThai : MonoBehaviour {

    public tk2dTextMesh txtContent;
    public tk2dSprite spTitle;
    public tk2dUIItem btnPlay;

    void onClick_btnPlay()
    {
        PopUpController.instance.HideStartThongThai();
        PopUpController.instance.ShowQuestionMonkey();
        SoundManager.Instance.PauseBGMusic();
        SoundManager.Instance.PlayAudioClick();
    }

	// Use this for initialization
	void Start () {
        btnPlay.OnClick += onClick_btnPlay;
        if (GameController.instance.tienganh!=1)
        {
            spTitle.SetSprite("monkey");
        }
        else
        {
            spTitle.SetSprite("khithongminh");
        }
        btnPlay.gameObject.transform.GetChild(0).GetComponent<tk2dTextMesh>().text = ClsLanguage.doVaoThi();
        txtContent.text = ClsLanguage.doContentMoney();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
