using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAppear : MonoBehaviour
{

    public GameObject BleedingBtn, RABtn, BreathingBtn, CBBtn, PulseBtn, Victim;
    public GameObject BlackBtn, RedBtn, GreenBtn, YellowBtn;
    public GameObject TripleBtnClose, TripleBtnDisabled;
    public GameObject TripleTopBtn, TripleMidBtn, TripleBotBtn;

    public List<GameObject> VictimActions;
    public List<GameObject> CardActions;
    public List<GameObject> TripleActions;
    public bool active;

    void Start(){
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