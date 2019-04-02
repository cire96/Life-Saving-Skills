using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnReact : MonoBehaviour
{
    public GameObject BreathImage, White, HowBtn, MenuBtn;

    public GameObject SoundLayer, SoundBlurEffect;
    public GameObject HowLayer, HowCloseBtn, HowBlurEffect;
    public GameObject MisAccRestartBtn, MisAccGoToMenuBtn, MisAccBlurEffect, MisAccLayer;
    public GameObject GameOverLayer, GameOverBlurEffect, GameOverRestartBtn, GameOverGoToMenuBtn;
    public GameObject MenuResumeBtn, MenuSoundBtn, MenuRestartBtn, MenuBlurEffect, MenuLayer;
    public GameObject BlackBtn, RedBtn, GreenBtn, YellowBtn;
    public GameObject BleedingBtn, RABtn, BreathingBtn, CBBtn, PulseBtn;
    public GameObject TripleBot, TripleMid, TripleTop, TripleBtnBg, TripleBtnClose;
    public GameObject CommTalkBtn, CommFinishBtn;

    public List<GameObject> VictimActions; //x
    public List<GameObject> MenuActions; //x 
    public List<GameObject> GameOverActions; //x
    public List<GameObject> MisAccActions; //x
    public List<GameObject> HowActions; //x
    public List<GameObject> SoundActions; //x
    public List<GameObject> CommunicationActions; //x
    public List<GameObject> CardActions; //x
    public List<GameObject> TripleActions; //x

    public GameObject[] victims;

    void Start(){
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
        TripleBtnToggle(false);

        victims = GameObject.FindGameObjectsWithTag("Victim");
    }

    public void HideThis(List<GameObject> ItemList)
    {
        foreach (GameObject Item in ItemList)
        {
            Item.SetActive(false);
        }
    }

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
            ShowThis(CardActions);
            TripleBtnToggle(true);
        }
        else if (ThisBtn == "TopBtn")
        {
            ShowThis(CommunicationActions);
            TripleBtnToggle(true);
        }

    }









    public GameObject getVictim(){
        foreach(GameObject victim in victims){
            UIAppear UIAppear = victim.transform.Find("Radius").GetComponent<UIAppear>();
            if (UIAppear.active){
                return victim;
            }
        }
        return null;
    }

    public void GivePriority(string color){
        Debug.Log("ran fuction");
        GameObject victim= getVictim();
        if (victim){
            ShowPriority ShowPriority = victim.transform.Find("PriorityCard").GetComponent<ShowPriority>();
            ShowPriority.UpdatePriority(color);
        }
    }

    public void ReleaseAirways(){
        GameObject victim = getVictim();
        Parameters Parameters = victim.GetComponent<Parameters>();
        // Play animation function
        Parameters.FreeAirways();

    }

    public void Bleeding(){
        GameObject victim = getVictim();
        Parameters Parameters = victim.GetComponent<Parameters>();
        // Play animation function
        Parameters.StopBleeding();       
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

    }

    public void HideMenuLayer()
    {
        HideThis(MenuActions);
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


