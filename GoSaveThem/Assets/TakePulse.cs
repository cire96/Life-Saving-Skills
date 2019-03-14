using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TakePulse : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{   
    public GameObject Hud;
    public GameObject BloodyScreen;
    
    // Start is called before the first frame update
    void Start () {
        BloodyScreen.SetActive(false);
    }
    void Update()
    {
        if (!ispressed){
            BloodyScreen.SetActive(false);
            return;
        }
        // DO SOMETHING HERE
        PulsateBlood();
    }
    bool ispressed = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }

    void PulsateBlood(){
        //BtnReact BtnReact
        BtnReact BtnReact = Hud.GetComponent<BtnReact>();
        GameObject victim = BtnReact.getVictim();
        Parameters Parameters = victim.GetComponent<Parameters>();

        int Pulse = Parameters.Pulse;
        double Delay = (double) Pulse / 60.0;

        BloodyScreen.SetActive(true);
        
    }
}