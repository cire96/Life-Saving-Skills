using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject HUD, Victim;
    GameObject RescueLeader, RescueRadius;
    GameObject TutorialViews, StartingContainer, CommunicateContainer, FinishContainer, PauseContainer;
    GameObject HowContainer, ScoreContainer, BreathingContainer, PulseContainer, CBContainer;
    public List<GameObject> TutorialList;

    bool NotShownCommunicate = true;


    // Use this for initialization
    void Start()
    {
        RescueLeader = GameObject.FindGameObjectWithTag("RescueLeader");
        RescueRadius = RescueLeader.transform.Find("Radius").gameObject;
        Victim = GameObject.FindGameObjectWithTag("Victim");


        TutorialViews = HUD.transform.Find("TutorialViews").gameObject;
        StartingContainer = TutorialViews.transform.Find("StartingContainer").gameObject;
        CommunicateContainer = TutorialViews.transform.Find("CommunicateContainer").gameObject;
        FinishContainer = TutorialViews.transform.Find("FinishContainer").gameObject;
        PauseContainer = TutorialViews.transform.Find("PauseContainer").gameObject;
        HowContainer = TutorialViews.transform.Find("HowContainer").gameObject;
        ScoreContainer = TutorialViews.transform.Find("ScoreContainer").gameObject;
        BreathingContainer = TutorialViews.transform.Find("BreathingContainer").gameObject;
        PulseContainer = TutorialViews.transform.Find("PulseContainer").gameObject;
        CBContainer = TutorialViews.transform.Find("CBContainer").gameObject;

        TutorialList = new List<GameObject>() { StartingContainer, CommunicateContainer, FinishContainer, PauseContainer, HowContainer, ScoreContainer, BreathingContainer, PulseContainer, CBContainer };

        CloseAll();

        Victim.SetActive(false);
        StartingContainer.SetActive(true);


    }

    // Update is called once per frame
    public void CloseAll()
    {
        foreach (GameObject item in TutorialList)
        {
            item.SetActive(false);
        }
    }

    public void CloseCommunicate()
    {
        CommunicateContainer.SetActive(false);
        FinishContainer.SetActive(true);
    }

    public void CloseFinish()
    {
        FinishContainer.SetActive(false);
        PauseContainer.SetActive(true);
    }

    public void ClosePause()
    {
        PauseContainer.SetActive(false);
        HowContainer.SetActive(true);
    }

    public void CloseHow()
    {
        HowContainer.SetActive(false);
        ScoreContainer.SetActive(true);
    }

    public void CloseScore()
    {
        ScoreContainer.SetActive(false);
        Victim.SetActive(true);
    }

    public void ShowCommunicate()
    {

        if (RescueRadius.GetComponent<RescueMeny>().GetActive() && NotShownCommunicate)
        {
            CommunicateContainer.SetActive(true);
            NotShownCommunicate = false;
        } 
        else if (!RescueRadius.GetComponent<RescueMeny>().GetActive() && !NotShownCommunicate) {
            CommunicateContainer.SetActive(false);
        }

    }


    void Update()
    {
        ShowCommunicate();
    }
}
