using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindingTimer : MonoBehaviour
{

    public static float timeLeft = 20;

    public static Text timeRunning;
    public static bool Cleared = false;

    // Use this for initialization
    void Start ()
    {
        timeRunning = GameObject.Find("Timer2").GetComponent<Text>(); //Print timer in text object.

        //if (DifferenceManager.TimerLevel == 2)
        //{
        //    timeLeft = 20;
        //}
        //else if (DifferenceManager.TimerLevel == 3)
        //{
        //    timeLeft = 30;
        //}
    }

    //Restart timer.    --> DifferenceManager.OnLevelWasLoaded && RestartDifference.Replay
    public static void StartGame()
    {
        Cleared = false;

        //if (DifferenceManager.TimerLevel == 2)
        //{
        //    timeLeft = 20;
        //}
        //else if (DifferenceManager.TimerLevel == 3)
        //{
        //    timeLeft = 30;
        //}
    }

    //Stop timer.       --> ClickMistake.OnMouseDown.
    public static void EndGame()
    {
        Cleared = true;
        Debug.Log("Voitit");
    }

    // Update is called once per frame
    void Update ()
    {

        if (Cleared == false)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                //Debug.Log(timeLeft);
            }

            else if (timeLeft <= 0)
            {
                //DifferenceManager.manager.PlayerLose();     //Activates losing panel.
                DifGameScript.isLose = true;
            }

            //print(timeLeft); //Tulostetaan Consoleen
            timeRunning.text = timeLeft.ToString("f1"); //Print time with one decimal.
        }
    }
}
