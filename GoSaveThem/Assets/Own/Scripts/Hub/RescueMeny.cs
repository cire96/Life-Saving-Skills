using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RescueMeny : MonoBehaviour
{
    public GameObject HUD;
    GameObject FinishBtn, TalkBtn, TalkImage, CommunicationLayer, TalkText;
    Animator RescueLeaderAnim;
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
        TalkText = TalkImage.transform.Find("TalkText").gameObject;
        Text txtField = TalkText.GetComponent<Text>();
        txtField.text = "Hi! There has been a car accident. Several pepople are serverely injured. Please hurry! And also, watch out for the gas leak... ";
        TalkText.SetActive(false);
        TalkImage.SetActive(false);
        RescueLeaderAnim=transform.parent.gameObject.GetComponent<Animator>();
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
            TalkText.SetActive(false);
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
            TalkText.SetActive(false);
        }
        else
        {
            RescueLeaderAnim.SetTrigger("LeaderTalkTrigger");
            TalkImage.SetActive(true);
            TalkImageActive = true;
            TalkText.SetActive(true);
        }
    }
    public void CloseTalk()
    {
        TalkImage.SetActive(false);
        TalkImageActive = false;
        TalkText.SetActive(false);
    }
}