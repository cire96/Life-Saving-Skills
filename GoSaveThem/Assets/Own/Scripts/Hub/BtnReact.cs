using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnReact : MonoBehaviour
{
    public GameObject ActionBtn, BleedingBtn, RABtn, BreathingBtn, CBBtn, PulseBtn, 
    BlackBtn, RedBtn, GreenBtn, YellowBtn, PriorityBtn, BreathImage;
    public List<GameObject> actions;
    public List<GameObject> cards;
    public GameObject[] victims;


    void Start(){
        actions = new List<GameObject>(){BleedingBtn, RABtn, BreathingBtn, PulseBtn, CBBtn};
        cards = new List<GameObject>(){BlackBtn,GreenBtn,RedBtn,YellowBtn};
        foreach(GameObject btn in actions){
            btn.SetActive(false);
        }
        foreach(GameObject btn in cards){
            btn.SetActive(false);
        }
        PriorityBtn.SetActive(false);
        ActionBtn.SetActive(false);

        victims = GameObject.FindGameObjectsWithTag("Victim");
    }

    public void Action(){
        foreach(GameObject btn in actions){
            btn.SetActive(true);
        }
        foreach(GameObject btn in cards){
            btn.SetActive(false);
        }
        ActionBtn.SetActive(false);
        PriorityBtn.SetActive(true);
    }

    public void Priority(){
        foreach(GameObject btn in actions){
            btn.SetActive(false);
        }
        foreach(GameObject btn in cards){
            btn.SetActive(true);
        }
        ActionBtn.SetActive(true);
        PriorityBtn.SetActive(false);

    }

    public GameObject getVictim(){
        foreach(GameObject victim in victims){
            Debug.Log("loop..");
            UIAppear UIAppear = victim.transform.Find("Radius").GetComponent<UIAppear>();
            if (UIAppear.active){
                return victim;
            }
        }
        return null;
    }

    public void GivePriority(string color){
        Debug.Log("ran fuction");
        GameObject victim= getVictim();
        if (victim){
            //Debug.Log("found victim");
            ShowPriority ShowPriority = victim.transform.Find("PriorityCard").GetComponent<ShowPriority>();
            ShowPriority.UpdatePriority(color);
        }
    }

    public void ChangeScene(){
        
    }

    public void ReleaseAirways(){
        GameObject victim = getVictim();
        Parameters Parameters = victim.GetComponent<Parameters>();
        // Play animation function
        Parameters.FreeAirways();

    }

    public void Bleeding(){
        GameObject victim = getVictim();
        Parameters Parameters = victim.GetComponent<Parameters>();
        // Play animation function
        Parameters.StopBleeding();       
    }

    public void Breathing(){
        GameObject victim = getVictim();
        BreathingEffect BreathingEffect = victim.GetComponent<BreathingEffect>();
        Parameters Parameters = victim.GetComponent<Parameters>();

        BreathingEffect.BreathEnable();
    }

}


