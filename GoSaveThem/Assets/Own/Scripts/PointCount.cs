using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCount : MonoBehaviour
{
    // Start is called before the first frame update
    public int Points;
    public GameObject[] victims;
    private Parameters victimParam;
    void Start()
    {   

        //victimGroup = GameObject.Find("VictumGroup");
        Points=0;
        victims = GameObject.FindGameObjectsWithTag("Victim");
        
    }

    // Update is called once per frame
    void Update()
    {
        countPoints();
    }

    void countPoints(){
        foreach (GameObject victim in victims){
            Parameters victimParam=victim.GetComponent<Parameters>();
            Debug.Log(victimParam);
        }
    }
}
