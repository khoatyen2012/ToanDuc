using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class QuestionSapXepL1 : MonoBehaviour {

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
        levelCreate.gameObject.GetComponent<tk2dSprite>().scale = new Vector3(2.7f, 2.7f, 1);
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
        PopUpController.instance.HideQuestionSapXepL1();
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

  
    #endregion

    void doPhanPhat(ref List<PhepToan> lstP, ref int vt, ref float positionX, ref float positionY)
    {
        int chon = UnityEngine.Random.Range(0, lstP.Count);




        CreateLevel(positionX, positionY, lstP[chon], vt);
        lstP.RemoveAt(chon);

        positionX += distanceX;
        if ((vt) % 3 == 0)
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

        int sl = 12;

        if (GameController.instance.level == 4 || GameController.instance.level == 5)
        {
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 1).ToList();
            chonData(12, sl, 2, ref lstTMG, ref lstSapXep, query);
        }
        else if (GameController.instance.level == 6)
        {
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 1).ToList();
            chonData(12, sl, 4, ref lstTMG, ref lstSapXep, query);
            //phep toan vs hoa qua
        }
        else if (GameController.instance.level == 7)
        {
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 1).ToList();
            chonData(12, sl, 6, ref lstTMG, ref lstSapXep, query);
        }
        else if (GameController.instance.level == 8)
        {
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 1).ToList();
            chonData(12, sl, 5, ref lstTMG, ref lstSapXep, query);
        }
        else if (GameController.instance.level == 9)
        {
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 2).ToList();
            chonData(12, sl, 3, ref lstTMG, ref lstSapXep, query);

            //int GT = 12;

            //chonData(GT, sl, 3, ref lstTMG, ref lstSapXep, clsThaoTac.ChuanHoaData(GT, GameController.instance.lst2));
        }
        else if (GameController.instance.level == 10)
        {
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 2).ToList();
            chonData(12, sl, 6, ref lstTMG, ref lstSapXep, query);
        }
        else if (GameController.instance.level == 11)
        {

            // chonData(12, sl, 3, ref lstTMG, ref lstSapXep, GameController.instance.lst3);

            int GT = 12;
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 3).ToList();

            chonData(GT, sl, 3, ref lstTMG, ref lstSapXep, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
        }
        else if (GameController.instance.level == 12)
        {
            int GT = 12;

            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 3).ToList();
            chonData(GT, sl, 6, ref lstTMG, ref lstSapXep, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));

        }
        else if (GameController.instance.level == 13)
        {
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 4).ToList();
            int GT = 12;
            chonData(GT, sl, 3, ref lstTMG, ref lstSapXep, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
        }
        else if (GameController.instance.level == 14)
        {
            int GT = 12;
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 4).ToList();
            chonData(GT, sl, 1, ref lstTMG, ref lstSapXep, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
        }
        else if (GameController.instance.level == 15)
        {
            int GT = 12;
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 5).ToList();
            chonData(GT, sl, 3, ref lstTMG, ref lstSapXep, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
        }
        else if (GameController.instance.level == 16)
        {
            int GT = 12;
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 5).ToList();
            chonData(GT, sl, 6, ref lstTMG, ref lstSapXep, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
        }
        else if (GameController.instance.level == 17)
        {
            int GT = 12;
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 6).ToList();
            chonData(GT, sl, 3, ref lstTMG, ref lstSapXep, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
        }
        else if (GameController.instance.level == 18)
        {
            int GT = 12;
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 6).ToList();
            chonData(GT, sl, 6, ref lstTMG, ref lstSapXep, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
        }
        else if (GameController.instance.level == 19)
        {
            int GT = 12;

            chonData(GT, sl, 3, ref lstTMG, ref lstSapXep, GameController.instance.lstPhepToan1);
        }
        else if (GameController.instance.level == 20)
        {
            int GT = 12;
            chonData(GT, sl, 2, ref lstTMG, ref lstSapXep, GameController.instance.lstPhepToan1);
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

            for (int i = 0; i < 12; i++)
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

    void chonData(int GT, int sl, int type, ref List<PhepToan> tmg1, ref List<PhepToan> tmg2, List<PhepToan> lstRank)
    {

        string loai = "number";
        for (int i = GT - (sl - 1); i <= GT; i++)
        {

            //phep toan , so
            PhepToan vo;
            int chon = UnityEngine.Random.Range(0, 4);
            if ((chon == 0) && (type == 2 || type == 3 || type == 6))
            {
                loai = "number";
                vo = new PhepToan("" + i, ""+i, loai);
            }
            else if ((chon == 1) && (type == 3 || type == 4) && (i < 10))
            {
                int tn = UnityEngine.Random.Range(0, 3);
                if (tn == 0)
                {
                    loai = "tao";
                }
                else if (tn == 1)
                {
                    loai = "hoa";
                }
                else
                {
                    loai = "meo";
                }
                loai = loai + "" + i;

                if (i > 10)
                {
                    loai = "number";
                }

                vo = new PhepToan("" + i, ""+i, loai);
            }
            else if ((chon == 2) && (type == 5 || type == 6))
            {
                loai = "number";
                if (i > 1)
                {
                    vo = new PhepToan(ClsLanguage.doSoLienTruoc() + (i + 1), ""+i, loai);

                }
                else
                {
                    vo = new PhepToan(ClsLanguage.doSoLienSau() + (i - 1), ""+i, loai);

                }
            }
            else if (chon == 2 && type == 2)
            {
                vo = new PhepToan("" + i, ""+i, loai);
            }
            else
            {
                loai = "number";
                List<PhepToan> query1 = lstRank.FindAll(r =>int.Parse(r.Ketqua) == i);
                if (query1.Count > 0)
                {
                    int vt = UnityEngine.Random.Range(0, query1.Count);
                    vo = new PhepToan("" + query1[vt].Congthuc, ""+i, loai);
                }
                else
                {
                    vo = new PhepToan("" + i, ""+i, loai);
                }
            }

            tmg1.Add(vo);
            tmg2.Add(vo);


        }
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
