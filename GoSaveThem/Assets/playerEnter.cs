using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerEnter : MonoBehaviour
{
 
    public GameObject ActionButton;

    void start(){
    	ActionButton.SetActive(false);
    }
     
    void OnTriggerEnter (Collider other) {
        if (other.tag =="Player") {
    	    //Debug.Log("ENTERED");
    	    ActionButton.SetActive(true);
        }
    }
 
    void OnTriggerExit (Collider other) {
        if (other.tag =="Player") {
        	//Debug.Log("Exited");
            ActionButton.SetActive(false);
        }
    }
}
 