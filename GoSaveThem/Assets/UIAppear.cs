﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAppear : MonoBehaviour
{
 
    public GameObject ActionBtn, BleedingBtn, RABtn, BreathingBtn, CBBtn, PulseBtn, Victim,
    BlackBtn, RedBtn, GreenBtn, YellowBtn, PriorityBtn;
    public List<GameObject> actions;
    public List<GameObject> cards;

    void Start(){
        actions = new List<GameObject>(){BleedingBtn, RABtn, BreathingBtn, PulseBtn, CBBtn};
        cards = new List<GameObject>(){BlackBtn,GreenBtn,RedBtn,YellowBtn};
    }

    void OnTriggerEnter (Collider other) {
        if (other.tag =="Player") {
    	    Debug.Log("ENTERED");
            foreach(GameObject action in actions){
                action.SetActive(true);
            }
            PriorityBtn.SetActive(true);
        }

    }
 
    void OnTriggerExit (Collider other) {
        if (other.tag =="Player") {
        	Debug.Log("Exited");
            foreach(GameObject btn in actions){
                btn.SetActive(false);
            }
            foreach(GameObject btn in cards){
                btn.SetActive(false);
            }
            PriorityBtn.SetActive(false);
            ActionBtn.SetActive(false);
        }
    }
}