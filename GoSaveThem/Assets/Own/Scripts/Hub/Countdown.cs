using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Countdown : MonoBehaviour
{
    public GameObject HUD;
    private TutorialBtnReact BtnReactor;
    public int timeLeft;
    public Text countdownTxt;

    // Use this for initialization
    void Start()
    {
        timeLeft = 240; //set the time for the scene
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
        BtnReactor = HUD.GetComponent<TutorialBtnReact>();
    }

    // Update is called once per frame
    void Update()
    {
        countdownTxt.text = ("" + timeLeft); //Showing the Score on the Canvas
    }

    IEnumerator LoseTime()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1); //Använt time.DeltaTime vid tidigare tillfällen
            timeLeft--;
        }
        if (timeLeft == 0)
        {
            BtnReactor.ShowGameOverLayer();
        }
    }

    public int getTimeLeft() {
        return timeLeft;
    }

    public void ResetTimeLeft()
    {
        timeLeft = 0;
    }

}
