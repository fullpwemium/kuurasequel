﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMistake : MonoBehaviour
{
    //public Sprite emptySprite;

    public static int Mistakes = 0;

    public static int ClickRights = 0;

    public int Trash;

    //public GameObject layerManager;

    public GameObject Active;

    public bool Right = false;

    //public float x, y;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Virheet = " + Mistakes);
        Debug.Log("ClickRights = " + ClickRights);
    }

    //Zero mistake clicks.    --> DifGameScript.OnLevelWasLoaded
    public static void StartClicks()
    {
        Mistakes = 0;
        Debug.Log("Virheet = " + Mistakes);
        ClickRights = 0;
        Debug.Log("ClickRights = " + ClickRights);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //When clicking trash object.
        //if (/*this.gameObject.name == "Roska"*/ Trash == 1 && FindingTimer.timeLeft > 0)
        if (Trash == 1 && DifGameScript.playable)
        {
            //x = 0;
            //y = 2;
            click();

            //Actions when clicked all mistake objects.
            //if (ClickRights == DifferenceManager.Spots /*DifferenceManager.RightClicks == 0*/)
            if (ClickRights == DifGameScript.spots)
            {
                Debug.Log("Last click");
                FindingTimer.EndGame();     //Stop timer.

                //DifferenceManager.manager.PlayerWin();
                //DifGameScript.gamescript.winningGame();

                DifGameScript.isWin = true;     //This makes level won.
                //DifGameScript.playable = false;
                Debug.Log("Virheet = " + Mistakes);
            }
        }
        //When clicking background.
        //else if (/*this.gameObject.name == "Background"*/ Trash == 0 && FindingTimer.timeLeft > 0)
        else if(Trash == 0 && DifGameScript.playable)
        {
            FindingTimer.timeLeft -= 3;
            Mistakes++;
            Debug.Log("Virhe!");
        }
    }
    //Actions when clicking trash object.       --> OnMouseDown()
    void click()
    {
        Debug.Log("Roska löydetty");

        //DifferenceManager.RightClicks--;
        ClickRights++;
        DifClicksLeft.clicksLeft--;
        Debug.Log("Click rights = " + ClickRights);
        Debug.Log("Clicks left = " + DifClicksLeft.clicksLeft);

        //Right = true;

        //Destroy(gameObject);
        Active.SetActive(false);

        //GameObject clickedCard = this.gameObject;

        //layerManager = GameObject.Find("LayerManager");
        //layerManager.GetComponent<LayerScript>().ClickAction(clickedCard, (int)x, (int)y); //kun x ja y floatteja, niin edessä oltava sulkeissa int
    }
}