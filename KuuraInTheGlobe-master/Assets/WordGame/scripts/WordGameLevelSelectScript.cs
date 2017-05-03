using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * This script serves as the main script for the Word Quiz Minigame level select scene.
 */

public class WordGameLevelSelectScript : MonoBehaviour
{
    public GameObject systemPrefab;
    public List<Button> buttons;        //List of the level buttons in the scene
    WordGameSystemScript system;        //reference to the WordGameSystemScript

    // Use this for initialization
    /**
     * Fetches or creates the WordGameSystem object, updates the level select buttons and cats and then starts the music loop.
     */
    void Start()
    {
        if (!GameObject.Find("wordGameSystem"))
        {
            system = GameObject.Instantiate(systemPrefab).GetComponent<WordGameSystemScript>();
            //system.init();
            Debug.Log("System initialized");
        }
        else system = GameObject.Find("wordGameSystem").GetComponent<WordGameSystemScript>();

        checkButtons();

        MusicPlayer.PlayMusic(MusicTrack.BubbleWarehouseCutscene);
    }

    /**
     * All the level buttons will call this function, the parameter being the level of the button.
     * When called, this function will start the WordGame game loop and the new scene will load the level that was passed as a parameter.
     */
    public void levelButtonClick(int level)
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuEffect, 1);
        system.setStartingLevel(level);
        SceneManager.LoadScene("WordGameScene", LoadSceneMode.Single);
    }

    /**
     * This function will check how many levels has the player cleared and then mark the correct amount of buttons as clickable
     * Additionally this function will hide all the cats that the player has not yet acquired.
     */
    private void checkButtons()
    {
        int clearedlevels = system.getClearedLevels();
        for (int i = 0; i < buttons.Capacity; i++)
        {           
            if (clearedlevels >= i)
            {
                buttons[i].interactable = true;
                if (system.isCatCollected(i))
                {
                    GameObject.Find("Main Canvas/Buttons/Level" + (i+1) + "/cat_l" + (i+1)).SetActive(true);
                }
            }
            else if (clearedlevels < i)
            {
                buttons[i].interactable = false;
                GameObject.Find("Main Canvas/Buttons/Level" + (i+1) + "/cat_l" + (i+1)).SetActive(false);
            }
            /*
            if(i == (buttons.Capacity - 1) && !system.isCatCollected(i))                                      //makes sure that the number of cats being displayed is correct
            {
                GameObject.Find("Main Canvas/Buttons/Level" + (i+1) + "/cat_l" + (i+1)).SetActive(false);
            }
            */
        }
    }

    /**
     * Exits the minigame to the overworld scene.
     */
    public void exitMinigame()
    {
        system.exit();
    }
}