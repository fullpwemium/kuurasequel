using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordGameSystemScript : MonoBehaviour {

    private bool initialized = false;
    private bool[] cats = new bool[10];
    private int clearedlevels;
    private int startinglevel = 1;

	// Use this for initialization
	public void init ()
    {
        if (!initialized)
        {
            Debug.Log("Initializing WordGameSystem");
            for(int i = 0; i < 10; i++)
            {
                cats[i] = false;
            }
            initialized = true;
        }
        else return;
	}

    public bool isCatCollected(int level)
    {
        return cats[level-1];
    }

    public void collectCat(int level)
    {
        if (!cats[level-1])
        {
            cats[level] = true;
        }
    }

    public void clearlevel(int level)
    {
        if(clearedlevels < level)
        {
            clearedlevels = level;
        }
    }

    public int getClearedLevels()
    {
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
