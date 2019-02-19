using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnReact : MonoBehaviour
{
    public GameObject ActionBtn, BleedingBtn, RABtn, BreathingBtn, CBBtn, PulseBtn, 
    BlackBtn, RedBtn, GreenBtn, YellowBtn, PriorityBtn;
    public List<GameObject> actions;
    public List<GameObject> cards;

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

    public void ChangeScene(){
        
    }

}


