﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifGameScript : MonoBehaviour
{
    public static DifGameScript DGS;

    //Variables used to initialize the game system
    public GameObject systemPrefab;
    private DifGameSystem system;
    public static DifGameScript gamescript;

    //Three main states of the game
    public static bool isWin;
    public static bool isLose;
    public static bool playable;

    //Variables that control the game states
    public static int spots;
    private int mistakes;
    private int rightClicks;
    private int currentLevel = 0;
    public int thisLevel = 0;
    public static int[] levelCats = new int[10];

    bool[] cats = new bool[10];

    //UI objects
    public GameObject winningPanel;
    public GameObject losingPanel;

    // Use this for initialization
    void Start ()
    {
        //PlayerPrefs.DeleteAll();
        //Debug.Log("All deleted");

        isLose = false;
        isWin = false;
        playable = true;

        initSystem();

        //Defines required clics/removable objects number (when not opening level from LevelSelect scene).
        //if (thisLevel == 0)       //When opening all levels in own scenes.
        if (DifLevelObjects.levelNumber == 0)       //When opening all levels in common DifGameplay scene.
        {
            currentLevel = 0;

            spots = 5;
            FindingTimer.timeLeft = 40;
            Debug.Log("Spots = " + spots);
        }
        //if (thisLevel == 1)
        if (DifLevelObjects.levelNumber == 1)
        {
            currentLevel = 1;

            spots = 5;
            FindingTimer.timeLeft = 30;
            Debug.Log("Spots = " + spots);
        }
        if (thisLevel == 2)
        {
            currentLevel = 2;

            spots = 5;
            FindingTimer.timeLeft = 25;
            Debug.Log("Spots = " + spots);


        }
        if (thisLevel == 3)
        {
            currentLevel = 3;


        }
        if (thisLevel == 4)
        {
            currentLevel = 4;


        }
        if (thisLevel == 5)
        {
            currentLevel = 5;


        }
        if (thisLevel == 6)
        {
            currentLevel = 6;


        }

        winningPanel.SetActive(false);
        losingPanel.SetActive(false);
        Debug.Log("Current level = " + currentLevel);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isLose && playable)
        {
            losingGame();
        }

        if (isWin && playable)
        {
            winningGame();
        }

        if (ClickMistake.Mistakes >= 3)
        {
            //DifGameScript.isLose = true;
        }
    }

    private void initSystem()
    {
        if (!GameObject.Find("difGameSystem"))
        {
            system = GameObject.Instantiate(systemPrefab).GetComponent<DifGameSystem>();
            //system.init();
            Debug.Log("System added");
        }
        else
        {
            system = GameObject.Find("difGameSystem").GetComponent<DifGameSystem>();
            Debug.Log("System found");
        }
    }

    private void replaySystem()
    {
        if (currentLevel == 0)
        {
            spots = 5;
            FindingTimer.timeLeft = 40;
            Debug.Log("Spots = " + spots);
        }

        isLose = false;
        isWin = false;
        playable = true;

        FindingTimer.StartGame();       //Restart timer.
        ClickMistake.StartClicks();     ////Zero mistake clicks.
    }

    //Actions when losing level
    public void losingGame()
    {
        Debug.Log("Game over");
        //MusicPlayer.PlayMusic(MusicTrack.GameOverJingle);
        playable = false;
        losingPanel.SetActive(true);
    }

    //Actions when winning level
    public void winningGame()
    {
        //Wait for time before making winning functions.
        StartCoroutine(Wait());

        //Debug.Log("You win!");
        //playable = false;
        ////winningPanel.SetActive(true);

        ////if first time clear
        //if (!system.isCatCollected(currentLevel))
        //{
        //    system.collectCat(currentLevel);
        //    system.clearLevel(currentLevel);
        //    system.addClearedLevels();
        //    activateWinningCat();
        //}

        ////if already cleared
        //else
        //{
        //    activateWonLevel();
        //}
    }

    public void activateWinningCat()
    {
        losingPanel.SetActive(false);
        winningPanel.SetActive(true);
        Debug.Log("You won a cat");
    }

    public void activateWonLevel()
    {
        losingPanel.SetActive(false);
        winningPanel.SetActive(true);
        Debug.Log("Cat already won");
    }

    public void onButtonClick()
    {
        if (playable)
        {
            if (spots == ClickMistake.ClickRights)
            {
                Debug.Log("You found all trashes");
                FindingTimer.EndGame();     //Stop timer.
                //DifferenceManager.manager.PlayerWin();
                //Debug.Log("Virheet = " + Mistakes);
                Debug.Log("Working");
            }
        }
    }

    private void OnLevelWasLoaded(int level)
    {


        FindingTimer.StartGame();       //Restart timer.
        ClickMistake.StartClicks();     ////Zero mistake clicks.

        Debug.Log("Load");
    }

    public void exitMinigame()
    {
        //MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.dontBuy, 1);
        Debug.Log("Exiting difference minigame");
        SceneManager.LoadScene("DifLevelSelect2", LoadSceneMode.Single);
    }

    public void replayLevel()
    {
        Application.LoadLevel(Application.loadedLevel);     //Reload opened scene.
    }

    IEnumerator Wait()
    {
        Debug.Log("Odottaa...");
        yield return new WaitForSeconds(0.8F);

        //Functions after second
        Debug.Log("You win!");
        playable = false;
        //winningPanel.SetActive(true);

        //if first time clear
        if (!system.isCatCollected(currentLevel))
        {
            system.collectCat(currentLevel);
            system.clearLevel(currentLevel);
            system.addClearedLevels();
            activateWinningCat();
        }

        //if already cleared
        else
        {
            activateWonLevel();
        }
    }
}
