using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victimController : MonoBehaviour
{
    public Animator anim;
    public int randNum;

    // Start is called before the first frame update
    void Awake()
    {
        randNum = Random.Range(0,2);
        anim = GetComponent<Animator>();
        
        if(randNum == 1){
            Debug.Log("sitting");
            anim.SetBool("sitOrLayingBool", true);
        }else{
            anim.SetBool("sitOrLayingBool", false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
