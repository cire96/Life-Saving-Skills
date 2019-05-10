using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueMeny : MonoBehaviour
{
    public GameObject HUD;
    GameObject FinishBtn, TalkBtn, TalkImage, CommunicationLayer;
    public List<GameObject> actions;
    public bool active;
    public bool TalkImageActive = false;

    void Start()
    {
        CommunicationLayer = HUD.transform.Find("CommunicationLayer").gameObject;
        TalkBtn = CommunicationLayer.transform.Find("CommTalkBtn").gameObject;
        FinishBtn = CommunicationLayer.transform.Find("CommFinishBtn").gameObject;
        TalkImage = HUD.transform.Find("TalkImage").gameObject;

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

    public bool GetActive()
    {
        return active;
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
        }
    }
}