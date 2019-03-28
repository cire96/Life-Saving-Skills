using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BreathingEffect : MonoBehaviour
{
    public int freq;
    public GameObject Img;
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        Img.SetActive(active);
    }

    public void BreathEnable(){
        Debug.Log("BreathEnabled");
        Img.SetActive(true);
    }
}
