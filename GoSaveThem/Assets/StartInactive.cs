using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInactive : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject btn;
    void Start()
    {
		btn.SetActive(false);        
    }

}
