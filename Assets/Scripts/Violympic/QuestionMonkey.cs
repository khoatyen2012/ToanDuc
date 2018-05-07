using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class QuestionMonkey : MonoBehaviour
{


    public SpItemMonkey spPrefab;
    public float startX;
    public float distanceX;

    public float startY;
    public tk2dSprite ConKhi;

    private SpItemMonkey bt1;
    private SpItemMonkey bt2;
    private SpItemMonkey bt3;
    private SpItemMonkey bt4;
    private SpItemMonkey bt5;
    private SpItemMonkey bt6;
    private SpItemMonkey bt7;
    private SpItemMonkey bt8;
    private SpItemMonkey bt9;
    private SpItemMonkey bt10;
    private SpItemMonkey bt11;
    private SpItemMonkey bt12;
    private SpItemMonkey bt13;
    private SpItemMonkey bt14;
    private SpItemMonkey bt15;
    private SpItemMonkey bt16;
    private SpItemMonkey bt17;
    private SpItemMonkey bt18;
    private SpItemMonkey bt19;
    private SpItemMonkey bt20;

    public GameObject respawn;

    public GameObject XuLy;
    private tk2dUIItem sp;

    public float KhoangCach;
    int buoc = 1;
    private float positionStartX;
    public tk2dUIItem btnNext;
    private SpItemMonkey BangSoSanh;
    private SpItemMonkey BangKq;

    List<SpItemMonkey> children = new List<SpItemMonkey>();
    int vtg;

    private tk2dSprite sprite;

    int mDem = 0;



    int mTime = 1200;

    int demframe = 0;
    public tk2dTextMesh txtTime;
    public tk2dTextMesh txtLoading;
    int mDiemB3 = 0;

    public GameObject taptap;
    public bool checkNext = true;


    public enum State
    {
        Start,
        InGame1,
        Click1

    }

    public State currentState;


    void btnOnClick_Next()
    {
        if (currentState == State.InGame1)
        {
            if (buoc < 4)
            {
                buoc++;
                respawn.transform.position = new Vector3(respawn.transform.position.x - KhoangCach, respawn.transform.position.y, respawn.transform.position.z);

            }
            else
            {
                buoc = 1;
                respawn.transform.position = new Vector3(positionStartX, respawn.transform.position.y, respawn.transform.position.z);
            }


            XuLy.transform.position = respawn.transform.position;
        }

        taptap.SetActive(false);
        checkNext = false;

    }

    public void XuatDaTa()
    {
        if (children.Count > 0)
        {
            PhepToan tmvi;
            int chon = UnityEngine.Random.Range(0, children.Count);

            vtg = chon;

            tmvi = new PhepToan(children[chon].Pheptoan, ""+children[chon].Giatri, children[chon].mLoai);
            BangKq = children[chon];


            SpItemMonkey levelCreate = spPrefab.Spawn<SpItemMonkey>
                (
                   new Vector3(-32f, -233f, 33),
                 spPrefab.transform.rotation
                );
            levelCreate.Giatri = ClsThaoTac.doKetQua(tmvi.Ketqua);
            levelCreate.Pheptoan = "" + tmvi.Congthuc;

            levelCreate.setData(tmvi.Loai);
            BangSoSanh = levelCreate;
            BangSoSanh.gameObject.SetActive(true);
            currentState = State.InGame1;

            ConKhi.SetSprite("khihoi");

        }


    }


    public void loadData()
    {
        StartCoroutine(WaitTimeLoadData(1.2f));
    }

    IEnumerator WaitTimeLoadData(float time)
    {
        yield return new WaitForSeconds(time);
        Create();
    }

    public void Create()
    {


        float positionX = startX;

        List<PhepToan> lstTMG = new List<PhepToan>();
        List<PhepToan> lstTMG2 = new List<PhepToan>();

        switch (GameController.instance.mGrade)
        {
            case 2:
                chonData2(ref lstTMG, ref lstTMG2, GameController.instance.lstPhepToan2, GameController.instance.level);
                break;
            case 3:
                chonData3(ref lstTMG, ref lstTMG2, GameController.instance.lstPhepToan3, GameController.instance.level);
                break;
            case 4:
                chonData4(ref lstTMG, ref lstTMG2, GameController.instance.lstPhepToan4, GameController.instance.level);
                break;
            case 5:
                chonData5(ref lstTMG, ref lstTMG2, GameController.instance.lstPhepToan5, GameController.instance.level);
                break;
            default:
                if (GameController.instance.level == 1 || GameController.instance.level == 2 || GameController.instance.level == 3)
                {

                    string loai = "";
                    string nameType = "";


                    for (int i = 1; i < 10; i++)
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

                        if (i > 10)
                        {
                            loai = "number";
                        }



                        PhepToan vo = new PhepToan("" + i, ""+i, loai+""+i);
                        PhepToan vi = new PhepToan("" + i + " " + nameType, ""+i, "number");

                        int chon = UnityEngine.Random.Range(0, 3);
                        if (chon == 0)
                        {
                            lstTMG.Add(vo);
                            lstTMG2.Add(vi);
                            // lstXuLy.Add(vi);
                        }
                        else
                        {
                            //lstXuLy.Add(vo);
                            lstTMG2.Add(vo);
                            lstTMG.Add(vi);
                        }




                        // lstSapXep.Add(i);
                    }

                    PhepToan vov;
                    PhepToan viv;
                    if (GameController.instance.level == 1)
                    {


                        loai = "hinhtamgiac";
                        nameType = ClsLanguage.doHinhTamGiac();

                        vov = new PhepToan("", ""+(-1), loai);
                        viv = new PhepToan("" + nameType, "" + (-1), "number");

                    }
                    else if (GameController.instance.level == 2)
                    {


                        loai = "hinhvuong";
                        nameType = ClsLanguage.doHinhVuong();

                        vov = new PhepToan("", ""+(-2), loai);
                        viv = new PhepToan("" + nameType, "" + (-2), "number");

                    }
                    else
                    {
                        loai = "hinhtron";
                        nameType = ClsLanguage.doHinhTron();

                        vov = new PhepToan("", "" + (-3), loai);
                        viv = new PhepToan("" + nameType, "" + (-3), "number");

                    }

                    int chon1 = UnityEngine.Random.Range(0, 3);
                    if (chon1 == 0)
                    {
                        lstTMG.Add(vov);
                        lstTMG2.Add(viv);

                    }
                    else
                    {

                        lstTMG2.Add(vov);
                        lstTMG.Add(viv);
                    }






                }
                else if (GameController.instance.level == 4 || GameController.instance.level == 5)
                {
                    var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 1).ToList();
                    chonData1(10, 10, 2, ref lstTMG, ref lstTMG2, query);
                }
                else if (GameController.instance.level == 6)
                {
                    var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 1).ToList();
                    chonData1(10, 10, 4, ref lstTMG, ref lstTMG2, query);
                    //phep toan vs so, phep toan vs phep toan
                }
                else if (GameController.instance.level == 7)
                {
                    var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 1).ToList();
                    chonData1(10, 10, 6, ref lstTMG, ref lstTMG2, query);
                }
                else if (GameController.instance.level == 8)
                {
                    var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 1).ToList();
                    chonData1(10, 10, 7, ref lstTMG, ref lstTMG2, query);
                }
                else if (GameController.instance.level == 9)
                {
                    var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 2).ToList();
                    chonData1(10, 10, 1, ref lstTMG, ref lstTMG2, query);
                }
                else if (GameController.instance.level == 10)
                {
                    var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 2).ToList();
                    chonData1(10, 10, 7, ref lstTMG, ref lstTMG2, query);
                }
                else if (GameController.instance.level == 11)
                {
                    var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 3).ToList();
                    int GT = 10;
                    chonData1(GT, 10, 4, ref lstTMG, ref lstTMG2, ClsThaoTac.ChuanHoaDaTa(GT,query, 1));
                }
                else if (GameController.instance.level == 12)
                {
                    var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 3).ToList();
                    int GT = 10;
                    chonData1(GT, 10, 7, ref lstTMG, ref lstTMG2, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
                }
                else if (GameController.instance.level == 13)
                {

                    var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 4).ToList();

                    int GT = 10;
                    chonData1(GT, 10, 1, ref lstTMG, ref lstTMG2, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));

                }
                else if (GameController.instance.level == 14)
                {
                    var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 4).ToList();
                    int GT = 10;
                    chonData1(GT, 10, 7, ref lstTMG, ref lstTMG2, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
                }
                else if (GameController.instance.level == 15)
                {
                    var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 5).ToList();
                    int GT = 10;
                    chonData1(GT, 10, 2, ref lstTMG, ref lstTMG2, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
                }
                else if (GameController.instance.level == 16)
                {
                    var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 5).ToList();
                    int GT = 10;
                    chonData1(GT, 10, 7, ref lstTMG, ref lstTMG2, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
                }
                else if (GameController.instance.level == 17)
                {
                    var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 6).ToList();
                    int GT = 10;
                    chonData1(GT, 10, 1, ref lstTMG, ref lstTMG2, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
                }
                else if (GameController.instance.level == 18)
                {
                    var query = GameController.instance.lstPhepToan1.Where(p => int.Parse(p.Loai) == 6).ToList();
                    int GT = 10;
                    chonData1(GT, 10, 7, ref lstTMG, ref lstTMG2, ClsThaoTac.ChuanHoaDaTa(GT, query, 1));
                }
                else if (GameController.instance.level == 19)
                {
                    int GT = 10;
                    chonData1(GT, 10, 1, ref lstTMG, ref lstTMG2, GameController.instance.lstPhepToan1);
                }
                else if (GameController.instance.level == 20)
                {
                    int GT = 10;
                    chonData1(GT, 10, 7, ref lstTMG, ref lstTMG2, GameController.instance.lstPhepToan1);
                }
                break;
        }

        
        
       


        int vt = 1;

        for (int i = 1; i <= 10; i++)
        {

            doPhanPhat(ref lstTMG, ref lstTMG2, ref vt, ref positionX);
        }

        foreach (Transform child in XuLy.transform)
        {
            children.Add(child.GetComponent<SpItemMonkey>());

        }
        XuatDaTa();
        txtLoading.gameObject.SetActive(false);
    }
    void chonData1(int GT, int sl, int type, ref List<PhepToan> tmg1, ref List<PhepToan> tmg2, List<PhepToan> lstRank)
    {
        string loai = "";
        string nameType = "";

        if (type == 1)
        {

            for (int i = GT - (sl - 2); i <= GT; i++)
            {

                PhepToan vo;
                PhepToan vi;
                int chonj = UnityEngine.Random.Range(0, 3);

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

                    vo = new PhepToan("" + i, ""+i, loai+""+i);
                    vi = new PhepToan("" + i + " " + nameType, ""+i, "number");



                    if (chonj == 0)
                    {
                        tmg1.Add(vo);
                        tmg2.Add(vi);
                    }
                    else
                    {
                        tmg2.Add(vo);
                        tmg1.Add(vi);
                    }


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
                    if (chonj == 0)
                    {
                        tmg1.Add(vos);
                        tmg2.Add(vis);
                    }
                    else
                    {
                        tmg2.Add(vos);
                        tmg1.Add(vis);
                    }
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

            int chonk = UnityEngine.Random.Range(0, 3);

            if (chonk == 0)
            {
                tmg1.Add(voh);
                tmg2.Add(vih);
            }
            else
            {
                tmg2.Add(voh);
                tmg1.Add(vih);
            }




        }
        else
        {

            PhepToan vo;
            PhepToan vi;

            for (int i = GT - (sl - 1); i <= GT; i++)
            {
                int chonk = UnityEngine.Random.Range(0, 3);
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

                        vo = new PhepToan("" + i, ""+i, loai+""+i);
                        vi = new PhepToan("" + i + " " + nameType, ""+i, "number");


                        if (chonk == 0)
                        {
                            tmg1.Add(vo);
                            tmg2.Add(vi);
                        }
                        else
                        {
                            tmg2.Add(vo);
                            tmg1.Add(vi);
                        }
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
                        if (chonk == 0)
                        {
                            tmg1.Add(vo);
                            tmg2.Add(vi);
                        }
                        else
                        {
                            tmg2.Add(vo);
                            tmg1.Add(vi);
                        }
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
                    if (chonk == 0)
                    {
                        tmg1.Add(vo);
                        tmg2.Add(vi);
                    }
                    else
                    {
                        tmg2.Add(vo);
                        tmg1.Add(vi);
                    }
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
                        if (chonk == 0)
                        {
                            tmg1.Add(vo);
                            tmg2.Add(vi);
                        }
                        else
                        {
                            tmg2.Add(vo);
                            tmg1.Add(vi);
                        }
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
                        if (chonk == 0)
                        {
                            tmg1.Add(vo);
                            tmg2.Add(vi);
                        }
                        else
                        {
                            tmg2.Add(vo);
                            tmg1.Add(vi);
                        }
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
                    if (chonk == 0)
                    {
                        tmg1.Add(vo);
                        tmg2.Add(vi);
                    }
                    else
                    {
                        tmg2.Add(vo);
                        tmg1.Add(vi);
                    }
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
                        if (chonk == 0)
                        {
                            tmg1.Add(vo);
                            tmg2.Add(vi);
                        }
                        else
                        {
                            tmg2.Add(vo);
                            tmg1.Add(vi);
                        }
                    }
                    else if (chon1 == 1)
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
                        if (chonk == 0)
                        {
                            tmg1.Add(vo);
                            tmg2.Add(vi);
                        }
                        else
                        {
                            tmg2.Add(vo);
                            tmg1.Add(vi);
                        }
                    }
                    else if (chon1 == 2 || chon1 == 3)
                    {
                        if (chon1 == 2)
                        {
                            if (i > 1)
                            {
                                vo = new PhepToan(ClsLanguage.doSoLienTruoc() + (i + 1), ""+i, "number");
                                vi = new PhepToan("" + i,""+ i, "number");
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
                        if (chonk == 0)
                        {
                            tmg1.Add(vo);
                            tmg2.Add(vi);
                        }
                        else
                        {
                            tmg2.Add(vo);
                            tmg1.Add(vi);
                        }
                    }
                    else
                    {
                        if (type == 7)
                        {
                            List<PhepToan> query1 = lstRank.FindAll(r => int.Parse(r.Ketqua) == i);
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
                        if (chonk == 0)
                        {
                            tmg1.Add(vo);
                            tmg2.Add(vi);
                        }
                        else
                        {
                            tmg2.Add(vo);
                            tmg1.Add(vi);
                        }
                    }
                }


            }

        }
    }
    void chonData2(ref List<PhepToan> tmg1, ref List<PhepToan> tmg2, List<PhepToan> lstTam, int loai)
    {

        List<PhepToan> lstRank = new List<PhepToan>();
        foreach (PhepToan item in lstTam)
        {
            //them kieu dau tien
            if (loai == 1||loai==2)
            {
                if (item.Loai.Equals("" + 51) || item.Loai.Equals("" + 52))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 3||loai==4)
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

                if (loai == 19 || loai == 20)
                {
                    if (item.Loai.Equals("" + 59) || item.Loai.Equals("" + 60))
                    {
                        lstRank.Add(item);
                    }

                    if (item.Loai.Equals("" + 73) || item.Loai.Equals("" + 74))
                    {
                        lstRank.Add(item);
                    }

                    if (item.Loai.Equals("" + 75) || item.Loai.Equals("" + 76))
                    {
                        lstRank.Add(item);
                    }

                    if (loai == 19)
                    {
                        if (item.Loai.Equals("" + 51) || item.Loai.Equals("" + 52) || item.Loai.Equals("" + 53) || item.Loai.Equals("" + 54) || item.Loai.Equals("" + 55) || item.Loai.Equals("" + 56))
                        {
                            lstRank.Add(item);
                        }
                    }
                    else
                    {
                        if (item.Loai.Equals("" + 61) || item.Loai.Equals("" + 62) || item.Loai.Equals("" + 63) || item.Loai.Equals("" + 64) || item.Loai.Equals("" + 65) || item.Loai.Equals("" + 66) || item.Loai.Equals("" + 67) || item.Loai.Equals("" + 68) || item.Loai.Equals("" + 69) || item.Loai.Equals("" + 70) || item.Loai.Equals("" + 71) || item.Loai.Equals("" + 72))
                        {
                            lstRank.Add(item);
                        }
                    }

                }
            }
            else if (loai == 6)
            {
                if (item.Loai.Equals("" + 59) || item.Loai.Equals("" + 60))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 7)
            {
                if (item.Loai.Equals("" + 61) || item.Loai.Equals("" + 62))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 8)
            {
                if (item.Loai.Equals("" + 63) || item.Loai.Equals("" + 64))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 9)
            {
                if (item.Loai.Equals("" + 65) || item.Loai.Equals("" + 66))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 10)
            {
                if (item.Loai.Equals("" + 67) || item.Loai.Equals("" + 68))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 11)
            {
                if (item.Loai.Equals("" + 69) || item.Loai.Equals("" + 70))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 12)
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
         
        }

        if (loai == 1)
        {
            lstRank = ClsThaoTac.ChuanHoaDaTa(10, 80, 1, lstRank);
        }
        else if (loai == 2)
        {
            lstRank = ClsThaoTac.ChuanHoaDaTa(0, 50, 2, lstRank);
        }
        else if (loai == 3)
        {
            lstRank = ClsThaoTac.ChuanHoaDaTa(20, 80, 1, lstRank);
        }
        else if (loai == 4)
        {
            lstRank = ClsThaoTac.ChuanHoaDaTa(0, 40, 2, lstRank);
        }



        if (loai == 1)
        {

            while (tmg1.Count < 8)
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

                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                }

            }

            PhepToan pt = new PhepToan("" + ClsLanguage.doHinhTron(), ""+(-1), "number");
            PhepToan pta = new PhepToan("", "" + (-1), "monkeyhinhtron");
            int chons = UnityEngine.Random.Range(0, 3);
            if (chons == 0)
            {
                tmg1.Add(pt);
                tmg2.Add(pta);
            }
            else
            {
                tmg1.Add(pta);
                tmg2.Add(pt);
            }

            PhepToan pt11 = new PhepToan("" + ClsLanguage.doHinhChuNhat(), "" + (-4), "number");
            PhepToan pta1 = new PhepToan("", "" + (-4), "monkeyhinhchunhat");
            int chonk = UnityEngine.Random.Range(0, 3);
            if (chonk == 0)
            {
                tmg1.Add(pt11);
                tmg2.Add(pta1);
            }
            else
            {
                tmg1.Add(pta1);
                tmg2.Add(pt11);
            }


        }
        else if (loai == 2)
        {

            while (tmg1.Count < 8)
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
                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                }

            }

            PhepToan pt = new PhepToan("" + ClsLanguage.doHinhVuong(), ""+(-3), "number");
            PhepToan pta = new PhepToan("", "" + (-3), "monkeyhinhvuong");
            int chons = UnityEngine.Random.Range(0, 3);
            if (chons == 0)
            {
                tmg1.Add(pt);
                tmg2.Add(pta);
            }
            else
            {
                tmg1.Add(pta);
                tmg2.Add(pt);
            }


            PhepToan pt11 = new PhepToan("" + ClsLanguage.doHinhChuNhat(), "" + (-4), "number");
            PhepToan pta1 = new PhepToan("", "" + (-4), "monkeyhinhchunhat");
            int chonk = UnityEngine.Random.Range(0, 3);
            if (chonk == 0)
            {
                tmg1.Add(pt11);
                tmg2.Add(pta1);
            }
            else
            {
                tmg1.Add(pta1);
                tmg2.Add(pt11);
            }


        }
        else if (loai == 3)
        {

            while (tmg1.Count < 8)
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
                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                }

            }

            PhepToan pt = new PhepToan("" + ClsLanguage.doHinhNguGiac(), "" + (-6), "number");
            PhepToan pta = new PhepToan("", "" + (-6), "monkeyhinhngugiac");
            int chons = UnityEngine.Random.Range(0, 3);
            if (chons == 0)
            {
                tmg1.Add(pt);
                tmg2.Add(pta);
            }
            else
            {
                tmg1.Add(pta);
                tmg2.Add(pt);
            }


            PhepToan pt11 = new PhepToan("" + ClsLanguage.doHinhLucGiac(), "" + (-7), "number");
            PhepToan pta1 = new PhepToan("", "" + (-7), "monkeyhinhlucgiac");
            int chonk = UnityEngine.Random.Range(0, 3);
            if (chonk == 0)
            {
                tmg1.Add(pt11);
                tmg2.Add(pta1);
            }
            else
            {
                tmg1.Add(pta1);
                tmg2.Add(pt11);
            }


        }
        else if (loai == 4 || loai == 7 || loai == 8 || loai == 9 || loai == 10 || loai == 11 || loai == 12 || loai == 15 || loai == 16 || loai == 17 || loai == 18)
        {
            while (tmg1.Count < 10)
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
                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                }

            }
        }
        else if (loai == 5 || loai == 6 || loai == 13 || loai == 14)
        {
            while (tmg1.Count < 10)
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
                    PhepToan pt2;
                    if (chon % 2 == 0)
                    {
                        pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    }
                    else
                    {
                        pt2 = ClsThaoTac.getCongThuc(lstRank[chon]);
                    }

                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                }

            }
        }        
        else if (loai == 19||loai==20)
        {

            
            while (tmg1.Count < 10)
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
                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                }


            }
        }


    }

    void chonData3(ref List<PhepToan> tmg1, ref List<PhepToan> tmg2, List<PhepToan> lstTam, int loai)
    {

        List<PhepToan> lstRank = new List<PhepToan>();
        List<PhepToan> lstCongTru = new List<PhepToan>();
        List<PhepToan> lstMmCm = new List<PhepToan>();
        List<PhepToan> lstDmM = new List<PhepToan>();
        List<PhepToan> lstChia51150 = new List<PhepToan>();
        List<PhepToan> lstNhan69CongTru = new List<PhepToan>();
        List<PhepToan> lstNhan5199 = new List<PhepToan>();
        foreach (PhepToan item in lstTam)
        {

            //them kieu dau tien
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
                if (item.Loai.Equals("" + 23))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 5)
            {
                if (item.Loai.Equals("" + 24))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 6)
            {
                if (item.Loai.Equals("" + 25))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 7)
            {
                if (item.Loai.Equals("" + 26))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 8)
            {
                if (item.Loai.Equals("" + 27))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 9)
            {
                if (item.Loai.Equals("" + 28))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 10||loai==11)
            {
                if (item.Loai.Equals("" + 29))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 12||loai==14)
            {
                if (item.Loai.Equals("" + 31))
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
            else if (loai == 15||loai==16)
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





            //them tam thoi mang phu
            if (loai == 3 || loai == 4 || loai == 19)
            {
                if (item.Loai.Equals("" + 30))
                {
                    lstCongTru.Add(item);
                }
            }
            else if (loai == 7)
            {
                if (item.Loai.Equals("" + 35))
                {
                    lstMmCm.Add(item);
                }
            }
            else if (loai == 8||loai==11)
            {
                if (item.Loai.Equals("" + 36))
                {
                    lstDmM.Add(item);
                }
            }
            else if (loai ==14||loai==20)
            {
                if (item.Loai.Equals("" + 29))
                {
                    lstChia51150.Add(item);
                }
            }
            else if (loai == 16)
            {
                if (item.Loai.Equals("" + 31))
                {
                    lstNhan69CongTru.Add(item);
                }
            }
            else if (loai == 18 || loai == 20)
            {
                if (item.Loai.Equals("" + 25))
                {
                    lstNhan5199.Add(item);
                }
            }
        

        }



        //Them chinh thuc mang phu vao mang chinh
        if (loai == 3||loai==4)
        {
            lstRank = lstRank.Concat(ClsThaoTac.ChuanHoaDaTa(10, lstCongTru,2)).ToList();
        }
        else if (loai == 19)
        {
            lstRank = lstRank.Concat(lstCongTru).ToList();
        }
        else if (loai == 7)
        {
            lstRank = lstRank.Concat(ClsThaoTac.ChuanHoaDaTa(20, lstMmCm, 2)).ToList();
        }
        else if (loai == 8)
        {
            lstRank = lstRank.Concat(ClsThaoTac.ChuanHoaDaTa(20, lstDmM, 2)).ToList();
        }
        else if (loai == 11)
        {
            lstRank = lstRank.Concat(lstDmM).ToList();
        }
        else if (loai == 14)
        {
            lstRank = lstRank.Concat(lstChia51150).ToList();
        }
        else if (loai == 16)
        {
            lstRank = ClsThaoTac.ChuanHoaDaTa(200, lstRank, 2).Concat(ClsThaoTac.ChuanHoaDaTa(200, lstNhan69CongTru, 2)).ToList();
        }
        else if (loai == 18)
        {
            lstRank = ClsThaoTac.ChuanHoaDaTa(200, lstRank, 2).Concat(ClsThaoTac.ChuanHoaDaTa(200, lstNhan5199, 2)).ToList();
        }
        else if (loai == 20)
        {
            lstRank = lstRank.Concat(ClsThaoTac.ChuanHoaDaTa(50, lstNhan5199, 2)).Concat(ClsThaoTac.ChuanHoaDaTa(50, lstChia51150, 2)).ToList();
        }


        if (loai == 1)
        {
            // 1 phep toan don gian
            while (tmg1.Count < 10)
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

                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                }

            }




        }
        else if (loai == 13)
        {

            List<PhepToan> lstRankTam = new List<PhepToan>();
            lstRankTam = lstRank;
            while (tmg1.Count < 10)
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


                        giacu = item.Congthuc;
                        ketquacu = item.Ketqua;
                        ptmoi = ClsThaoTac.getTimeCongThuc(giacu);
                        PhepToan pt2 = new PhepToan(ptmoi, ketquacu, "number");
                        if (chon % 2 == 0)
                        {
                            tmg1.Add(pt1);
                            tmg2.Add(pt2);
                        }
                        else
                        {
                            tmg1.Add(pt2);
                            tmg2.Add(pt1);
                        }

                    }

                }
            }
        }
        else if (loai == 7 || loai == 8 || loai == 11)
        {
            string dv = "";
            while (tmg1.Count < 10)
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

                    if (int.Parse(lstRank[chon].Loai) == 35)
                    {
                        dv = "mm";
                    }
                    else if (int.Parse(lstRank[chon].Loai) == 36)
                    {
                        dv = "dm";
                    }
                    else
                    {
                        dv = "";
                    }

                    PhepToan pt1 = new PhepToan(lstRank[chon].Ketqua + dv, lstRank[chon].Ketqua, "number");

                    PhepToan pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");

                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                }
            }
        }

        else if (loai == 2 || loai == 5 || loai == 6 || loai == 9 || loai == 10 || loai == 12 || loai == 14 || loai == 15 || loai == 16 || loai == 17 || loai == 18 || loai == 19 || loai == 20)
        {
            // 1 2 phep deu dc
            while (tmg1.Count < 10)
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
                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                }

            }
        }
        else if (loai == 3 || loai == 4)
        {
            //chi 1 phep toan them lien trc sau cong thuc
            while (tmg1.Count < 10)
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
                    PhepToan pt2;
                    if (chon % 3 == 0)
                    {

                        pt2 = ClsThaoTac.getCongThuc(lstRank[chon]);
                    }
                    else
                    {
                        pt2 = new PhepToan("" + lstRank[chon].Congthuc, lstRank[chon].Ketqua, "number");
                    }

                    if (chon % 3 == 0)
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                    else
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);

                    }
                }

            }
        }



    }

    void chonData4(ref List<PhepToan> tmg1, ref List<PhepToan> tmg2, List<PhepToan> lstTam, int loai)
    {

        List<PhepToan> lstRank = new List<PhepToan>();
        foreach (PhepToan item in lstTam)
        {
            if (loai == 5)
            {
                if (item.Loai.Equals("" + (loai - 1)) || item.Loai.Equals("" + (loai + 1)))
                {
                    lstRank.Add(item);
                }
            }
            else if (loai == 15)
            {
                if (item.Loai.Equals("" + (loai - 2)) || item.Loai.Equals("" + (loai - 3)))
                {
                    lstRank.Add(item);
                }
            }
            else
            {
                if (item.Loai.Equals("" + loai))
                {
                    lstRank.Add(item);
                }
            }
        }


        if (loai == 16 || loai == 17 || loai == 18)
        {
            while (tmg1.Count < 10)
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
                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }

                }
            }
        }
        else if (loai == 19 || loai == 20)
        {
            while (tmg1.Count < 10)
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
                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                }
            }
        }
        else if (loai == 14)
        {
            while (tmg1.Count < 10)
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
                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                }
            }
        }
        else
        {

            while (tmg1.Count < 10)
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


                        int nh = UnityEngine.Random.Range(0, 4);
                        if (nh == 0)
                        {
                            if (double.Parse(lstRank[chon].Ketqua) > 1)
                            {

                                pt1 = new PhepToan(ClsLanguage.doSoLienSau() + (double.Parse(lstRank[chon].Ketqua) - 1), lstRank[chon].Ketqua, "number");
                            }
                            else
                            {
                                pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (double.Parse(lstRank[chon].Ketqua) + 1), lstRank[chon].Ketqua, "number");
                            }
                        }
                        else if (nh == 1)
                        {
                            pt1 = new PhepToan(ClsLanguage.doSoLienTruoc() + (double.Parse(lstRank[chon].Ketqua) + 1), lstRank[chon].Ketqua, "number");
                        }
                        else
                        {
                            pt1 = new PhepToan("" + lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                        }
                    }

                    if (chon % 3 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }

                }
            }
        }


    }

    void chonData5(ref List<PhepToan> tmg1, ref List<PhepToan> tmg2, List<PhepToan> lstTam, int loai)
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
            while (tmg1.Count < 10)
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

                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                }
            }
        }
        else
        {
            while (tmg1.Count < 10)
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
                    PhepToan pt1;
                    if (chon % 3 == 0)
                    {

                        if (lstRank[chon].Ketqua.Contains("/"))
                        {
                            pt1 = new PhepToan(lstRank[chon].Ketqua, lstRank[chon].Ketqua, "phanso");
                        }
                        else
                        {
                            pt1 = new PhepToan(lstRank[chon].Ketqua, lstRank[chon].Ketqua, "number");
                        }
                    }
                    else
                    {
                        pt1 = ClsThaoTac.getPhepToan(lstRank[chon], ref lstRank, chon);
                    }
                   // PhepToan pt1 = ClsThaoTac.getPhepToan(lstRank[chon], ref lstRank, chon);

                    if (chon % 2 == 0)
                    {
                        tmg1.Add(pt1);
                        tmg2.Add(pt2);
                    }
                    else
                    {
                        tmg1.Add(pt2);
                        tmg2.Add(pt1);
                    }
                }
            }
        }


    }


    void doPhanPhat(ref List<PhepToan> lstP, ref List<PhepToan> lstXL, ref int vt, ref float positionX)
    {
        int chon = UnityEngine.Random.Range(0, lstP.Count);




        CreateLevel(positionX, lstP[chon], vt);
        CreateLevel(positionX, lstXL[chon]);
        lstP.RemoveAt(chon);
        lstXL.RemoveAt(chon);

        if (vt % 3 == 0)
        {
            positionX += distanceX * 2;
        }
        else
        {
            positionX += distanceX;
        }

        vt++;
    }

    void CreateLevel(float positionX, PhepToan vio, int thutu)
    {


        SpItemMonkey levelCreate = spPrefab.Spawn<SpItemMonkey>
            (
               new Vector3(positionX, startY, 70f),
             spPrefab.transform.rotation
            );
        levelCreate.Giatri = ClsThaoTac.doKetQua(vio.Ketqua);
        levelCreate.Pheptoan = "" + vio.Congthuc;
        levelCreate.setData(vio.Loai);
        levelCreate.Trangthai = true;
        levelCreate.Vitri = thutu;



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
        levelCreate.transform.parent = respawn.transform;
    }

    void CreateLevel(float positionX, PhepToan vio)
    {

        SpItemMonkey levelCreate = spPrefab.Spawn<SpItemMonkey>
           (
              new Vector3(positionX, startY - 115f, 71f),
            spPrefab.transform.rotation
           );
        levelCreate.Giatri = ClsThaoTac.doKetQua(vio.Ketqua);
        levelCreate.Pheptoan = "" + vio.Congthuc;
        levelCreate.setData(vio.Loai);


        levelCreate.transform.parent = XuLy.transform;
        levelCreate.gameObject.SetActive(false);

    }
    IEnumerator WaitTimeXuatData(float time)
    {
        yield return new WaitForSeconds(time);
        XuatDaTa();
    }

    void doXuLy(SpItemMonkey bt)
    {
        if (currentState == State.InGame1)
        {
            if (bt.Trangthai == true)
            {
                bt.Trangthai = false;

                ConKhi.SetSprite("khixet");
                sprite = bt.GetComponent<tk2dSprite>();
                sprite.color = new Color(1, 1, 0.5f, 1);
                currentState = State.Click1;
                SoundManager.Instance.PlayAudioClick();
                StartCoroutine(WaitTimeXuLyTT(1f, bt));
            }
        }

    }

    IEnumerator WaitTimeXuLyTT(float time, SpItemMonkey bt)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        sprite.color = new Color(1, 1, 1, 1);

        if (bt.Giatri == BangSoSanh.Giatri)
        {
            mDiemB3 += 10;
            SoundManager.Instance.Stop();
            SoundManager.Instance.PlayAudioChucTrue();
            children.RemoveAt(vtg);
            //if (children.Count <= 0)
            //{
            //    GameOver();
            //}
            StartCoroutine(WaitTimeDungRoiTT(0.5f));
        }
        else
        {
            mDiemB3 -= 2;
            StartCoroutine(WaitTimeSaiRoiTT(0.5f));
            bt.Trangthai = true;
        }
    }
    IEnumerator WaitTimeDungRoiTT(float time)
    {
        //do something...............
        yield return new WaitForSeconds(time);

        SoundManager.Instance.Stop();
        ConKhi.SetSprite("khicuoi");

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
        BangKq.gameObject.SetActive(true);
        BangSoSanh.gameObject.SetActive(false);
        BangSoSanh.RecycleSp();


        if (children.Count > 0)
        {

            StartCoroutine(WaitTimeXuatData(1.5f));
        }
        else
        {
            StartCoroutine(WaitTimeGameOver(1f));
        }
    }

    IEnumerator WaitTimeGameOver(float time)
    {
        yield return new WaitForSeconds(time);
        GameOver();
    }

    IEnumerator WaitTimeSaiRoiTT(float time)
    {
        yield return new WaitForSeconds(time);

        SoundManager.Instance.Stop();
        ConKhi.SetSprite("khikhoc");
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
        BangSoSanh.gameObject.SetActive(false);
        BangSoSanh.RecycleSp();


        if (mDem >= 3)
        {
            StartCoroutine(WaitTimeGameOver(1f));



        }
        else
        {
            StartCoroutine(WaitTimeXuatData(1.5f));
        }
    }

    void GameOver()
    {
        currentState = State.Start;
        PopUpController.instance.HideQuestionMonkey();
        if (mDiemB3 < 0)
        {
            mDiemB3 = 0;
        }
        GameController.instance.sumCoin += mDiemB3;
        GameController.instance.sumTime += mTime;
        PopUpController.instance.ShowStopMonkey(mDiemB3, ClsThaoTac.CoverTimeToString(1200 - mTime));

        resetTL();
    }
    public void resetTL()
    {
        mTime = 1200;
        ConKhi.SetSprite("khixet");
        demframe = 0;
        mDem = 0;
        mDiemB3 = 0;
        buoc = 1;
        respawn.transform.position = new Vector3(positionStartX, respawn.transform.position.y, respawn.transform.position.z);
        XuLy.transform.position = respawn.transform.position;
        currentState = State.Start;
        children.Clear();
        txtLoading.gameObject.SetActive(true);

        //remove item in key chinh
        var keychinh = new List<GameObject>();
        foreach (Transform child in respawn.transform)
        {
            keychinh.Add(child.gameObject);
        }


        foreach (GameObject item in keychinh)
        {
            RemoveEvent(item.GetComponent<SpItemMonkey>());
            item.transform.parent = null;
            item.transform.Recycle();
        }

        // remove key phu o key xu ly

        var keyxuly = new List<GameObject>();
        foreach (Transform child in XuLy.transform)
        {
            keyxuly.Add(child.gameObject);
        }


        foreach (GameObject item in keyxuly)
        {
            RemoveEvent(item.GetComponent<SpItemMonkey>());
            item.transform.parent = null;
            item.transform.Recycle();
        }

    }

    void RemoveEvent(SpItemMonkey pSP)
    {

        int tmg = pSP.Vitri;
        tk2dUIItem uiitem = pSP.GetComponent<tk2dUIItem>();
        switch (tmg)
        {
            case 1:
                uiitem.OnClick -= onClick_sp1;
                break;
            case 2:
                uiitem.OnClick -= onClick_sp2;
                break;
            case 3:
                uiitem.OnClick -= onClick_sp3;
                break;
            case 4:
                uiitem.OnClick -= onClick_sp4;
                break;
            case 5:
                uiitem.OnClick -= onClick_sp5;
                break;
            case 6:
                uiitem.OnClick -= onClick_sp6;
                break;
            case 7:
                uiitem.OnClick -= onClick_sp7;
                break;
            case 8:
                uiitem.OnClick -= onClick_sp8;
                break;
            case 9:
                uiitem.OnClick -= onClick_sp9;
                break;
            case 10:
                uiitem.OnClick -= onClick_sp10;
                break;
            case 11:
                uiitem.OnClick -= onClick_sp11;
                break;
            case 12:
                uiitem.OnClick -= onClick_sp12;
                break;
            case 13:
                uiitem.OnClick -= onClick_sp13;
                break;
            case 14:
                uiitem.OnClick -= onClick_sp14;
                break;
            case 15:
                uiitem.OnClick -= onClick_sp15;
                break;
            case 16:
                uiitem.OnClick -= onClick_sp16;
                break;
            case 17:
                uiitem.OnClick -= onClick_sp17;
                break;
            case 18:
                uiitem.OnClick -= onClick_sp18;
                break;
            case 19:
                uiitem.OnClick -= onClick_sp19;
                break;
            case 20:
                uiitem.OnClick -= onClick_sp20;
                break;
        }
    }
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




    // Use this for initialization
    void Start()
    {

        btnNext.OnClick += btnOnClick_Next;
        positionStartX = respawn.transform.position.x;
        txtLoading.text = ClsLanguage.doLoading();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == State.InGame1 || currentState == State.Click1)
        {
            if (demframe < 30)
            {
                demframe++;
            }
            else
            {
                mTime--;

                txtTime.text = ClsThaoTac.CoverTimeToString(mTime);
                if (mTime <= 1185 && checkNext && currentState == State.InGame1 && GameController.instance.vuotqua<3)
                {
                    taptap.SetActive(true);
                    checkNext = false;
                    
                }

                demframe = 0;
                if (mTime <= 0)
                {
                    BangSoSanh.gameObject.SetActive(false);
                    BangSoSanh.RecycleSp();
                    GameOver();
                }


            }
        }
    }
}
