using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordGameLevelSelectScript : MonoBehaviour
{
    public GameObject systemPrefab;
    WordGameSystemScript system;

    // Use this for initialization
    void Start()
    {
        if (!GameObject.Find("wordGameSystem"))
        {
            system = GameObject.Instantiate(systemPrefab).GetComponent<WordGameSystemScript>();
            system.init();
            Debug.Log("System initialized");
        }
        else system = GameObject.Find("wordGameSystem").GetComponent<WordGameSystemScript>();
    }

    public void levelButtonClick(int level)
    {
        MusicPlayer.instance.PlaySoundEffect(MusicPlayer.instance.menuEffect, 1);
        system.setStartingLevel(level);
        SceneManager.LoadScene("WordGameScene", LoadSceneMode.Single);
    }

    public void exitMinigame()
    {
        system.exit();
    }
}
