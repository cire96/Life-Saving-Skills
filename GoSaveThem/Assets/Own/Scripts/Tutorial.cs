﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject HUD, Victim, VictimRadius;
    public GameObject RescueLeader, RescueRadius, MarkVictimContainer, VictimSearchContainer, NotFinishedContainer;
    public GameObject TutorialViews, StartingContainer, CommunicateContainer, FinishContainer, PauseContainer, DoneContainer, CloseActionsContainer;
    public GameObject HowContainer, ScoreContainer, BreathingContainer, PulseContainer, CBContainer, RAContainer, BleedingContainer;
    public List<GameObject> TutorialList, BtnList, TripleActions;
    public GameObject BlackBtn, RedBtn, YellowBtn, GreenBtn;

    TutorialBtnReact TutorialBtnReact;
    PointCount PointCount;

    public GameObject TripleBot, TripleMid, TripleBtnBg, TripleBtnClose, HowBtn, MenuBtn;
    public List<GameObject> BtnActions;

    bool NotShownCommunicate = true;
    bool NotShownVictim = true;
    bool IsXClickable = false;
    bool IsTripleMidClickable = false;
    bool IsVictimMarked = false;
    bool IsTutorialFinished;
   
    // Use this for initialization
    void Start()
    {
        TutorialBtnReact = GameObject.FindGameObjectWithTag("HUD").GetComponent<TutorialBtnReact>();
        PointCount = GameObject.FindGameObjectWithTag("Player").GetComponent<PointCount>();
        
        RescueLeader = GameObject.FindGameObjectWithTag("RescueLeader");
        RescueRadius = RescueLeader.transform.Find("Radius").gameObject;

        BlackBtn.GetComponent<Button>().onClick.AddListener(SetMarked);
        RedBtn.GetComponent<Button>().onClick.AddListener(SetMarked);
        GreenBtn.GetComponent<Button>().onClick.AddListener(SetMarked);
        YellowBtn.GetComponent<Button>().onClick.AddListener(SetMarked);

        TripleActions = new List<GameObject>() { TripleBot, TripleMid, TripleBtnBg, TripleBtnClose };
        TutorialList = new List<GameObject>() { StartingContainer, CommunicateContainer, FinishContainer, PauseContainer, HowContainer, ScoreContainer, BreathingContainer, PulseContainer, CBContainer, RAContainer, BleedingContainer, DoneContainer, CloseActionsContainer, MarkVictimContainer, VictimSearchContainer, NotFinishedContainer };
        BtnActions = new List<GameObject>() { HowBtn, MenuBtn };
        BtnList = new List<GameObject>() { BlackBtn, RedBtn, YellowBtn, GreenBtn };

        CloseAll();
        DisableTripleBtn();

        StartingContainer.SetActive(true);
        Time.timeScale = 0;
    }

    public void SetMarked()
    {
        IsVictimMarked = true;
        DisableMarks();
        TutorialBtnReact.TripleBtnToggle(false);
        DoneContainer.SetActive(true);
    }

    public void DisableMarks()
    {
        foreach (GameObject item in BtnList)
        {
            item.SetActive(false);
        }
    }

    public void DisableTripleBtn()
    {
        foreach (GameObject tripleBtn in TripleActions)
        {
            tripleBtn.GetComponent<Button>().interactable = false;
        }
    }

    public void EnableTripleBtn()
    {
        foreach (GameObject tripleBtn in TripleActions)
        {
            tripleBtn.GetComponent<Button>().interactable = true;
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
        //Victim.SetActive(true);
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
        IsXClickable = true;
    }

    public void CloseNotFinished()
    {
        NotFinishedContainer.SetActive(false);
    }

    public void CloseActions()
    {
        CloseActionsContainer.SetActive(false);
        if (IsXClickable && !IsVictimMarked)
        {
            MarkVictimContainer.SetActive(true);
            Time.timeScale = 1;
            IsXClickable = false;
            IsTripleMidClickable = true;
        } 
    }

    public void CloseMarkVictim()
    {
        if (IsTripleMidClickable)
        {
            MarkVictimContainer.SetActive(false);
            IsXClickable = true;
            IsTutorialFinished = true;
        }
    }

    public void ShowCommunicate()
    {
        if (RescueRadius.GetComponent<RescueMeny>().GetActive() && NotShownCommunicate) 
        {
            CommunicateContainer.SetActive(true);
            NotShownCommunicate = false;
            Time.timeScale = 0;
        }
        else if (!RescueRadius.GetComponent<RescueMeny>().GetActive() && !NotShownCommunicate) 
        {
            CommunicateContainer.SetActive(false);
        }
    }

    public void EnteredVictimArea()
    {

        if (VictimRadius.GetComponent<UIAppear>().GetActive() && NotShownVictim)
        {
            TripleBtnBg.SetActive(false);
            EnableTripleBtn();
            BleedingContainer.SetActive(true);
            NotShownVictim = false;
        }
        else if (!VictimRadius.GetComponent<UIAppear>().GetActive() && !NotShownVictim)
        {
            TripleBtnBg.SetActive(true);
            DisableTripleBtn();
            CloseAll();
            NotShownVictim = true;
            IsXClickable = false;
         }
    }

    public void FinishTutorial()
    {
        if (RescueRadius.GetComponent<RescueMeny>().GetActive() && IsVictimMarked)
        {
            PointCount.countPoints();
        }
        else
        {
            NotFinishedContainer.SetActive(true);
        }
    }

    void Update()
    {
        Victim = GameObject.FindGameObjectWithTag("Victim");
        VictimRadius = Victim.transform.Find("Radius").gameObject;
        ShowCommunicate();
        EnteredVictimArea();
        if(VictimRadius.GetComponent<UIAppear>().GetActive() || RescueRadius.GetComponent<RescueMeny>().GetActive())
        {
            HowBtn.GetComponent<Button>().interactable = false;
            MenuBtn.GetComponent<Button>().interactable = false;

            if (IsXClickable)
            {
                TripleBtnClose.GetComponent<Button>().interactable = true;
            }
            else
            {
                TripleBtnClose.GetComponent<Button>().interactable = false;
            }
            if (IsTripleMidClickable)
            {
                TripleMid.GetComponent<Button>().interactable = true;
                TripleBtnBg.GetComponent<Button>().interactable = true;
                TripleBot.GetComponent<Button>().interactable = false;
            }
            if (IsTutorialFinished)
            {
                TripleBot.GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            TripleBtnClose.GetComponent<Button>().interactable = true;
            TutorialBtnReact.TripleBtnToggle(false);
            HowBtn.GetComponent<Button>().interactable = true;
            MenuBtn.GetComponent<Button>().interactable = true;
        }
    }
}
