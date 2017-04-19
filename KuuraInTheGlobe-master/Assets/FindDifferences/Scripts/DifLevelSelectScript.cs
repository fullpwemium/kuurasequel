using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DifLevelSelectScript : MonoBehaviour
{
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
        }
        else
        {
            system = GameObject.Find("difGameSystem").GetComponent<DifGameSystem>();
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
        system.setStartingLevel(level);
        if (level == 1)
        {
            SceneManager.LoadScene("DifLevel1(2)", LoadSceneMode.Single);
        }
        else if (level == 2)
        {

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
