using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class QuestionBNLop1 : MonoBehaviour {



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

        if (mDiemB1 < 51)
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
        PopUpController.instance.HideQuestionBangNhauL1();
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


        float positionX = startX;
        float positionY = startY;
        List<PhepToan> lstTMG = new List<PhepToan>();

        int sl = 12;

        if (GameController.instance.level == 1 || GameController.instance.level == 2 || GameController.instance.level == 3)
        {
            string loai = "";
            string nameType = "";


            for (int i = 1; i <= ((sl / 2) - 1); i++)
            {

                int chontmg = UnityEngine.Random.Range(0, 4);

                if (chontmg == 0)
                {
                    loai = "meo";
                    nameType = ClsLanguage.doConMeo();
                }
                else if (chontmg == 1)
                {
                    loai = "hoa";
                    nameType = ClsLanguage.doBongHoa();
                }
                else
                {
                    loai = "tao";
                    nameType = ClsLanguage.doQuaTao();
                }

                loai = loai + "" + i;
                if (i > 10)
                {
                    loai = "number";
                }
                PhepToan vo = new PhepToan("" + i, ""+i, loai);
                PhepToan vi = new PhepToan("" + i + " " + nameType, ""+i, "number");
                lstTMG.Add(vo);
                lstTMG.Add(vi);
                // lstSapXep.Add(i);
            }

            if (GameController.instance.level == 1)
            {
                loai = "hinhtron";
                nameType = ClsLanguage.doHinhTron();

                PhepToan vo = new PhepToan("", ""+(-1), loai);
                PhepToan vi = new PhepToan("" + nameType, "" + (-1), "number");
                lstTMG.Add(vo);
                lstTMG.Add(vi);
            }
            else if (GameController.instance.level == 2)
            {
                loai = "hinhtamgiac";
                nameType = ClsLanguage.doHinhTamGiac();

                PhepToan vo = new PhepToan("", "" + (-2), loai);
                PhepToan vi = new PhepToan("" + nameType, "" + (-2), "number");
                lstTMG.Add(vo);
                lstTMG.Add(vi);
            }
            else
            {
                loai = "hinhvuong";
                nameType = ClsLanguage.doHinhVuong();

                PhepToan vo = new PhepToan("", "" + (-3), loai);
                PhepToan vi = new PhepToan("" + nameType, "" + (-3), "number");
                lstTMG.Add(vo);
                lstTMG.Add(vi);
            }




        }
        else if (GameController.instance.level == 4 || GameController.instance.level == 5)
        {
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 1).ToList();
            chonData(6, 2, ref lstTMG, query);
        }
        else if (GameController.instance.level == 6)
        {
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 2).ToList();
            chonData(6, 5, ref lstTMG, query);
            // phep toan vs phep toan lst2
        }
        else if (GameController.instance.level == 7)
        {
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 1).ToList();
            chonData(6, 6, ref lstTMG, query);
        }
        else if (GameController.instance.level == 8)
        {
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 1).ToList();
            chonData(6, 7, ref lstTMG, query);
        }
        else if (GameController.instance.level == 9)
        {
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 2).ToList();
            chonData(6, 1, ref lstTMG, query);
        }
        else if (GameController.instance.level == 10)
        {
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 2).ToList();
            chonData(6, 7, ref lstTMG, query);
        }
        else if (GameController.instance.level == 11)
        {
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 3).ToList();
            int GT = 6;

            chonData(GT, 2, ref lstTMG, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
        }
        else if (GameController.instance.level == 12)
        {
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 3).ToList();
            int GT = 6;

            chonData(GT, 4, ref lstTMG, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
        }
        else if (GameController.instance.level == 13)
        {

            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 4).ToList();
            int GT = 6;

            chonData(GT, 3, ref lstTMG, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));

        }
        else if (GameController.instance.level == 14)
        {
            int GT = 6;
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 4).ToList();
            chonData(GT, 5, ref lstTMG, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
        }
        else if (GameController.instance.level == 15)
        {
            int GT = 6;
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 5).ToList();
            chonData(GT, 4, ref lstTMG, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
        }
        else if (GameController.instance.level == 16)
        {
            int GT = 6;
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 5).ToList();
            chonData(GT, 3, ref lstTMG, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
        }
        else if (GameController.instance.level == 17)
        {
            int GT = 6;
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 6).ToList();
            chonData(GT, 3, ref lstTMG, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
        }
        else if (GameController.instance.level == 18)
        {
            int GT = 6;
            var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 6).ToList();
            chonData(GT, 5, ref lstTMG, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
        }
        else if (GameController.instance.level == 19)
        {
            int GT = 6;

            chonData(GT, 4, ref lstTMG, GameController.instance.lstPhepToan1);
        }
        else if (GameController.instance.level == 20)
        {
            int GT = 6;

            chonData(GT, 5, ref lstTMG, GameController.instance.lstPhepToan1);
        }






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

    void chonData(int GT, int type, ref List<PhepToan> tmg1, List<PhepToan> lstRank)
    {
        string loai = "";
        string nameType = "";

        if (type == 1)
        {

            for (int i = GT - 5; i < GT; i++)
            {

                PhepToan vo;
                PhepToan vi;

                int chon1 = UnityEngine.Random.Range(0, 2);
                if (chon1 == 0 && i <= 10)
                {


                    int chontmg = UnityEngine.Random.Range(0, 4);

                    if (chontmg == 0)
                    {
                        loai = "meo";
                        nameType = ClsLanguage.doConMeo();
                    }
                    else if (chontmg == 1)
                    {
                        loai = "hoa";
                        nameType = ClsLanguage.doBongHoa();
                    }
                    else
                    {
                        loai = "tao";
                        nameType = ClsLanguage.doQuaTao();
                    }
                    loai = loai + "" + i;
                    vo = new PhepToan("" + i, ""+i, loai);
                    vi = new PhepToan("" + i + " " + nameType, ""+i, "number");
                    tmg1.Add(vo);
                    tmg1.Add(vi);

                }
                else
                {
                    PhepToan vos;
                    PhepToan vis;
                    List<PhepToan> query1 = lstRank.FindAll(r => int.Parse(r.Ketqua) == i);
                    if (query1.Count > 0)
                    {
                        int vt = UnityEngine.Random.Range(0, query1.Count);
                        vos = new PhepToan("" + query1[vt].Congthuc, ""+i, "number");
                        vis = new PhepToan("" + i, ""+i, "number");
                    }
                    else
                    {
                        //xem xet
                        vos = new PhepToan(ClsLanguage.doNumber() + i, ""+i, "number");
                        vis = new PhepToan("" + i, ""+i, "number");
                    }
                    tmg1.Add(vos);
                    tmg1.Add(vis);
                }

            }
            int gtTam;

            int chon2 = UnityEngine.Random.Range(0, 4);
            if (chon2 == 0)
            {
                loai = "hinhtron";
                nameType = ClsLanguage.doHinhTron();
                gtTam = -1;
            }
            else if (chon2 == 1)
            {
                loai = "hinhtamgiac";
                nameType = ClsLanguage.doHinhTamGiac();
                gtTam = -2;
            }
            else
            {
                loai = "hinhvuong";
                nameType = ClsLanguage.doHinhVuong();
                gtTam = -3;
            }

            PhepToan voh = new PhepToan("", ""+gtTam, loai);
            PhepToan vih = new PhepToan("" + nameType, ""+gtTam, "number");
            tmg1.Add(voh);
            tmg1.Add(vih);




        }
        else
        {

            PhepToan vo;
            PhepToan vi;

            for (int i = GT - 5; i <= GT; i++)
            {
                int chon1 = UnityEngine.Random.Range(0, 5);
                if (type == 2)
                {
                    if ((chon1 == 0 || chon1 == 2) && (i <= 10))
                    {
                        int chontmg = UnityEngine.Random.Range(0, 4);

                        if (chontmg == 0)
                        {
                            loai = "meo";
                            nameType = ClsLanguage.doConMeo();
                        }
                        else if (chontmg == 1)
                        {
                            loai = "hoa";
                            nameType = ClsLanguage.doBongHoa();
                        }
                        else
                        {
                            loai = "tao";
                            nameType = ClsLanguage.doQuaTao();
                        }
                        loai = loai + "" + i;
                        vo = new PhepToan("" + i, ""+i, loai);
                        vi = new PhepToan("" + i + " " + nameType, ""+i, "number");
                        tmg1.Add(vo);
                        tmg1.Add(vi);
                    }
                    else
                    {

                        List<PhepToan> query1 = lstRank.FindAll(r => int.Parse(r.Ketqua) == i);
                        if (query1.Count > 0)
                        {
                            int vt = UnityEngine.Random.Range(0, query1.Count);
                            vo = new PhepToan("" + query1[vt].Congthuc, ""+i, "number");
                            vi = new PhepToan("" + i, ""+i, "number");
                        }
                        else
                        {
                            //xem xet
                            vo = new PhepToan(ClsLanguage.doNumber() + i, ""+i, "number");
                            vi = new PhepToan("" + i, ""+i, "number");
                        }
                        tmg1.Add(vo);
                        tmg1.Add(vi);
                    }
                }
                else if (type == 3)
                {
                    List<PhepToan> query1 = lstRank.FindAll(r => int.Parse(r.Ketqua) == i);
                    if (query1.Count > 0)
                    {
                        int vt = UnityEngine.Random.Range(0, query1.Count);
                        vo = new PhepToan("" + query1[vt].Congthuc, ""+i, "number");
                        vi = new PhepToan("" + i, ""+i, "number");
                    }
                    else
                    {
                        //xem xet
                        vo = new PhepToan(ClsLanguage.doNumber() + i, ""+i, "number");
                        vi = new PhepToan("" + i, ""+i, "number");
                    }
                    tmg1.Add(vo);
                    tmg1.Add(vi);
                }
                else if (type == 4)
                {
                    if (chon1 == 0)
                    {
                        List<PhepToan> query1 = lstRank.FindAll(r => int.Parse(r.Ketqua) == i);
                        if (query1.Count > 0)
                        {
                            int vt = UnityEngine.Random.Range(0, query1.Count);
                            if (query1.Count != 1)
                            {
                                int vt2 = UnityEngine.Random.Range(0, query1.Count);

                                vo = new PhepToan("" + query1[vt].Congthuc, ""+i, "number");
                                vi = new PhepToan("" + query1[vt2].Congthuc, ""+i, "number");
                            }
                            else
                            {
                                vo = new PhepToan("" + query1[vt].Congthuc, ""+i, "number");
                                vi = new PhepToan("" + i, ""+i, "number");
                            }
                        }
                        else
                        {
                            //xem xet
                            vo = new PhepToan(ClsLanguage.doNumber() + i, ""+i, "number");
                            vi = new PhepToan("" + i, ""+i, "number");
                        }
                        tmg1.Add(vo);
                        tmg1.Add(vi);
                    }
                    else
                    {
                        List<PhepToan> query1 = lstRank.FindAll(r => int.Parse(r.Ketqua) == i);
                        if (query1.Count > 0)
                        {
                            int vt = UnityEngine.Random.Range(0, query1.Count);
                            vo = new PhepToan("" + query1[vt].Congthuc, ""+i, "number");
                            vi = new PhepToan("" + i, ""+i, "number");
                        }
                        else
                        {
                            //xem xet
                            vo = new PhepToan(ClsLanguage.doNumber() + i, ""+i, "number");
                            vi = new PhepToan("" + i, ""+i, "number");
                        }
                        tmg1.Add(vo);
                        tmg1.Add(vi);
                    }
                }
                else if (type == 5)
                {
                    List<PhepToan> query1 = lstRank.FindAll(r => int.Parse(r.Ketqua) == i);
                    if (query1.Count > 0)
                    {
                        int vt = UnityEngine.Random.Range(0, query1.Count);
                        if (query1.Count != 1)
                        {
                            int vt2 = UnityEngine.Random.Range(0, query1.Count);

                            vo = new PhepToan("" + query1[vt].Congthuc, ""+i, "number");
                            vi = new PhepToan("" + query1[vt2].Congthuc, ""+i, "number");
                        }
                        else
                        {
                            vo = new PhepToan("" + query1[vt].Congthuc, ""+i, "number");
                            vi = new PhepToan("" + i, ""+i, "number");
                        }
                    }
                    else
                    {
                        //xem xet
                        vo = new PhepToan(ClsLanguage.doNumber() + i, ""+i, "number");
                        vi = new PhepToan("" + i, ""+i, "number");
                    }
                    tmg1.Add(vo);
                    tmg1.Add(vi);
                }
                else if (type == 6 || type == 7)
                {
                    if (chon1 == 0)
                    {
                        List<PhepToan> query1 = lstRank.FindAll(r => int.Parse(r.Ketqua) == i);
                        if (query1.Count > 0)
                        {
                            int vt = UnityEngine.Random.Range(0, query1.Count);
                            vo = new PhepToan("" + query1[vt].Congthuc, ""+i, "number");
                            vi = new PhepToan("" + i, ""+i, "number");
                        }
                        else
                        {
                            //xem xet
                            vo = new PhepToan(ClsLanguage.doNumber() + i, ""+i, "number");
                            vi = new PhepToan("" + i, ""+i, "number");
                        }
                        tmg1.Add(vo);
                        tmg1.Add(vi);
                    }
                    else if (chon1 == 1)
                    {
                        List<PhepToan> query1 = lstRank.FindAll(r =>int.Parse(r.Ketqua) == i);
                        if (query1.Count > 0)
                        {
                            int vt = UnityEngine.Random.Range(0, query1.Count);
                            if (query1.Count != 1)
                            {
                                int vt2 = UnityEngine.Random.Range(0, query1.Count);

                                vo = new PhepToan("" + query1[vt].Congthuc, ""+i, "number");
                                vi = new PhepToan("" + query1[vt2].Congthuc, ""+i, "number");
                            }
                            else
                            {
                                vo = new PhepToan("" + query1[vt].Congthuc, ""+i, "number");
                                vi = new PhepToan("" + i, ""+i, "number");
                            }
                        }
                        else
                        {
                            //xem xet
                            vo = new PhepToan(ClsLanguage.doNumber() + i, ""+i, "number");
                            vi = new PhepToan("" + i, ""+i, "number");
                        }
                        tmg1.Add(vo);
                        tmg1.Add(vi);
                    }
                    else if (chon1 == 2 || chon1 == 3)
                    {
                        if (chon1 == 2)
                        {
                            if (i > 1)
                            {
                                vo = new PhepToan(ClsLanguage.doSoLienTruoc() + (i + 1), ""+i, "number");
                                vi = new PhepToan("" + i, ""+i, "number");
                            }
                            else
                            {
                                vo = new PhepToan(ClsLanguage.doSoLienSau() + (i - 1), ""+i, "number");
                                vi = new PhepToan("" + i, ""+i, "number");
                            }

                        }
                        else
                        {
                            vo = new PhepToan(ClsLanguage.doSoLienSau() + (i - 1), ""+i, "number");
                            vi = new PhepToan("" + i, ""+i, "number");
                        }
                        tmg1.Add(vo);
                        tmg1.Add(vi);
                    }
                    else
                    {
                        if (type == 7)
                        {
                            List<PhepToan> query1 = lstRank.FindAll(r =>int.Parse(r.Ketqua) == i);
                            if (query1.Count > 0)
                            {
                                int vt = UnityEngine.Random.Range(0, query1.Count);



                                string trs = "";
                                if (vt % 2 == 0)
                                {
                                    if (i > 1)
                                    {
                                        trs = ClsLanguage.doSoLienTruoc() + (i + 1);
                                    }
                                    else
                                    {
                                        trs = ClsLanguage.doSoLienSau() + (i - 1);
                                    }
                                }
                                else
                                {
                                    trs = ClsLanguage.doSoLienSau() + (i - 1);
                                }

                                vo = new PhepToan("" + trs, ""+i, "number");
                                vi = new PhepToan("" + query1[vt].Congthuc, ""+i, "number");


                            }
                            else
                            {
                                //xem xet
                                vo = new PhepToan(ClsLanguage.doNumber() + i, ""+i, "number");
                                vi = new PhepToan("" + i, ""+i, "number");
                            }



                        }
                        else
                        {
                            vo = new PhepToan(ClsLanguage.doSoLienSau() + (i - 1), ""+i, "number");
                            vi = new PhepToan("" + i, ""+i, "number");
                        }
                        tmg1.Add(vo);
                        tmg1.Add(vi);
                    }
                }


            }

        }
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
