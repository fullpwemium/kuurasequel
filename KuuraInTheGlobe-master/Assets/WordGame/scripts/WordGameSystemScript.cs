using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This script serves as the main controller for the whole minigame, serving as the only way to communicate with the Global Game Manager
 * The object implementing this script will persist through scene change.
 */

public class WordGameSystemScript : MonoBehaviour {

    private bool initialized = false;       //is this script initialized
    private bool[] cats = new bool[10];     //an array of bool containing the information of the cats been collected from this minigame
    private int clearedlevels = 0;          //number of levels that have been cleared, can be changed
    private int startinglevel = 1;          //the level that will be loaded when the minigame starts, can be changed via functions

    /**
     * The procedure that will be gone through after every invocation of the object
     * Updates the number of the cleared levels and the list that stores the cat info
     */
    public void Awake()
    {
        clearedlevels = GlobalGameManager.GGM.getNumberOfBeatenLevels("quizGame");

        for (int i = 0; i < cats.Length; i++)
        {
            cats[i] = GlobalGameManager.GGM.hasCatBeenAcquiredForGivenLevel("quizGame", i + 1);
        }
    }

    /**
     * Returns a boolean value that is true if the cat is collected and false otherwise.
     * The integer parameter is the level that the cat data is requested for.
     */
    public bool isCatCollected(int level)
    {
        return cats[level];
    }

    /**
     * Tells the GGM that the cat is been collected from the level that was passed as a parameter.
     * Level 0 in the minigame is level 1 for GGM and so on.
     */
    public void collectCat(int level)
    {
        if (!cats[level])
        {
            Debug.Log("Cat collected from level " + (level + 1));
            GlobalGameManager.GGM.setCatAcquisitionForGivenLevel("quizGame", (level + 1), 1);
            cats[level] = true;         //update the cat info for this object as well
        }
    }

    /**
     * Tells the GGM that the level that was passed as a parameter has been cleared.
     * Level 0 in the minigame is level 1 for GGM and so on.
     */
    public void clearlevel(int level)
    {
        if (clearedlevels <= level)
        {
            Debug.Log("Level " + (level + 1) + " cleared");
            clearedlevels = level + 1;
            GlobalGameManager.GGM.setNumberOfBeatenLevels("quizGame", clearedlevels);
        }
    }

    /**
     * Returns the number of cleared levels.
     */
    public int getClearedLevels()
    {
        Debug.Log("Cleared levels = " + clearedlevels);
        return clearedlevels;
    }

    /**
     * Sets the starting level equal to the parameter.
     */
    public void setStartingLevel(int level)
    {
        startinglevel = level;
        Debug.Log("Starting level set at " + level);
    }

    /**
     * Returns an integer containing the starting level.
     */
    public int getStartingLevel()
    {
        Debug.Log("Returning level " + startinglevel);
        return startinglevel;
    }
    
    /**
     * Resets cleared levels and aquired cats. For debugging purposes
     */
    private void resetProgress()
    {
        GlobalGameManager.GGM.setNumberOfBeatenLevels("quizGame", 0);
        for(int i = 0; i < 10; i++)
        {
            GlobalGameManager.GGM.setCatAcquisitionForGivenLevel("quizGame", (i + 1), 0);
        }
        
    }

    /**
     * Called when creating the object, setting a name for the object and then making it persist.
     */
	void Start ()
    {
        gameObject.name = "wordGameSystem";
        DontDestroyOnLoad(gameObject);
	}

    /**
     * Destroys the object and returns to the overworld.
     */
    public void exit()
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuCancel, 1);
        Destroy(gameObject);
        SceneManager.LoadScene("Overworld", LoadSceneMode.Single);
    }
}
