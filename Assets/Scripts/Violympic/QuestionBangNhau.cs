using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class QuestionBangNhau : MonoBehaviour
{


    public SpItem spPrefab;
    public float startX;
    public float distanceX;
    public float startY;
    public float distanceY;
    private tk2dUIItem sp;
    private SpItem sp1;


    private SpItem bt1;
    private SpItem bt2;
    private SpItem bt3;
    private SpItem bt4;
    private SpItem bt5;
    private SpItem bt6;
    private SpItem bt7;
    private SpItem bt8;
    private SpItem bt9;
    private SpItem bt10;
    private SpItem bt11;
    private SpItem bt12;
    private SpItem bt13;
    private SpItem bt14;
    private SpItem bt15;
    private SpItem bt16;
    private SpItem bt17;
    private SpItem bt18;
    private SpItem bt19;
    private SpItem bt20;

    double gt1 = 0;
    double gt2 = 0;

    private tk2dSprite sprite1;
    private tk2dSprite sprite2;

    public int mDiemB1 = 0;
    public tk2dSprite khocCuoi;
    int mDem = 0;
    int mTime = 1200;

    int demframe = 0;
    bool checkCreate = true;



    public tk2dTextMesh txtTime;
    public tk2dTextMesh txtLoading;


    public enum State
    {
        Start,
        InGame1,
        Click1,
        Click2

    }

    public State currentState;
    public void setPlay()
    {

        //currentState = State.InGame1;
        StartCoroutine(WaitTimeLoadData(1.2f));
    }



    IEnumerator WaitTimeLoadData(float time)
    {
        yield return new WaitForSeconds(time);
        Create();

    }

    void doXuLy(SpItem bt)
    {

        if (currentState == State.InGame1)
        {
            sp1 = bt;
            if (sp1.Trangthai == true)
            {
                sp1.Trangthai = false;
                currentState = State.Click1;
                khocCuoi.SetSprite("nguoihoi");
                sprite1 = bt.GetComponent<tk2dSprite>();
                sprite1.color = new Color(1, 1, 0.5f, 1);

                gt1 = bt.Giatri;
                SoundManager.Instance.PlayAudioClick();
            }

        }
        else if (currentState == State.Click1)
        {
            if (bt.Trangthai == true)
            {
                bt.Trangthai = false;
                currentState = State.Click2;

                sprite2 = bt.GetComponent<tk2dSprite>();
                sprite2.color = new Color(1, 1, 0.5f, 1);

                gt2 = bt.Giatri;
                SoundManager.Instance.PlayAudioClick();
                StartCoroutine(WaitTimeXuLyBN(1f, bt));
            }
        }

    }

    IEnumerator WaitTimeXuLyBN(float time, SpItem bt)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        sprite1.color = new Color(1, 1, 1, 1);
        sprite2.color = new Color(1, 1, 1, 1);


        sp1.Trangthai = true;
        bt.Trangthai = true;


        if (gt1 == gt2)
        {
            SoundManager.Instance.Stop();
            SoundManager.Instance.PlayAudioChucTrue();

            bt.gameObject.SetActive(false);


            sp1.gameObject.SetActive(false);
            mDiemB1 += 10;
            khocCuoi.SetSprite("nguoicuoi");
            StartCoroutine(WaitTimeDungRoiBN(0.5f));
        }
        else
        {
            mDiemB1 -= 2;
            khocCuoi.SetSprite("nguoikhoc");
            StartCoroutine(WaitTimeSaiRoiBN(0.5f));
        }
    }

    IEnumerator WaitTimeSaiRoiBN(float time)
    {
        yield return new WaitForSeconds(time);


        SoundManager.Instance.Stop();
        mDem++;


        int chon = UnityEngine.Random.Range(0, 6);
        switch (chon)
        {
            case 0:
                SoundManager.Instance.PlayAudioChucSai1();
                break;
            case 1:
                SoundManager.Instance.PlayAudioChucSai2();
                break;
            case 3:
                SoundManager.Instance.PlayAudioChucSai3();
                break;
            case 4:
                SoundManager.Instance.PlayAudioChucSai4();
                break;
            case 5:
                SoundManager.Instance.PlayAudioChucSai5();
                break;
            default:
                SoundManager.Instance.PlayAudioChucSai2();
                break;

        }

        currentState = State.InGame1;

        if (mDem >= 3)
        {
            GameOver();
        }

    }

    IEnumerator WaitTimeDungRoiBN(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        SoundManager.Instance.Stop();

        int chon = UnityEngine.Random.Range(0, 12);
        switch (chon)
        {
            case 0:
                SoundManager.Instance.PlayAudioChucDung1(chon);
                break;
            case 1:
                SoundManager.Instance.PlayAudioChucDung2(chon);
                break;
            case 3:
                SoundManager.Instance.PlayAudioChucDung3(chon);
                break;
            case 4:
                SoundManager.Instance.PlayAudioChucDung4(chon);
                break;
            case 5:
                SoundManager.Instance.PlayAudioChucDung5(chon);
                break;
            default:
                SoundManager.Instance.PlayAudioChucDung2(chon);
                break;

        }

        if (mDiemB1 < 91)
        {
            currentState = State.InGame1;

        }
        else
        {
            GameOver();
        }



    }

    public void GameOver()
    {
        currentState = State.Start;
        PopUpController.instance.HideQuestionBangNhau();
        if (mDiemB1 < 0)
        {
            mDiemB1 = 0;
        }
        GameController.instance.sumCoin += mDiemB1;
        GameController.instance.sumTime += mTime;
        PopUpController.instance.ShowStopBangNhau(mDiemB1, ClsThaoTac.CoverTimeToString(1200 - mTime));
        resetTL();
    }
    public void resetTL()
    {
        mTime = 1200;

        demframe = 0;
        mDem = 0;

        mDiemB1 = 0;
        setEmptyChild();
        khocCuoi.SetSprite("nguoihoi");
        txtLoading.gameObject.SetActive(true);
    }

    public void setEmptyChild()
    {

        foreach (Transform child in this.transform)
        {

            if (child.gameObject.CompareTag("nguoi"))
            {
                continue;
            }
            child.gameObject.SetActive(false);
        }






    }



  
    void onClick_sp1()
    {

        doXuLy(bt1);
    }

    void onClick_sp2()
    {

        doXuLy(bt2);
    }

    void onClick_sp3()
    {

        doXuLy(bt3);
    }

    void onClick_sp4()
    {

        doXuLy(bt4);
    }



    void onClick_sp5()
    {

        doXuLy(bt5);
    }

    void onClick_sp6()
    {

        doXuLy(bt6);
    }

    void onClick_sp7()
    {

        doXuLy(bt7);
    }

    void onClick_sp8()
    {

        doXuLy(bt8);
    }
    void onClick_sp9()
    {

        doXuLy(bt9);
    }
    void onClick_sp10()
    {

        doXuLy(bt10);
    }
    void onClick_sp11()
    {

        doXuLy(bt11);
    }
    void onClick_sp12()
    {

        doXuLy(bt12);
    }

    void onClick_sp13()
    {

        doXuLy(bt13);
    }

    void onClick_sp14()
    {

        doXuLy(bt14);
    }

    void onClick_sp15()
    {

        doXuLy(bt15);
    }

    void onClick_sp16()
    {

        doXuLy(bt16);
    }

    void onClick_sp17()
    {

        doXuLy(bt17);
    }

    void onClick_sp18()
    {

        doXuLy(bt18);
    }

    void onClick_sp19()
    {

        doXuLy(bt19);
    }

    void onClick_sp20()
    {

        doXuLy(bt20);
    }




    void CreateLevel(float positionX, float positionY, PhepToan vio, int thutu)
    {

        SpItem levelCreate = spPrefab.Spawn<SpItem>
            (
               new Vector3(positionX, positionY, 71),
             spPrefab.transform.rotation
            );
        levelCreate.gameObject.GetComponent<tk2dSprite>().scale = new Vector3(2.4f, 2.4f, 1);
        levelCreate.Giatri = ClsThaoTac.doKetQua(vio.Ketqua);
        levelCreate.Pheptoan = "" + vio.Congthuc;
        levelCreate.setData(vio.Loai);
        levelCreate.Trangthai = true;
        //levelCreate.Vitri = thutu;


        sp = levelCreate.GetComponent<tk2dUIItem>();

        switch (thutu)
        {
            case 1:
                bt1 = levelCreate;
                sp.OnClick += onClick_sp1;
                break;
            case 2:
                bt2 = levelCreate;
                sp.OnClick += onClick_sp2;
                break;
            case 3:
                bt3 = levelCreate;
                sp.OnClick += onClick_sp3;
                break;
            case 4:
                bt4 = levelCreate;
                sp.OnClick += onClick_sp4;
                break;
            case 5:
                bt5 = levelCreate;
                sp.OnClick += onClick_sp5;
                break;
            case 6:
                bt6 = levelCreate;
                sp.OnClick += onClick_sp6;
                break;
            case 7:
                bt7 = levelCreate;
                sp.OnClick += onClick_sp7;
                break;
            case 8:
                bt8 = levelCreate;
                sp.OnClick += onClick_sp8;
                break;
            case 9:
                bt9 = levelCreate;
                sp.OnClick += onClick_sp9;
                break;
            case 10:
                bt10 = levelCreate;
                sp.OnClick += onClick_sp10;
                break;
            case 11:
                bt11 = levelCreate;
                sp.OnClick += onClick_sp11;
                break;
            case 12:
                bt12 = levelCreate;
                sp.OnClick += onClick_sp12;
                break;
            case 13:
                bt13 = levelCreate;
                sp.OnClick += onClick_sp13;
                break;
            case 14:
                bt14 = levelCreate;
                sp.OnClick += onClick_sp14;
                break;
            case 15:
                bt15 = levelCreate;
                sp.OnClick += onClick_sp15;
                break;
            case 16:
                bt16 = levelCreate;
                sp.OnClick += onClick_sp16;
                break;
            case 17:
                bt17 = levelCreate;
                sp.OnClick += onClick_sp17;
                break;
            case 18:
                bt18 = levelCreate;
                sp.OnClick += onClick_sp18;
                break;
            case 19:
                bt19 = levelCreate;
                sp.OnClick += onClick_sp19;
                break;
            case 20:
                bt20 = levelCreate;
                sp.OnClick += onClick_sp20;
                break;
            default:
                Debug.Log("Default case");
                break;
        }

        levelCreate.transform.parent = this.gameObject.transform;


    }

    void doPhanPhat(ref List<PhepToan> lstP, ref int vt, ref float positionX, ref float positionY)
    {
        int chon = UnityEngine.Random.Range(0, lstP.Count);




        CreateLevel(positionX, positionY, lstP[chon], vt);
        lstP.RemoveAt(chon);

        positionX += distanceX;
        if ((vt) % 4 == 0)
        {
            positionY -= distanceY;
            positionX = startX;

        }
        vt++;
    }

    public void Create()
    {
       

        float positionX = startX;
        float positionY = startY;
        List<PhepToan> lstTMG = new List<PhepToan>();

        switch (GameController.instance.mGrade)
        {
            case 2:
                chonData2(ref lstTMG, GameController.instance.lstPhepToan2, GameController.instance.level);
                break;
            case 3:
                chonData3(ref lstTMG, GameController.instance.lstPhepToan3, GameController.instance.level);
                break;
            case 4:
                chonData4(ref lstTMG, GameController.instance.lstPhepToan4, GameController.instance.level);
                break;
            case 5:
                chonData5(ref lstTMG, GameController.instance.lstPhepToan5, GameController.instance.level);
                break;
            default:
                break;
        }






        if (checkCreate)
        {
            int vt = 1;

            for (int i = 0; i < 20; i++)
            {

                doPhanPhat(ref lstTMG, ref vt, ref positionX, ref positionY);
            }

            checkCreate = false;
        }
        else
        {
            setDataLst(ref lstTMG);
        }



        currentState = State.InGame1;
        txtLoading.gameObject.SetActive(false);
    }

    void setDataLst(ref List<PhepToan> lstP)
    {
        var children = new List<GameObject>();
        foreach (Transform child in this.transform)
        {
            children.Add(child.gameObject);
        }


        foreach (GameObject item in children)
        {

            if (item.CompareTag("nguoi"))
            {
                continue;
            }

            item.SetActive(true);

            int chon = UnityEngine.Random.Range(0, lstP.Count);

            item.GetComponent<SpItem>().Giatri = ClsThaoTac.doKetQua(lstP[chon].Ketqua);
            item.GetComponent<SpItem>().Pheptoan = "" + lstP[chon].Congthuc;
            item.GetComponent<SpItem>().setData(lstP[chon].Loai);
            item.GetComponent<SpItem>().Trangthai = true;

            lstP.RemoveAt(chon);
        }

    }

    void chonData2(ref List<PhepToan> tmg1, List<PhepToan> lstTam, int loai)
    {



        List<PhepToan> lstRank = new List<PhepToan>();
     

        foreach (PhepToan item in lstTam)
        {
            if (loai == 1 || loai == 2 || loai == 19)
            {
                if (item.Loai.Equals("" + 51) || item.Loai.Equals("" + 52))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 3 || loai == 4 || loai == 19)
            {
                if (item.Loai.Equals("" + 53) || item.Loai.Equals("" + 54) || item.Loai.Equals("" + 55) || item.Loai.Equals("" + 56))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 5||loai==19||loai==20)
            {
                if (item.Loai.Equals("" + 57) || item.Loai.Equals("" + 58))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 6)
            {
                if (item.Loai.Equals("" + 59) || item.Loai.Equals("" + 60))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 7||loai==20)
            {
                if (item.Loai.Equals("" + 61) || item.Loai.Equals("" + 62))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 8||loai==20)
            {
                if (item.Loai.Equals("" + 63) || item.Loai.Equals("" + 64))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 9||loai==20)
            {
                if (item.Loai.Equals("" + 65) || item.Loai.Equals("" + 66))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 10||loai==20)
            {
                if (item.Loai.Equals("" + 67) || item.Loai.Equals("" + 68))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 11||loai==20)
            {
                if (item.Loai.Equals("" + 69) || item.Loai.Equals("" + 70))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 12||loai==20)
            {
                if (item.Loai.Equals("" + 71) || item.Loai.Equals("" + 72))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 13)
            {
                if (item.Loai.Equals("" + 73) || item.Loai.Equals("" + 74))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 14)
            {
                if (item.Loai.Equals("" + 75) || item.Loai.Equals("" + 76))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 15)
            {
                if (item.Loai.Equals("" + 77) || item.Loai.Equals("" + 78))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 16)
            {
                if (item.Loai.Equals("" + 79) || item.Loai.Equals("" + 80))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 17)
            {
                if (item.Loai.Equals("" + 81) || item.Loai.Equals("" + 82))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 18)
            {
                if (item.Loai.Equals("" + 83) || item.Loai.Equals("" + 84))
                {
                    lstRank.Add(item);
                }
            }



            if (loai == 19 || loai == 20)
            {
                if (item.Loai.Equals("" + 59) || item.Loai.Equals("" + 60) || item.Loai.Equals("" + 73) || item.Loai.Equals("" + 74) || item.Loai.Equals("" + 75) || item.Loai.Equals("" + 76))
                {
                    lstRank.Add(item);
                }
            }
            
        }

        if (loai == 1)
        {
            lstRank = ClsThaoTac.ChuanHoaDaTa(0, 50, 0, lstRank);
        }
        else if (loai == 2)
        {
            lstRank = ClsThaoTac.ChuanHoaDaTa(20, 70, 1, lstRank);
        }
        else if (loai == 3)
        {
            lstRank = ClsThaoTac.ChuanHoaDaTa(0, 40, 0, lstRank);
        }
        else if (loai == 4)
        {
            lstRank = ClsThaoTac.ChuanHoaDaTa(30, 80, 1, lstRank);
        }

        #region Singleton
        if (loai == 1)
        {

            while (tmg1.Count < 15)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    PhepToan pt1;
                    if (chon % 3 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }

            PhepToan pt = new PhepToan("" + ClsLanguage.doHinhTron(), ""+(-1), "number");
            PhepToan pta = new PhepToan("", "" + (-1), "hinhtron");
            tmg1.Add(pt);
            tmg1.Add(pta);

            PhepToan pt11 = new PhepToan("" + ClsLanguage.doHinhTamGiac(), "" + (-2), "number");
            PhepToan pta1 = new PhepToan("", "" + (-2), "hinhtamgiac");
            tmg1.Add(pt11);
            tmg1.Add(pta1);


        }
        else if (loai == 2)
        {

            while (tmg1.Count < 15)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    PhepToan pt1;
                    if (chon % 4 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (chon % 3 == 0)
                    {
                        int nh = UnityEngine.Random.Range(0, 3);
                        if (nh == 0)
                        {
                            if (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) > 1)
                            {

                                pt1 = new PhepToan(ClsLanguage.doSoLienSau() + (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) - 1), lstRank[chon].Ketqua, "number");
                            }
                            else
                            {
                                pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                            }
                        }
                        else
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                    }
                    else
                    {
                        int chon1 = UnityEngine.Random.Range(0, 2);
                        if (chon1 == 0)
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                        }
                        else
                        {
                            pt1 = ClsThaoTac.getPhepToan(lstRank[chon], lstRank);
                        }
                    }
                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }

            PhepToan pt = new PhepToan("" + ClsLanguage.doHinhVuong(), "" + (-3), "number");
            PhepToan pta = new PhepToan("", "" + (-3), "hinhvuong");
            tmg1.Add(pt);
            tmg1.Add(pta);

            PhepToan pt11 = new PhepToan("" + ClsLanguage.doHinhTamGiac(), "" + (-2), "number");
            PhepToan pta1 = new PhepToan("", "" + (-2), "hinhtamgiac");
            tmg1.Add(pt11);
            tmg1.Add(pta1);


        }
        else if (loai == 3)
        {

            while (tmg1.Count < 15)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    PhepToan pt1;
                    if (chon % 4 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (chon % 3 == 0)
                    {
                        int nh = UnityEngine.Random.Range(0, 3);
                        if (nh == 0)
                        {
                            if (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) > 1)
                            {

                                pt1 = new PhepToan(ClsLanguage.doSoLienSau() + (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) - 1), lstRank[chon].Ketqua, "number");
                            }
                            else
                            {
                                pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                            }
                        }
                        else
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                    }
                    else
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }

            PhepToan pt = new PhepToan("" + ClsLanguage.doHinhNgoiSao(), "" + (-5), "number");
            PhepToan pta = new PhepToan("", "" + (-5), "hinhngoisao");
            tmg1.Add(pt);
            tmg1.Add(pta);

            PhepToan pt11 = new PhepToan("" + ClsLanguage.doHinhLucGiac(), "" + (-7), "number");
            PhepToan pta1 = new PhepToan("", "" + (-7), "hinhlucgiac");
            tmg1.Add(pt11);
            tmg1.Add(pta1);


        }
        else if (loai == 4 || loai == 7 || loai == 8 || loai == 9 || loai == 10 || loai == 11 || loai == 12 || loai == 15 || loai == 16 || loai == 17 || loai == 18)
        {

            while (tmg1.Count < 20)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    PhepToan pt1;
                    if (chon % 4 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (chon % 6 == 0)
                    {
                        int nh = UnityEngine.Random.Range(0, 3);
                        if (nh == 0)
                        {
                            if (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) > 1)
                            {

                                pt1 = new PhepToan(ClsLanguage.doSoLienSau() + (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) - 1), lstRank[chon].Ketqua, "number");
                            }
                            else
                            {
                                pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                            }
                        }
                        else
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                    }
                    else
                    {
                        int chon1 = UnityEngine.Random.Range(0, 2);
                        if (chon1 == 0)
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                        }
                        else
                        {
                            pt1 = ClsThaoTac.getPhepToan(lstRank[chon], lstRank);
                        }
                    }
                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }
        }
        else if (loai == 5 || loai == 6 || loai == 13 || loai == 14)
        {

            while (tmg1.Count < 20)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    PhepToan pt1;
                    if (chon % 4 == 0)
                    {
                        if (chon % 2 == 0)
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                        }
                        else
                        {

                            pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                        }
                    }
                    else if (chon % 7 == 0)
                    {
                        int nh = UnityEngine.Random.Range(0, 3);
                        if (nh == 0)
                        {
                            if (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) > 1)
                            {

                                pt1 = new PhepToan(ClsLanguage.doSoLienSau() + (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) - 1), lstRank[chon].Ketqua, "number");
                            }
                            else
                            {
                                pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                            }
                        }
                        else
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                    }
                    else
                    {

                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");

                    }
                    PhepToan pt2;
                    if (chon % 2 == 0)
                    {
                        pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        pt2 = ClsThaoTac.getCongThuc(lstRank[chon]);
                    }

                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }
        }
        else if (loai == 19 || loai == 20)
        {


            while (tmg1.Count < 20)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    PhepToan pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");

                    PhepToan pt2 = ClsThaoTac.getPhepToan(lstRank[chon], ref lstRank, chon);
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }


            }
        }
        #endregion
    }

    void chonData3(ref List<PhepToan> tmg1, List<PhepToan> lstTam, int loai)
    {

       

        List<PhepToan> lstRank = new List<PhepToan>();
        foreach (PhepToan item in lstTam)
        {
            if (loai == 1)
            {
                if (item.Loai.Equals("" + 30))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 2)
            {
                if (item.Loai.Equals("" + 21))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 3)
            {
                if (item.Loai.Equals("" + 22))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 4)
            {
                if (item.Loai.Equals("" + 35))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 5)
            {
                if (item.Loai.Equals("" + 23))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 6)
            {
                if (item.Loai.Equals("" + 24))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 7)
            {
                if (item.Loai.Equals("" + 36))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 8)
            {
                if (item.Loai.Equals("" + 26))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 9)
            {
                if (item.Loai.Equals("" + 27))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 10)
            {
                if (item.Loai.Equals("" + 28))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 11)
            {
                if (item.Loai.Equals("" + 29))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 12)
            {
                if (item.Loai.Equals("" + 37))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 13 || loai == 14)
            {
                if (item.Loai.Equals("" + 31))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 15 || loai == 16)
            {
                if (item.Loai.Equals("" + 32))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 17 || loai == 18)
            {
                if (item.Loai.Equals("" + 33))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 19 || loai == 20)
            {
                if (item.Loai.Equals("" + 34))
                {
                    lstRank.Add(item);
                }
            }

        }


        if (loai == 1)
        {

            while (tmg1.Count < 20)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    PhepToan pt1;
                    if (chon % 3 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }




        }
        else if (loai == 2)
        {

            while (tmg1.Count < 20)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    PhepToan pt1;
                    if (chon % 4 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (chon % 3 == 0)
                    {
                        int nh = UnityEngine.Random.Range(0, 3);
                        if (nh == 0)
                        {
                            if (chon > 1)
                            {

                                pt1 = new PhepToan(ClsLanguage.doSoLienSau() + (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) - 1), lstRank[chon].Ketqua, "number");
                            }
                            else
                            {
                                pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                            }
                        }
                        else
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                    }
                    else
                    {
                        int chon1 = UnityEngine.Random.Range(0, 2);
                        if (chon1 == 0)
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                        }
                        else
                        {
                            pt1 = ClsThaoTac.getPhepToan(lstRank[chon], lstRank);
                        }
                    }
                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }




        }
        else if (loai == 3)
        {

            while (tmg1.Count < 20)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    PhepToan pt1;
                    if (chon % 4 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (chon % 3 == 0)
                    {
                        int nh = UnityEngine.Random.Range(0, 3);
                        if (nh == 0)
                        {
                            if (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) > 1)
                            {

                                pt1 = new PhepToan(ClsLanguage.doSoLienSau() + (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) - 1), lstRank[chon].Ketqua, "number");
                            }
                            else
                            {
                                pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                            }
                        }
                        else
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                    }
                    else
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }




        }
        else if (loai == 4 || loai == 7)
        {
            string dv = "mm";
            if (loai == 4)
            {
                dv = "mm";
            }
            else
            {
                dv = "dm";
            }

            while (tmg1.Count < 20)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    PhepToan pt1;
                    if (chon % 2 == 0)
                    {
                        pt1 = ClsThaoTac.getPhepToan(lstRank[chon], lstRank);
                    }
                    else
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua + dv, lstRank[chon].Ketqua, "number");
                    }
                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }
            }
        }
        else if (loai == 12)
        {
            List<PhepToan> lstRankTam = new List<PhepToan>();
            lstRankTam = lstRank;

            while (tmg1.Count < 20)
            {

                int chon = UnityEngine.Random.Range(0, lstRankTam.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRankTam[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    string giacu = lstRankTam[chon].Congthuc;
                    string ketquacu = lstRankTam[chon].Ketqua;
                    string ptmoi = ClsThaoTac.getTimeCongThuc(giacu);



                    PhepToan pt1 = new PhepToan(ptmoi, ketquacu, "number");

                    lstRankTam.RemoveAt(chon);

                    var item = lstRankTam.Find(x => x.Ketqua == ketquacu);
                    if (item == null)
                    {
                        continue;
                    }
                    else
                    {
                        tmg1.Add(pt1);

                        giacu = item.Congthuc;
                        ketquacu = item.Ketqua;
                        ptmoi = ClsThaoTac.getTimeCongThuc(giacu);
                        PhepToan pt2 = new PhepToan(ptmoi, ketquacu, "number");
                        tmg1.Add(pt2);

                    }





                }
            }
        }
        else if (loai == 13 || loai == 14 || loai == 15 || loai == 16 || loai == 17 || loai == 18 || loai == 19 || loai == 20)
        {
            //3 so hang
            while (tmg1.Count < 20)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    PhepToan pt1;
                    if (chon % 4 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (chon % 6 == 0)
                    {
                        int nh = UnityEngine.Random.Range(0, 3);
                        if (nh == 0)
                        {
                            if (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) > 1)
                            {

                                pt1 = new PhepToan(ClsLanguage.doSoLienSau() + (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) - 1), lstRank[chon].Ketqua, "number");
                            }
                            else
                            {
                                pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                            }
                        }
                        else
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                    }
                    else
                    {
                        int chon1 = UnityEngine.Random.Range(0, 2);
                        if (chon1 == 0)
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                        }
                        else
                        {
                            pt1 = ClsThaoTac.getPhepToan(lstRank[chon], lstRank);
                        }
                    }
                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }
        }
        else if (loai == 5 || loai == 6 || loai == 8 || loai == 9 || loai == 10 || loai == 11)
        {
            //phep toan 2 so
            while (tmg1.Count < 20)
            {

                int chon = UnityEngine.Random.Range(0, lstRank.Count);
                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }
                if (ok == false)
                {
                    PhepToan pt1;
                    if (chon % 4 == 0)
                    {
                        if (chon % 2 == 0)
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                        }
                        else
                        {

                            pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                        }
                    }
                    else if (chon % 7 == 0)
                    {
                        int nh = UnityEngine.Random.Range(0, 3);
                        if (nh == 0)
                        {
                            if (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) > 1)
                            {

                                pt1 = new PhepToan(ClsLanguage.doSoLienSau() + (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) - 1), lstRank[chon].Ketqua, "number");
                            }
                            else
                            {
                                pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                            }
                        }
                        else
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                    }
                    else
                    {

                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");

                    }
                    PhepToan pt2;
                    if (chon % 6 == 0)
                    {
                        pt2 = ClsThaoTac.getCongThuc(lstRank[chon]);
                    }
                    else
                    {

                        pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    }

                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }
        }


    }

    void chonData4(ref List<PhepToan> tmg1, List<PhepToan> lstTam, int loai)
    {

      

        List<PhepToan> lstRank = new List<PhepToan>();
        foreach (PhepToan item in lstTam)
        {
            if (item.Loai.Equals("" + loai))
            {
                lstRank.Add(item);
            }
        }



        if (loai == 16 || loai == 17 || loai == 18)
        {
            while (tmg1.Count < 20)
            {
                int chon = UnityEngine.Random.Range(0, lstRank.Count);

                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }

                if (ok == false)
                {

                    PhepToan pt2 = new PhepToan(lstRank[chon].Congthuc, lstRank[chon].Ketqua, "phantrai");
                    PhepToan pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");

                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }
            }
        }
        else if (loai == 19 || loai == 20)
        {
            while (tmg1.Count < 20)
            {
                int chon = UnityEngine.Random.Range(0, lstRank.Count);

                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }

                if (ok == false)
                {


                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "phansohai");

                    PhepToan pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");

                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }
        }
        else if (loai == 14)
        {
            while (tmg1.Count < 20)
            {
                int chon = UnityEngine.Random.Range(0, lstRank.Count);

                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }

                if (ok == false)
                {
                    string tambo = "" + lstRank[chon].Congthuc;


                    if (tambo.Contains("/"))
                    {
                        tambo = "phanso";
                    }
                    else
                    {
                        tambo = "number";
                    }

                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, tambo);

                    PhepToan pt1 = ClsThaoTac.getPhepToan(lstRank[chon], ref lstRank, chon);

                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }

            }
        }
        else
        {
            while (tmg1.Count < 20)
            {
                int chon = UnityEngine.Random.Range(0, lstRank.Count);

                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }

                if (ok == false)
                {

                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");

                    PhepToan pt1;
                    if (chon % 2 == 0)
                    {

                        pt1 = ClsThaoTac.getPhepToan(lstRank[chon], ref lstRank, chon);
                    }
                    else
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }

                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }
            }
        }




    }

    void chonData5(ref List<PhepToan> tmg1, List<PhepToan> lstTam, int loai)
    {

      

        List<PhepToan> lstRank = new List<PhepToan>();
        foreach (PhepToan item in lstTam)
        {
            if (item.Loai.Equals("" + loai))
            {
                lstRank.Add(item);
            }
        }



        if (loai == 5)
        {
            while (tmg1.Count < 20)
            {
                int chon = UnityEngine.Random.Range(0, lstRank.Count);

                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (lstRank[chon].Ketqua == tmg1[i].Ketqua)
                    {
                        ok = true;
                        break;
                    }
                }

                if (ok == false)
                {

                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    double kqn = double.Parse(lstRank[chon].Ketqua);
                    int gtrd = UnityEngine.Random.Range(0, 8);
                    string stKq = "";


                    switch (gtrd)
                    {
                        case 0:
                            stKq = kqn + " mm";
                            break;
                        case 1:
                            stKq = (kqn / 10) + " cm";
                            break;
                        case 2:
                            stKq = (kqn / 100) + " dm";
                            break;
                        case 3:
                            stKq = (kqn / 1000000) + " km";
                            break;
                        case 4:
                            stKq = (kqn / 10000) + " dam";
                            break;
                        case 5:
                            stKq = (kqn / 100000) + " hm";
                            break;
                        default:
                            stKq = (kqn / 1000) + " m";
                            break;

                    }

                    PhepToan pt1 = new PhepToan(stKq, lstRank[chon].Ketqua, "number");

                    tmg1.Add(pt2);
                    tmg1.Add(pt1);

                }
            }
        }
        else
        {
            while (tmg1.Count < 20)
            {
                int chon = UnityEngine.Random.Range(0, lstRank.Count);

                bool ok = false;
                for (int i = 0; i < tmg1.Count; i++)
                {
                    if (ClsThaoTac.doKetQua(lstRank[chon].Ketqua) == ClsThaoTac.doKetQua(tmg1[i].Ketqua))
                    {
                        ok = true;
                        break;
                    }
                }

                if (ok == false)
                {
                    string tambo = "" + lstRank[chon].Congthuc;
                    string tambo2 = "" + lstRank[chon].Congthuc;
                    if (tambo.Contains("c"))
                    {
                        string[] mang = tambo.Split('c');
                        if (mang[0].Contains("/") && mang[1].Contains("/"))
                        {
                            tambo = "phanhai";
                        }
                        else if (mang[0].Contains("/"))
                        {
                            tambo = "phantrai";
                        }
                        else if (mang[1].Contains("/"))
                        {
                            tambo = "phanphai";
                        }
                        else
                        {
                            tambo = "number";
                            tambo2 = mang[0] + ClsLanguage.doOf() + mang[1];
                        }
                    }
                    else if (tambo.Contains("]"))
                    {
                        if (tambo.Contains("+") || tambo.Contains("-") || tambo.Contains("x") || tambo.Contains(":"))
                        {
                            tambo = "mixhai";
                        }
                        else
                        {
                            tambo = "mix";
                        }
                    }
                    else if (tambo.Contains("/"))
                    {
                        if (tambo.Contains("+") || tambo.Contains("-") || tambo.Contains("x") || tambo.Contains(":"))
                        {
                            string[] mang = tambo.Split(new Char[] { '-', '+', 'x', ':' });
                            if (mang.Length >= 3)
                            {

                                int dem = 0;
                                for (int i = 0; i < tambo.Count(); i++)
                                {
                                    string dkm = "" + tambo[i];
                                    if (dkm.Equals("/"))
                                    {
                                        dem++;
                                    }
                                }
                                if (dem >= 2)
                                {

                                    tambo = "phansoba";

                                }
                                else
                                {
                                    tambo = "phanso";
                                }
                            }
                            else
                            {
                                if (mang[0].Contains("/") && mang[1].Contains("/"))
                                {
                                    tambo = "phansohai";

                                }
                                else if (mang[0].Contains("/"))
                                {
                                    tambo = "phansotrai";
                                }
                                else if (mang[1].Contains("/"))
                                {
                                    tambo = "phansophai";
                                }
                                else
                                {
                                    tambo = "phanso";
                                }
                            }
                        }
                        else
                        {
                            tambo = "phanso";
                        }
                    }
                    else
                    {
                        tambo = "number";
                    }


                    PhepToan pt2 = new PhepToan(tambo2, lstRank[chon].Ketqua, tambo);
                    PhepToan pt1 = ClsThaoTac.getPhepToan(lstRank[chon], ref lstRank, chon);

                    tmg1.Add(pt2);
                    tmg1.Add(pt1);
                }
            }
        }




    }

    // Use this for initialization
    void Start()
    {
        txtLoading.text = ClsLanguage.doLoading();
    }

    // Update is called once per frame
    void Update()
    {

        if (currentState == State.InGame1 || currentState == State.Click1 || currentState == State.Click2)
        {
            if (demframe < 30)
            {
                demframe++;
            }
            else
            {
                mTime--;
                txtTime.text = ClsThaoTac.CoverTimeToString(mTime);
                //if (mTime <= 10)
                //{
                //    txtTime.color = new Color(1, 0, 1, 1);
                //}

                demframe = 0;
                if (mTime <= 0)
                {
                    GameOver();
                }
            }
        }

    }
}
