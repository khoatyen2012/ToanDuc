using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class RankController : MonoBehaviour {

    public GameObject itemGD;
    public GameObject lstGD;
    public ScrollRect scroll;
    public List<UserVi> lstUser = new List<UserVi>();
    public tk2dUIItem btnBack;
    public tk2dUIItem btnContinute;
    public InputField textboxFileName;
    public string stName="";
    public InputField textboxFileSchool;
    public string stSchool="";
    public GameObject wyn;
    public tk2dTextMesh txtTop;
    public tk2dTextMesh txtName;
    public tk2dTextMesh txtLevel;
    public tk2dTextMesh txtYear;
    public int year=2019;
    int grade = 0;
    int level=0;
    int second=0;
    private string stID;
   // DatabaseReference mDatabaseRef;

    void btnContinute_onClick()
    {

        //lay ten 
        stName = "" + textboxFileName.text;
        if (stName.Length > 40)
        {
            stName = stName.Substring(0, 39);
        }

        //lay truong
        stSchool = "" + textboxFileSchool.text;
        if (stSchool.Length > 40)
        {
            stSchool = stSchool.Substring(0, 39);
        }

      


        if (!stName.Trim().Equals(""))
        {
            txtName.text = "" + stName;
            txtYear.text = "" + year;
            txtLevel.text = "Level " + level;
            DataManager.SaveName(stName);
            DataManager.SaveSchool(stSchool);
            wyn.SetActive(false);
            textboxFileName.gameObject.SetActive(false);
            textboxFileSchool.gameObject.SetActive(false);
            scroll.gameObject.SetActive(true);

           // writeNewUser(stID, stName, level, stSchool, second, year);

            doLoadData();
        }
        else
        {
            textboxFileName.Select();
            textboxFileName.ActivateInputField();
        }
    }

    void btnBack_onClick()
    {
      
        SceneManager.LoadScene("Violympic");
    }

    public static string GetUniqueIdentifier()
    {
        System.Guid uid = System.Guid.NewGuid();
        return uid.ToString();
    }

	// Use this for initialization
	void Start () {

        btnBack.OnClick += btnBack_onClick;
        btnContinute.OnClick += btnContinute_onClick;

        year = int.Parse("" + System.DateTime.Now.Year);

        stName = DataManager.GetName();
        if (!stName.Equals(""))
        {
            textboxFileName.text = stName;
        }
        stSchool = DataManager.GetSchool();
        if (!stSchool.Equals(""))
        {
            textboxFileSchool.text = stSchool;
        }
        grade = DataManager.GetGrade();
        switch (grade)
        {
            case 1:
                level = DataManager.GetHightLevel1();
                break;
            case 2:
                level = DataManager.GetHightLevel2();
                break;
            case 3:
                level = DataManager.GetHightLevel3();
                break;
            case 4:
                level = DataManager.GetHightLevel4();
                break;
            default:
                level = DataManager.GetHightLevel5();
                break;
        }

        stID = DataManager.GetMac();
        if (stID.Trim().Equals(""))
        {
            stID = "" + GetUniqueIdentifier();
            DataManager.SaveMac(stID);
        }

        second = DataManager.GetHightSecond();


        //// Set up the Editor before calling into the realtime database.
        //FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://popping-fire-5979.firebaseio.com/");
        //// Get the root reference location of the database.
        //mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;


	}

    //private void writeNewUser(string userId, string pName, int pLevel,string pSchool,int pSecond, int pYear)
    //{
    //   // User user = new User(userId, level, rate, name, "" + Application.systemLanguage.ToString().ToLower().Trim(), year);
    //    UserVi user = new UserVi(pName, userId, pLevel, pSchool, "" + Application.systemLanguage.ToString().ToLower().Trim(), pSecond, pYear);
    //    string json = JsonUtility.ToJson(user);

    //    mDatabaseRef.Child("users9").Child(userId).SetRawJsonValueAsync(json);
    //}

    public void doLoadData()
    {
        for (int i = 0; i < 30; i++)
        {
            UserVi vi = new UserVi("name:" + i, "Top " + i, 20, "le quy don", "Viet Nam", 300, 2017);
            lstUser.Add(vi);
        }

        for (int i = 0; i < lstUser.Count; i++)
        {
            itemGD.transform.GetChild(0).GetComponent<Text>().text = "Top:"+i;
            itemGD.transform.GetChild(1).GetComponent<Text>().text = ""+lstUser[i].Name;
            itemGD.transform.GetChild(2).GetComponent<Text>().text = "" + lstUser[i].School;
            itemGD.transform.GetChild(3).GetComponent<Text>().text = "Level " + lstUser[i].Level;
            itemGD.transform.GetChild(4).GetComponent<Text>().text = "" + lstUser[i].Contri;
            GameObject item = (GameObject)Instantiate(itemGD, lstGD.transform);

            item.transform.localScale = new Vector3(1, 1, 1);
        }
        scroll.verticalNormalizedPosition = 1;
    }

    // Update is called once per frame
    void Update()
    {
	
	}
}
