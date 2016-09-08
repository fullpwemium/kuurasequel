using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class LabyGameManager : MonoBehaviour {

    //This variable allows us to access this script from anywhere
    //without making any GetComponent searches, see Awake()
    public static LabyGameManager manager;
    //public static GlobalGameManager GGM;

    /* This array defines the order of the levels and remembers the scene IDs.
     * This allows the scenes in the build settings to be in any order,
     * as they can be reordered here.
     */
    public int[] levelIndex;
    public List<int> completedLevels = new List<int>();

    //The current index in the 'levelIndex' array.
    public int currentLevel;
    //Level select scene index
    public int levelSelectScene;

    //Singleton check
    protected virtual void Awake()
    {
        //completedLevels = new List<int>();
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

    //Return to level select
    public virtual void PlayerLose()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    //Loads next level and stores completed level
    public virtual void PlayerWin()
    {
        //Debug.Log (currentLevel);
        //Debug.Log (currentLevel + 1);
        LoadLevel(currentLevel + 1);
    }

    public virtual void CheckForWin(bool hasKisse)
    {
		if (hasKisse)
		{
			PlayerWin();
		}
    }

    public virtual void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Loads the given level
    public void LoadLevel(int levelToLoad)
    {
        //Add check to not go over array bounds

        if (levelToLoad < levelIndex.Length)
        {
            SceneManager.LoadScene(levelIndex[levelToLoad]);
            currentLevel = levelToLoad;
            Debug.Log("Level index = " + levelIndex);
            Debug.Log("Level to load = " + levelToLoad);
            Debug.Log("Current level = " + currentLevel);

            if (currentLevel == 0)      //Loading level on the basis of currentLevel
            {
                SceneManager.LoadScene("LabPuzzleLevel0");
            }
            else if (currentLevel == 1)
            {
                SceneManager.LoadScene("LabPuzzleLevel1");
            }
            else if (currentLevel == 2)
            {
                SceneManager.LoadScene("LabPuzzleLevel2");
            }
            else if (currentLevel == 3)
            {
                SceneManager.LoadScene("LabPuzzleLevel3");
            }
            else if (currentLevel == 4)
            {
                SceneManager.LoadScene("LabPuzzleLevel4");
            }
            else if (currentLevel == 5)
            {
                SceneManager.LoadScene("LabPuzzleLevel5");
            }
            else if (currentLevel == 6)
            {
                SceneManager.LoadScene("LabPuzzleLevel6");
            }
            else if (currentLevel == 7)
            {
                SceneManager.LoadScene("LabPuzzleLevel7");
            }
            else if (currentLevel == 8)
            {
                SceneManager.LoadScene("LabPuzzleLevel8");
            }
            else if (currentLevel == 9)
            {
                SceneManager.LoadScene("LabPuzzleLevel9");
            }
            else if (currentLevel == 10)    //Not set to Labyrinth level select
            {
                SceneManager.LoadScene("LabPuzzleLevel11");
            }
        }
        else
        {
            Debug.Log("Index out of range in level list!");
            GoToMenu();
        }

        //if (BobLevelScript.StandingLevelNumberX == 0)     //Ladataan kenttä StandingLevelNumberin perusteella. Ongelmana tähtien värittäminen ensimmäiseen Level Buttoniin vaikka olisi
                                                            //jokin muu kenttä läpäisty.
        //{
        //    SceneManager.LoadScene("LabPuzzleLevel0");
        //}
        //else if (BobLevelScript.StandingLevelNumberX == 1)
        //{
        //    SceneManager.LoadScene("LabPuzzleLevel0");
        //}
        //else if (BobLevelScript.StandingLevelNumberX == 2)
        //{
        //    SceneManager.LoadScene("LabPuzzleLevel2");
        //}
    }

    /*public virtual void LoadNextLevel()
    {
        	
    }*/

    //Returns to menu
    public void GoToMenu()
    {
        SceneManager.LoadScene(levelSelectScene);
    }

    public void ReturnToWorldSelect()
    {
        GlobalGameManager.GGM.GoToGameSelect();
        Destroy(gameObject);
    }
}
