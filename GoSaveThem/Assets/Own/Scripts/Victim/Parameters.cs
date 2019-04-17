using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    public string prio, SetPrio;   
    public int Bfreq, Pulse, Backfill;
    public bool Bleeding, AirwaysBlocked, Dead, Walking;
    public GameObject Blood;

    void Start(){
        Bfreq = 0;
        Pulse = 0;
        Backfill = 0;       //i sekunder
        Bleeding = false;
        AirwaysBlocked = false;
        Walking = false;
        SetPrio = "unset";
        GiveParameters();
        
        // Sätter igång blodpartikelsystemt ifall den skadade blöder.
        Blood.SetActive(Bleeding);
    }

    public void SetPrioColor(string color){
        SetPrio=color;
    }

    void GiveParameters(){

        // Ta fram en slumpad int, som sedan kan användas till att slumpafram tillstånd. Exempelvis ifall vi
        // vill ha 20% att någon blöder; if(r < 3): bleed 
        int r;

        switch (prio) 
        {
            case "Black":
                r = Random.Range(1,10);
                Dead = true;
                if (r < 3)
                    AirwaysBlocked = true;
                break;
            case "Green":
                Walking = true;
                Bleeding = true;
                Pulse = Random.Range(60, 120);
                Bfreq = Random.Range(12,25);
                // Byt till float?
                Backfill = Random.Range(1,5);
                break;
            case "Yellow":
                r = Random.Range(1,10);
                if (r < 6)
                    Bleeding = true;
                Bfreq = Random.Range(12,25);
                Pulse = Random.Range(60, 120);
                Backfill = Random.Range(1, 5);
                break;
            case "Red":
                r = Random.Range(1,10);
                if (r < 6)
                    Bleeding = true;
                r = Random.Range(1,10);
                if (r < 4){
                    AirwaysBlocked = true;
                    Bfreq = 0;
                } else {
                    Bfreq = Random.Range(5,45);
                }
                // Ifall andningsfrekvensen är normal måste pulsen vara tokig.
                if ( Bfreq < 30 && Bfreq > 10 ){
                    Pulse = Random.Range(120,180);
                } else {
                    Pulse = Random.Range(60,180);
                }
                Backfill = Random.Range(1, 5);
                break;
        }
        Blood.SetActive(Bleeding);

        /* int i = Random.Range(1,10);
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
        */
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
