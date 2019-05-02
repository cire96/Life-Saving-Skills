using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Feedback : MonoBehaviour
{
    private GameObject[] victims;
    private Parameters victimParam;
    private bool NoPriority = false;
    private bool MissedTorniquet = false;
    private bool MissedFreeingAirways = false;
    private bool WastedTorniquet = false;
    private bool UnnecessaryReleasedAirways = false;
    private bool WrongPrio = false;

    public GameObject HUD;
    private GameObject FeedbackOne, FeedbackTwo, FeedbackThree, GoS;

    public void CheckActions()
    {
        victims = GameObject.FindGameObjectsWithTag("Victim");
        foreach (GameObject victim in victims)
        {
            victimParam = victim.GetComponent<Parameters>();
            Dictionary<string, object> ParamDic = victimParam.getParamHash();
            string SetPrio = ParamDic["SetPrio"].ToString();
    
            if (SetPrio == "unset")
            {
                NoPriority = true;
                continue;
            }
            // Bleeding
            if ((bool) ParamDic["Bleeding"] == true)
            {
                MissedTorniquet = true;
            }
            if ((bool)ParamDic["UnnecessaryTourniquet"] == true)
            {
                WastedTorniquet = true;
            }
            // Breathing
            if ((bool)ParamDic["AirwaysBlocked"] == true)
            {
                MissedFreeingAirways = true;
            }
            if((bool)ParamDic["UnnecessaryAirwaysReleased"] == true)
            {
                UnnecessaryReleasedAirways = true;
            }

            string prio = ParamDic["prio"].ToString();
            if ( prio != SetPrio)
            {
                WrongPrio = true;
            }
        }
    }


    public void GiveFeedback()
    {
        GoS = HUD.transform.Find("GameOverStats").gameObject;
        string m;

        CheckActions();
        Debug.Log("Row 54");
        int FeedbackCount = 0;

        // Ordningen av if-satserna är enligt prioriteringen av feedbacken.
        if (NoPriority && FeedbackCount < 3)
        {
            m = "- You forgot to give priority to victim(s).";
            Debug.Log("Forgot to give priority");
            FeedbackCount++;
            SetText(m, FeedbackCount);
        }
        if (MissedTorniquet && FeedbackCount < 3)
        {
            m = "- Victim(s) in need of torniquet was not treated.";
            Debug.Log("missed torni");
            FeedbackCount++;
            SetText(m, FeedbackCount);
        }
        if (MissedFreeingAirways && FeedbackCount < 3)
        {
            m = "- Airway of victim(s) was not freed.";
            Debug.Log("Airway of victim(s) was not freed.");
            FeedbackCount++;
            SetText(m, FeedbackCount);
        }

        if (WastedTorniquet && FeedbackCount < 3)
        {
            m = "- A torniquet was wasted on a victim who was not bleeding.";
            Debug.Log("A torniquet was wasted on a victim who was not bleeding.");
            FeedbackCount++;
            SetText(m, FeedbackCount);
        }

        if (UnnecessaryReleasedAirways && FeedbackCount < 3)
        {
            m = "- Tried to free the airway of victim(s) whose airway was not blocked.";
            Debug.Log("Tried to free the airway of victim(s) whose airway was not blocked.");
            FeedbackCount++;
            SetText(m, FeedbackCount);
        }
        if (WrongPrio && FeedbackCount < 3)
        {
            m = "- Wrong priority given, be careful when measuring pulse, breathing frequency, and capillary backfill.";
            Debug.Log("Wrong priority given, be careful when measuring pulse, breathing frequency, and capillary backfill.");
            FeedbackCount++;
            SetText(m, FeedbackCount);
        }
    }

    void SetText(string msg, int count)
    {
        if(count == 1)
        {
            FeedbackOne = GoS.transform.Find("FeedbackOne").gameObject;
            Text txtField = FeedbackOne.GetComponent<Text>();
            txtField.text = msg;
        }
        else if (count == 2)
        {
            FeedbackTwo = GoS.transform.Find("FeedbackTwo").gameObject;
            Text txtField = FeedbackTwo.GetComponent<Text>();
            txtField.text = msg;
        }
        else if (count == 3)
        {
            FeedbackThree = GoS.transform.Find("FeedbackThree").gameObject;
            Text txtField = FeedbackThree.GetComponent<Text>();
            txtField.text = msg;
        }
    }
}
