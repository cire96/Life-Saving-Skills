using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject HUD, Victim, VictimRadius;
    GameObject RescueLeader, RescueRadius, MarkVictimContainer;
    GameObject TutorialViews, StartingContainer, CommunicateContainer, FinishContainer, PauseContainer, DoneContainer, CloseActionsContainer;
    GameObject HowContainer, ScoreContainer, BreathingContainer, PulseContainer, CBContainer, RAContainer, BleedingContainer;
    public List<GameObject> TutorialList;

    bool NotShownCommunicate = true;
    bool NotShownVictim = true;


    // Use this for initialization
    void Start()
    {
        RescueLeader = GameObject.FindGameObjectWithTag("RescueLeader");
        RescueRadius = RescueLeader.transform.Find("Radius").gameObject;

        Victim = GameObject.FindGameObjectWithTag("Victim");
        VictimRadius = Victim.transform.Find("Radius").gameObject;

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
        RAContainer = TutorialViews.transform.Find("RAContainer").gameObject;
        BleedingContainer = TutorialViews.transform.Find("BleedingContainer").gameObject;
        DoneContainer = TutorialViews.transform.Find("DoneContainer").gameObject;
        CloseActionsContainer = TutorialViews.transform.Find("CloseActionsContainer").gameObject;
        MarkVictimContainer = TutorialViews.transform.Find("MarkVictimContainer").gameObject;

        TutorialList = new List<GameObject>() { StartingContainer, CommunicateContainer, FinishContainer, PauseContainer, HowContainer, ScoreContainer, BreathingContainer, PulseContainer, CBContainer, RAContainer, BleedingContainer, DoneContainer, CloseActionsContainer, MarkVictimContainer };

        CloseAll();

        Victim.SetActive(false);
        StartingContainer.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void CloseAll()
    {
        foreach (GameObject item in TutorialList)
        {
            item.SetActive(false);
        }
        Time.timeScale = 1;
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
        Time.timeScale = 1;
    }

    public void CloseBleeding()
    {
        BleedingContainer.SetActive(false);
        BreathingContainer.SetActive(true);
    }

    public void CloseBreathing()
    {
        BreathingContainer.SetActive(false);
        PulseContainer.SetActive(true);
    }

    public void ClosePulse()
    {
        PulseContainer.SetActive(false);
        RAContainer.SetActive(true);
    }

    public void CloseRA()
    {
        RAContainer.SetActive(false);
        CBContainer.SetActive(true);
    }

    public void CloseCB()
    {
        CBContainer.SetActive(false);
        CloseActionsContainer.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseActions()
    {
        CloseActionsContainer.SetActive(false);
        MarkVictimContainer.SetActive(true);
        Time.timeScale = 1;

    }

    public void CloseMarkVictim()
    {
        MarkVictimContainer.SetActive(false);
        DoneContainer.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShowCommunicate()
    {
        if (RescueRadius.GetComponent<RescueMeny>().GetActive() && NotShownCommunicate)
        {
            CommunicateContainer.SetActive(true);
            NotShownCommunicate = false;
            Time.timeScale = 0;
        } 
        else if (!RescueRadius.GetComponent<RescueMeny>().GetActive() && !NotShownCommunicate) {
            CommunicateContainer.SetActive(false);
        }
    }

    public void EnteredVictimArea()
    {
        if (VictimRadius.GetComponent<UIAppear>().GetActive() && NotShownVictim)
        {
            BleedingContainer.SetActive(true);
            NotShownVictim = false;
        }
        else if (!VictimRadius.GetComponent<UIAppear>().GetActive() && !NotShownVictim)
        {
            BleedingContainer.SetActive(false);
        }
    }

    void Update()
    {
        ShowCommunicate();
        EnteredVictimArea();
    }
}
