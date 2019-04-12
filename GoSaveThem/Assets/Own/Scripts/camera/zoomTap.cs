using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomTap : MonoBehaviour
{
    private int tapCount;
    public float MaxDubbleTapTime;
    private float NewTime;
    public GameObject Camera;
    private PlayerCameraController cc;
    private Vector2 lastTouchPos;
    private float positionRange;
 
    void Start () {
        cc=Camera.GetComponent<PlayerCameraController>();
        tapCount = 0;
        MaxDubbleTapTime = 0.12f;
        lastTouchPos = new Vector2(0f,0f);
        positionRange = 40f;
    }
 
    void Update () {
    
        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch (0);            
            Debug.Log("Touch Position : " + touch.position); 
        
            if ((touch.phase == TouchPhase.Ended) &&
                (tapCount == 1) &&
                (touch.position.x>=lastTouchPos.x-positionRange && touch.position.x<=lastTouchPos.x+positionRange) &&
                (touch.position.y>=lastTouchPos.y-positionRange && touch.position.y<=lastTouchPos.y+positionRange)){
                tapCount += 1;
            }
            else if ((touch.phase == TouchPhase.Ended) && tapCount == 0){
                tapCount += 1;
                lastTouchPos = touch.position;
            }
        
            if (tapCount == 1) {
                NewTime = Time.time + MaxDubbleTapTime;

            }else if(tapCount == 2 && Time.time <= NewTime){

                cc.zoomCamera();
                tapCount = 0;
            }
            //Debug.Log("tap: "+tapCount); 
        }
        if (Time.time > NewTime) {
            tapCount = 0; 
        }
    }
}

