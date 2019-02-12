using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAppear : MonoBehaviour
{
 
    public GameObject ActionButton;

    void start(){
    	Debug.Log("Star Run");
    	ActionButton.SetActive(false);
    }
     
    void OnTriggerEnter (Collider other) {
        if (other.tag =="Player") {
    	    Debug.Log("ENTERED");
    	    ActionButton.SetActive(true);
        }
    }
 
    void OnTriggerExit (Collider other) {
        if (other.tag =="Player") {
        	Debug.Log("Exited");
            ActionButton.SetActive(false);
        }
    }
}