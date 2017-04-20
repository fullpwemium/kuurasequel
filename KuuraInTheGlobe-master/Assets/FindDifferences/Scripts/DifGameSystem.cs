using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifGameSystem : MonoBehaviour
{
    // How many levels has the player cleared?
    int clearedLevels = 0;

    // Chosen level or the point at which player starts from after picking "retry" on game over screen
    int startingLevel = 1;

    // List of the cats that have been collected; true if yes, false if not
    bool[] cats = new bool[10];

    // Has this script's init() function been called?
    //bool initialized = false;

    // Use this for initialization
    void Start ()
    {
        gameObject.name = "difGameSystem";
        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    // Function to initialize the game system state; mostly relevant
    // for checking what cats have been acquired and what haven't
    void Awake()
    {
        /*if (initialized) {
			return;
		}*/

        clearedLevels = GlobalGameManager.GGM.getNumberOfBeatenLevels("difGame");
        Debug.Log("Cleared levels = " + clearedLevels);
        if (clearedLevels == 0)
        {
            //clearedLevels++;
        }

        for (int i = 0; i < cats.Length; i++)
        {
            cats[i] = GlobalGameManager.GGM.hasCatBeenAcquiredForGivenLevel("difGame", i + 1);
        }
        //initialized = true;
    }

    // Return if cat is collected for a given level
    // Parameter should vary between [0,9] inclusively
    public bool isCatCollected(int level)
    {
        //return cats[level - 1];
        return cats[level];
    }

    // Mark cat as collected for the given level
    // Parameter should vary between [0,9] inclusively
    public void collectCat(int level)
    {
        if (!cats[level])
        {
            Debug.Log("Cat was collected from level [" + level + "]");
            cats[level] = true;
            GlobalGameManager.GGM.setCatAcquisitionForGivenLevel("difGame", level, 1);
        }
    }

    // Mark a level as cleared by incrementing the value
    public void clearLevel(int cleared)
    {
        // If cleared level is higher than previous maximum, update the value
        if (clearedLevels < cleared)
        {
            Debug.Log("Level " + (cleared + 1) + " cleared");
            clearedLevels = cleared;
            GlobalGameManager.GGM.setNumberOfBeatenLevels("difGame", clearedLevels);
        }
    }

    // Return what levels have been cleared
    public int getClearedLevels()
    {
        Debug.Log("Cleared levels = " + clearedLevels);
        return clearedLevels;
    }

    public void addClearedLevels()
    {
        clearedLevels++;
        Debug.Log("Added cleared levels = " + clearedLevels);
    }

    public void setStartingLevel(int level)
    {
        startingLevel = level;
        Debug.Log("Starting level set at " + level);
    }

    public int getStartingLevel()
    {
        Debug.Log("Returning level " + startingLevel);
        return startingLevel;
    }

    // Function to call when player wants to exit the minigame
    public void exit()
    {
        // Saving cleared levels, collected cats, and other details would go here

        //MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuCancel, 1);
        Destroy(gameObject);
        SceneManager.LoadScene("Overworld", LoadSceneMode.Single);
    }
}
