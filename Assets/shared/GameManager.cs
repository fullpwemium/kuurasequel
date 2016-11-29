using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //This variable allows us to access this script from anywhere
    //without making any GetComponent searches, see Awake()
    public static GameManager manager;
    //public static GlobalGameManager GGM;

    /* This array defines the order of the levels and remembers the scene IDs.
     * This allows the scenes in the build settings to be in any order,
     * as they can be reordered here.
     */
    public int[] levelIndex;
    public List<int> completedLevels = new List<int>(100);
    //The current index in the 'levelIndex' array.
    public int currentLevel;
    //Level select scene index
    public int levelSelectScene;
    public static float catSpeedMultiplier = 1;
    public static float spawnSpeedMultiplier = 1;
    public static float extraTime = 10;
    public static int kissaMultiplier = 0;
    public static int brokenItemMultiplier = 1;
    public static int stars;
    public static int[] levelStars = new int[200];
    public static float aika = 1f;
    public static bool aikamuutettu = false;
    public static int snowFlakeSpeedMultiplier = 7;


    

    //Singleton check
    protected virtual void Awake ()
    {

        GlobalGameManager.GGM.bubbleWarehouseLoad();
        //completedLevels = new List<int>();
		if (manager == null) 
		{
			DontDestroyOnLoad (gameObject);
			manager = this;
		} 

		else if (manager != this) 
		{
			Destroy (gameObject);
		}
    }

    //Return to level select
    public virtual void PlayerLose ()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    //Loads next level and stores completed level
    public virtual void PlayerWin()
    {
		//Debug.Log (currentLevel);
		//Debug.Log (currentLevel + 1);
        LoadLevel(currentLevel + 1);
        if (stars > levelStars[currentLevel])
        {
            levelStars[currentLevel] = stars;
        }
        else
        {

        }
        

    }

    public virtual void CheckForWin(bool hasKisse)
    {
        //check win conditions
    }

	public virtual void RestartLevel()
	{
        aikamuutettu = false;

        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

    //Loads the given level
    public void LoadLevel(int levelToLoad)
    {
        //Add check to not go over array bounds
        //if (levelToLoad < levelIndex.Length)
        //{
            aikamuutettu = false;
            currentLevel = levelToLoad;
            Debug.Log(currentLevel);

//            SceneManager.LoadScene("LoadScene");      //Ladataan tyhjä scene ennen varsinaisen kentän avaamista

            SceneManager.LoadScene("ShelfLevel1");
        //}
        if (currentLevel == 0)
            {
                catSpeedMultiplier = 0.5f;     //Määritellään kissojen nopeus.
                spawnSpeedMultiplier = 1.5f;        //Määritellään esineiden ilmestymisnopeus.
                extraTime = 21;     //Määritellään aikaraja. Kun 0, niin neljä sekuntia.
                kissaMultiplier = 0;        //Määritellään kissojen määrä. Kun 0, niin kaksi kissaa.
                brokenItemMultiplier = 1;       //Määritellään rikkoutuvien esineiden maksimi. Kun 1, niin kolmen rikotun jälkeen Game Over.
                snowFlakeSpeedMultiplier = 8;
            }
            else if (currentLevel == 1)
            {
                catSpeedMultiplier = 0.75f;
                spawnSpeedMultiplier = 4;
                extraTime = 21;
                kissaMultiplier = 0;
                brokenItemMultiplier = 1;

            }
            else if (currentLevel == 2)
            {
                catSpeedMultiplier = 0.5f;
                spawnSpeedMultiplier = 3;
                extraTime = 21;
                kissaMultiplier = 1;
                brokenItemMultiplier = 1;

            }
            else if (currentLevel == 3)
            {
                catSpeedMultiplier = 0.75f;
                spawnSpeedMultiplier = 4;
                extraTime = 21;
                kissaMultiplier = 1;
                brokenItemMultiplier = 1;

            }
            else if (currentLevel == 4)
            {
                catSpeedMultiplier = 0.5f;
                spawnSpeedMultiplier = 9;
                extraTime = 21;
                kissaMultiplier = 2;
                brokenItemMultiplier = 1;

            }
            else if (currentLevel == 5)
            {
                catSpeedMultiplier = 0.75f;
                spawnSpeedMultiplier = 4;
                extraTime = 21;
                kissaMultiplier = 2;
                brokenItemMultiplier = 1;
                snowFlakeSpeedMultiplier = 2;

            }
            else if (currentLevel == 6)
            {
                catSpeedMultiplier = 1F;
                spawnSpeedMultiplier = 9;
                extraTime = 21;
                kissaMultiplier = 0;
                brokenItemMultiplier = 2;

            }
            else if (currentLevel == 7)
            {
                catSpeedMultiplier = 1F;
                spawnSpeedMultiplier = 6;
                extraTime = 21;
                kissaMultiplier = 1;
                brokenItemMultiplier = 1;
                snowFlakeSpeedMultiplier = 2;

            }
            else if (currentLevel == 8)
            {
                catSpeedMultiplier = 1F;
                spawnSpeedMultiplier = 9;
                extraTime = 21;
                kissaMultiplier = 2;
                brokenItemMultiplier = 3;

            }
            else if (currentLevel == 9)
            {
                catSpeedMultiplier = 1.25f;
                spawnSpeedMultiplier = 9;
                extraTime = 21;
                kissaMultiplier = 1;
                brokenItemMultiplier = 3;

            }
            else if (currentLevel == 10)
            {
                catSpeedMultiplier = 1.25f;
                spawnSpeedMultiplier = 4;
                extraTime = 35;
                kissaMultiplier = 1;
                brokenItemMultiplier = 1;

            }
            else if (currentLevel == 11)
            {
                catSpeedMultiplier = 1.5f;
                spawnSpeedMultiplier = 4;
                extraTime = 45;
                kissaMultiplier = 1;
                brokenItemMultiplier = 1;

            }
            else if (currentLevel == 12)
            {
                catSpeedMultiplier = 1.5f;
                spawnSpeedMultiplier = 4;
                extraTime = 50;
                kissaMultiplier = 1;
                brokenItemMultiplier = 1;

            }
            else if (currentLevel == 13)
            {
                catSpeedMultiplier = 1.5f;
                spawnSpeedMultiplier = 4;
                extraTime = 30;
                kissaMultiplier = 1;
                brokenItemMultiplier = 1;

            }
            else if (currentLevel == 14)
            {
                catSpeedMultiplier = 1.5f;
                spawnSpeedMultiplier = 6;
                extraTime = 35;
                kissaMultiplier = 1;
                brokenItemMultiplier = 1;

            }
            else if (currentLevel == 15)
            {
                catSpeedMultiplier = 1.625f;
                spawnSpeedMultiplier = 10;
                extraTime = 30;
                kissaMultiplier = 0;
                brokenItemMultiplier = 1;

            }
            else if (currentLevel == 16)
            {
                catSpeedMultiplier = 1.625f;
                spawnSpeedMultiplier = 8;
                extraTime = 35;
                kissaMultiplier = 0;
                brokenItemMultiplier = 1;

            }
            else if (currentLevel == 17)
            {
                catSpeedMultiplier = 1.625f;
                spawnSpeedMultiplier = 6;
                extraTime = 40;
                kissaMultiplier = 1;
                brokenItemMultiplier = 1;

            }
            else if (currentLevel == 18)
            {
                catSpeedMultiplier = 1.625f;
                spawnSpeedMultiplier = 4;
                extraTime = 45;
                kissaMultiplier = 1;
                brokenItemMultiplier = 1;

            }
            else if (currentLevel == 19)
            {
                catSpeedMultiplier = 1.625f;
                spawnSpeedMultiplier = 4;
                extraTime = 60;
                kissaMultiplier = 1;
                brokenItemMultiplier = 1;

            }
            else if (currentLevel == 20)
            {
                catSpeedMultiplier = 1.625f;
                spawnSpeedMultiplier = 6;
                extraTime = 20;
                kissaMultiplier = 7;
                brokenItemMultiplier = 1;
                snowFlakeSpeedMultiplier = 10;

            }
           
            }

        //Returns to menu
    public void GoToMenu ()
    {
        aikamuutettu = false;
        SceneManager.LoadScene(levelSelectScene);
    }

    public void ReturnToWorldSelect()
    {
        aikamuutettu = false;
        GlobalGameManager.GGM.GoToGameSelect();
        Destroy(gameObject);
    }
}
