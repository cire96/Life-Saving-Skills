using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointCount : MonoBehaviour
{
    // Start is called before the first frame update
    public int Points;
    public GameObject[] victims;
    public Parameters victimParam;
    public GameObject HUD;
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
    }

    // Update is called once per frame
    void Update()
    {
        //countPoints();
    }

    public void countPoints(){
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
                Points += correctTriagePoint; 
            }
            else if ((string)ParamDic["SetPrio"] != ParamDic["prio"].ToString().ToLower())
            {
                Debug.Log("incorrect");
                Points -= incorrectTriagePenelty;
            }
            //Debug.Log(ParamDic["prio"]+" : "+ParamDic["SetPrio"]);
        }
        Debug.Log("Points: " + Points);
        Points = 0;
    }
}
