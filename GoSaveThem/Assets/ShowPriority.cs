using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPriority : MonoBehaviour
{
	private Renderer ObjectRenderer;
    // Start is called before the first frame update
    void Start()
    {
    	//Fetch the GameObject's Renderer component
        ObjectRenderer = GetComponent<Renderer>();
        ObjectRenderer.enabled = false;
    }

    // Update is called once per frame
    public void UpdatePriority(string color)
    {

    	switch (color)
      	{
          	case "red":
            	ObjectRenderer.material.color = Color.red;
             	break;
        	case "green":
             	ObjectRenderer.material.color = Color.green;
             	break;
         	case "yellow":
          	 	ObjectRenderer.material.color = Color.yellow;
          	 	break;
         	case "black":
            	ObjectRenderer.material.color = Color.black;
            	break;
     	} 
     	ObjectRenderer.enabled = true;
    }
}
