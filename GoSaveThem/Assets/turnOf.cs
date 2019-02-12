using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOf : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject btn;
    void Start()
    {
		btn  = GetComponent<GameObject>();
		btn.SetActive(false);        
    }

}
