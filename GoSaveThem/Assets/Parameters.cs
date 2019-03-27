using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{   
    public int Bfreq, Pulse, Backfill;
    public bool Bleeding, AirwaysBlocked, Dead;
    public GameObject Blood;

    void Start(){
        Bfreq = 0;
        Pulse = 0;
        Backfill = 0;
        Bleeding = false;
        AirwaysBlocked = false;
        GiveParameters();
        
        // Sätter igång blodpartikelsystemt ifall den skadade blöder.
        Blood.SetActive(Bleeding);
    }

    void GiveParameters(){
        int i = Random.Range(1,10);
        if ( i == 1 ){
            Dead = true;
        } else {
            Dead = false;
        }

        if ( !Dead ){
            if ( i > 8 ){
                Bfreq = 0;
                AirwaysBlocked = true;
            } else {
                Bfreq = Random.Range(5,60);
            }
            Pulse = Random.Range(40, 180);
            if ( i > 5 ){
                Bleeding = true;
            }

        }
        //Backfill = Random.Range(500, 5000);
        Backfill = 5000;
    }

    public void StopBleeding(){
        Bleeding = false;
        Blood.SetActive(Bleeding);
    }

    public void FreeAirways(){
        if ( !Dead && AirwaysBlocked ){
            Bfreq = Random.Range(5,60);
            AirwaysBlocked = false;
        }
    }
}
