using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointCount : MonoBehaviour
{
    // Start is called before the first frame update
    public int Points;
    public int PointRatio;
    public GameObject[] victims;
    Parameters victimParam;
    public GameObject HUD;
    public List<GameObject> GameOverList, StarList;
    GameObject GameOverLayer, GameOverBlurEffect, GameOverRestartBtn, GameOverMenuBtn, GameOverBg, GameOverStats;
    GameObject PointsValue, LevelValue, Star1, Star2, Star3;
    Text PointsTxt, LevelTxt;

    Countdown countdownScript;
    int timeFactor = 2;
    int correctTriagePoint;
    int unSetTriagePenelty;
    int incorrectTriagePenelty;

    void Start()
    {   
        Points=0;
        correctTriagePoint = 100 * timeFactor;
        unSetTriagePenelty = 75 * timeFactor;
        incorrectTriagePenelty = 25*timeFactor;

        GameObject countdown = HUD.transform.Find("countdownTxt").gameObject;
        countdownScript = countdown.GetComponent<Countdown>();
    
        GameOverLayer = HUD.transform.Find("GameOverLayer").gameObject;
        GameOverBlurEffect = GameOverLayer.transform.Find("GameOverBlurEffect").gameObject;
        GameOverBg = GameOverLayer.transform.Find("GameOverBg").gameObject;
        GameOverRestartBtn = GameOverBg.transform.Find("GameOverRestartBtn").gameObject;
        GameOverMenuBtn = GameOverBg.transform.Find("GameOverGoToMenuBtn").gameObject;
        GameOverStats = HUD.transform.Find("GameOverStats").gameObject;
        GameOverStats.SetActive(false);
        GameOverList = new List<GameObject>() { GameOverLayer, GameOverBlurEffect, GameOverMenuBtn, GameOverRestartBtn, GameOverStats };

        PointsValue = GameOverStats.transform.Find("PointsValue").gameObject;
        PointsTxt = PointsValue.GetComponent<Text>();

        LevelValue = GameOverStats.transform.Find("LevelValue").gameObject;
        LevelTxt = LevelValue.GetComponent<Text>();

        Star1 = GameOverStats.transform.Find("Star1").gameObject;
        Star2 = GameOverStats.transform.Find("Star2").gameObject;
        Star3 = GameOverStats.transform.Find("Star3").gameObject;
        StarList = new List<GameObject>() { Star1, Star2, Star3 };

        foreach (GameObject star in StarList)
        {
            star.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //countPoints();
    }

    public void countPoints(){
        Time.timeScale = 0; //Pausa spelet och tiden
        int numSaved =0;
        Points += timeFactor*countdownScript.getTimeLeft();
        victims = GameObject.FindGameObjectsWithTag("Victim");
        foreach (GameObject victim in victims){
            victimParam=victim.GetComponent<Parameters>();
            Dictionary<string, object> ParamDic = victimParam.getParamHash();
            if ((string)ParamDic["SetPrio"] == "unset")
            {
                Points -= unSetTriagePenelty;
            }
            else if((string)ParamDic["SetPrio"]==ParamDic["prio"].ToString().ToLower()){
                Debug.Log("Correct");
                numSaved += 1;
                Points += correctTriagePoint; 
            }
            else if ((string)ParamDic["SetPrio"] != ParamDic["prio"].ToString().ToLower())
            {
                Debug.Log("incorrect");
                Points -= incorrectTriagePenelty;
            }
            if((bool)ParamDic["Bleeding"]==true){
                Debug.Log("Bleeding");
                Points -= incorrectTriagePenelty;
            }
            //Debug.Log(ParamDic["prio"]+" : "+ParamDic["SetPrio"]);
        }
        foreach (GameObject item in GameOverList)
        {
            item.SetActive(true);
        }
        //Behöver göras dynamisk när vi har fler levels

        if(Points<=0){
            PointRatio=0;
        }else{
            PointRatio = Points; //Kvot för nuv. poäng genom tot. möjliga poäng * 100
        }

        PointsTxt.text = PointRatio.ToString();
        LevelTxt.text = "1";
        int starCapPoint = victims.Length*correctTriagePoint;
        Debug.Log(PointRatio + " : " +starCapPoint);
        if (PointRatio > starCapPoint*0.25f) {
            Star1.SetActive(true);
        }

        if (PointRatio > starCapPoint*0.5f) {
            Star2.SetActive(true);
        }

        if (PointRatio >= starCapPoint) {
            Star3.SetActive(true);
        }

    }
}
