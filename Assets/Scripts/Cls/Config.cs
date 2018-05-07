using UnityEngine;
using System.Collections;


public class Config  {

#if UNITY_IPHONE
 
       public static string adsInIDGameOver = "ca-app-pub-5148482490300491/2810940969";
    public static string adsInIDTrigger = "ca-app-pub-5148482490300491/2810940969";
    public static string adsInIDBanner = "ca-app-pub-5148482490300491/2810940969";
     public static string hedieuhanh="ios5";
   

#endif

#if UNITY_ANDROID


    public static string adsInIDGameOver = "ca-app-pub-5148482490300491/2329302968";
    public static string adsInIDTrigger = "ca-app-pub-5148482490300491/7589850968";
    public static string adsInIDBanner = "ca-app-pub-5148482490300491/3578453764";
                        

#endif

}
