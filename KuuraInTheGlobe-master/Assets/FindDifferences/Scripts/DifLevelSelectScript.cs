using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifLevelSelectScript : MonoBehaviour
{
    public static DifLevelSelectScript DLSS;

    public static int wonCats;

    public GameObject systemPrefab;
    public List<Button> buttons;
    DifGameSystem system;

    // Use this for initialization
    void Start ()
    {
        // Fetch system object
        if (!GameObject.Find("difGameSystem"))
        {
            system = GameObject.Instantiate(systemPrefab).GetComponent<DifGameSystem>();
            //system.init ();
            Debug.Log("system added");
        }
        else
        {
            system = GameObject.Find("difGameSystem").GetComponent<DifGameSystem>();
            Debug.Log("system found");
        }

        checkButtons();

        //MusicPlayer.PlayMusic(MusicTrack.BubbleWarehouseCutscene);
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public void levelButtonClick(int level)
    {
        //MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuEffect, 1);

        //system.setStartingLevel(level);

        SceneManager.LoadScene("DifGameplay", LoadSceneMode.Single);        //When opening all levels in common DifGameplay scene.

        if (level == 1)
        {
            Debug.Log("Kenttä 1");

            //SceneManager.LoadScene("DifLevel1(2)", LoadSceneMode.Single);         //When opening all levels in own scenes.

            DifLevelObjects.levelNumber = 0;
            Debug.Log("Level number = " + DifLevelObjects.levelNumber);
        }
        else if (level == 2)
        {
            Debug.Log("Kenttä 2");

            //SceneManager.LoadScene("DifLevel2", LoadSceneMode.Single);

            DifLevelObjects.levelNumber = 1;
            Debug.Log("Level number = " + DifLevelObjects.levelNumber);
        }
        else if (level == 3)
        {
            Debug.Log("Kenttä 3");
            //SceneManager.LoadScene("DifLevel3", LoadSceneMode.Single);
            DifLevelObjects.levelNumber = 2;
            Debug.Log("Level number = " + DifLevelObjects.levelNumber);
        }
        else if (level == 4)
        {
            Debug.Log("Kenttä 4");

        }
        else if (level == 5)
        {
            Debug.Log("Kenttä 5");

        }
        else if (level == 6)
        {
            Debug.Log("Kenttä 6");

        }
    }

    private void checkButtons()
    {
        for (int i = 0; i < buttons.Capacity; i++)
        {
            int clearedlevels = system.getClearedLevels();
            if (clearedlevels >= i)
            {
                buttons[i].interactable = true;
                Debug.Log("Open buttons = " + i);

                wonCats = i - 1;
                Debug.Log("Won cats = " + i);
            }
            else if (clearedlevels < i)
            {
                buttons[i].interactable = false;
            }
        }
    }

    public void exitMinigame()
    {
        system.exit();
    }
}
