using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAppear : MonoBehaviour
{
    public GameObject HUD;
    public List<GameObject> VictimActions;
    public List<GameObject> CardActions;
    public List<GameObject> TripleActions;
    public bool active;
    GameObject TripleBtnLayer, TripleBtnClose, TripleMidBtn, TripleTopBtn, TripleBotBtn, TripleBtnDisabled,
        BleedingBtn, RABtn, CBBtn, BreathingBtn, PulseBtn, BlackBtn, RedBtn, GreenBtn, YellowBtn;

    void Start(){

        TripleBtnLayer = HUD.transform.Find("TripleBtnLayer").gameObject;
        TripleBtnClose = TripleBtnLayer.transform.Find("TripleBtnClose").gameObject;
        TripleMidBtn = TripleBtnLayer.transform.Find("TripleMidBtn").gameObject;
        TripleTopBtn = TripleBtnLayer.transform.Find("TripleTopBtn").gameObject;
        TripleBotBtn = TripleBtnLayer.transform.Find("TripleBotBtn").gameObject;
        TripleBtnDisabled = HUD.transform.Find("TripleBtnDisabled").gameObject;

        BleedingBtn = HUD.transform.Find("Bleeding").gameObject;
        RABtn = HUD.transform.Find("ReleaseAirways").gameObject;
        CBBtn = HUD.transform.Find("CapillaryBackfill").gameObject;
        BreathingBtn = HUD.transform.Find("Breathing").gameObject;
        PulseBtn = HUD.transform.Find("Pulse").gameObject;

        BlackBtn = HUD.transform.Find("Black").gameObject;
        RedBtn = HUD.transform.Find("Red").gameObject;
        GreenBtn = HUD.transform.Find("Yellow").gameObject;
        YellowBtn = HUD.transform.Find("Green").gameObject;

        VictimActions = new List<GameObject>() { BleedingBtn, RABtn, BreathingBtn, PulseBtn, CBBtn };
        CardActions = new List<GameObject>() { BlackBtn, GreenBtn, RedBtn, YellowBtn };
        TripleActions = new List<GameObject>() { TripleBotBtn, TripleMidBtn, TripleTopBtn };
        active = false;
    }

    void OnTriggerEnter (Collider other) {
        if (other.tag =="Player") {
    	    active = true;
            foreach(GameObject action in VictimActions){
                action.SetActive(true);
            }
            TripleBtnClose.SetActive(true);
            TripleBtnDisabled.SetActive(false);
            foreach(GameObject tripleBtn in TripleActions)
            {
                tripleBtn.SetActive(false);
            }
        }

    }
 
    void OnTriggerExit (Collider other) {
        if (other.tag =="Player") {
        	active = false;
            TripleBtnDisabled.SetActive(true);
            foreach (GameObject btn in VictimActions){
                btn.SetActive(false);
            }
            foreach(GameObject btn in CardActions){
                btn.SetActive(false);
            }
         }
    }
}