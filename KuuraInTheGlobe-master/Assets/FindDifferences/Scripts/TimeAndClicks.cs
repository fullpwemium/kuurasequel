using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeAndClicks : MonoBehaviour
{
    public static float timeLeft;

    public static Text timeRunning;
    public static bool Cleared = false;

    public static float Mistakes = 0;

    public int Trash;

    public GameObject layerManager;

    public GameObject Active;

    public bool Right = false;

    public static int ClickRights = 0;

    // Use this for initialization
    void Start ()
    {
        timeRunning = GameObject.Find("Timer2").GetComponent<Text>(); //Print timer in text object.
        Debug.Log("Virheet = " + Mistakes);
    }

    //Zero mistake clicks.    --> DifferenceManager.OnLevelWasLoaded.
    public static void StartGame()
    {
        Cleared = false;
        Mistakes = 0;
        Debug.Log("Virheet = " + Mistakes);
        ClickRights = 0;
        Debug.Log("ClickRights = " + ClickRights);
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
                DifferenceManager.manager.PlayerLose();     //Activates losing panel.
            }

            //print(timeLeft); //Tulostetaan Consoleen
            timeRunning.text = timeLeft.ToString("f1"); //Print time with one decimal.
        }
    }

    void OnMouseDown()
    {
        //When clicking trash object.
        if (/*this.gameObject.name == "Roska"*/ Trash == 1 && timeLeft > 0)
        {
            //x = 0;
            //y = 2;
            click();

            if (ClickRights == DifferenceManager.Spots /*DifferenceManager.RightClicks == 0*/)
            //if (/*RightClicks == DifferenceManager.Spots*/ DifferenceManager.RightClicks == 0)
            {
                EndGame();     //Stop timer.
                DifferenceManager.manager.PlayerWin();
                Debug.Log("Virheet = " + Mistakes);
            }
        }
        //When clicking background.
        else if (/*this.gameObject.name == "Background"*/ Trash == 0 && timeLeft > 0)
        {
            timeLeft -= 3;
            Mistakes++;
            Debug.Log("Virhe!");
        }
    }

    void click()
    {
        Debug.Log("Roska löydetty");

        //DifferenceManager.RightClicks--;
        ClickRights++;
        Debug.Log("Click rights = " + ClickRights);

        Right = true;

        //Destroy(gameObject);
        Active.SetActive(false);

        GameObject clickedCard = this.gameObject;
        //layerManager = GameObject.Find("LayerManager");
        //layerManager.GetComponent<LayerScript>().ClickAction(clickedCard, (int)x, (int)y); //kun x ja y floatteja, niin edessä oltava sulkeissa int
    }

    public static void EndGame()
    {
        Cleared = true;
        Debug.Log("Voitit");
    }
}
