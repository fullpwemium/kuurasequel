using System;
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
    //public int thisLevel = 0;
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

        //-----------------------------------------------------------------------
        //Defines required clics/removable objects number (when not opening level from LevelSelect scene).
        //if (thisLevel == 0)       //When opening all levels in own scenes (Not using)
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
        if (DifLevelObjects.levelNumber == 2)
        {
            currentLevel = 2;

            spots = 4;
            FindingTimer.timeLeft = 15;
            Debug.Log("Spots = " + spots);


        }
        if (DifLevelObjects.levelNumber == 3)
        {
            currentLevel = 3;

            spots = 5;
            FindingTimer.timeLeft = 30;
            Debug.Log("Spots = " + spots);
        }
        if (DifLevelObjects.levelNumber == 4)
        {
            currentLevel = 4;

            spots = 5;
            FindingTimer.timeLeft = 30;
            Debug.Log("Spots = " + spots);
        }
        if (DifLevelObjects.levelNumber == 5)
        {
            currentLevel = 5;


        }
        if (DifLevelObjects.levelNumber == 6)
        {
            currentLevel = 6;


        }
        if (DifLevelObjects.levelNumber == 7)
        {
            currentLevel = 7;


        }
        if (DifLevelObjects.levelNumber == 8)
        {
            currentLevel = 8;


        }
        if (DifLevelObjects.levelNumber == 9)
        {
            currentLevel = 9;


        }
        //-----------------------------------------------------------------------

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
        if (!GameObject.Find("difGameSystem"))      //Create system prefab if it's missing.
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

    //private void replaySystem()     //Not using
    //{
    //    if (currentLevel == 0)
    //    {
    //        spots = 5;
    //        FindingTimer.timeLeft = 40;
    //        Debug.Log("Spots = " + spots);
    //    }

    //    isLose = false;
    //    isWin = false;
    //    playable = true;

    //    FindingTimer.StartGame();       //Restart timer.
    //    ClickMistake.StartClicks();     ////Zero mistake clicks.
    //}

    //Actions when losing level, called in Update()
    public void losingGame()
    {
        Debug.Log("Game over");
        MusicPlayer.PlayMusic(MusicTrack.GameOverJingle);
        playable = false;
        losingPanel.SetActive(true);
    }

    //Actions when winning level, called in Update()
    public void winningGame()
    {
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

    //Set winning panels active     --> Wait()
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

    //Actions when loading level.
    private void OnLevelWasLoaded(int level)
    {


        FindingTimer.StartGame();       //Restart timer.
        ClickMistake.StartClicks();     ////Zero mistake clicks.

        Debug.Log("Load");
    }

    public void exitMinigame()      //Return to level select.
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.dontBuy, 1);
        Debug.Log("Exiting difference minigame");
        SceneManager.LoadScene("DifLevelSelect2", LoadSceneMode.Single);
    }

    public void replayLevel()
    {
        Application.LoadLevel(Application.loadedLevel);     //Reload opened scene.
    }

    //Wait for time before making winning functions.        -->winningGame()
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
            Debug.Log("oidulgi");
            system.collectCat(currentLevel);
            system.clearLevel(currentLevel);      //It seems that addClearedLevels has made this action useless.
            system.addClearedLevels();
            activateWinningCat();
        }

        //if already cleared
        else
        {
            Debug.Log("jgolfyuk");
            activateWonLevel();
        }
    }
}
