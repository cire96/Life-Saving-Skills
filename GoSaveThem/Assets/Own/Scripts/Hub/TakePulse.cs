﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TakePulse : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{   
    public GameObject Hud;
    public GameObject BloodyScreen; 
    public GameObject PulseBlur;
    bool ispressed = false;
    double Delay, timeLeft;
    float transparency = 1.0f;
   	Color temp;
    
    // Start is called before the first frame update
    void Start () {
        BloodyScreen.SetActive(false);
        PulseBlur.SetActive(false);
    }
    void Update()
    {
        if (ispressed){
            PulsateBlood();
        }
        // DO SOMETHING HERE
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
        startPulsation();
        PulseBlur.SetActive(true);
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {	
    	BloodyScreen.SetActive(false);
        PulseBlur.SetActive(false);
        ispressed = false;
    }

    void PulsateBlood(){
    	
    	timeLeft -= Time.deltaTime;
    	if (timeLeft < 0.0f){
    		Debug.Log("reseting transparency");
    		timeLeft = Delay;
    		transparency = 1.0f;
    	}
    	Debug.Log(timeLeft);
        temp = BloodyScreen.GetComponent<Image>().color;
        transparency = Mathf.Max(0.0f, transparency - 0.02f);
        temp.a = transparency;
        
        BloodyScreen.GetComponent<Image>().color = temp;
        //BtnReact BtnReact
  
        
        
    }
    void startPulsation(){
    	//BtnReact BtnReact
        BtnReact BtnReact = Hud.GetComponent<BtnReact>();
        GameObject victim = BtnReact.getVictim();
        Parameters Parameters = victim.GetComponent<Parameters>();

        int Pulse = Parameters.Pulse;
        Delay = (double)60.0 / Pulse;
        timeLeft = Delay;
        BloodyScreen.SetActive(true);
    }
}