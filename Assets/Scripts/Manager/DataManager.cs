using UnityEngine;
using System.Collections;

public class DataManager  {

   
    private static string TAG_HIGHTSECOND = "ssf";
    private static string TAG_HIGHTNAME = "mynamef";
    private static string TAG_GRADE = "mygrade";
    private static string TAG_HIGHTSCHOOL = "schoolf";
    private static string TAG_MAC = "mymacf";
    private static string TAG_TOP = "mytopf";
    private static string TAG_VIP = "vipprof";

    private static string TAG_HIGHTLEVEL5 = "lvf5";
    private static string TAG_HIGHTCOIN5 = "scf5";

    private static string TAG_HIGHTLEVEL4 = "lvf4";
    private static string TAG_HIGHTCOIN4 = "scf4";

    private static string TAG_HIGHTLEVEL3 = "lvf3";
    private static string TAG_HIGHTCOIN3 = "scf3";

    private static string TAG_HIGHTLEVEL2 = "lvf2";
    private static string TAG_HIGHTCOIN2 = "scf2";

    private static string TAG_HIGHTLEVEL1 = "lvf1";
    private static string TAG_HIGHTCOIN1 = "scf1";


    //grade
    public static int GetGrade()
    {
        if (PlayerPrefs.HasKey(TAG_GRADE))
        {
            return PlayerPrefs.GetInt(TAG_GRADE);
        }
        else
        {
            return 0;
        }
    }

    //luu lai gia tri level da vuot qua.
    public static void SaveGrade(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_GRADE, newHightScore);
    }

    //-------------------Lop1

    public static int GetHightLevel1()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTLEVEL1))
        {
            return PlayerPrefs.GetInt(TAG_HIGHTLEVEL1);
        }
        else
        {
            return 0;
        }
    }

    //luu lai gia tri level da vuot qua.
    public static void SaveHightLevel1(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_HIGHTLEVEL1, newHightScore);
    }


    //lay lai gia tri chuoi diem tung level da vuot qua.

    public static string GetHightStringCoin1()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTCOIN1))
        {
            return PlayerPrefs.GetString(TAG_HIGHTCOIN1);
        }
        else
        {
            return "1+2+3+4+5+6+7+8+9+10+11+12+13+14+15+16+17+18+19+20";
        }
    }

    //luu lai gia tri chuoi diem tung level da vuot qua.
    public static void SaveHightStringCoin1(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_HIGHTCOIN1, newHightScore);
    }

    //____________________LOP 2

    public static int GetHightLevel2()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTLEVEL2))
        {
            return PlayerPrefs.GetInt(TAG_HIGHTLEVEL2);
        }
        else
        {
            return 0;
        }
    }

    //luu lai gia tri level da vuot qua.
    public static void SaveHightLevel2(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_HIGHTLEVEL2, newHightScore);
    }


    //lay lai gia tri chuoi diem tung level da vuot qua.

    public static string GetHightStringCoin2()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTCOIN2))
        {
            return PlayerPrefs.GetString(TAG_HIGHTCOIN2);
        }
        else
        {
            return "1+2+3+4+5+6+7+8+9+10+11+12+13+14+15+16+17+18+19+20";
        }
    }

    //luu lai gia tri chuoi diem tung level da vuot qua.
    public static void SaveHightStringCoin2(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_HIGHTCOIN2, newHightScore);
    }

    //_________________Lop3

    public static int GetHightLevel3()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTLEVEL3))
        {
            return PlayerPrefs.GetInt(TAG_HIGHTLEVEL3);
        }
        else
        {
            return 0;
        }
    }

    //luu lai gia tri level da vuot qua.
    public static void SaveHightLevel3(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_HIGHTLEVEL3, newHightScore);
    }


    //lay lai gia tri chuoi diem tung level da vuot qua.

    public static string GetHightStringCoin3()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTCOIN3))
        {
            return PlayerPrefs.GetString(TAG_HIGHTCOIN3);
        }
        else
        {
            return "1+2+3+4+5+6+7+8+9+10+11+12+13+14+15+16+17+18+19+20";
        }
    }

    //luu lai gia tri chuoi diem tung level da vuot qua.
    public static void SaveHightStringCoin3(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_HIGHTCOIN3, newHightScore);
    }




    //_________Lop4
    public static int GetHightLevel4()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTLEVEL4))
        {
            return PlayerPrefs.GetInt(TAG_HIGHTLEVEL4);
        }
        else
        {
            return 0;
        }
    }

    //luu lai gia tri level da vuot qua.
    public static void SaveHightLevel4(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_HIGHTLEVEL4, newHightScore);
    }


    //lay lai gia tri chuoi diem tung level da vuot qua.

    public static string GetHightStringCoin4()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTCOIN4))
        {
            return PlayerPrefs.GetString(TAG_HIGHTCOIN4);
        }
        else
        {
            return "1+2+3+4+5+6+7+8+9+10+11+12+13+14+15+16+17+18+19+20";
        }
    }

    //luu lai gia tri chuoi diem tung level da vuot qua.
    public static void SaveHightStringCoin4(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_HIGHTCOIN4, newHightScore);
    }


    //__________________________________LOp5
    //lay lai gia tri level da vuot qua.
    public static int GetHightLevel5()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTLEVEL5))
        {
            return PlayerPrefs.GetInt(TAG_HIGHTLEVEL5);
        }
        else
        {
            return 0;
        }
    }

    //luu lai gia tri level da vuot qua.
    public static void SaveHightLevel5(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_HIGHTLEVEL5, newHightScore);
    }


    //lay lai gia tri chuoi diem tung level da vuot qua.

    public static string GetHightStringCoin5()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTCOIN5))
        {
            return PlayerPrefs.GetString(TAG_HIGHTCOIN5);
        }
        else
        {
            return "1+2+3+4+5+6+7+8+9+10+11+12+13+14+15+16+17+18+19+20";
        }
    }

    //luu lai gia tri chuoi diem tung level da vuot qua.
    public static void SaveHightStringCoin5(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_HIGHTCOIN5, newHightScore);
    }

    //_____________________________________


    public static int GetVip()
    {
        if (PlayerPrefs.HasKey(TAG_VIP))
        {
            return PlayerPrefs.GetInt(TAG_VIP);
        }
        else
        {
            return 0;
        }
    }

    public static void SaveVip(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_VIP, newHightScore);
    }



    public static string GetMac()
    {
        if (PlayerPrefs.HasKey(TAG_MAC))
        {
            return PlayerPrefs.GetString(TAG_MAC);
        }
        else
        {
            return "";
        }
    }

    public static void SaveMac(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_MAC, newHightScore);
    }


    public static int GetTop()
    {
        if (PlayerPrefs.HasKey(TAG_TOP))
        {
            return PlayerPrefs.GetInt(TAG_TOP);
        }
        else
        {
            return 0;
        }
    }

    public static void SaveTop(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_TOP, newHightScore);
    }


    //Lay ra truong tieu hoc cua nguoi choi

    public static string GetSchool()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTSCHOOL))
        {
            return PlayerPrefs.GetString(TAG_HIGHTSCHOOL);
        }
        else
        {
            return "";
        }
    }

    //luu lai truong tieu hoc cua nguoi choi
    public static void SaveSchool(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_HIGHTSCHOOL, newHightScore);
    }




    //Lay ra ten cua nguoi choi

    public static string GetName()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTNAME))
        {
            return PlayerPrefs.GetString(TAG_HIGHTNAME);
        }
        else
        {
            return "";
        }
    }

    //luu lai ten cua nguoi choi
    public static void SaveName(string newHightScore)
    {
        PlayerPrefs.SetString(TAG_HIGHTNAME, newHightScore);
    }











   

    //get lai gia tri second cua bai 3 khi con thong thai.

    public static int GetHightSecond()
    {
        if (PlayerPrefs.HasKey(TAG_HIGHTSECOND))
        {
            return PlayerPrefs.GetInt(TAG_HIGHTSECOND);
        }
        else
        {
            return 0;
        }
    }

    //Luu lai gia tri second cua bai 3 khi con thong thai.
    public static void SaveHightSecond(int newHightScore)
    {
        PlayerPrefs.SetInt(TAG_HIGHTSECOND, newHightScore);
    }
}
