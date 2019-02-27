using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingEffect : MonoBehaviour
{
    public int freq;
    public GameObject Img;
    // Start is called before the first frame update
    void Start()
    {
        freq = -1;
        Img.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(freq != -1){
           ObjectRenderer.enabled = !(ObjectRenderer.enabled);
        }
        
    }

    public void BreathEnable(int newFreq){
        Debug.Log("BreathEnabled");
        freq = newFreq;
        Img.SetActive(true);
    }
    public void BrethDisable(){
        freq = -1;
        Img.SetActive(false);
    }
}
