using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class QuestionSapXep : MonoBehaviour
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


    private tk2dSprite sprite;

    List<PhepToan> lstSapXep = new List<PhepToan>();
    public int mDiemB1 = 0;
    public tk2dSprite khocCuoi;

    int mTime = 1200;

    int demframe = 0;
    int mDem = 0;





    public tk2dTextMesh txtTime;
    public tk2dTextMesh txtLoading;

    bool checkCreate = true;

    public enum State
    {
        Start,
        InGame1,
        Click1

    }

    public State currentState;

    public void setPlay()
    {

        StartCoroutine(WaitTimeLoadData(1.2f));

    }



    IEnumerator WaitTimeLoadData(float time)
    {
        yield return new WaitForSeconds(time);
        Create();
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
    void doXuLy(SpItem bt)
    {

        if (currentState == State.InGame1)
        {
            if (bt.Trangthai == true)
            {
                //khi đã kích vào nút
                khocCuoi.SetSprite("nguoihoi");
                bt.Trangthai = false;
                sprite = bt.GetComponent<tk2dSprite>();
                sprite.color = new Color(1, 1, 0.5f, 1);
                currentState = State.Click1;
                SoundManager.Instance.PlayAudioClick();
                StartCoroutine(WaitTimeXuLySX(1f, bt));
            }
        }
    }

    IEnumerator WaitTimeXuLySX(float time, SpItem bt)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        if (lstSapXep.Count > 0)
        {

            double pSo = bt.Giatri;
            double tmgSo = double.Parse(lstSapXep[0].Ketqua);
            bt.Trangthai = true;
            //nếu đúng thì làm gì , sai thì lam j
            if (tmgSo == pSo)
            {


                sprite.color = new Color(1, 1, 1, 1);
                //RemoveEvent(bt);
               // bt.transform.parent = null;
                bt.gameObject.SetActive(false);
                lstSapXep.RemoveAt(0);
                mDiemB1 += 5;
                khocCuoi.SetSprite("nguoicuoi");
                SoundManager.Instance.Stop();
                SoundManager.Instance.PlayAudioChucTrue();
                StartCoroutine(WaitTimeDungRoiSX(0.5f));
            }
            else
            {

                mDiemB1 -= 1;
                StartCoroutine(WaitTimeSaiRoiSX(0.5f));
                khocCuoi.SetSprite("nguoikhoc");
            }
        }
    }
    IEnumerator WaitTimeSaiRoiSX(float time)
    {
        yield return new WaitForSeconds(time);

        // nếu sai

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



        sprite.color = new Color(1, 1, 1, 1);
        if (mDem >= 3)
        {
            // sai quá 3 lần thì game over
            GameOver();


        }
        else
        {
            currentState = State.InGame1;
        }

    }


    IEnumerator WaitTimeDungRoiSX(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);
        // nếu đúng

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
        if (lstSapXep.Count > 0)
        {

            currentState = State.InGame1;
        }
        else
        {
            //qua màn
            GameOver();
        }




    }

    void GameOver()
    {
        currentState = State.Start;
        PopUpController.instance.HideQuestionSapXep();
        if (mDiemB1 < 0)
        {
            mDiemB1 = 0;
        }
        GameController.instance.sumCoin += mDiemB1;
        GameController.instance.sumTime += mTime;
        PopUpController.instance.ShowStopSapXep(mDiemB1, ClsThaoTac.CoverTimeToString(1200 - mTime));
        resetTL();
    }
    public void resetTL()
    {
        //Đưa các giá trị về giá trị ban đầu
        mTime = 1200;

        demframe = 0;
        mDem = 0;

        mDiemB1 = 0;
        setEmptyChild();
        currentState = State.Start;
        lstSapXep.Clear();
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

    //void RemoveEvent(SpItem pSP)
    //{
    //    int tmg = pSP.Vitri;
    //    tk2dUIItem uiitem = pSP.GetComponent<tk2dUIItem>();
    //    switch (tmg)
    //    {
    //        case 1:
    //            uiitem.OnClick -= onClick_sp1;
    //            break;
    //        case 2:
    //            uiitem.OnClick -= onClick_sp2;
    //            break;
    //        case 3:
    //            uiitem.OnClick -= onClick_sp3;
    //            break;
    //        case 4:
    //            uiitem.OnClick -= onClick_sp4;
    //            break;
    //        case 5:
    //            uiitem.OnClick -= onClick_sp5;
    //            break;
    //        case 6:
    //            uiitem.OnClick -= onClick_sp6;
    //            break;
    //        case 7:
    //            uiitem.OnClick -= onClick_sp7;
    //            break;
    //        case 8:
    //            uiitem.OnClick -= onClick_sp8;
    //            break;
    //        case 9:
    //            uiitem.OnClick -= onClick_sp9;
    //            break;
    //        case 10:
    //            uiitem.OnClick -= onClick_sp10;
    //            break;
    //        case 11:
    //            uiitem.OnClick -= onClick_sp11;
    //            break;
    //        case 12:
    //            uiitem.OnClick -= onClick_sp12;
    //            break;
    //        case 13:
    //            uiitem.OnClick -= onClick_sp13;
    //            break;
    //        case 14:
    //            uiitem.OnClick -= onClick_sp14;
    //            break;
    //        case 15:
    //            uiitem.OnClick -= onClick_sp15;
    //            break;
    //        case 16:
    //            uiitem.OnClick -= onClick_sp16;
    //            break;
    //        case 17:
    //            uiitem.OnClick -= onClick_sp17;
    //            break;
    //        case 18:
    //            uiitem.OnClick -= onClick_sp18;
    //            break;
    //        case 19:
    //            uiitem.OnClick -= onClick_sp19;
    //            break;
    //        case 20:
    //            uiitem.OnClick -= onClick_sp20;
    //            break;
    //    }
    //}


    #region Singleton
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
    #endregion

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
        #region Singleton

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

       
       

        #endregion

        lstSapXep = lstSapXep.OrderBy(p => double.Parse(p.Ketqua)).ToList();

        //foreach (PhepToan item in lstSapXep)
        //{
        //    Debug.Log(""+item.Congthuc+" gt:"+item.Ketqua);
        //}


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

        int i = 0;
        foreach (GameObject item in children)
        {

            if (item.CompareTag("nguoi"))
            {
                continue;
            }

            item.SetActive(true);

            item.GetComponent<SpItem>().Giatri = ClsThaoTac.doKetQua(lstP[i].Ketqua);
            item.GetComponent<SpItem>().Pheptoan = "" + lstP[i].Congthuc;
            item.GetComponent<SpItem>().setData(lstP[i].Loai);
            item.GetComponent<SpItem>().Trangthai = true;
            i++;

        }

    }

    void chonData2(ref List<PhepToan> tmg1, List<PhepToan> lstTam, int loai)
    {


        List<PhepToan> lstRank = new List<PhepToan>();
        List<PhepToan> lstNhanBonNam = new List<PhepToan>();
   
        foreach (PhepToan item in lstTam)
        {
            if (loai == 4||loai==5)
            {
                if (item.Loai.Equals("" + 51) || item.Loai.Equals("" + 52))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 6 || loai == 7)
            {
                if (item.Loai.Equals("" + 53) || item.Loai.Equals("" + 54) || item.Loai.Equals("" + 55) || item.Loai.Equals("" + 56))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 8||loai==15||loai==19||loai==20)
            {
                if (item.Loai.Equals("" + 57) || item.Loai.Equals("" + 58))
                {
                    lstRank.Add(item);
                }

                if (loai == 15 || loai == 19 || loai == 20)
                {
                    if (item.Loai.Equals("" + 73) || item.Loai.Equals("" + 74))
                    {
                        lstRank.Add(item);
                    }
                }


                 if (loai == 19||loai==20)
                 {
                     if (item.Loai.Equals("" + 59) || item.Loai.Equals("" + 60) || item.Loai.Equals("" + 75) || item.Loai.Equals("" + 76))
                     {
                         lstRank.Add(item);
                     }
                 }

            }
            else if (loai == 9)
            {
                if (item.Loai.Equals("" + 61) || item.Loai.Equals("" + 62))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 10)
            {
                if (item.Loai.Equals("" + 63) || item.Loai.Equals("" + 64))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 11)
            {
                if (item.Loai.Equals("" + 65) || item.Loai.Equals("" + 66))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 12)
            {
                if (item.Loai.Equals("" + 67) || item.Loai.Equals("" + 68))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 13)
            {
                if (item.Loai.Equals("" + 69) || item.Loai.Equals("" + 70))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 14)
            {
                if (item.Loai.Equals("" + 71) || item.Loai.Equals("" + 72))
                {
                    lstRank.Add(item);
                }
            }
        
            else if (loai == 16)
            {
                if (item.Loai.Equals("" + 75) || item.Loai.Equals("" + 76) || item.Loai.Equals("" + 59) || item.Loai.Equals("" + 60))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 17)
            {
                if (item.Loai.Equals("" + 77) || item.Loai.Equals("" + 78) || item.Loai.Equals("" + 81) || item.Loai.Equals("" + 82))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 18)
            {
                if (item.Loai.Equals("" + 79) || item.Loai.Equals("" + 80) || item.Loai.Equals("" + 83) || item.Loai.Equals("" + 84))
                {
                    lstRank.Add(item);
                }
            }
        
          


            if (loai == 8||loai==16)
            {
                if (item.Loai.Equals("" + 59) || item.Loai.Equals("" + 60))
                {
                    lstNhanBonNam.Add(item);
                }
            }
           
        }

        if (loai == 4)
        {
            lstRank = ClsThaoTac.ChuanHoaDaTa(10, 80, 1, lstRank);
        }
        else if (loai == 6)
        {
            lstRank = ClsThaoTac.ChuanHoaDaTa(0, 50, 0, lstRank);
        }
        else if (loai == 7)
        {
            lstRank = ClsThaoTac.ChuanHoaDaTa(30, 100, 1, lstRank);
        }
        else if (loai == 8)
        {
            lstRank = lstRank.Concat(ClsThaoTac.ChuanHoaDaTa(1, 32, 0, lstNhanBonNam)).Concat(ClsThaoTac.FakeData(2, 50)).ToList();
        }
        else if (loai == 15)
        {
            lstRank = lstRank.Concat(ClsThaoTac.FakeData(2, 33)).ToList();
        }
        else if (loai == 16)
        {
            lstRank = lstRank.Concat(ClsThaoTac.FakeData(2, 52)).ToList();
        }

        #region Singleton
        if (loai == 4 || loai == 5 || loai == 19 || loai == 20)
        {
            //1 phep toan
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
                    if (chon % 7 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (chon % 4 == 0)
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        int nh = UnityEngine.Random.Range(0, 10);
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
                        else if (nh == 1)
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                        else if (nh == 2)
                        {
                            pt1 = ClsThaoTac.getCongThuc(lstRank[chon]);
                        }
                        else
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                        }
                    }

                    tmg1.Add(pt1);
                    lstSapXep.Add(pt1);
                }

            }




        }
        else if (loai == 6 || loai == 7 || loai == 9 || loai == 10 || loai == 11 || loai == 12 || loai == 13 || loai == 14 || loai == 17 || loai == 18)
        {
            //2 phep toan
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
                    if (chon % 7 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (chon % 4 == 0)
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        int nh = UnityEngine.Random.Range(0, 7);
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
                        else if (nh == 1)
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                        else
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                        }
                    }

                    tmg1.Add(pt1);
                    lstSapXep.Add(pt1);
                }

            }

        }
        else if (loai == 8 || loai == 15 || loai == 16)
        {
            //1 phep toan biet truopc number
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
                    if (chon % 7 == 0 && lstRank[chon].Loai.Equals("number"))
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (chon % 4 == 0 && lstRank[chon].Loai.Equals("number"))
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        int nh = UnityEngine.Random.Range(0, 7);
                        if (nh == 0 && lstRank[chon].Loai.Equals("number"))
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
                        else if (nh == 1 && lstRank[chon].Loai.Equals("number"))
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                        else if (nh == 2)
                        {
                            pt1 = ClsThaoTac.getCongThuc(lstRank[chon]);
                        }
                        else
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                        }
                    }

                    tmg1.Add(pt1);
                    lstSapXep.Add(pt1);
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
            if (loai == 4)
            {
                if (item.Loai.Equals("" + 30))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 5)
            {
                if (item.Loai.Equals("" + 21) || item.Loai.Equals("" + 22))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 6)
            {
                if (item.Loai.Equals("" + 23))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 7)
            {
                if (item.Loai.Equals("" + 35))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 8)
            {
                if (item.Loai.Equals("" + 24))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 9)
            {
                if (item.Loai.Equals("" + 25))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 10)
            {
                if (item.Loai.Equals("" + 36))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 11)
            {
                if (item.Loai.Equals("" + 26) || item.Loai.Equals("" + 28))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 12)
            {
                if (item.Loai.Equals("" + 27) || item.Loai.Equals("" + 29))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 13)
            {
                if (item.Loai.Equals("" + 37))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 14||loai==15)
            {
                if (item.Loai.Equals("" + 31))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 16)
            {
                if (item.Loai.Equals("" + 32))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 17||loai==18)
            {
                if (item.Loai.Equals("" + 33))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 19||loai==20)
            {
                if (item.Loai.Equals("" + 34))
                {
                    lstRank.Add(item);
                }
            }
                      
         
        }

        if (loai == 5)
        {
          lstRank= lstRank.Concat(ClsThaoTac.FakeData(70, 80)).ToList();
        }
        else if (loai == 6)
        {
           lstRank= lstRank.Concat(ClsThaoTac.FakeData(90, 100)).ToList();
        }

        #region Singleton
        if (loai == 4 || loai == 8 || loai == 9 || loai == 11 || loai == 12)
        {
            //1 phep toan
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
                    if (chon % 7 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (chon % 4 == 0)
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        int nh = UnityEngine.Random.Range(0, 10);
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
                        else if (nh == 1)
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                        else if (nh == 2)
                        {
                            pt1 = ClsThaoTac.getCongThuc(lstRank[chon]);
                        }
                        else
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                        }
                    }

                    tmg1.Add(pt1);
                    lstSapXep.Add(pt1);
                }

            }
        }
        else if (loai == 13)
        {
            //gio phut
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
                    string ptmoi = ClsThaoTac.getTimeCongThuc(lstRank[chon].Congthuc);
                    PhepToan pt1 = new PhepToan(ptmoi, lstRank[chon].Ketqua, "number");
                    tmg1.Add(pt1);
                    lstSapXep.Add(pt1);
                }
            }
        }
        else if (loai == 14 || loai == 15 || loai == 16 || loai == 17 || loai == 18 || loai == 19 || loai == 20)
        {
            //2 phep toan
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
                    if (chon % 7 == 0)
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (chon % 4 == 0)
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        int nh = UnityEngine.Random.Range(0, 7);
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
                        else if (nh == 1)
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                        else
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                        }
                    }

                    tmg1.Add(pt1);
                    lstSapXep.Add(pt1);
                }

            }

        }
        else if (loai == 7 || loai == 10)
        {
            string dv = "mm";
            if (loai == 7)
            {
                dv = "mm";
            }
            else
            {
                dv = "dm";
            }

            //1 phep toan biet truopc number
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
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua + dv, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    }

                    tmg1.Add(pt1);
                    lstSapXep.Add(pt1);
                }
            }
        }
        else if (loai == 5 || loai == 6)
        {
            //1 phep toan biet truopc number
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
                    if (chon % 7 == 0 && lstRank[chon].Loai.Equals("number"))
                    {
                        pt1 = new PhepToan(ClsLanguage.doNumber() + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else if (chon % 4 == 0 && lstRank[chon].Loai.Equals("number"))
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        int nh = UnityEngine.Random.Range(0, 7);
                        if (nh == 0 && lstRank[chon].Loai.Equals("number"))
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
                        else if (nh == 1 && lstRank[chon].Loai.Equals("number"))
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (lstRank[chon].Ketqua + 1), lstRank[chon].Ketqua, "number");
                        }
                        else if (nh == 2)
                        {
                            pt1 = ClsThaoTac.getCongThuc(lstRank[chon]);
                        }
                        else
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                        }
                    }

                    tmg1.Add(pt1);
                    lstSapXep.Add(pt1);
                }

            }




        }



        #endregion

    }

    void chonData4(ref List<PhepToan> tmg1, List<PhepToan> lstTam, int loai)
    {

        #region Singleton
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
                  
                    PhepToan pt1;
                    if (chon % 6 == 0)
                    {

                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        pt1 = new PhepToan(lstRank[chon].Congthuc, lstRank[chon].Ketqua, "phantrai");
                    }

                    tmg1.Add(pt1);
                    lstSapXep.Add(pt1);
                }
            }
        }
        else if (loai == 15)
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
                    PhepToan pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "phanso");
                    tmg1.Add(pt1);
                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, "" + ClsThaoTac.doKetQua(lstRank[chon].Ketqua), "number");
                    lstSapXep.Add(pt2);
                }
            }
        }
        else if (loai == 5)
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
                    tmg1.Add(pt1);
                    lstSapXep.Add(pt1);
                }
            }
        }
        else
        {
            lstRank = lstRank.OrderBy(p => double.Parse(p.Ketqua)).ToList();
            List<PhepToan> lstTG = ClsThaoTac.FakeData(int.Parse(lstRank[0].Ketqua), int.Parse(lstRank[lstRank.Count - 1].Ketqua), 15);
            foreach (PhepToan item in lstTG)
            {
                lstRank.Add(item);
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
                        pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                    }

                    tmg1.Add(pt1);
                    lstSapXep.Add(pt1);
                }
            }
        }


        #endregion


    }

    void chonData5(ref List<PhepToan> tmg1, List<PhepToan> lstTam, int loai)
    {

        #region Singleton
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
                    PhepToan pt1;
                    if (chon % 2 == 0)
                    {
                        pt1 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
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
                        pt1 = new PhepToan(stKq, lstRank[chon].Ketqua, "number");
                    }
                    tmg1.Add(pt1);
                    lstSapXep.Add(pt1);
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
                      PhepToan pt1;
                      PhepToan ptTm;
                      if (chon % 2 == 0)
                      {
                          if (lstRank[chon].Ketqua.Contains("/"))
                          {
                              pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "phanso");
                              ptTm = new PhepToan("" + lstRank[chon].Ketqua, "" + ClsThaoTac.doKetQua(lstRank[chon].Ketqua), "phanso");
                          }
                          else
                          {
                              pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                              ptTm = new PhepToan("" + lstRank[chon].Ketqua, "" + ClsThaoTac.doKetQua(lstRank[chon].Ketqua), "number");
                          }
                      }
                      else
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

                          pt1 = new PhepToan(tambo2, lstRank[chon].Ketqua, tambo);
                          ptTm = new PhepToan(tambo2, "" + ClsThaoTac.doKetQua(lstRank[chon].Ketqua),tambo);
                      }

                      tmg1.Add(pt1);
                      lstSapXep.Add(ptTm);
                }
            }
        }


        #endregion


    }

    // Use this for initialization
    void Start()
    {

        txtLoading.text = ClsLanguage.doLoading();

    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == State.InGame1 || currentState == State.Click1)
        {
            //đếm ngược thời gian từ 20 phút
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
                    //hết giờ thì game over
                    GameOver();
                }
            }
        }
    }
}
