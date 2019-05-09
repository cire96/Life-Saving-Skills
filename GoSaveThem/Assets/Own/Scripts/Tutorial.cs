using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject HUD, Victim, VictimRadius;
    public GameObject RescueLeader, RescueRadius, MarkVictimContainer, VictimSearchContainer;
    public GameObject TutorialViews, StartingContainer, CommunicateContainer, FinishContainer, PauseContainer, DoneContainer, CloseActionsContainer;
    public GameObject HowContainer, ScoreContainer, BreathingContainer, PulseContainer, CBContainer, RAContainer, BleedingContainer;
    public List<GameObject> TutorialList;


    public GameObject TripleBot, TripleMid, TripleTop, TripleBtnBg, TripleBtnClose, HowBtn, MenuBtn;
    public List<GameObject> BtnActions;

    bool NotShownCommunicate = true;
    bool NotShownVictim = true;
    bool IsXClickable = false;


    // Use this for initialization
    void Start()
    {
        Victim = GameObject.FindGameObjectWithTag("Victim");
        VictimRadius = Victim.transform.Find("Radius").gameObject;
        RescueLeader = GameObject.FindGameObjectWithTag("RescueLeader");
        RescueRadius = RescueLeader.transform.Find("Radius").gameObject;

        TutorialList = new List<GameObject>() { StartingContainer, CommunicateContainer, FinishContainer, PauseContainer, HowContainer, ScoreContainer, BreathingContainer, PulseContainer, CBContainer, RAContainer, BleedingContainer, DoneContainer, CloseActionsContainer, MarkVictimContainer, VictimSearchContainer };
        BtnActions = new List<GameObject>() { TripleBot, TripleMid, TripleTop, TripleBtnBg, HowBtn, MenuBtn };

        CloseAll();
        DisableBtns();

        Victim.SetActive(false);
        StartingContainer.SetActive(true);
        Time.timeScale = 0;
    }

    public void DisableBtns()
    {
        foreach (GameObject item in BtnActions)
        {

            item.GetComponent<Button>().interactable = false;
        }
    }

    public void EnableBtns()
    {
        foreach (GameObject item in BtnActions)
        {
            item.GetComponent<Button>().interactable = true;
        }
    }

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
        VictimSearchContainer.SetActive(true);
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
        IsXClickable = true;
    }

    public void CloseActions()
    {
        if (IsXClickable)
        {
            CloseActionsContainer.SetActive(false);
            MarkVictimContainer.SetActive(true);
            Time.timeScale = 1;
            IsXClickable = false;
        }

    }

    public void CloseMarkVictim()
    {
        MarkVictimContainer.SetActive(false);
        DoneContainer.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShowCommunicate()
    {
        if (RescueRadius.GetComponent<RescueMeny>().GetActive()) {
            //DisableBtns();
            if (NotShownCommunicate)
            {
                CommunicateContainer.SetActive(true);
                NotShownCommunicate = false;
                Time.timeScale = 0;
            }
        } 
        else if (!RescueRadius.GetComponent<RescueMeny>().GetActive()) {
            //EnableBtns();
            if (!NotShownCommunicate)
            {
                CommunicateContainer.SetActive(false);
            }
        }
    }

    public void EnteredVictimArea()
    {
        if (VictimRadius.GetComponent<UIAppear>().GetActive())
        {
            //DisableBtns();
            if (NotShownVictim)
            {
                BleedingContainer.SetActive(true);
                NotShownVictim = false;
            }
        }
        else if (!VictimRadius.GetComponent<UIAppear>().GetActive())
        {
            //EnableBtns();
            if (!NotShownVictim)
            {
                BleedingContainer.SetActive(false);
            }
        }
    }

    void Update()
    {
        //har ändrat här tabort commentarne när du hittar den
        if(VictimRadius.GetComponent<UIAppear>().GetActive()||RescueRadius.GetComponent<RescueMeny>().GetActive()){
            if(IsXClickable)
            {
                TripleBtnClose.GetComponent<Button>().interactable = true;
            }
            else
            {
                TripleBtnClose.GetComponent<Button>().interactable = false;
                DisableBtns();
            }
        }
        else{
            EnableBtns();
        }
        ShowCommunicate();
        EnteredVictimArea();

         

    }
}
