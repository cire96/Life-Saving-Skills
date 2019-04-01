using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnReact : MonoBehaviour
{
    public GameObject ActionBtn, BleedingBtn, RABtn, BreathingBtn, CBBtn, PulseBtn, 
        BlackBtn, RedBtn, GreenBtn, YellowBtn, PriorityBtn, BreathImage, White, HowBtn, 
        HowLayer, HowCloseBtn, MenuLayer, ResumeBtn, SoundBtn, RestartBtn, MenuBtn, MenuBlurEffect, HowBlurEffect, GameOverLayer, GameOverBlurEffect,
        MissionAccomplishedBlurEffect, MissionAccomplishedLayer, SoundLayer, SoundBlurEffect, MisAccRestartBtn, MisAccGoToMenuBtn, GameOverRestartBtn, GameOverGoToMenuBtn;
    public List<GameObject> actions;
    public List<GameObject> cards;
    public GameObject[] victims;


    void Start(){
        actions = new List<GameObject>(){BleedingBtn, RABtn, BreathingBtn, PulseBtn, CBBtn};
        cards = new List<GameObject>(){BlackBtn,GreenBtn,RedBtn,YellowBtn};
        foreach(GameObject btn in actions){
            btn.SetActive(false);
        }
        foreach(GameObject btn in cards){
            btn.SetActive(false);
        }

        MenuLayer.SetActive(false);
        HowLayer.SetActive(false);
        SoundLayer.SetActive(false);
        GameOverLayer.SetActive(false);
        MissionAccomplishedLayer.SetActive(false);

       
        PriorityBtn.SetActive(false);
        ActionBtn.SetActive(false);

        victims = GameObject.FindGameObjectsWithTag("Victim");
    }

    public void Action(){
        foreach(GameObject btn in actions){
            btn.SetActive(true);
        }
        foreach(GameObject btn in cards){
            btn.SetActive(false);
        }
        ActionBtn.SetActive(false);
        PriorityBtn.SetActive(true);
    }

    public void Priority(){
        foreach(GameObject btn in actions){
            btn.SetActive(false);
        }
        foreach(GameObject btn in cards){
            btn.SetActive(true);
        }
        ActionBtn.SetActive(true);
        PriorityBtn.SetActive(false);

    }

    public GameObject getVictim(){
        foreach(GameObject victim in victims){
            Debug.Log("loop..");
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
            //Debug.Log("found victim");
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
        HowLayer.SetActive(true);
        HowBlurEffect.SetActive(true);
    }

    public void HideHowLayer()
    {
        HowLayer.SetActive(false);
        HowBlurEffect.SetActive(false);

    }

    public void ShowMenuLayer()
    {
        MenuLayer.SetActive(true);
        MenuBlurEffect.SetActive(true);

    }

    public void HideMenuLayer()
    {
        MenuLayer.SetActive(false);
        MenuBlurEffect.SetActive(false);
    }

    public void ShowGameOverLayer()
    {
        GameOverLayer.SetActive(true);
        GameOverBlurEffect.SetActive(true);
        GameOverRestartBtn.SetActive(true);
        GameOverGoToMenuBtn.SetActive(true);
    }

    public void HideGameOverLayer()
    {
        GameOverLayer.SetActive(false);
        GameOverBlurEffect.SetActive(false);
        GameOverRestartBtn.SetActive(false);
        GameOverGoToMenuBtn.SetActive(false);
    }

    public void ShowMissionAccomplishedLayer()
    {
        MissionAccomplishedLayer.SetActive(true);
        MissionAccomplishedBlurEffect.SetActive(true);
        MisAccRestartBtn.SetActive(true);
        MisAccGoToMenuBtn.SetActive(true);
    }

    public void HideMissionAccomplishedLayer()
    {
        MissionAccomplishedLayer.SetActive(false);
        MissionAccomplishedBlurEffect.SetActive(false);
        MisAccRestartBtn.SetActive(false);
        MisAccGoToMenuBtn.SetActive(false);
    }

    public void ShowSoundLayer()
    {
        SoundLayer.SetActive(true);
        SoundBlurEffect.SetActive(true);
    }

    public void HideSoundLayer()
    {
        SoundLayer.SetActive(false);
        SoundBlurEffect.SetActive(false);
    }

    /*public void Breathing(){
        GameObject victim = getVictim();
        BreathingEffect BreathingEffect = victim.GetComponent<BreathingEffect>();
        Parameters Parameters = victim.GetComponent<Parameters>();

        BreathingEffect.BreathEnable();
    }
    */
}


