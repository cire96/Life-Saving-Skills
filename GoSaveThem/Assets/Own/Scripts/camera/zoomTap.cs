using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomTap : MonoBehaviour
{
    int tapCount;
    public float MaxDubbleTapTime;
    float NewTime;
 
    void Start () {
         tapCount = 0;
         MaxDubbleTapTime = 0.12f;
    }
 
void Update () {
    
    if (Input.touchCount == 1) {
        Touch touch = Input.GetTouch (0);
        Vector2 lastpos = touch.deltaPosition;
        //Debug.Log(lastpos.magnitude); 

                
        if ((touch.phase == TouchPhase.Ended)) {
            tapCount += 1;
        }
    
        if (tapCount == 1) {
            NewTime = Time.time + MaxDubbleTapTime;

        }else if(tapCount == 2 && Time.time <= NewTime){

            Debug.Log("Dubble tap"); 
            tapCount = 0;
        }
        Debug.Log("tap: "+tapCount); 
    }
    if (Time.time > NewTime) {
        tapCount = 0; 
    }
}
}

