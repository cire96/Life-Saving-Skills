using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BreathingEffect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public GameObject Img;
    public GameObject Hud;
    public GameObject BreathingBlur;
    bool ispressed = false;
    double Delay, timeLeft;
    float transparency = 1.0f;
    Color temp;


    //private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        Img.SetActive(false);
        BreathingBlur.SetActive(false);
    }

    void Update()
    {
        if (ispressed)
        {
            PulsateFog();
        }
        // DO SOMETHING HERE
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
        startBreathing();
        BreathingBlur.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Img.SetActive(false);
        BreathingBlur.SetActive(false);
        ispressed = false;
    }



    void PulsateFog()
    {

        timeLeft -= Time.deltaTime;
        if (timeLeft < 0.0f)
        {
            Debug.Log("reseting transparency");
            timeLeft = Delay;
            transparency = 1.0f;
        }
        Debug.Log(timeLeft);
        temp = Img.GetComponent<Image>().color;
        transparency = Mathf.Max(0.0f, transparency - 0.02f);
        temp.a = transparency;

        Img.GetComponent<Image>().color = temp;
        //BtnReact BtnReact



    }

    void startBreathing()
    {
        //BtnReact BtnReact
        BtnReact BtnReact = Hud.GetComponent<BtnReact>();
        GameObject victim = BtnReact.getVictim();
        Parameters Parameters = victim.GetComponent<Parameters>();

        int Bfreq = Parameters.Bfreq;
        Delay = (double)60.0 / Bfreq;
        timeLeft = Delay;
        Img.SetActive(true);
    }

   /* public void BreathEnable(){
        Debug.Log("BreathEnabled");
        Img.SetActive(true);
    }*/
}
