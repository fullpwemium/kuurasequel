using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordGameSystemScript : MonoBehaviour {

    private bool initialized = false;
    private bool[] cats = new bool[10];
    private int clearedlevels = 0;
    private int startinglevel = 1;

    public void Awake()
    {
        clearedlevels = GlobalGameManager.GGM.getNumberOfBeatenLevels("quizGame");

        for (int i = 0; i < cats.Length; i++)
        {
            cats[i] = GlobalGameManager.GGM.hasCatBeenAcquiredForGivenLevel("quizGame", i + 1);
        }
    }

    public bool isCatCollected(int level)
    {
        return cats[level];
    }

    public void collectCat(int level)
    {
        if (!cats[level])
        {
            Debug.Log("Cat collected from level " + (level + 1));
            GlobalGameManager.GGM.setCatAcquisitionForGivenLevel("quizGame", (level + 1), 1);
            cats[level] = true;
        }
    }

    public void clearlevel(int level)
    {
        if (clearedlevels < level)
        {
            Debug.Log("Level " + (level + 1) + " cleared");
            clearedlevels = level;
            GlobalGameManager.GGM.setNumberOfBeatenLevels("quizGame", clearedlevels);
        }
    }

    public int getClearedLevels()
    {
        Debug.Log("Cleared levels = " + clearedlevels);
        return clearedlevels;
    }

    public void setStartingLevel(int level)
    {
        startinglevel = level;
        Debug.Log("Starting level set at " + level);
    }

    public int getStartingLevel()
    {
        Debug.Log("Returning level " + startinglevel);
        return startinglevel;
    }
	
	void Start ()
    {
        gameObject.name = "wordGameSystem";
        DontDestroyOnLoad(gameObject);
	}

    public void exit()
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuCancel, 1);
        Destroy(gameObject);
        SceneManager.LoadScene("Overworld", LoadSceneMode.Single);
    }
}
