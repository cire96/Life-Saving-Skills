﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class BtnReact : MonoBehaviour {
    public GameObject HUD, BreathImage, White, HowBtn, MenuBtn;
    public GameObject SoundLayer, SoundBlurEffect;
    public GameObject HowLayer, HowCloseBtn, HowBlurEffect;
    public GameObject MisAccRestartBtn, MisAccGoToMenuBtn, MisAccBlurEffect, MisAccLayer;
    public GameObject GameOverLayer, GameOverBlurEffect, GameOverRestartBtn, GameOverGoToMenuBtn;
    public GameObject MenuResumeBtn, MenuSoundBtn, MenuRestartBtn, MenuBlurEffect, MenuLayer;
    public GameObject BlackBtn, RedBtn, GreenBtn, YellowBtn;
    public GameObject BleedingBtn, RABtn, BreathingBtn, CBBtn, PulseBtn;
    public GameObject TripleBot, TripleMid, TripleTop, TripleBtnBg, TripleBtnClose;
    public GameObject CommTalkBtn, CommFinishBtn;
    public GameObject Tourniquet;

    public List<GameObject> VictimActions, MenuActions, GameOverActions, MisAccActions, HowActions, SoundActions, CommunicationActions, CardActions, TripleActions;

    public GameObject[] victims;

    GameObject textTourniquet;
    public int numTourniquets;
    public bool isTutorial;
    public PointCount pointCountScript;
    public Feedback feedbackScript;

    // --------------- TUTORIAL START --------------------------------
    public GameObject Victim, VictimRadius;
    public GameObject RescueLeader, RescueRadius, MarkVictimContainer;
    public GameObject TutorialViews, StartingContainer, CommunicateContainer, FinishContainer, PauseContainer, DoneContainer, CloseActionsContainer;
    public GameObject HowContainer, ScoreContainer, BreathingContainer, PulseContainer, CBContainer, RAContainer, BleedingContainer, FindVictimContainer;
    public List<GameObject> TutorialList, TutorialVictimActions;

    bool NotShownCommunicate = true;
    bool NotShownVictim = true;
    bool NotClickedX = true;
    bool NotClickedMark = true;
    bool IsNotMarked = true;
    bool NotShowingPopUp = true;
    // --------------- TUTORIAL END ----------------------------------

    void Start() {
        BleedingBtn = transform.Find("Bleeding").gameObject;
        BreathImage = transform.Find("Breath").gameObject;
        BreathingBtn = transform.Find("Breathing").gameObject;
        PulseBtn = transform.Find("Pulse").gameObject;
        RABtn = transform.Find("ReleaseAirways").gameObject;
        CBBtn = transform.Find("CapillaryBackfill").gameObject;

        HowBtn = transform.Find("HowBtn").gameObject;
        HowLayer = transform.Find("HowLayer").gameObject;
        HowCloseBtn = transform.Find("HowCloseBtn").gameObject;
        HowBlurEffect = transform.Find("HowBlurEffect").gameObject;

        SoundLayer = transform.Find("SoundLayer").gameObject;
        SoundBlurEffect = transform.Find("SoundBlurEffect").gameObject;

        MisAccRestartBtn = transform.Find("MisAccRestartBtn").gameObject;
        MisAccGoToMenuBtn = transform.Find("MisAccGoToMenuBtn").gameObject;
        MisAccBlurEffect = transform.Find("MisAccBlurEffect").gameObject;
        MisAccLayer = transform.Find("MisAccLayer").gameObject;

        GameOverLayer = transform.Find("GameOverLayer").gameObject;
        GameOverBlurEffect = transform.Find("GameOverBlurEffect").gameObject;
        GameOverRestartBtn = transform.Find("GameOverRestartBtn").gameObject;
        GameOverGoToMenuBtn = transform.Find("GameOverGoToMenuBtn").gameObject;

        MenuBtn = transform.Find("MenuBtn").gameObject;
        MenuResumeBtn = transform.Find("MenuResumeBtn").gameObject;
        MenuSoundBtn = transform.Find("MenuSoundBtn").gameObject;
        MenuRestartBtn = transform.Find("MenuRestartBtn").gameObject;
        MenuBlurEffect = transform.Find("MenuBlurEffect").gameObject;
        MenuLayer = transform.Find("MenuLayer").gameObject;

        White = transform.Find("White").gameObject;
        BlackBtn = transform.Find("Black").gameObject;
        RedBtn = transform.Find("Red").gameObject;
        GreenBtn = transform.Find("Green").gameObject;
        YellowBtn = transform.Find("Yellow").gameObject;

        TripleBot = transform.Find("TripleBotBtn").gameObject;
        TripleMid = transform.Find("TripleMidBtn").gameObject;
        TripleTop = transform.Find("TripleTopBtn").gameObject;
        TripleBtnBg = transform.Find("TripleBtnBg").gameObject;
        TripleBtnClose = transform.Find("TripleBtnClose").gameObject;

        CommTalkBtn = transform.Find("CommTalkBtn").gameObject;
        CommFinishBtn = transform.Find("CommFinishBtn").gameObject;

        Tourniquet = transform.Find("Tourniquet").gameObject;

        VictimActions = new List<GameObject>(){BleedingBtn, RABtn, BreathingBtn, PulseBtn, CBBtn};
        CardActions = new List<GameObject>(){BlackBtn,GreenBtn,RedBtn,YellowBtn};
        TripleActions = new List<GameObject>() { TripleBot, TripleMid, TripleTop, TripleBtnBg };
        MenuActions = new List<GameObject>() { MenuResumeBtn, MenuSoundBtn, MenuRestartBtn, MenuBlurEffect, MenuLayer };
        GameOverActions = new List<GameObject>() { GameOverLayer, GameOverBlurEffect, GameOverRestartBtn, GameOverGoToMenuBtn };
        MisAccActions = new List<GameObject>() { MisAccRestartBtn, MisAccGoToMenuBtn, MisAccBlurEffect, MisAccLayer };
        HowActions = new List<GameObject>() { HowLayer, HowCloseBtn, HowBlurEffect };
        SoundActions = new List<GameObject>() { SoundLayer, SoundBlurEffect };
        CommunicationActions = new List<GameObject>() { CommTalkBtn, CommFinishBtn };

        HideThis(VictimActions);
        HideThis(CardActions);
        HideThis(MenuActions);
        HideThis(SoundActions);
        HideThis(GameOverActions);
        HideThis(MisAccActions);
        HideThis(HowActions);

        ShowThis(TripleActions);

        textTourniquet = Tourniquet.transform.Find("numOf").gameObject;
        textTourniquet.GetComponent<TextMeshProUGUI>().text = numTourniquets.ToString();
        pointCountScript = GameObject.FindWithTag("Player").GetComponent<PointCount>();
        feedbackScript = GameObject.FindWithTag("Player").GetComponent<Feedback>();

        // --------------- TUTORIAL START --------------------------------
        if (isTutorial) {
            RescueLeader = GameObject.FindGameObjectWithTag("RescueLeader");
            RescueRadius = RescueLeader.transform.Find("Radius").gameObject;
            Victim = GameObject.FindGameObjectWithTag("Victim");
            VictimRadius = Victim.transform.Find("Radius").gameObject;
            TutorialViews = GameObject.FindGameObjectWithTag("TutorialViews");
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
            TutorialVictimActions = new List<GameObject>() { BreathingContainer, PulseContainer, CBContainer, RAContainer, BleedingContainer, DoneContainer, CloseActionsContainer, MarkVictimContainer };

            CloseAllTutorials();
            CloseTutorialVictimActions();
            Victim.SetActive(false);
            StartingContainer.SetActive(true);
            NotShowingPopUp = false;
            Time.timeScale = 0;
        }
        // --------------- TUTORIAL END ----------------------------------

    }

    //CLOSE ALL TUTORIAL POPUPS
    public void CloseAllTutorials()
    {
        foreach (GameObject item in TutorialList)
        {
            item.SetActive(false);
        }
        Time.timeScale = 1;
        NotShowingPopUp = true;
    }

    public void CloseTutorialVictimActions()
    {
        foreach (GameObject item in TutorialVictimActions)
        {
            item.SetActive(false);
        }
        NotShowingPopUp = true;
    }

    public void CloseTutorialCommunicate()
    {
        CommunicateContainer.SetActive(false);
        FinishContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseTutorialFinish()
    {
        FinishContainer.SetActive(false);
        PauseContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseTutorialPause()
    {
        PauseContainer.SetActive(false);
        HowContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseTutorialHow()
    {
        HowContainer.SetActive(false);
        ScoreContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseTutorialScore()
    {
        ScoreContainer.SetActive(false);
        Victim.SetActive(true);
        FindVictimContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseTutorialFindVictim()
    {
        FindVictimContainer.SetActive(false);
        Time.timeScale = 1;
        NotShowingPopUp = true;
    }

    public void CloseTutorialBleeding()
    {
        BleedingContainer.SetActive(false);
        BreathingContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseTutorialBreathing()
    {
        BreathingContainer.SetActive(false);
        PulseContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseTutorialPulse()
    {
        PulseContainer.SetActive(false);
        RAContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseTutorialRA()
    {
        RAContainer.SetActive(false);
        CBContainer.SetActive(true);
        NotShowingPopUp = false;
    }

    public void CloseTutorialCB()
    {
        CBContainer.SetActive(false);
        CloseActionsContainer.SetActive(true);
        NotShowingPopUp = false;
        Time.timeScale = 0;
    }

    public void CloseTutorialActions()
    {
        CloseActionsContainer.SetActive(false);
        NotShowingPopUp = true;
        Time.timeScale = 1;

    }

    public void CloseTutorialMarkVictim()
    {
        MarkVictimContainer.SetActive(false);
        NotShowingPopUp = true;
        Time.timeScale = 0;
    }

    public void ShowTutorialCommunicate()
    {
        if (RescueRadius.GetComponent<RescueMeny>().GetActive() && NotShownCommunicate)
        {
            CommunicateContainer.SetActive(true);
            NotShownCommunicate = false;
            NotShowingPopUp = false;
            Time.timeScale = 0;
        }
        else if (!RescueRadius.GetComponent<RescueMeny>().GetActive() && !NotShownCommunicate)
        {
            CommunicateContainer.SetActive(false);
            NotShowingPopUp = true;
        }
    }

    public void EnteredTutorialVictimArea()
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
                CloseTutorialVictimActions();
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

    public void EnableTutorialHowAndMenuButton()
    {
        if (!NotShowingPopUp)
        {
            MenuBtn.GetComponent<Button>().interactable = false;
            HowBtn.GetComponent<Button>().interactable = false;
        }
    }


    //HIDE ALL ELEMENTS OF LIST
    public void HideThis(List<GameObject> ItemList) {
        foreach (GameObject Item in ItemList)
        {
            Item.SetActive(false);
        }
    }

    //SHOW ALL ELEMENTS OF LIST
    public void ShowThis(List<GameObject> ItemList)
    {
        foreach (GameObject Item in ItemList)
        {
            Item.SetActive(true);
        }
    }

    public void TripleBtnToggle(bool IsClicked)
    {
        if (IsClicked)
        {
            HideThis(TripleActions);
            TripleBtnClose.SetActive(true);
            
        }
        else
        {
            if (isTutorial) {
                IsXClicked();
            }
            ShowThis(TripleActions);
            TripleBtnClose.SetActive(false);
            HideThis(VictimActions);
            HideThis(CommunicationActions);
            HideThis(CardActions);
        }
    }

    public void TripleBtnPressed(string ThisBtn)
    {
        if (ThisBtn == "BotBtn")
        {
            ShowThis(VictimActions);
            TripleBtnToggle(true);
        }
        else if (ThisBtn == "MidBtn")
        {
            if(isTutorial){
                IsMarkClicked();
            }
            ShowThis(CardActions);
            TripleBtnToggle(true);
        }
        else if (ThisBtn == "TopBtn")
        {
            ShowThis(CommunicationActions);
            TripleBtnToggle(true);
        }

    }

    public void FinishMission()
    {
        if(isTutorial)
        {
            if(IsNotMarked)
            {
                Debug.Log("Not marked");
            }
            else
            {
                pointCountScript.countPoints();
                feedbackScript.GiveFeedback();
            }
        }
        else
        {
            pointCountScript.countPoints();
            feedbackScript.GiveFeedback();
        }
    }

    public GameObject getVictim(){
        foreach(GameObject victim in GameObject.FindGameObjectsWithTag("Victim")){
            UIAppear UIAppear = victim.transform.Find("Radius").GetComponent<UIAppear>();
            if (UIAppear.active){
                return victim;
            }
        }
        return null;
    }

    public void GivePriority(string color){
        GameObject victim = getVictim();
        if (victim){
            Parameters Parameters = victim.GetComponent<Parameters>();
            Parameters.SetPrioColor(color);
            ShowPriority ShowPriority = victim.transform.Find("PriorityCard").GetComponent<ShowPriority>();
            ShowPriority.UpdatePriority(color);
            if(isTutorial){
                IsVictimMarked();
            }
        }
    }

    public void ReleaseAirways(){
        GameObject victim = getVictim();
        Parameters Parameters = victim.GetComponent<Parameters>();
        // Play animation function
        Parameters.FreeAirways();

    }

    public void Bleeding(){
        if(numTourniquets>0){
            GameObject victim = getVictim();
            Parameters Parameters = victim.GetComponent<Parameters>();
            // Play animation function
            Parameters.StopBleeding();  
            numTourniquets-=1; 
            textTourniquet.GetComponent<TextMeshProUGUI>().text= numTourniquets.ToString(); 
             
        }//do something else
    }

    public void CapillaryBackfill()
    {
        Backfill Backfill = White.GetComponent<Backfill>();
        Backfill.ShowThumb();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene("main_menu");
    }

    public void ShowHowLayer()
    {
        ShowThis(HowActions);
    }

    public void HideHowLayer()
    {
        HideThis(HowActions);

    }

    public void ShowMenuLayer()
    {
        ShowThis(MenuActions);
        Time.timeScale = 0; //Pausa spelet och tiden

    }

    public void HideMenuLayer()
    {
        HideThis(MenuActions);
        Time.timeScale = 1; //Starta spelet och tiden

    }

    public void ShowGameOverLayer()
    {
        ShowThis(GameOverActions);
    }

    public void HideGameOverLayer()
    {
        HideThis(GameOverActions);
    }

    public void ShowMissionAccomplishedLayer()
    {
        ShowThis(MisAccActions);
    }

    public void HideMissionAccomplishedLayer()
    {
        HideThis(MisAccActions);
    }

    public void ShowSoundLayer()
    {
        ShowThis(SoundActions);
    }

    public void HideSoundLayer()
    {
        HideThis(SoundActions);
    }
}


