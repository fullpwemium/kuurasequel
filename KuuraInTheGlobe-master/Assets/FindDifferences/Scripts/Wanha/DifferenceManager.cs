using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DifferenceManager : MonoBehaviour
{
    public static DifferenceManager manager;
    DifGameSystem system;

    public int[] levelIndex;
    //public int levelDifficulty;
    public List<int> completedLevels = new List<int>(20);
    public int CompletedLevels;
    //public int wonLevels = 0;
    public int currentLevel;
    public int levelSelectScene;

    bool levelComplete;
    public static int cats;
    public static int score;
    public static int[] levelCats = new int[200];

    public static int Spots;

    private DifferenceUI winningUI;

    int[] DifferenceCats;
    List<int> DifferenceCompletedLevels = new List<int>();

    // Use this for initialization
    void Start ()
    {
        //PlayerPrefs.DeleteAll();

        //DifferenceLoad();

        //Defines required clics/removable objects number (when not opening level from LevelSelect scene).
        if (currentLevel == 0)
        {
            Spots = 2;
            //TimeAndClicks.timeLeft = 20;
            FindingTimer.timeLeft = 20;
            Debug.Log("Spots = " + Spots);
        }
        if (currentLevel == 1)
        {
            Spots = 3;
            //TimeAndClicks.timeLeft = 30;
            FindingTimer.timeLeft = 30;
            Debug.Log("Spots = " + Spots);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayerWin()
    {
        GameObject.Find("Canvas").GetComponent<DifferenceUI>().TextSwitcher(true);

        if (completedLevels.Contains(currentLevel) == false)
        {
            completedLevels.Add(currentLevel);        //Adds won level to completed levels.
            Debug.Log("Uusi kenttä");

            CompletedLevels++;

            //completeLevel(currentLevel);

            //DifferenceSave();

            //system.clearLevel(currentLevel);
        }
        //base.PlayerWin();
    }

    public void PlayerLose()
    {
        GameObject.Find("Canvas").GetComponent<DifferenceUI>().TextSwitcher(false);

        Debug.Log("Hävisit");

        //base.PlayerLose();
    }

    public void LoadLevel(int levelToLoad)
    {
        if (levelToLoad < levelIndex.Length)
        {
            SceneManager.LoadScene(levelIndex[levelToLoad]);    //Load scene written in LevelIndex in Unity Inspector.
            currentLevel = levelToLoad;

            Debug.Log("Difference Current Level = " + currentLevel);
            Debug.Log("Difference Level Index = " + levelIndex.Length);
            Debug.Log("Difference Level to Load = " + levelToLoad);
        }

        else
        {
            Debug.Log(levelIndex.Length);
            Debug.Log("Index out of range in level list!");
            SceneManager.LoadScene(levelSelectScene);
        }
    }

    void OnLevelWasLoaded(int level)
    {
        //------------------------------------------------------------------------
        //Defines required clics/removable objects number (when opening level from LevelSelect scene).
        if (level == 12 || level == 13)
        {
            DifferenceInitialPanel();
        }

        if (level == 12)
        {
            currentLevel = 0;
            Debug.Log("Current level = " + currentLevel);

            //RightClicks = 2;
            Spots = 2;
            //TimerLevel = 2;
            FindingTimer.timeLeft = 20;
            Debug.Log("Spots = " + Spots);
        }
        if (level == 13)
        {
            currentLevel = 1;
            Debug.Log("Current level = " + currentLevel);

            //RightClicks = 3;
            Spots = 3;
            //TimerLevel = 3;
            FindingTimer.timeLeft = 30;
            Debug.Log("Spots = " + Spots);
        }
        if (level == 1)
        {
            //currentLevel = 2;
        }

        else
        {

        }
        //------------------------------------------------------------------------

        //TimeAndClicks.StartGame();       //Restart timer and zero clicks.
        FindingTimer.StartGame();       //Restart timer.
        ClickMistake.StartClicks();     ////Zero mistake clicks.

        //Debug.Log("IIIII");
    }

    void DifferenceInitialPanel()
    {
        Debug.Log("DifferenceInitialPanel");
    }

    //public void completeLevel(int level)
    //{
    //    if (wonLevels < level)
    //    {
    //        wonLevels = level;
    //        Debug.Log("Difference level " + (level + 1) + " cleared");
    //    }
    //}

    //public int getWonLevels()
    //{
    //    Debug.Log("Won levels = " + wonLevels);
    //    return wonLevels;
    //}

//___________________________________________________________________________________________________________________

    //Saving information in prefabs     --> PlayerWin() && DifferenceUI.Score()
    public void DifferenceSave()
    {
        Debug.Log("aloitetaan tallennus difference");

        DifferenceCats = levelCats;
        DifferenceCompletedLevels = completedLevels;

        for (int i = 0; i <= 20; i++)
        {
            PlayerPrefs.SetInt("DifferenceCats" + i, DifferenceCats[i]);
            Debug.Log("Difference saved cats = " + DifferenceCats[i]);
        }
        for (int i = 0; i <= 20; i++)
        {
            if (completedLevels.Contains(i))
            {
                PlayerPrefs.SetInt("DifferenceWonLevels" + i, i);
                Debug.Log("Difference saved levels = " + DifferenceCompletedLevels[i]);
            }
        }
    }

    //Loading information from prefabs     --> Start()
    public void DifferenceLoad()
    {
        Debug.Log("ladataan difference");

        for (int i = 0; i <= 100; i++)
        {
            levelCats[i] = PlayerPrefs.GetInt("DifferenceCats" + i);
            //Debug.Log("Difference loaded stars = " + DifferenceCats[i]);
            Debug.Log("Difference loaded stars = " + levelCats[i]);
        }
        if (/*DifferenceManager.manager != null*/ manager != null)
        {
            for (int i = 0; i <= 100; i++)
            {

                DifferenceCompletedLevels.Add(PlayerPrefs.GetInt("DifferenceWonLevels" + i));
                Debug.Log("Difference loaded levels = " + DifferenceCompletedLevels[i]);
                //Debug.Log("Difference completed levels = " + completedLevels[i]);

                if (DifferenceCompletedLevels.Contains(i))
                {
                    //LabyGameManager.manager.completedLevels.Add(i);
                    manager.completedLevels.Add(i);
                    Debug.Log("leveli ladattu " + i);
                }
            }
        }
        else
        {
            Debug.Log("DifferenceManager.manager = null");
        }
    }

}
