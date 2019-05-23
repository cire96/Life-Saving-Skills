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
    bool ispressed = false, BreatheIn = false;
    float Delay, timeLeft;
    float transparency = 0.0f;  //var tidigare 1.0f men ser bättre ut att börja genomskinlig
    Color temp;
    int Bfreq = 0;

    //private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        temp = Img.GetComponent<Image>().color;
        temp.a = 0.0f; //Image start with full transparancy
        Img.GetComponent<Image>().color = temp;
        Img.SetActive(false);
        BreathingBlur.SetActive(false);
    }

    void Update()
    {
        if (ispressed && Bfreq != 0)
        {
            PulsateFog();
        }
        // DO SOMETHING HERE
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        startBreathing();
        BreathingBlur.SetActive(true);
        ispressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Img.SetActive(false);
        BreathingBlur.SetActive(false);
        ispressed = false;
        temp = Img.GetComponent<Image>().color;
        temp.a = 0.0f; //Image start with full transparancy
        Img.GetComponent<Image>().color = temp;
        BreatheIn = false;
    }



    void PulsateFog()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0.0f)
        {
            //Debug.Log("reseting transparency");
            BreatheIn = !BreatheIn;
            timeLeft = Delay/2;

        }
        if (BreatheIn)
        {
            transparency -= 2 * Time.deltaTime / Delay;
            transparency = Mathf.Max(0.0f, transparency);
        }
        else
        {
            transparency += 2 * Time.deltaTime / Delay;
            transparency = Mathf.Min(1.0f, transparency);
        }
        //Debug.Log(timeLeft);
        temp = Img.GetComponent<Image>().color;
        temp.a = transparency;
        Img.GetComponent<Image>().color = temp;
        //BtnReact BtnReact
        Img.SetActive(true);



    }

    void startBreathing()
    {
        //BtnReact BtnReact
        TutorialBtnReact BtnReact = Hud.GetComponent<TutorialBtnReact>();
        GameObject victim = BtnReact.getVictim();
        Parameters Parameters = victim.GetComponent<Parameters>();

        Bfreq = Parameters.Bfreq;
        Delay = 1;
        if (Bfreq != 0)
        {
            Delay = 60.0f / Bfreq;
            //Img.SetActive(true);
        }
        timeLeft = Delay / 2;



    }

   /* public void BreathEnable(){
        Debug.Log("BreathEnabled");
        Img.SetActive(true);
    }*/
}
