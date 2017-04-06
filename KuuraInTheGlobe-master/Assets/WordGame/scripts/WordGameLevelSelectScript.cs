using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordGameLevelSelectScript : MonoBehaviour
{
    public GameObject systemPrefab;
    public List<Button> buttons;
    WordGameSystemScript system;

    // Use this for initialization
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

    public void levelButtonClick(int level)
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuEffect, 1);
        system.setStartingLevel(level);
        SceneManager.LoadScene("WordGameScene", LoadSceneMode.Single);
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
