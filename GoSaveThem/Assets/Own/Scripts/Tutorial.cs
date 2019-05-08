using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject HUD, Victim, VictimRadius;
    GameObject RescueLeader, RescueRadius, MarkVictimContainer, HowBtn, MenuBtn, TripleBtnClose;
    GameObject TutorialViews, StartingContainer, CommunicateContainer, FinishContainer, PauseContainer, DoneContainer, CloseActionsContainer;
    GameObject HowContainer, ScoreContainer, BreathingContainer, PulseContainer, CBContainer, RAContainer, BleedingContainer, FindVictimContainer;
    public List<GameObject> TutorialList, VictimActions;

    bool NotShownCommunicate = true;
    bool NotShownVictim = true;
    bool NotClickedX = true;
    bool NotClickedMark = true;
    bool IsNotMarked = true;
    bool NotShowingPopUp = true;

    // Use this for initialization
    void Start()
    {
        RescueLeader = GameObject.FindGameObjectWithTag("RescueLeader");
        RescueRadius = RescueLeader.transform.Find("Radius").gameObject;

        Victim = GameObject.FindGameObjectWithTag("Victim");
        VictimRadius = Victim.transform.Find("Radius").gameObject;

        HowBtn = HUD.transform.Find("HowBtn").gameObject;
        MenuBtn = HUD.transform.Find("MenuBtn").gameObject;
        TripleBtnClose = HUD.transform.Find("TripleBtnLayer").gameObject.transform.Find("TripleBtnClose").gameObject;

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
        FindVictimContainer = TutorialViews.transform.Find("FindVictimContainer").gameObject;


        TutorialList = new List<GameObject>() { StartingContainer, CommunicateContainer, FinishContainer, PauseContainer, HowContainer, ScoreContainer, BreathingContainer, PulseContainer, CBContainer, RAContainer, BleedingContainer, DoneContainer, CloseActionsContainer, MarkVictimContainer, FindVictimContainer };
        VictimActions = new List<GameObject>() { BreathingContainer, PulseContainer, CBContainer, RAContainer, BleedingContainer, DoneContainer, CloseActionsContainer, MarkVictimContainer };


        CloseAll();

        Victim.SetActive(false);
        StartingContainer.SetActive(true);
        NotShowingPopUp = false;
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
        NotShowingPopUp = true;
    }

    public void CloseVictimActions()
    {
        foreach (GameObject item in VictimActions)
        {
            item.SetActive(false);
        }
        NotShowingPopUp = true;
    }

    public void CloseCommunicate()
    {
        CommunicateContainer.SetActive(false);
        FinishContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseFinish()
    {
        FinishContainer.SetActive(false);
        PauseContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void ClosePause()
    {
        PauseContainer.SetActive(false);
        HowContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseHow()
    {
        HowContainer.SetActive(false);
        ScoreContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseScore()
    {
        ScoreContainer.SetActive(false);
        Victim.SetActive(true);
        FindVictimContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseFindVictim() 
    {
        FindVictimContainer.SetActive(false);
        Time.timeScale = 1;
        NotShowingPopUp = true;
    }

    public void CloseBleeding()
    {
        BleedingContainer.SetActive(false);
        BreathingContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseBreathing()
    {
        BreathingContainer.SetActive(false);
        PulseContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void ClosePulse()
    {
        PulseContainer.SetActive(false);
        RAContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseRA()
    {
        RAContainer.SetActive(false);
        CBContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseCB()
    {
        CBContainer.SetActive(false);
        CloseActionsContainer.SetActive(true);
        NotShowingPopUp = false;
        Time.timeScale = 0;
    }

    public void CloseActions()
    {
        CloseActionsContainer.SetActive(false);
        NotShowingPopUp = true;
        Time.timeScale = 1;

    }

    public void CloseMarkVictim()
    {
        MarkVictimContainer.SetActive(false);
        NotShowingPopUp = true;
        Time.timeScale = 0;
    }

    public void ShowCommunicate()
    {
        if (RescueRadius.GetComponent<RescueMeny>().GetActive() && NotShownCommunicate)
        {
            CommunicateContainer.SetActive(true);
            NotShownCommunicate = false;
            NotShowingPopUp = false;
            Time.timeScale = 0;
        } 
        else if (!RescueRadius.GetComponent<RescueMeny>().GetActive() && !NotShownCommunicate) {
            CommunicateContainer.SetActive(false);
            NotShowingPopUp = true;
        }
    }

    public void EnteredVictimArea()
    {
        if (VictimRadius.GetComponent<UIAppear>().GetActive())
        {
            if (IsNotMarked && NotShownVictim)
            {
                BleedingContainer.SetActive(true);
                NotShownVictim = false;
                NotShowingPopUp = false;
            }
        }
        else if (!VictimRadius.GetComponent<UIAppear>().GetActive())
        {
            if (!NotShownVictim && IsNotMarked)
            {
                
                NotShownVictim = true;
                NotClickedX = true;
                NotClickedMark = true;
                CloseVictimActions();
            }
            NotShowingPopUp = true;
        }
    }

    public void IsXClicked()
    {
        if (NotClickedX)
        {
            NotClickedX = false;
            CloseActionsContainer.SetActive(false);
            MarkVictimContainer.SetActive(true);
            NotShowingPopUp = false;
            Time.timeScale = 0;
        }
    }

    public void IsMarkClicked()
    {
        if (NotClickedMark)
        {
            NotClickedMark = false;
            MarkVictimContainer.SetActive(false);
            NotShowingPopUp = true;
            Time.timeScale = 1;
        }
    }

    public void IsVictimMarked()
    {
        if (IsNotMarked)
        {
            IsNotMarked = false;
            DoneContainer.SetActive(true);
            NotShowingPopUp = false;
            Time.timeScale = 0;
        }
    }

    public void EnableHowAndMenuButton()
    {
        if (!NotShowingPopUp)
        {
            MenuBtn.GetComponent<Button>().interactable = false;
            HowBtn.GetComponent<Button>().interactable = false;
        }
    }

void Update()
    {
        ShowCommunicate();
        EnteredVictimArea();
        EnableHowAndMenuButton();
    }
}