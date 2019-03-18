using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubelTap : MonoBehaviour
{
    int tapCount;
    public float MaxDubbleTapTime;
    float NewTime;
 
    void Start () {
         tapCount = 0;
    }
 
void Update () {
    if (Input.touchCount == 1) {
    Touch touch = Input.GetTouch (0);
             
    if (touch.phase == TouchPhase.Ended) {
        tapCount += 1;
    }
 
    if (tapCount == 1) {
        NewTime = Time.time + MaxDubbleTapTime;
    }else if(tapCount == 2 && Time.time <= NewTime){

        Debug.Log("Dubble tap"); 
        tapCount = 0;
    }

    }
    if (Time.time > NewTime) {
        tapCount = 0;
    }
}
}

