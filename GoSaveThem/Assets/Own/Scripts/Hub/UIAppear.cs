using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{
    GameObject HUD;
    private GameObject ring;
    public List<GameObject> VictimActions;
    public List<GameObject> CardActions;
    public List<GameObject> TripleActions;
    public bool active;
    GameObject BleedingBtn, RABtn, CBBtn, BreathingBtn, PulseBtn, BlackBtn, RedBtn, GreenBtn, YellowBtn;
    GameObject TripleBtnLayer, TripleBtnClose, TripleMidBtn, TripleBotBtn, TripleBtnBg;

    void Start(){
    
        HUD = GameObject.FindGameObjectWithTag("HUD");

        TripleBtnLayer = HUD.transform.Find("TripleBtnLayer").gameObject;
        TripleBtnClose = TripleBtnLayer.transform.Find("TripleBtnClose").gameObject;
        TripleMidBtn = TripleBtnLayer.transform.Find("TripleMidBtn").gameObject;
        TripleBotBtn = TripleBtnLayer.transform.Find("TripleBotBtn").gameObject;
        TripleBtnBg = TripleBtnLayer.transform.Find("TripleBtnBg").gameObject;

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
        TripleActions = new List<GameObject>() { TripleBotBtn, TripleMidBtn };

        active = false;
        Debug.Log(transform.childCount);
        ring = transform.GetChild(0).gameObject;

        foreach (GameObject tripleBtn in TripleActions)
        {
            tripleBtn.GetComponent<Button>().interactable = false;
        }
        TripleBtnBg.GetComponent<Button>().interactable = false;

    }

    void OnTriggerEnter (Collider other) {
        if (other.tag =="Player") {
    	    active = true;
            ring.SetActive(true);

            foreach(GameObject action in VictimActions){
                action.SetActive(true);
            }
            foreach (GameObject tripleBtn in TripleActions)
            {
                tripleBtn.GetComponent<Button>().interactable = true;
            }
            TripleBtnBg.SetActive(false);
            TripleBtnBg.GetComponent<Button>().interactable = true;
            TripleBtnClose.SetActive(true);
        }

    }
 
    void OnTriggerExit (Collider other) {
        if (other.tag =="Player") {
        	active = false;
            ring.SetActive(false);
            TripleBtnClose.SetActive(false);
            TripleBtnBg.SetActive(true);
            foreach (GameObject btn in VictimActions){
                btn.SetActive(false);
            }
            foreach(GameObject btn in CardActions){
                btn.SetActive(false);
            }
            foreach (GameObject tripleBtn in TripleActions)
            {
                tripleBtn.GetComponent<Button>().interactable = false;
            }
            TripleBtnBg.GetComponent<Button>().interactable = false;
        }
    }

    public bool GetActive()
    {
        return active;
    }
}