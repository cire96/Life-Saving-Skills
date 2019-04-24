using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Countdown : MonoBehaviour
{
    public GameObject HUD;
    private BtnReact BtnReactor;
    public int timeLeft = 120;
    public Text countdownTxt;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
        BtnReactor = HUD.GetComponent<BtnReact>();
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
            yield return new WaitForSeconds(1);
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

}
