using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{   
    public int Bfreq, Pulse;
    public bool Bleeding, AirwaysBlocked;

    void Start(){
        Bfreq = 20;
        Pulse = 110;
        Bleeding = true;
        AirwaysBlocked = false;
    }
}
