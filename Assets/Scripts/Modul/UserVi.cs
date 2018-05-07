using UnityEngine;
using System.Collections;

public class UserVi  {

    string name;
    string stt;
    int level;
    string school;
    string contri;
    int second;
    int year;

    public UserVi(string name, string stt, int level, string school, string contri, int second, int year)
    {
        this.name = name;
        this.stt = stt;
        this.level = level;
        this.school = school;
        this.contri = contri;
        this.year = year;
        this.second = second;
    }

    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    public int Second
    {
        get { return second; }
        set { second = value; }
    }

    public string Contri
    {
        get { return contri; }
        set { contri = value; }
    }

    public string School
    {
        get { return school; }
        set { school = value; }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

  

    public string Stt
    {
        get { return stt; }
        set { stt = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}
