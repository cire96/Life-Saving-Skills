using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    public bool outZoomed; 
    // Start is called before the first frame update
    void Start()
    {   
        transform.position = new Vector3(-4.49f, 3.53f, -55f);
        //transform.position = new Vector3(-5.07f, 2.51f, -52.4f);
        offset = transform.position - player.transform.position;
        outZoomed = true;
        //zoomCamera();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

    public void zoomCamera(){
        if(outZoomed){
            outZoomed=false;
            offset=offset + new Vector3(0f,3f,-6);
        }else{
            outZoomed=true;
            offset=offset - new Vector3(0f,3f,-6);
        }
    }
}
