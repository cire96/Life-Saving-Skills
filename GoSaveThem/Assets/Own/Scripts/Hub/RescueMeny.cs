using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueMeny : MonoBehaviour
{

    public GameObject FinishBtn, TalkBtn, TalkImage;
    public List<GameObject> actions;
    public bool active;
    public bool TalkImageActive = false;

    void Start()
    {
        actions = new List<GameObject>() { FinishBtn, TalkBtn };
        active = false;
        foreach (GameObject btn in actions)
        {
            btn.SetActive(false);
        }
        TalkImage.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("ENTERED");
            active = true;
            foreach (GameObject action in actions)
            {
                action.SetActive(true);
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Exited");
            active = false;
            foreach (GameObject btn in actions)
            {
                btn.SetActive(false);
            }
            TalkImage.SetActive(false);
            TalkImageActive = false;


        }
    }

    public void Talk()
    {
        if (TalkImageActive) {
            TalkImage.SetActive(false);
            TalkImageActive = false;
        }
        else
        {
            TalkImage.SetActive(true);
            TalkImageActive = true;
            Debug.Log("Picture");
        }

    }
}