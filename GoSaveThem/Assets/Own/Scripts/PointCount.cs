using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointCount : MonoBehaviour
{
    // Start is called before the first frame update
    public int Points;
    public GameObject[] victims;
    public Parameters victimParam;
    void Start()
    {   
        Points=0;        
    }

    // Update is called once per frame
    void Update()
    {
        //countPoints();
    }

    public void countPoints(){
        victims = GameObject.FindGameObjectsWithTag("Victim");
        foreach (GameObject victim in victims){
            victimParam=victim.GetComponent<Parameters>();
            Dictionary<string, object> ParamDic = victimParam.getParamHash();
            Debug.Log(ParamDic["prio"]+" : "+ParamDic["SetPrio"]);
        }
    }
}
