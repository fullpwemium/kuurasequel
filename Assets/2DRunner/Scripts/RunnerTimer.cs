using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RunnerTimer : MonoBehaviour
{
    public static float timeCountUp = 0;

    public static Text timerText;
    public static bool Cleared = false;
    public static bool Paused = false;


    // Use this for initialization
    void Start ()
    {
        timerText = GameObject.Find("Time").GetComponent<Text>(); //Tulostetaan linkitettyyn textiin
    }

    public static void StartGame()
    {
        Cleared = false;
        Paused = false;
        timeCountUp = 0;
    }

    public static void EndGame()
    {
        Cleared = true; //Kun päästään maaliin, niin ajastin pysähtyy
    }
    public static void PauseGame()
    {
        Paused = true;
    }
    public static void Continue()
    {
        Paused = false;
    }
    //public static void Replay()
    //{
    //    Paused = false;
    //    timeCountUp = 0;
    //}

    // Update is called once per frame
    void Update ()
    {

        if (Cleared == true || Paused == true)
        {
            //            print(timeCountUp); //Tulostetaan Consoleen
            timerText.text = timeCountUp.ToString("f2"); //Määritellään aika printattavaksi textiin kolmella desimaalilla
        }
        else if (Cleared == false || Paused == false)
        {
            timeCountUp += Time.deltaTime;
            timerText.text = timeCountUp.ToString("f2");

        }
    }
}
