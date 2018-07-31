using UnityEngine;
using System.Collections;


public class Config  {

#if UNITY_IPHONE
 
       public static string adsInIDGameOver = "ca-app-pub-5148482490300491/7257520601";
    public static string adsInIDTrigger = "ca-app-pub-5148482490300491/7054340624";
    public static string adsInIDBanner = "ca-app-pub-5148482490300491/4977582443";
   

#endif

#if UNITY_ANDROID


	public static string adsInIDGameOver = "ca-app-pub-2127327600096597/1733255667";
	public static string adsInIDTrigger = "ca-app-pub-2127327600096597/1733255667";
	public static string adsInIDBanner = "ca-app-pub-2127327600096597/1872856469";
                        

#endif

}
