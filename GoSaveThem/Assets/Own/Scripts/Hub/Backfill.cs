using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Backfill : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool ispressed = false;
    float PressedTime, RefillTime;
    float Delay;
    public GameObject Thumb, ThumbWhite, Hud, ThumbBlur;
    Color temp;



    // Start is called before the first frame update
    void Start()
    {
        //ThumbWhite.SetActive(false);
        //ThumbBlur.SetActive(false);
        temp = ThumbWhite.GetComponent<Image>().color;
        temp.a = 0.0f;
        ThumbWhite.GetComponent<Image>().color = temp;
    }

    // Update is called once per frame
    void Update()
    {
        temp = ThumbWhite.GetComponent<Image>().color;
        if (ispressed)
        {
            PressedTime += Time.deltaTime;
            temp.a = Mathf.Min(PressedTime / 2, 1.0f);//2 seconds until white
            Debug.Log("changing alpha");
            ThumbWhite.GetComponent<Image>().color = temp;


        }
        else if(temp.a>0)
        {

            RefillTime -= Time.deltaTime;
            Debug.Log(temp.a);
            Debug.Log(Delay);
            temp.a = Mathf.Max(RefillTime / Delay, 0.0f);
            Debug.Log(temp.a);
            ThumbWhite.GetComponent<Image>().color = temp;
            Debug.Log(temp);
        }


    }

    public void ShowThumb()
    {
        ThumbBlur.SetActive(true);
        Thumb.SetActive(true);
        ThumbWhite.SetActive(true);
        BtnReact BtnReact = Hud.GetComponent<BtnReact>();
        GameObject victim = BtnReact.getVictim();
        Parameters Parameters = victim.GetComponent<Parameters>();

        Delay = Parameters.Backfill; //backfill in seconds
        Debug.Log(Delay);
 
    }


    public void OnPointerDown(PointerEventData eventData)
    {

        ispressed = true;
        PressedTime = 0.0f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
        RefillTime = ThumbWhite.GetComponent<Image>().color.a * Delay; //Reset from previous a
    }
}
